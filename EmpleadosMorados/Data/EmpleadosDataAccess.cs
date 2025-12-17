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
        private readonly CatalogosDataAccess _catalogosData;

        public EmpleadosDataAccess()
        {
            _dbAccess = PostgresSQLDataAccess.GetInstance();
            _personasData = new PersonasDataAccess();
            _catalogosData = new CatalogosDataAccess();
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

        public bool ActualizarEmpleado(Empleado empleado)
        {
            if (empleado == null || empleado.Id == 0)
            {
                _logger.Error("Intento de actualizar empleado con objeto nulo o sin ID (Registro Laboral).");
                return false;
            }

            try
            {
                _dbAccess.Connect();

                // --- 1. Actualizar Datos Personales ---
                // Llama al método ModificarPersona, que retorna el número de filas afectadas (int).
                int filasPersonaAfectadas = _personasData.ModificarPersona(empleado.DatosPersonales);

                if (filasPersonaAfectadas == -1)
                {
                    _logger.Error($"Fallo grave al modificar datos personales para ID_PERSONA: {empleado.IdPersona}. Revisar logs de PersonasDataAccess.");
                    // Podrías lanzar una excepción o simplemente retornar false si el error es grave
                    return false;
                }
                else if (filasPersonaAfectadas == 0)
                {
                    _logger.Warn($"Modificación de datos personales no realizó cambios (0 filas afectadas) para ID_PERSONA: {empleado.IdPersona}.");
                }
                else
                {
                    _logger.Info($"Datos personales actualizados (filas afectadas: {filasPersonaAfectadas}) para ID_PERSONA: {empleado.IdPersona}.");
                }


                // --- 2. Actualizar el Registro Laboral (TRAY_LAB) ---
                // Usamos el campo Id (Id de TRAY_LAB) como clave de actualización.
                string trayLabQuery = @"
                    UPDATE TRAY_LAB SET 
                        MATRICULA = @Matricula, 
                        PUESTO = @Puesto, 
                        SUELDO = @Sueldo, 
                        TIPO_CONTRATO = @TipoContrato, 
                        SALARIO_FIJO = @SalarioFijo, 
                        FECHA_BAJA = @FechaBaja,
                        FECHA_ALTA = @FechaIngreso 
                    WHERE 
                        ID = @IdRegistroLaboral;";

                // Crea y mapea los parámetros del objeto Empleado
                NpgsqlParameter[] trayLabParams = new NpgsqlParameter[]
                {
                    _dbAccess.CreateParameter("@IdRegistroLaboral", empleado.Id), // ID de TRAY_LAB es la clave aquí
                    _dbAccess.CreateParameter("@Matricula", empleado.Matricula),
                    _dbAccess.CreateParameter("@Puesto", empleado.Puesto),
                    _dbAccess.CreateParameter("@Sueldo", empleado.Sueldo),
                    _dbAccess.CreateParameter("@TipoContrato", empleado.TipoContrato),
                    _dbAccess.CreateParameter("@SalarioFijo", empleado.SalarioFijo),
                    // Manejo de valores DateTime nulos (NULL en BD)
                    _dbAccess.CreateParameter("@FechaBaja", empleado.FechaBaja.HasValue ? (object)empleado.FechaBaja.Value : DBNull.Value),
                    _dbAccess.CreateParameter("@FechaIngreso", empleado.FechaIngreso)
                };

                int rowsAffected = _dbAccess.ExecuteNonQuery(trayLabQuery, trayLabParams);

                if (rowsAffected > 0)
                {
                    _logger.Info($"Registro laboral (TRAY_LAB) actualizado correctamente para ID: {empleado.Id}");
                    return true;
                }
                else
                {
                    _logger.Warn($"No se afectó ninguna fila al actualizar en TRAY_LAB para ID: {empleado.Id}. Puede que el registro no exista.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error crítico al actualizar el registro laboral (TRAY_LAB).");
                throw; // Propagar la excepción a la capa de Negocio
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

    }
}
        // ...

        // (El resto de métodos como ObtenerTodosLosEmpleados, deben ser refactorizados para usar TRAY_LAB y la nueva estructura de Persona/Domicilio)
  
