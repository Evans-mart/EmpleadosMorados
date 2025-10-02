using NLog;
using EmpleadosMorados.Data;
using EmpleadosMorados.Model;
using EmpleadosMorados.Utilities; // Asumo que aquí está tu clase Validaciones
using System;
using System.Collections.Generic;

namespace EmpleadosMorados.Controller

{
    // Clase que contiene la lógica de negocio para la gestión de Empleados
    public class EmpleadosController
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("EmpleadosMorados.Business.EmpleadosNegocio");
        private readonly EmpleadosDataAccess _empleadosData;
        private readonly PersonasDataAccess _personasData;

        // Asumo la existencia de una clase de catálogo para obtener IDs geográficos
        private readonly CatalogosDataAccess _catalogosData;

        public EmpleadosController()
        {
            _empleadosData = new EmpleadosDataAccess();
            _personasData = new PersonasDataAccess();
            _catalogosData = new CatalogosDataAccess(); // Necesaria para ID_MUNICIPIO
        }

        /// <summary>
        /// Registra un nuevo empleado en el sistema.
        /// Esto incluye USUARIOS, CORREOS, DOMICILIOS y TRAY_LAB.
        /// </summary>
        /// <param name="empleado">Objeto Empleado con todos los datos.</param>
        /// <param name="municipioNombre">Nombre del municipio seleccionado.</param>
        /// <param name="estadoNombre">Nombre del estado seleccionado.</param>
        /// <returns>Tupla (ID generado, Mensaje de resultado).</returns>
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

                // 2. Obtener IDs de catálogo necesarios para la inserción
                // Esta es la parte CLAVE para el DDL (DOMICILIOS requiere ID_MUNICIPIO)
                string idMunicipio = _catalogosData.ObtenerIdMunicipioPorNombres(municipioNombre, estadoNombre);

                if (string.IsNullOrEmpty(idMunicipio))
                {
                    return (-2, "Error: No se encontró el ID del Municipio/Estado seleccionado.");
                }

                // Asignar el ID al modelo Domicilio
                empleado.DatosPersonales.Domicilio.IdMunicipio = idMunicipio;

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
            catch (Exception ex)
            {
                _logger.Error(ex, "Error crítico al registrar nuevo empleado.");
                return (-3, $"Error inesperado: {ex.Message}");
            }
        }

        // Métodos auxiliares de negocio para poblar ComboBoxes

        public List<KeyValuePair<string, string>> ObtenerDepartamentos()
        {
            // Llama a CatalogosDataAccess.ObtenerDepartamentos() y mapea a KeyValuePair<ID, NOMBRE>
            // Por ejemplo:
            return _catalogosData.ObtenerDepartamentosActivos();
        }

        public List<KeyValuePair<string, string>> ObtenerEstados()
        {
            // Llama a CatalogosDataAccess.ObtenerEstados()
            return _catalogosData.ObtenerEstadosActivos();
        }

        public List<KeyValuePair<string, string>> ObtenerMunicipiosPorEstado(string idEstado)
        {
            // Llama a CatalogosDataAccess.ObtenerMunicipiosPorEstado(idEstado)
            return _catalogosData.ObtenerMunicipiosPorEstado(idEstado);
        }
    }
}