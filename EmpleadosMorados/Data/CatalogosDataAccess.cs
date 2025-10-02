using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NLog;
using Npgsql;
using EmpleadosMorados.Utilities;

namespace EmpleadosMorados.Data
{
    public class CatalogosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("EmpleadosMorados.Data.CatalogosDataAccess");
        private readonly PostgresSQLDataAccess _dbAccess;

        public CatalogosDataAccess()
        {
            _dbAccess = PostgresSQLDataAccess.GetInstance();
        }

        // ----------------------------------------------------------------------
        // MÉTODOS PARA OBTENER IDs GEOGRÁFICOS (Necesario para RegistrarNuevoEmpleado)
        // ----------------------------------------------------------------------

        /// <summary>
        /// Obtiene el ID_MUNICIPIO buscando por el nombre del Municipio y Estado.
        /// Necesario para insertar en la tabla DOMICILIOS.
        /// </summary>
        /// <param name="municipioNombre">Nombre del municipio.</param>
        /// <param name="estadoNombre">Nombre del estado.</param>
        /// <returns>ID_MUNICIPIO (VARCHAR(6)) o string.Empty si no se encuentra.</returns>
        public string ObtenerIdMunicipioPorNombres(string municipioNombre, string estadoNombre)
        {
            string idMunicipio = string.Empty;
            try
            {
                string query = @"SELECT m.ID_MUNICIPIO 
                                 FROM CAT_MUNICIPIOS m
                                 INNER JOIN CAT_ESTADOS e ON m.ID_ESTADO = e.ID_ESTADO
                                 WHERE m.NOM_MUNICIPIO = @MunicipioNombre AND e.NOM_ESTADO = @EstadoNombre AND m.ESTATUS = 'ACTIVO'";

                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    _dbAccess.CreateParameter("@MunicipioNombre", municipioNombre),
                    _dbAccess.CreateParameter("@EstadoNombre", estadoNombre)
                };

                _dbAccess.Connect();
                object result = _dbAccess.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    idMunicipio = result.ToString();
                    _logger.Debug($"ID_MUNICIPIO '{idMunicipio}' encontrado para {municipioNombre}, {estadoNombre}.");
                }
                else
                {
                    _logger.Warn($"ID_MUNICIPIO no encontrado para {municipioNombre}, {estadoNombre}.");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener ID de municipio por nombres.");
                // Dejamos que el negocio maneje el error al devolver string.Empty
            }
            finally
            {
                _dbAccess.Disconnect();
            }
            return idMunicipio;
        }

        // ----------------------------------------------------------------------
        // MÉTODOS PARA POBLAR COMBOBOXES (Requerido por EmpleadosNegocio)
        // ----------------------------------------------------------------------

        public List<KeyValuePair<string, string>> ObtenerDepartamentosActivos()
        {
            List<KeyValuePair<string, string>> departamentos = new List<KeyValuePair<string, string>>();
            try
            {
                string query = "SELECT ID_DEPTO, NOMBRE_DEPTO FROM DEPARTAMENTOS WHERE ESTATUS = 'ACTIVO' ORDER BY NOMBRE_DEPTO";
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                foreach (DataRow row in resultado.Rows)
                {
                    // Key = ID_DEPTO, Value = NOMBRE_DEPTO
                    departamentos.Add(new KeyValuePair<string, string>(row["ID_DEPTO"].ToString(), row["NOMBRE_DEPTO"].ToString()));
                }
                _logger.Debug($"Se obtuvieron {departamentos.Count} departamentos activos.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener departamentos.");
                // En caso de error, devolvemos lista vacía y dejamos que la UI muestre el mensaje.
            }
            finally
            {
                _dbAccess.Disconnect();
            }
            return departamentos;
        }

        public List<KeyValuePair<string, string>> ObtenerEstadosActivos()
        {
            List<KeyValuePair<string, string>> estados = new List<KeyValuePair<string, string>>();
            try
            {
                string query = "SELECT ID_ESTADO, NOM_ESTADO FROM CAT_ESTADOS WHERE ESTATUS = 'ACTIVO' ORDER BY NOM_ESTADO";
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                foreach (DataRow row in resultado.Rows)
                {
                    // Key = ID_ESTADO, Value = NOM_ESTADO
                    estados.Add(new KeyValuePair<string, string>(row["ID_ESTADO"].ToString(), row["NOM_ESTADO"].ToString()));
                }
                _logger.Debug($"Se obtuvieron {estados.Count} estados activos.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener estados.");
            }
            finally
            {
                _dbAccess.Disconnect();
            }
            return estados;
        }

        public List<KeyValuePair<string, string>> ObtenerMunicipiosPorEstado(string idEstado)
        {
            List<KeyValuePair<string, string>> municipios = new List<KeyValuePair<string, string>>();
            try
            {
                string query = @"SELECT ID_MUNICIPIO, NOM_MUNICIPIO 
                                 FROM CAT_MUNICIPIOS 
                                 WHERE ID_ESTADO = @IdEstado AND ESTATUS = 'ACTIVO' 
                                 ORDER BY NOM_MUNICIPIO";

                NpgsqlParameter paramIdEstado = _dbAccess.CreateParameter("@IdEstado", idEstado);

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdEstado);

                foreach (DataRow row in resultado.Rows)
                {
                    // Key = ID_MUNICIPIO, Value = NOM_MUNICIPIO
                    municipios.Add(new KeyValuePair<string, string>(row["ID_MUNICIPIO"].ToString(), row["NOM_MUNICIPIO"].ToString()));
                }
                _logger.Debug($"Se obtuvieron {municipios.Count} municipios para el estado {idEstado}.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener municipios para el estado {idEstado}.");
            }
            finally
            {
                _dbAccess.Disconnect();
            }
            return municipios;
        }
    }
}