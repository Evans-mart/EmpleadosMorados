using NLog;
using EmpleadosMorados.Data;
using EmpleadosMorados.Model;
using EmpleadosMorados.Utilities; // Asegúrate de que tu clase de validaciones esté aquí
using System;
using System.Collections.Generic;
using Npgsql;  // Asegúrate de tener esta referencia para la excepción PostgresException

namespace EmpleadosMorados.Controller

{

    public class EmpleadosController
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("EmpleadosMorados.Controller.EmpleadosController");
        private readonly EmpleadosDataAccess _empleadosData;
        private readonly PersonasDataAccess _personasData;
        private readonly CatalogosDataAccess _catalogosData;

        public EmpleadosController()
        {
            _empleadosData = new EmpleadosDataAccess();
            _personasData = new PersonasDataAccess();
            _catalogosData = new CatalogosDataAccess();
        }

        public (int id, string mensaje) RegistrarNuevoEmpleado(Empleado empleado, string municipioNombre, string estadoNombre)
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
    }
}
