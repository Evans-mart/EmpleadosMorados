using System;
using System.Data;
using System.Linq;
using System.Text;
using EmpleadosMorados.Model;
using EmpleadosMorados.Utilities;
using NLog;
using Npgsql;

namespace EmpleadosMorados.Data
{
    public class EmpleadosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("NominaXpert.Data.EmpleadosDataAccess");
        private readonly PostgresSQLDataAccess _dbAccess;
        private readonly PersonasDataAccess _personasData;

        public EmpleadosDataAccess()
        {
            _dbAccess = PostgresSQLDataAccess.GetInstance();
            _personasData = new PersonasDataAccess();
        }

        // Insertar un nuevo empleado (Datos Personales + Registro Laboral)
        public int InsertarEmpleado(Empleado empleado)
        {
            if (empleado?.DatosPersonales == null)
            {
                _logger.Error("Los datos del empleado o la persona son nulos");
                return -1;
            }

            // 1. Insertar Persona/Usuario, Domicilio, Correos (Maneja USUARIOS, CORREOS, DOMICILIOS)
            // Se asume que IdDepartamento se pasa en DatosPersonales.IdDepartamento
            int idPersona = _personasData.InsertarPersona(empleado.DatosPersonales);

            if (idPersona <= 0)
            {
                _logger.Error("Fallo al insertar los datos de la persona/usuario.");
                return -1;
            }

            empleado.IdPersona = idPersona;

            // 2. Insertar el registro laboral en la tabla TRAY_LAB
            // NOTA: TRAY_LAB solo registra la fecha de alta. Si se necesitan más campos, la BD debe cambiar.
            string trayLabQuery = @"INSERT INTO TRAY_LAB (NUMERO_USUARIO, FECHA_ALTA, USR_CONTRATO)
                                    VALUES (@IdPersona, @FechaAlta, @UsrContrato)";

            NpgsqlParameter[] trayLabParams = new NpgsqlParameter[]
            {
                _dbAccess.CreateParameter("@IdPersona", empleado.IdPersona),
                _dbAccess.CreateParameter("@FechaAlta", empleado.FechaIngreso),
                // Usamos un valor por defecto o la matrícula si no tenemos un usuario de contrato
                _dbAccess.CreateParameter("@UsrContrato", empleado.Matricula)
            };

            try
            {
                _dbAccess.Connect();
                int rowsAffected = _dbAccess.ExecuteNonQuery(trayLabQuery, trayLabParams);

                if (rowsAffected > 0)
                {
                    _logger.Info($"Registro laboral (TRAY_LAB) insertado correctamente para ID_PERSONA: {idPersona}");
                    return idPersona; // Retornamos el Id de la persona, ya que es la clave única
                }
                else
                {
                    _logger.Error($"No se afectó ninguna fila al insertar en TRAY_LAB para ID_PERSONA: {idPersona}");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al insertar el registro laboral (TRAY_LAB)");
                // Implementar rollback para USUARIOS, CORREOS, DOMICILIOS
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // ** El método ActualizarEmpleado se eliminaría o modificaría para solo actualizar los campos laborales 
        // ** en TRAY_LAB o una tabla de detalle laboral, asumiendo que los datos personales se actualizan por separado.

        public int ModificarUsuario(Persona datosPersonales)
        {
            if (datosPersonales == null || datosPersonales.IdPersona <= 0)
            {
                _logger.Error("Datos personales o IdPersona nulo/inválido para modificación.");
                return -1;
            }

            // 1. Inicialización de la consulta dinámica y lista de parámetros
            StringBuilder sql = new StringBuilder("UPDATE USUARIOS SET ");
            List<NpgsqlParameter> parametros = new List<NpgsqlParameter>();

            // 2. Construcción Dinámica: Añadir campos solo si el valor NO es nulo o por defecto

            // Ejemplo de actualización de cadenas (string)
            if (!string.IsNullOrEmpty(datosPersonales.Nombre))
            {
                sql.Append("NOMBRE = @Nombre, ");
                parametros.Add(_dbAccess.CreateParameter("@Nombre", datosPersonales.Nombre));
            }
            if (!string.IsNullOrEmpty(datosPersonales.ApPat))
            {
                sql.Append("APELLIDO_PAT = @ApPat, ");
                parametros.Add(_dbAccess.CreateParameter("@ApPat", datosPersonales.ApPat));
            }
            if (!string.IsNullOrEmpty(datosPersonales.Curp))
            {
                sql.Append("CURP = @Curp, ");
                parametros.Add(_dbAccess.CreateParameter("@Curp", datosPersonales.Curp));
            }

            // Ejemplo de actualización de valores numéricos o que pueden ser nulos (Nullable<T>)
            if (datosPersonales.Telefono.HasValue)
            {
                sql.Append("TELEFONO = @Telefono, ");
                parametros.Add(_dbAccess.CreateParameter("@Telefono", datosPersonales.Telefono.Value));
            }

            // Si no hay parámetros para actualizar, terminamos
            if (parametros.Count == 0)
            {
                _logger.Warning($"No hay campos para actualizar en USUARIOS para ID: {datosPersonales.IdPersona}.");
                return 0; // 0 filas afectadas
            }

            // 3. Limpiar y finalizar la consulta
            // Remover la última coma y espacio (, )
            if (sql.ToString().TrimEnd().EndsWith(","))
            {
                sql.Length -= 2;
            }

            // Cláusula WHERE
            sql.Append(" WHERE NUMERO_USUARIO = @IdPersona");

            // Añadir el parámetro de la clave de búsqueda
            parametros.Add(_dbAccess.CreateParameter("@IdPersona", datosPersonales.IdPersona));

            int filasAfectadas = -1;

            try
            {
                // 4. Conexión y Ejecución (Delegando a PostgresSQLDataAccess)
                _dbAccess.Connect();

                // Ejecutar la consulta dinámica
                filasAfectadas = _dbAccess.ExecuteNonQuery(sql.ToString(), parametros.ToArray());

                if (filasAfectadas == 0)
                {
                    _logger.Warning($"Usuario con ID {datosPersonales.IdPersona} no encontrado para modificación en USUARIOS.");
                }

                return filasAfectadas;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al ejecutar UPDATE en USUARIOS para ID: {datosPersonales.IdPersona}.");
                return -1; // Indica un error SQL/de conexión
            }
            finally
            {
                // Asegurar que la conexión se cierra/libera
                _dbAccess.Disconnect();
            }
        }
    }
        // ...

        // (El resto de métodos como ObtenerTodosLosEmpleados, deben ser refactorizados para usar TRAY_LAB y la nueva estructura de Persona/Domicilio)
    }
}