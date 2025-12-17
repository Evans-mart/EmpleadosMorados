using System;
using EmpleadosMorados.Data;
using EmpleadosMorados.Model;
using EmpleadosMorados.Utilities;
using NLog;

namespace EmpleadosMorados.Bussines
{
    public class ActualizarEmp
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("EmpleadosMorados.Bussines.ActualizarEmp");
        private readonly EmpleadosDataAccess _dataAccess;

        public ActualizarEmp()
        {
            // Se inicializa la capa de acceso a datos para llamar al método de UPDATE
            _dataAccess = new EmpleadosDataAccess();
        }

        /// <summary>
        /// Valida las reglas de negocio y ejecuta la actualización de un empleado en la base de datos.
        /// </summary>
        /// <param name="empleadoActualizado">Objeto Empleado con los datos a guardar. Debe contener Id (TRAY_LAB) e IdPersona.</param>
        /// <returns>True si la operación fue exitosa.</returns>
        public bool EjecutarActualizacion(Empleado empleadoActualizado)
        {
            if (empleadoActualizado == null)
            {
                _logger.Error("El objeto Empleado para la actualización es nulo.");
                // Lanza una excepción que será capturada en el Controller
                throw new ArgumentNullException(nameof(empleadoActualizado), "Los datos del empleado no pueden ser nulos.");
            }

            // ** 1. Validaciones de Negocio **

            // Validar que se tenga el ID del registro laboral (TRAY_LAB) para el WHERE del UPDATE
            if (empleadoActualizado.Id <= 0)
            {
                _logger.Error($"El registro laboral no tiene ID (ID: {empleadoActualizado.Id}).");
                throw new InvalidOperationException("Se requiere el ID del registro laboral (TRAY_LAB) para actualizar.");
            }

            // Ejemplo de una validación de negocio: asegurar que el puesto no esté vacío
            if (string.IsNullOrWhiteSpace(empleadoActualizado.Puesto))
            {
                // Usamos ArgumentException para señalar que un argumento de entrada es inválido
                throw new ArgumentException("El campo Puesto es obligatorio para la actualización.");
            }

            // Si la fecha de baja existe, debe ser posterior a la fecha de ingreso
            if (empleadoActualizado.FechaBaja.HasValue && empleadoActualizado.FechaBaja.Value <= empleadoActualizado.FechaIngreso)
            {
                throw new ArgumentException("La Fecha de Baja debe ser posterior a la Fecha de Ingreso.");
            }

            // Puedes agregar aquí cualquier otra regla de negocio antes de tocar la base de datos.


            // ** 2. Llamar a la Capa de Datos **
            try
            {
                _logger.Info($"Iniciando UPDATE de acceso a datos para empleado ID: {empleadoActualizado.IdPersona}");
                bool exito = _dataAccess.ActualizarEmpleado(empleadoActualizado);

                if (exito)
                {
                    _logger.Info("Actualización de empleado completada con éxito en la capa Data.");
                }
                else
                {
                    _logger.Warn("Actualización de empleado fallida en la capa Data. El registro no existe o no se modificó.");
                }

                return exito;
            }
            catch (Exception ex)
            {
                // Captura cualquier error de la capa de Data (incluyendo PostgresException) y lo propaga.
                _logger.Fatal(ex, $"Error crítico al ejecutar la actualización del empleado ID: {empleadoActualizado.IdPersona}");
                throw;
            }
        }
    }
}