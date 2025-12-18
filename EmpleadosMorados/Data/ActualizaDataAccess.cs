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
    }
}
