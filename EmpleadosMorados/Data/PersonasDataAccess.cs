using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleadosMorados.Model;
using EmpleadosMorados.Utilities;
using NLog;
using Npgsql;

namespace EmpleadosMorados.Data
{
    public class PersonasDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("NominaXpert.Data.PersonasDataAccess");
        private readonly PostgresSQLDataAccess _dbAccess;

        public PersonasDataAccess()
        {
            try
            {
                _dbAccess = PostgresSQLDataAccess.GetInstance();
                _logger.Info("Instancia de PersonasDataAccess creada correctamente.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al inicializar PersonasDataAccess");
                throw;
            }
        }

        // Inserta una nueva persona en la base de datos
        public int InsertarPersona(Persona persona)
        {
            try
            {
                string query = @"INSERT INTO USUARIOS (NOMBRE, APELLIDO_PAT, APELLIDO_MAT, CURP, RFC, TELEFONO, SEXO, ESTATUS, ID_DEPTO)
                             VALUES (@Nombre, @ApellidoPat, @ApellidoMat, @Curp, @Rfc, @Telefono, @Sexo, @Estatus, @IdDepto) RETURNING NUMERO_USUARIO";

                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                _dbAccess.CreateParameter("@Nombre", persona.NombreCompleto),
                _dbAccess.CreateParameter("@ApellidoPat", persona.ApellidoPaterno),
                _dbAccess.CreateParameter("@ApellidoMat", persona.ApellidoMaterno),
                _dbAccess.CreateParameter("@Curp", persona.Curp),
                _dbAccess.CreateParameter("@Rfc", persona.Rfc),
                _dbAccess.CreateParameter("@Telefono", persona.Telefono),
                _dbAccess.CreateParameter("@Sexo", persona.Sexo),
                _dbAccess.CreateParameter("@Estatus", persona.Estatus),
                _dbAccess.CreateParameter("@IdDepto", persona.IdDepartamento)
                };

                _dbAccess.Connect();
                object result = _dbAccess.ExecuteScalar(query, parameters);
                int idGenerado = Convert.ToInt32(result);
                _logger.Info($"Persona insertada correctamente con ID: {idGenerado}");
                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al insertar la persona");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Actualiza una persona existente en la base de datos
        public bool ActualizarPersona(Persona persona)
        {
            try
            {
                string query = @"UPDATE USUARIOS 
                             SET NOMBRE = @Nombre, APELLIDO_PAT = @ApellidoPat, APELLIDO_MAT = @ApellidoMat, 
                                 CURP = @Curp, RFC = @Rfc, TELEFONO = @Telefono, SEXO = @Sexo, 
                                 ESTATUS = @Estatus, ID_DEPTO = @IdDepto 
                             WHERE NUMERO_USUARIO = @Id";

                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                _dbAccess.CreateParameter("@Id", persona.Id),
                _dbAccess.CreateParameter("@Nombre", persona.NombreCompleto),
                _dbAccess.CreateParameter("@ApellidoPat", persona.ApellidoPaterno),
                _dbAccess.CreateParameter("@ApellidoMat", persona.ApellidoMaterno),
                _dbAccess.CreateParameter("@Curp", persona.Curp),
                _dbAccess.CreateParameter("@Rfc", persona.Rfc),
                _dbAccess.CreateParameter("@Telefono", persona.Telefono),
                _dbAccess.CreateParameter("@Sexo", persona.Sexo),
                _dbAccess.CreateParameter("@Estatus", persona.Estatus),
                _dbAccess.CreateParameter("@IdDepto", persona.IdDepartamento)
                };

                _dbAccess.Connect();
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, parameters);
                bool exito = filasAfectadas > 0;
                _logger.Info(exito ? $"Persona actualizada con ID: {persona.Id}" : $"No se encontró persona con ID: {persona.Id}");
                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar la persona con ID {persona.Id}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Verifica si un CURP ya está registrado en la base de datos
        public bool ExisteCurp(string curp)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM USUARIOS WHERE curp = @Curp";
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", curp);

                _dbAccess.Connect();
                object result = _dbAccess.ExecuteScalar(query, paramCurp);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del CURP: {curp}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Verifica si un RFC ya está registrado en la base de datos
        public bool ExisteRFC(string rfc)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM USUARIOS WHERE rfc = @Rfc";
                NpgsqlParameter paramRfc = _dbAccess.CreateParameter("@Rfc", rfc);

                _dbAccess.Connect();
                object result = _dbAccess.ExecuteScalar(query, paramRfc);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del RFC: {rfc}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Elimina una persona por su ID
        public int EliminarPersona(int idPersona)
        {
            try
            {
                string query = "UPDATE USUARIOS SET ESTATUS = 'BAJA' WHERE NUMERO_USUARIO = @IdPersona";
                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", idPersona);

                _dbAccess.Connect();
                int rowsAffected = _dbAccess.ExecuteNonQuery(query, paramIdPersona);
                _logger.Info($"Persona con ID {idPersona} eliminada correctamente. Filas afectadas: {rowsAffected}");
                return rowsAffected;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al dar de baja la persona con ID {idPersona}");
                return 0;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }

}
