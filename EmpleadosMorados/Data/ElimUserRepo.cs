using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleadosMorados.Data;
using Npgsql;

namespace EmpleadosMorados.Data
{
    public class ElimUserRepo
    {
        /// <summary>
        /// Busca un usuario en la base de datos por su ID.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario a buscar.</param>
        /// <returns>Un DataTable con los datos del usuario, o un DataTable vacío si no se encuentra.</returns>
        public DataTable ObtenerUsuarioPorId(int usuarioId)
        {
            var db = PostgresSQLDataAccess.GetInstance();
            try
            {
                db.Connect();

                string query = "SELECT NOMBRE, APELLIDO_PAT FROM USUARIOS WHERE NUMERO_USUARIO = @id";
                var paramId = db.CreateParameter("@id", usuarioId);

                DataTable tablaUsuario = db.ExecuteQuery(query, paramId);
                return tablaUsuario;
            }
            catch
            {
                // En una aplicación real, aquí registrarías el error detallado.
                // Por ahora, relanzamos la excepción para que la capa superior la maneje.
                throw;
            }
            finally
            {
                // Aseguramos que la conexión siempre se cierre.
                db.Disconnect();
            }
        }

        public DataTable BuscarPorNombreYApellidoExacto(string nombre, string apellido)
        {
            var db = PostgresSQLDataAccess.GetInstance();
            try
            {
                db.Connect();

                // --- TU CONSULTA CON UNA MEJORA IMPORTANTE ---
                // Usamos ILIKE en lugar de = para que la búsqueda NO sea sensible a mayúsculas/minúsculas.
                // Si usas "=", "Juan" no encontraría a "juan". Con ILIKE, sí lo hace.
                string query = @"SELECT NUMERO_USUARIO, NOMBRE, APELLIDO_PAT, ID_DEPTO 
                         FROM USUARIOS 
                         WHERE (NOMBRE ILIKE @nom) AND (APELLIDO_PAT ILIKE @ap)";

                // Creamos los dos parámetros que necesita la consulta
                var paramNombre = db.CreateParameter("@nom", nombre);
                var paramApellido = db.CreateParameter("@ap", apellido);

                DataTable tablaUsuarios = db.ExecuteQuery(query, paramNombre, paramApellido);
                return tablaUsuarios;
            }
            catch
            {
                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }

        public void EliminarFisicamente(int usuarioId)
        {
            string connectionString = PostgresSQLDataAccess.ConnectionString;
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Paso 1: Eliminar correos
                        using (var cmd = new NpgsqlCommand("DELETE FROM CORREOS WHERE NUMERO_USUARIO = @id", conn))
                        {
                            // Creamos un nuevo parámetro solo para este comando
                            cmd.Parameters.Add(new NpgsqlParameter("@id", usuarioId));
                            cmd.ExecuteNonQuery();
                        }

                        // Paso 2: Eliminar domicilio
                        using (var cmd = new NpgsqlCommand("DELETE FROM DOMICILIOS WHERE NUMERO_USUARIO = @id", conn))
                        {
                            // Creamos otro nuevo parámetro para este comando
                            cmd.Parameters.Add(new NpgsqlParameter("@id", usuarioId));
                            cmd.ExecuteNonQuery();
                        }

                        // Paso 3: Eliminar trayectoria laboral
                        using (var cmd = new NpgsqlCommand("DELETE FROM TRAY_LAB WHERE NUMERO_USUARIO = @id", conn))
                        {
                            // Y otro más aquí
                            cmd.Parameters.Add(new NpgsqlParameter("@id", usuarioId));
                            cmd.ExecuteNonQuery();
                        }

                        // Paso 4: Eliminar al usuario principal
                        using (var cmd = new NpgsqlCommand("DELETE FROM USUARIOS WHERE NUMERO_USUARIO = @id", conn))
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@id", usuarioId));
                            int filasAfectadas = cmd.ExecuteNonQuery();
                            if (filasAfectadas == 0)
                            {
                                throw new Exception($"No se encontró ningún usuario con el ID {usuarioId} para eliminar.");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public int DarDeBajaLogica(int usuarioId)
        {
            var db = PostgresSQLDataAccess.GetInstance();
            try
            {
                db.Connect();

                string query = "UPDATE USUARIOS SET ESTATUS = 'BAJA' WHERE NUMERO_USUARIO = @id";
                var paramId = db.CreateParameter("@id", usuarioId);

                int filasAfectadas = db.ExecuteNonQuery(query, paramId);

                // Si no se actualizó ninguna fila, significa que el ID no existía.
                if (filasAfectadas == 0)
                {
                    throw new Exception($"No se encontró ningún usuario con el ID {usuarioId} para dar de baja.");
                }

                return filasAfectadas;
            }
            catch
            {
                // Relanzamos la excepción para que la capa de negocio (BLL) la maneje.
                throw;
            }
            finally
            {
                db.Disconnect();
            }
        }


    }
    }
