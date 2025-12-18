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
                string userQuery = @"INSERT INTO USUARIOS (NOMBRE, APELLIDO_PAT, APELLIDO_MAT, CURP, RFC, TELEFONO, SEXO, ESTATUS, ID_DEPTO, ID_PUESTO)
                                     VALUES (@Nombre, @ApellidoPat, @ApellidoMat, @Curp, @Rfc, @Telefono, @Sexo, @Estatus, @IdDepto, @IdPuesto) RETURNING NUMERO_USUARIO";

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
                    _dbAccess.CreateParameter("@IdDepto", persona.IdDepartamento),
                    _dbAccess.CreateParameter("@IdPuesto", persona.IdPuesto)
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
            // 1. Validaciones básicas
            if (persona == null || persona.Id <= 0)
            {
                // Retornamos 0 o lanzamos excepción según tu preferencia de manejo de errores
                return 0;
            }

            // 2. Construcción Dinámica del Query (StringBuilder)
            // Esto es vital para no sobrescribir datos con NULL si el objeto persona viene incompleto.
            StringBuilder queryBuilder = new StringBuilder("UPDATE USUARIOS SET ");
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();

            // --- Mapeo de Campos ---

            // Nombre
            if (!string.IsNullOrWhiteSpace(persona.NombreCompleto))
            {
                queryBuilder.Append("NOMBRE = @Nombre, ");
                parametros.Add(new NpgsqlParameter("@Nombre", persona.NombreCompleto.Trim()));
            }

            // Apellido Paterno
            if (!string.IsNullOrWhiteSpace(persona.ApellidoPaterno))
            {
                queryBuilder.Append("APELLIDO_PAT = @ApellidoPat, ");
                parametros.Add(new NpgsqlParameter("@ApellidoPat", persona.ApellidoPaterno.Trim()));
            }

            // Apellido Materno (Permite nulos o vacíos si se quiere borrar, depende de tu regla)
            // Aquí asumimos que si viene null, no se toca. Si quieres borrarlo, deberías mandar string.Empty o manejarlo explícitamente.
            if (persona.ApellidoMaterno != null)
            {
                queryBuilder.Append("APELLIDO_MAT = @ApellidoMat, ");
                parametros.Add(new NpgsqlParameter("@ApellidoMat", persona.ApellidoMaterno.Trim()));
            }

            // CURP
            if (!string.IsNullOrWhiteSpace(persona.Curp))
            {
                queryBuilder.Append("CURP = @Curp, ");
                parametros.Add(new NpgsqlParameter("@Curp", persona.Curp.Trim()));
            }

            // RFC
            if (!string.IsNullOrWhiteSpace(persona.Rfc))
            {
                queryBuilder.Append("RFC = @Rfc, ");
                parametros.Add(new NpgsqlParameter("@Rfc", persona.Rfc.Trim()));
            }

            // Teléfono (Asumiendo que es long/numeric)
            if (!string.IsNullOrWhiteSpace(persona.Telefono))
            {
                queryBuilder.Append("TELEFONO = @Telefono, ");

                // IMPORTANTE: Convertimos el string a Int64 (long) porque en la BD el campo es NUMERIC.
                // Si lo mandas como string sin convertir, PostgreSQL podría dar error de tipos.
                parametros.Add(new NpgsqlParameter("@Telefono", Convert.ToInt64(persona.Telefono)));
            }

            // Sexo
            if (!string.IsNullOrWhiteSpace(persona.Sexo))
            {
                queryBuilder.Append("SEXO = @Sexo, ");
                parametros.Add(new NpgsqlParameter("@Sexo", persona.Sexo));
            }

            // Estatus
            if (!string.IsNullOrWhiteSpace(persona.Estatus))
            {
                queryBuilder.Append("ESTATUS = @Estatus, ");
                parametros.Add(new NpgsqlParameter("@Estatus", persona.Estatus));
            }

            // Departamento
            if (!string.IsNullOrWhiteSpace(persona.IdDepartamento))
            {
                queryBuilder.Append("ID_DEPTO = @IdDepto, ");
                parametros.Add(new NpgsqlParameter("@IdDepto", persona.IdDepartamento));
            }

            // 3. Verificación de cambios
            // Si no se agregó ningún campo al query (solo dice "UPDATE USUARIOS SET "), no hacemos nada.
            if (parametros.Count == 0)
            {
                return 0;
            }

            // 4. Finalizar Query
            // Quitamos la última coma y espacio ", " que agregó el StringBuilder
            queryBuilder.Length -= 2;

            // Agregamos el WHERE
            queryBuilder.Append(" WHERE NUMERO_USUARIO = @IdPersona");
            parametros.Add(new NpgsqlParameter("@IdPersona", persona.Id));

            // 5. Ejecución usando la Transacción
            // IMPORTANTE: Aquí usamos la conexión que vive dentro de la transacción.

            using (var cmd = new NpgsqlCommand(queryBuilder.ToString()))
            {
                cmd.Parameters.AddRange(parametros.ToArray());

                // Ejecutamos
                int filasAfectadas = cmd.ExecuteNonQuery();
                return filasAfectadas;
            }
        }

        public void ActualizarOCrearCorreo(int idUsuario, string correo, string tipo, NpgsqlTransaction transaction)
        {
            if (string.IsNullOrWhiteSpace(correo)) return;

            string updateSql = "UPDATE CORREOS SET CORREO = @Correo WHERE NUMERO_USUARIO = @Id AND TIPO = @Tipo";

            using (var cmd = new NpgsqlCommand(updateSql, transaction.Connection, transaction))
            {
                cmd.Parameters.Add(new NpgsqlParameter("@Correo", correo));
                cmd.Parameters.Add(new NpgsqlParameter("@Id", idUsuario));
                cmd.Parameters.Add(new NpgsqlParameter("@Tipo", tipo));

                int filas = cmd.ExecuteNonQuery();

                if (filas == 0) // No existía, INSERTAMOS
                {
                    string insertSql = "INSERT INTO CORREOS (NUMERO_USUARIO, CORREO, TIPO) VALUES (@Id, @Correo, @Tipo)";
                    using (var cmdIns = new NpgsqlCommand(insertSql, transaction.Connection, transaction))
                    {
                        cmdIns.Parameters.Add(new NpgsqlParameter("@Correo", correo));
                        cmdIns.Parameters.Add(new NpgsqlParameter("@Id", idUsuario));
                        cmdIns.Parameters.Add(new NpgsqlParameter("@Tipo", tipo));
                        cmdIns.ExecuteNonQuery();
                    }
                }
            }
        }

        private int ActualizarOCrearDomicilio(int idUsuario, Domicilio domicilio)
        {
            // NOTA: Esta lógica asume que la persona solo tiene UN domicilio.
            string updateQuery = @"
                UPDATE DOMICILIOS SET 
                    CALLE = @Calle, 
                    NO_EXT = @NoExt, 
                    NO_INT = @NoInt, 
                    CP = @CP, 
                    COLONIA = @Colonia, 
                    ID_MUNICIPIO = @IdMunicipio
                WHERE 
                    NUMERO_USUARIO = @UsuarioId"; // Simplificado: actualiza el primer (o único) domicilio

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                _dbAccess.CreateParameter("@Calle", domicilio.Calle),
                _dbAccess.CreateParameter("@NoExt", domicilio.NoExterior),
                _dbAccess.CreateParameter("@NoInt", domicilio.NoInterior ?? "N/A"),
                _dbAccess.CreateParameter("@CP", Convert.ToInt32(domicilio.CodigoPostal)),
                _dbAccess.CreateParameter("@Colonia", domicilio.Colonia),
                _dbAccess.CreateParameter("@IdMunicipio", domicilio.IdMunicipio),
                _dbAccess.CreateParameter("@UsuarioId", idUsuario)
            };

            int rowsAffected = _dbAccess.ExecuteNonQuery(updateQuery, parameters);
            _logger.Debug($"Intentando actualizar domicilio para ID: {idUsuario}. Filas afectadas: {rowsAffected}");

            if (rowsAffected > 0)
            {
                return rowsAffected; // Éxito en la actualización
            }

            // Si no se afectó ninguna fila (no existía), lo insertamos
            _logger.Warn($"El domicilio no existía para ID: {idUsuario}, se procederá a insertarlo.");

            // Reutilizamos el método de inserción que ya tienes
            InsertarDomicilio(idUsuario, domicilio);
            return 1; // Devolvemos 1 fila afectada por la inserción
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
            string query = @"INSERT INTO DOMICILIOS (NUMERO_USUARIO, CALLE, NO_EXT, NO_INT, CP, COLONIA, ID_MUNICIPIO)
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