using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace EmpleadosMorados.Data
{
    public class ActualizaDataAccess
    {
        public static DataTable ObtenerEmpleadoPorId(int id)
        {
            try
            {
                string query = @"
            SELECT 
                u.NOMBRE, u.APELLIDO_PAT, u.APELLIDO_MAT, u.CURP, u.RFC, u.SEXO, u.ID_DEPTO, u.ID_PUESTO,
                dom.CALLE, dom.NO_EXT, dom.NO_INT, dom.COLONIA, dom.CP, m.ID_ESTADO, dom.ID_MUNICIPIO,
                u.TELEFONO,
                c1.CORREO AS CORREO_PRINCIPAL, 
                c2.CORREO AS CORREO_SECUNDARIO
            FROM USUARIOS u
            LEFT JOIN DOMICILIOS dom ON u.NUMERO_USUARIO = dom.NUMERO_USUARIO
            LEFT JOIN CAT_MUNICIPIOS m ON dom.ID_MUNICIPIO = m.ID_MUNICIPIO
            -- Join para el correo Principal
            LEFT JOIN CORREOS c1 ON u.NUMERO_USUARIO = c1.NUMERO_USUARIO AND c1.TIPO = 'PRINCIPAL'
            -- Join para el correo Secundario
            LEFT JOIN CORREOS c2 ON u.NUMERO_USUARIO = c2.NUMERO_USUARIO AND c2.TIPO = 'SECUNDARIO'
            WHERE u.NUMERO_USUARIO = @id";

                var parametros = new List<NpgsqlParameter> {
            new NpgsqlParameter("@id", id)
        };

                var db = PostgresSQLDataAccess.GetInstance();
                db.Connect();
                DataTable dt = db.ExecuteQuery(query, parametros.ToArray());
                db.Disconnect();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el empleado: " + ex.Message);
            }
        }

        ///
        public static bool ActualizarEmpleado(int id, string nombre, string apPat, string apMat, string curp, string rfc, string sexo, string tel,
                                    string calle, string noExt, string noInt, string colonia, string cp, string idMun,
                                    string correoPrin, string correoSec, string idDepto, string idPuesto)
        {
            try
            {
                var db = PostgresSQLDataAccess.GetInstance();
                db.Connect();

                // 1. Query para Usuarios y Domicilios
                string queryBasica = @"
            UPDATE USUARIOS 
            SET NOMBRE=@nom, APELLIDO_PAT=@apP, APELLIDO_MAT=@apM, CURP=@curp, RFC=@rfc, 
                SEXO=@sexo, TELEFONO=CAST(@tel AS NUMERIC), ID_DEPTO=@depto, ID_PUESTO=@puesto
            WHERE NUMERO_USUARIO = @id;

            UPDATE DOMICILIOS 
            SET CALLE=@calle, NO_EXT=@noE, NO_INT=@noI, COLONIA=@col, CP=CAST(@cp AS NUMERIC), ID_MUNICIPIO=@mun
            WHERE NUMERO_USUARIO = @id;";

                // 2. Query para el Correo Principal (Siempre se actualiza)
                string queryCorreos = @"
            UPDATE CORREOS SET CORREO = @cPrin 
            WHERE NUMERO_USUARIO = @id AND TIPO = 'PRINCIPAL';";

                // 3. Lógica condicional para el Correo Secundario
                if (!string.IsNullOrWhiteSpace(correoSec) && correoSec != "[null]")
                {
                    // Si tiene datos, usamos ON CONFLICT para insertar o actualizar
                    queryCorreos += @"
                INSERT INTO CORREOS (NUMERO_USUARIO, TIPO, CORREO)
                VALUES (@id, 'SECUNDARIO', @cSec)
                ON CONFLICT (NUMERO_USUARIO, TIPO) 
                DO UPDATE SET CORREO = EXCLUDED.CORREO;";
                }
                else
                {
                    // Si está vacío, eliminamos el registro para evitar violar la restricción NOT NULL
                    queryCorreos += "DELETE FROM CORREOS WHERE NUMERO_USUARIO = @id AND TIPO = 'SECUNDARIO';";
                }

                string queryFinal = queryBasica + queryCorreos;

                var parametros = new List<NpgsqlParameter> {
            new NpgsqlParameter("@id", id),
            new NpgsqlParameter("@nom", nombre),
            new NpgsqlParameter("@apP", apPat),
            new NpgsqlParameter("@apM", apMat),
            new NpgsqlParameter("@curp", curp),
            new NpgsqlParameter("@rfc", rfc),
            new NpgsqlParameter("@sexo", sexo),
            new NpgsqlParameter("@tel", Convert.ToInt64(tel)), // Conversión explícita para numeric
            new NpgsqlParameter("@calle", calle),
            new NpgsqlParameter("@noE", noExt),
            new NpgsqlParameter("@noI", (object)noInt ?? DBNull.Value),
            new NpgsqlParameter("@col", colonia),
            new NpgsqlParameter("@cp", Convert.ToInt32(cp)), // Conversión explícita para numeric
            new NpgsqlParameter("@mun", idMun),
            new NpgsqlParameter("@cPrin", correoPrin),
            new NpgsqlParameter("@cSec", correoSec ?? (object)DBNull.Value),
            new NpgsqlParameter("@depto", idDepto),
            new NpgsqlParameter("@puesto", idPuesto)
        };

                db.ExecuteNonQuery(queryFinal, parametros.ToArray());
                db.Disconnect();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar: " + ex.Message);
            }
        }
    }

}
