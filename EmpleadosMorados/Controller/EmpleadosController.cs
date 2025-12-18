using System;
using System.Collections.Generic;
using EmpleadosMorados.Bussines;
using EmpleadosMorados.Data;
using EmpleadosMorados.Model;
using EmpleadosMorados.Utilities; // Asegúrate de que tu clase de validaciones esté aquí
using NLog;
using Npgsql;  // Asegúrate de tener esta referencia para la excepción PostgresException

namespace EmpleadosMorados.Controller

{
    //Ya jala todo
    public class EmpleadosController
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("EmpleadosMorados.Controller.EmpleadosController");
        private readonly EmpleadosDataAccess _empleadosData;
        private readonly PersonasDataAccess _personasData;
        private readonly CatalogosDataAccess _catalogosData;
        private readonly ActualizarEmp _actualizarEmp;

        public EmpleadosController()
        {
            _empleadosData = new EmpleadosDataAccess();
            _personasData = new PersonasDataAccess();
            _catalogosData = new CatalogosDataAccess();
            _actualizarEmp = new ActualizarEmp();
        }

        public (int id, string mensaje) RegistrarNuevoEmpleado(Empleado empleado, string municipioNombre, string estadoNombre,string puestoNombre, string deptoNombre)
        {
            try
            {
                // 1. Validaciones de duplicidad (Delegado a PersonasDataAccess)
                if (_personasData.ExisteCurp(empleado.DatosPersonales.Curp))
                {
                    return (-1, $"El CURP {empleado.DatosPersonales.Curp} ya está registrado en el sistema.");
                }
                if (_personasData.ExisteRFC(empleado.DatosPersonales.Rfc))
                {
                    return (-1, $"El RFC {empleado.DatosPersonales.Rfc} ya está registrado en el sistema.");
                }

                // 2. Validaciones adicionales para claves foráneas y campos requeridos
                // Validar el ID del Municipio
                string idMunicipio = _catalogosData.ObtenerIdMunicipioPorNombres(municipioNombre, estadoNombre);
                if (string.IsNullOrEmpty(idMunicipio))
                {
                    return (-2, "Error: No se encontró el ID del Municipio/Estado seleccionado.");
                }

                // Validar el ID del Puesto
                string idPuesto = _catalogosData.ObtenerIdPuestoPorNombres(puestoNombre, deptoNombre);
                if (string.IsNullOrEmpty(idPuesto))
                {
                    return (-2, "Error: No se encontró el ID del Puesto/Depto seleccionado.");
                }

                // Asignar el ID al modelo Domicilio
                empleado.DatosPersonales.Domicilio.IdMunicipio = idMunicipio;

                // Validar que el ID de Departamento sea válido
                if (string.IsNullOrEmpty(empleado.DatosPersonales.IdDepartamento) ||
                    !_catalogosData.ObtenerDepartamentosActivos().Exists(d => d.Key == empleado.DatosPersonales.IdDepartamento))
                {
                    return (-2, "Error: El Departamento seleccionado no es válido.");
                }

                // Validar el teléfono (debe tener 10 dígitos)
                if (empleado.DatosPersonales.Telefono.ToString().Length != 10)
                {
                    return (-2, "Error: El número de teléfono debe tener 10 dígitos.");
                }

                // Validar SEXO (debe ser uno de los valores válidos)
                if (!new List<string> { "FEMENINO", "MASCULINO", "OTRO" }.Contains(empleado.DatosPersonales.Sexo))
                {
                    return (-2, "Error: El sexo debe ser 'FEMENINO', 'MASCULINO' o 'OTRO'.");
                }

                // 3. Registrar el empleado (transacción que inserta USUARIOS, CORREOS, DOMICILIOS y TRAY_LAB)
                _logger.Info($"Iniciando registro para {empleado.DatosPersonales.NombreCompleto}...");
                int idGenerado = _empleadosData.InsertarEmpleado(empleado); // Llama a la lógica corregida

                if (idGenerado > 0)
                {
                    _logger.Info($"Empleado registrado exitosamente. ID: {idGenerado}");
                    return (idGenerado, "Empleado registrado exitosamente.");
                }
                else
                {
                    return (0, "Error al registrar el empleado en la base de datos.");
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                // Captura de la excepción PostgresException para detalles específicos
                _logger.Error(ex, "Error en la base de datos (PostgresException).");

                // Imprime los detalles completos de la excepción
                Console.WriteLine($"Código SQL: {ex.SqlState}");  // Código SQL del error
                Console.WriteLine($"Detalle: {ex.Detail}");     // Detalles adicionales
                Console.WriteLine($"Sugerencia: {ex.Hint}");    // Sugerencia de PostgreSQL
                Console.WriteLine($"Mensaje: {ex.Message}");    // Mensaje del error

                // Devuelve el mensaje con detalles completos
                return (-3, $"Error de base de datos: {ex.Message}. Código SQL: {ex.SqlState}");
            }
            catch (Exception ex)
            {
                // Captura de excepciones generales
                _logger.Error(ex, "Error inesperado al registrar el empleado.");
                return (-4, $"Error inesperado: {ex.Message}");
            }
        }

        // =========================================================
        // ACTUALIZACIÓN DE EMPLEADO (Método llamado por la VISTA)
        // =========================================================
        public bool ActualizarEmpleado(Empleado empleado)
        {
            // Este método simplificado es el que tu View espera.
            // Llama a la lógica de negocio ActualizarEmp.
            try
            {
                return _actualizarEmp.EjecutarActualizacion(empleado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error en el Controller al llamar a ActualizarEmp.");
                // Re-lanzamos para que la Vista muestre el mensaje de error específico
                throw;
            }
        }

        // =========================================================
        // CONSULTAS DE DATOS (READ)
        // =========================================================
        public Empleado ObtenerEmpleadoParaActualizar(int idPersona)
        {
            try
            {
                // Asegúrate de que este método exista en EmpleadosDataAccess 
                // y devuelva un objeto Empleado completo con sus relaciones.
                //return _empleadosData.ObtenerEmpleadoPorIdPersona(idPersona);
                return null; // Temporalmente retornamos null hasta implementar el método
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener datos del empleado ID: {idPersona}");
                return null;
            }
        }

        // Métodos auxiliares de negocio para poblar ComboBoxes

        public List<KeyValuePair<string, string>> ObtenerDepartamentos()
        {
            return _catalogosData.ObtenerDepartamentosActivos();
        }

        public List<KeyValuePair<string, string>> ObtenerEstados()
        {
            return _catalogosData.ObtenerEstadosActivos();
        }

        public List<KeyValuePair<string, string>> ObtenerMunicipiosPorEstado(string idEstado)
        {
            return _catalogosData.ObtenerMunicipiosPorEstado(idEstado);
        }
        public List<KeyValuePair<string, string>> ObtenerPuestosPorDepto(string idDepto)
        {
            return _catalogosData.ObtenerPuestosPorDepto(idDepto);
        }
    }
}
