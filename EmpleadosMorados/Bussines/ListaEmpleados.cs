using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleadosMorados.Data;
using Npgsql;

namespace EmpleadosMorados.Bussines
{
    internal class ListaEmpleados
    {
        public static DataTable ObtenerUsuarios(string nombre, string numeroUsuario, string estatus, string departamento)
        {
            try
            {
                // Consulta base
                string query = @"
                SELECT 
                u.NUMERO_USUARIO,
                u.NOMBRE,
                u.APELLIDO_PAT,
                u.APELLIDO_MAT,
                u.CURP,
                u.RFC,
                u.TELEFONO,
                u.SEXO,
                u.ESTATUS,
                d.NOMBRE_DEPTO,
                c.CORREO AS CORREO_PRINCIPAL,
                dom.CALLE,
                dom.NO_EXT,
                dom.NO_INT,
                dom.COLONIA,
                dom.CP,
                m.NOM_MUNICIPIO,
                e.NOM_ESTADO
            FROM USUARIOS u
            LEFT JOIN DEPARTAMENTOS d ON u.ID_DEPTO = d.ID_DEPTO
            LEFT JOIN CORREOS c ON u.NUMERO_USUARIO = c.NUMERO_USUARIO AND c.TIPO = 'PRINCIPAL'
            LEFT JOIN DOMICILIOS dom ON u.NUMERO_USUARIO = dom.NUMERO_USUARIO
            LEFT JOIN CAT_MUNICIPIOS m ON dom.ID_MUNICIPIO = m.ID_MUNICIPIO
            LEFT JOIN CAT_ESTADOS e ON m.ID_ESTADO = e.ID_ESTADO
            WHERE 1=1"; // siempre verdadero, facilita concatenar filtros

                var parametros = new List<NpgsqlParameter>();

                // 🔹 Filtros dinámicos
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    query += " AND u.NOMBRE ILIKE @nombre";
                    parametros.Add(new NpgsqlParameter("@nombre", $"%{nombre}%"));
                }

                if (!string.IsNullOrWhiteSpace(numeroUsuario))
                {
                    query += " AND u.NUMERO_USUARIO::TEXT = @numeroUsuario";
                    parametros.Add(new NpgsqlParameter("@numeroUsuario", numeroUsuario.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(estatus))
                {
                    query += " AND u.ESTATUS = @estatus";
                    parametros.Add(new NpgsqlParameter("@estatus", estatus.ToUpper()));
                }

                if (!string.IsNullOrWhiteSpace(departamento))
                {
                    query += " AND d.ID_DEPTO ILIKE @departamento";
                    parametros.Add(new NpgsqlParameter("@departamento", $"%{departamento.Trim()}%"));
                }

                query += " ORDER BY u.NUMERO_USUARIO";

                // Conectamos a la base de datos y ejecutamos
                var db = PostgresSQLDataAccess.GetInstance();
                db.Connect();
                DataTable dt = db.ExecuteQuery(query, parametros.ToArray());
                db.Disconnect();

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuarios: " + ex.Message, ex);
            }


        }
        public static DataTable ObtenerDepartamentos() { 
            string query = "SELECT ID_DEPTO, NOMBRE_DEPTO FROM DEPARTAMENTOS WHERE ESTATUS='ACTIVO'"; 
            return PostgresSQLDataAccess.GetInstance().ExecuteQuery(query); }
        public static DataTable ObtenerEstatus() { 
            string query = "SELECT DISTINCT ESTATUS FROM USUARIOS"; 
            return PostgresSQLDataAccess.GetInstance().ExecuteQuery(query); }





    }
}
