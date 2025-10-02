using System;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        // Se asume que CatalogosDataAccess existe y tiene el método para obtener IDs.
        // private readonly CatalogosDataAccess _catalogosData; 

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

        // Inserta una nueva persona y su domicilio/correos
        public int InsertarPersona(Persona persona)
        {
            _dbAccess.Connect();
            int idGenerado = -1;
            try
            {
                // ** 1. Insertar en la tabla USUARIOS **
                // La tabla USUARIOS tiene la columna ID_DEPTO que viene de la Persona.
                string userQuery = @"INSERT INTO USUARIOS (NOMBRE, APELLIDO_PAT, APELLIDO_MAT, CURP, RFC, TELEFONO, SEXO, ESTATUS, ID_DEPTO)
                                     VALUES (@Nombre, @ApellidoPat, @ApellidoMat, @Curp, @Rfc, @Telefono, @Sexo, @Estatus, @IdDepto) RETURNING NUMERO_USUARIO";

                NpgsqlParameter[] userParams = new NpgsqlParameter[]
                {
                    _dbAccess.CreateParameter("@Nombre", persona.NombreCompleto),
                    _dbAccess.CreateParameter("@ApellidoPat", persona.ApellidoPaterno),
                    // Si ApellidoMaterno es nulo o vacío, pasamos DBNull para el campo NULLable en la DB
                    _dbAccess.CreateParameter("@ApellidoMat", persona.ApellidoMaterno ?? (object)DBNull.Value),
                    _dbAccess.CreateParameter("@Curp", persona.Curp),
                    _dbAccess.CreateParameter("@Rfc", persona.Rfc),
                    // Se asume que Telefono es un string que puede convertirse a long/numeric
                    _dbAccess.CreateParameter("@Telefono", Convert.ToInt64(persona.Telefono)),
                    _dbAccess.CreateParameter("@Sexo", persona.Sexo),
                    _dbAccess.CreateParameter("@Estatus", persona.Estatus),
                    _dbAccess.CreateParameter("@IdDepto", persona.IdDepartamento)
                };

                object result = _dbAccess.ExecuteScalar(userQuery, userParams);
                idGenerado = Convert.ToInt32(result);
                _logger.Info($"Persona insertada correctamente en USUARIOS con ID: {idGenerado}");

                if (idGenerado <= 0) return -1;

                // ** 2. Insertar en la tabla CORREOS **
                InsertarCorreo(idGenerado, persona.CorreoPrincipal, "PRINCIPAL");
                if (!string.IsNullOrEmpty(persona.CorreoSecundario))
                {
                    InsertarCorreo(idGenerado, persona.CorreoSecundario, "SECUNDARIO");
                }

                // ** 3. Insertar en la tabla DOMICILIOS **
                // Se asume que el Domicilio fue validado y tiene IdMunicipio
                if (persona.Domicilio != null && !string.IsNullOrEmpty(persona.Domicilio.IdMunicipio))
                {
                    InsertarDomicilio(idGenerado, persona.Domicilio);
                }
                else
                {
                    _logger.Warn($"No se insertó Domicilio para ID: {idGenerado} porque falta IdMunicipio o Domicilio es nulo.");
                }

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error en la transacción al insertar la persona (USUARIOS, CORREOS, DOMICILIOS)");
                // NOTA: En un entorno de producción, DEBES implementar aquí la lógica de ROLLBACK
                // (Ej. DELETE FROM CORREOS, DELETE FROM USUARIOS, etc.) si la inserción de USUARIOS fue exitosa.
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public int ModificarPersona(Persona persona)
        {
            // Validamos la clave principal para la modificación
            if (persona?.Id <= 0)
            {
                _logger.Error("ID de Persona no válido para la modificación.");
                return -1;
            }

            _dbAccess.Connect();
            int filasAfectadasTotal = 0;

            try
            {
                // --------------------------------------------------------------------------
                // ** 1. MODIFICAR la tabla USUARIOS (Implementación Dinámica) **
                // --------------------------------------------------------------------------

                StringBuilder sql = new StringBuilder("UPDATE USUARIOS SET ");
                List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();

                // La construcción dinámica es crucial para evitar sobrescribir campos con NULL
                if (!string.IsNullOrEmpty(persona.NombreCompleto))
                {
                    sql.Append("NOMBRE = @Nombre, ");
                    parametros.Add(_dbAccess.CreateParameter("@Nombre", persona.NombreCompleto));
                }
                if (!string.IsNullOrEmpty(persona.ApellidoPaterno))
                {
                    sql.Append("APELLIDO_PAT = @ApellidoPat, ");
                    parametros.Add(_dbAccess.CreateParameter("@ApellidoPat", persona.ApellidoPaterno));
                }
                // Nota: Si quieres permitir el borrado de ApellidoMaterno, no uses la validación !string.IsNullOrEmpty()
                if (persona.ApellidoMaterno != null)
                {
                    sql.Append("APELLIDO_MAT = @ApellidoMat, ");
                    // Usa DBNull si el valor es null, sino usa el valor
                    parametros.Add(_dbAccess.CreateParameter("@ApellidoMat", persona.ApellidoMaterno ?? (object)DBNull.Value));
                }
                if (!string.IsNullOrEmpty(persona.Curp))
                {
                    sql.Append("CURP = @Curp, ");
                    parametros.Add(_dbAccess.CreateParameter("@Curp", persona.Curp));
                }
                if (!string.IsNullOrEmpty(persona.Rfc))
                {
                    sql.Append("RFC = @Rfc, ");
                    parametros.Add(_dbAccess.CreateParameter("@Rfc", persona.Rfc));
                }
                if (persona.Telefono != null) // Actualiza si se proporciona el campo Telefono
                {
                    sql.Append("TELEFONO = @Telefono, ");
                    parametros.Add(_dbAccess.CreateParameter("@Telefono", Convert.ToInt64(persona.Telefono)));
                }
                if (!string.IsNullOrEmpty(persona.Sexo))
                {
                    sql.Append("SEXO = @Sexo, ");
                    parametros.Add(_dbAccess.CreateParameter("@Sexo", persona.Sexo));
                }
                if (!string.IsNullOrEmpty(persona.Estatus))
                {
                    sql.Append("ESTATUS = @Estatus, ");
                    parametros.Add(_dbAccess.CreateParameter("@Estatus", persona.Estatus));
                }
                if (persona.IdDepartamento == null)
                {
                    sql.Append("ID_DEPTO = @IdDepto, ");
                    parametros.Add(_dbAccess.CreateParameter("@IdDepto", persona.IdDepartamento.Value));
                }

                // Si no hay campos que actualizar, salimos
                if (parametros.Count == 0)
                {
                    _logger.Warn($"No se proporcionaron campos para actualizar para ID: {persona.Id}.");
                    return 0;
                }

                // Limpiar la última coma y agregar el WHERE
                sql.Length -= 2;
                sql.Append(" WHERE NUMERO_USUARIO = @IdPersona");
                parametros.Add(_dbAccess.CreateParameter("@IdPersona", persona.Id));

                // Ejecutar la actualización de USUARIOS
                int filasAfectadasUsuario = _dbAccess.ExecuteNonQuery(sql.ToString(), parametros.ToArray());
                filasAfectadasTotal += filasAfectadasUsuario;

                _logger.Info($"USUARIOS modificado para ID: {persona.Id}. Filas afectadas: {filasAfectadasUsuario}");

                // --------------------------------------------------------------------------
                // ** 2. MODIFICAR/ACTUALIZAR la tabla CORREOS **
                // --------------------------------------------------------------------------
                // Asumimos que los métodos auxiliares (como Update/Upsert) existen.
                /*if (!string.IsNullOrEmpty(persona.CorreoPrincipal))
                {
                    // La lógica aquí sería hacer un UPDATE o un UPSERT
                    // Usaremos un método auxiliar de actualización:
                    int afectadasCorreo = ActualizarOCrearCorreo(persona.Id, persona.CorreoPrincipal, "PRINCIPAL");
                    filasAfectadasTotal += afectadasCorreo;
                }
                if (!string.IsNullOrEmpty(persona.CorreoSecundario))
                {
                    int afectadasCorreo = ActualizarOCrearCorreo(persona.Id, persona.CorreoSecundario, "SECUNDARIO");
                    filasAfectadasTotal += afectadasCorreo;
                }

                // --------------------------------------------------------------------------
                // ** 3. MODIFICAR/ACTUALIZAR la tabla DOMICILIOS **
                // --------------------------------------------------------------------------
                if (persona.Domicilio != null && !string.IsNullOrEmpty(persona.Domicilio.IdMunicipio))
                {
                    // Asumimos un método auxiliar para actualizar el domicilio existente
                    int afectadasDomicilio = ActualizarOCrearDomicilio(persona.IdPersona, persona.Domicilio);
                    filasAfectadasTotal += afectadasDomicilio;
                }
                else
                {
                    _logger.Warn($"No se modificó Domicilio para ID: {persona.IdPersona} porque falta IdMunicipio o Domicilio es nulo.");
                }*/

                return filasAfectadasTotal;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error en la modificación de la persona (USUARIOS, CORREOS, DOMICILIOS)");
                // ADVERTENCIA CRÍTICA: Aquí, si falló en el Paso 2 o 3, el Paso 1 (USUARIOS) ya fue guardado. 
                // Se requiere un ROLLBACK manual si se quiere integridad.
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // ---------------------------------------------
        // MÉTODOS DE VALIDACIÓN DE UNICIDAD (FALTANTES)
        // ---------------------------------------------

        /// <summary>
        /// Verifica si un CURP ya está registrado en la tabla USUARIOS.
        /// </summary>
        public bool ExisteCurp(string curp)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM USUARIOS WHERE curp = @Curp AND ESTATUS = 'ACTIVO'";
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

        /// <summary>
        /// Verifica si un RFC ya está registrado en la tabla USUARIOS.
        /// </summary>
        public bool ExisteRFC(string rfc)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM USUARIOS WHERE rfc = @Rfc AND ESTATUS = 'ACTIVO'";
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

        // ---------------------------------------------
        // MÉTODOS AUXILIARES (Tablas relacionadas)
        // ---------------------------------------------

        private void InsertarCorreo(int idUsuario, string correo, string tipo)
        {
            string query = "INSERT INTO CORREOS (NUMERO_USUARIO, TIPO, CORREO) VALUES (@UsuarioId, @Tipo, @Correo)";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                _dbAccess.CreateParameter("@UsuarioId", idUsuario),
                _dbAccess.CreateParameter("@Tipo", tipo),
                _dbAccess.CreateParameter("@Correo", correo)
            };
            // Usamos ExecuteNonQuery sin conect/disconect aquí porque el método principal lo maneja (transacción implícita)
            _dbAccess.ExecuteNonQuery(query, parameters);
            _logger.Debug($"Correo {tipo} insertado para usuario ID: {idUsuario}");
        }

        private void InsertarDomicilio(int idUsuario, Domicilio domicilio)
        {
            string query = @"INSERT INTO DOMICILIOS (NOMBRE_USUARIO, CALLE, NO_EXT, NO_INT, CP, COLONIA, ID_MUNICIPIO)
                             VALUES (@UsuarioId, @Calle, @NoExt, @NoInt, @CP, @Colonia, @IdMunicipio)";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                _dbAccess.CreateParameter("@UsuarioId", idUsuario),
                _dbAccess.CreateParameter("@Calle", domicilio.Calle),
                _dbAccess.CreateParameter("@NoExt", domicilio.NoExterior),
                _dbAccess.CreateParameter("@NoInt", domicilio.NoInterior ?? "N/A"),
                _dbAccess.CreateParameter("@CP", Convert.ToInt32(domicilio.CodigoPostal)),
                _dbAccess.CreateParameter("@Colonia", domicilio.Colonia),
                _dbAccess.CreateParameter("@IdMunicipio", domicilio.IdMunicipio)
            };
            _dbAccess.ExecuteNonQuery(query, parameters);
            _logger.Debug($"Domicilio insertado para usuario ID: {idUsuario}");
        }

        // NOTA: Faltaría el método ActualizarPersona(Persona persona)
        // Y los métodos para eliminar (dar de BAJA) persona, si se necesita.
    }
}