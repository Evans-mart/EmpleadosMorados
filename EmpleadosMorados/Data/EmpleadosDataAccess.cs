using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                _dbAccess = PostgresSQLDataAccess.GetInstance();
                _personasData = new PersonasDataAccess();
                _logger.Info("Instancia de EmpleadosDataAccess creada correctamente.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al inicializar EmpleadosDataAccess");
                throw;
            }
        }

        // Obtener todos los empleados
        public List<Empleado> ObtenerTodosLosEmpleados(bool soloActivos = true)
        {
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                string query = @"SELECT u.NUMERO_USUARIO, u.NOMBRE, u.APELLIDO_PAT, u.APELLIDO_MAT, u.CURP, u.RFC, 
                             u.TELEFONO, u.SEXO, u.ESTATUS, d.NOMBRE_DEPTO, d.ID_DEPTO, 
                             dom.CALLE, dom.NO_EXT, dom.NO_INT, dom.CP, dom.COLONIA, m.NOM_MUNICIPIO, e.NOM_ESTADO
                             FROM USUARIOS u
                             INNER JOIN DEPARTAMENTOS d ON u.ID_DEPTO = d.ID_DEPTO
                             INNER JOIN DOMICILIOS dom ON u.NUMERO_USUARIO = dom.NOMBRE_USUARIO
                             INNER JOIN CAT_MUNICIPIOS m ON dom.ID_MUNICIPIO = m.ID_MUNICIPIO
                             INNER JOIN CAT_ESTADOS e ON m.ID_ESTADO = e.ID_ESTADO";

                if (soloActivos)
                    query += " WHERE u.ESTATUS = 'ACTIVO'";

                query += " ORDER BY u.NUMERO_USUARIO";

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                foreach (DataRow row in resultado.Rows)
                {
                    Empleado empleado = new Empleado
                    {
                        Id = Convert.ToInt32(row["NUMERO_USUARIO"]),
                        Nombre = row["NOMBRE"].ToString(),
                        ApellidoPaterno = row["APELLIDO_PAT"].ToString(),
                        ApellidoMaterno = row["APELLIDO_MAT"].ToString(),
                        Curp = row["CURP"].ToString(),
                        Rfc = row["RFC"].ToString(),
                        Telefono = row["TELEFONO"].ToString(),
                        Sexo = row["SEXO"].ToString(),
                        Estatus = row["ESTATUS"].ToString(),
                        Departamento = row["NOMBRE_DEPTO"].ToString(),
                        IdDepartamento = row["ID_DEPTO"].ToString(),
                        Domicilio = new Domicilio
                        {
                            Calle = row["CALLE"].ToString(),
                            NoExterior = row["NO_EXT"].ToString(),
                            NoInterior = row["NO_INT"].ToString(),
                            CodigoPostal = row["CP"].ToString(),
                            Colonia = row["COLONIA"].ToString(),
                            Municipio = row["NOM_MUNICIPIO"].ToString(),
                            Estado = row["NOM_ESTADO"].ToString()
                        }
                    };

                    empleados.Add(empleado);
                }

                _logger.Info($"Se obtuvieron {empleados.Count} empleados.");
                return empleados;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener empleados");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Insertar un nuevo empleado
        public int InsertarEmpleado(Empleado empleado)
        {
            try
            {
                if (empleado == null || empleado.Domicilio == null)
                {
                    _logger.Error("Los datos del empleado son nulos");
                    return -1;
                }

                string query = @"INSERT INTO USUARIOS (NUMERO_USUARIO, NOMBRE, APELLIDO_PAT, APELLIDO_MAT, CURP, RFC, TELEFONO, SEXO, ESTATUS, ID_DEPTO)
                             VALUES (@NUMERO_USUARIO, @NOMBRE, @APELLIDO_PAT, @APELLIDO_MAT, @CURP, @RFC, @TELEFONO, @SEXO, @ESTATUS, @ID_DEPTO) RETURNING NUMERO_USUARIO";

                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                _dbAccess.CreateParameter("@NUMERO_USUARIO", empleado.Id),
                _dbAccess.CreateParameter("@NOMBRE", empleado.Nombre),
                _dbAccess.CreateParameter("@APELLIDO_PAT", empleado.ApellidoPaterno),
                _dbAccess.CreateParameter("@APELLIDO_MAT", empleado.ApellidoMaterno),
                _dbAccess.CreateParameter("@CURP", empleado.Curp),
                _dbAccess.CreateParameter("@RFC", empleado.Rfc),
                _dbAccess.CreateParameter("@TELEFONO", empleado.Telefono),
                _dbAccess.CreateParameter("@SEXO", empleado.Sexo),
                _dbAccess.CreateParameter("@ESTATUS", empleado.Estatus),
                _dbAccess.CreateParameter("@ID_DEPTO", empleado.IdDepartamento)
                };

                _dbAccess.Connect();
                object result = _dbAccess.ExecuteScalar(query, parameters);

                int idEmpleado = Convert.ToInt32(result);
                _logger.Info($"Empleado insertado correctamente con ID: {idEmpleado}");
                return idEmpleado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al insertar el empleado");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        // Actualizar un empleado
        public int ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                string query = @"UPDATE USUARIOS SET 
                             NOMBRE = @NOMBRE, APELLIDO_PAT = @APELLIDO_PAT, APELLIDO_MAT = @APELLIDO_MAT, 
                             CURP = @CURP, RFC = @RFC, TELEFONO = @TELEFONO, SEXO = @SEXO, ESTATUS = @ESTATUS, 
                             ID_DEPTO = @ID_DEPTO
                             WHERE NUMERO_USUARIO = @NUMERO_USUARIO";

                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                _dbAccess.CreateParameter("@NOMBRE", empleado.Nombre),
                _dbAccess.CreateParameter("@APELLIDO_PAT", empleado.ApellidoPaterno),
                _dbAccess.CreateParameter("@APELLIDO_MAT", empleado.ApellidoMaterno),
                _dbAccess.CreateParameter("@CURP", empleado.Curp),
                _dbAccess.CreateParameter("@RFC", empleado.Rfc),
                _dbAccess.CreateParameter("@TELEFONO", empleado.Telefono),
                _dbAccess.CreateParameter("@SEXO", empleado.Sexo),
                _dbAccess.CreateParameter("@ESTATUS", empleado.Estatus),
                _dbAccess.CreateParameter("@ID_DEPTO", empleado.IdDepartamento),
                _dbAccess.CreateParameter("@NUMERO_USUARIO", empleado.Id)
                };

                _dbAccess.Connect();
                int rowsAffected = _dbAccess.ExecuteNonQuery(query, parameters);
                _logger.Info($"Empleado actualizado correctamente con ID: {empleado.Id}. Filas afectadas: {rowsAffected}");
                return rowsAffected;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al actualizar el empleado");
                return 0;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }
    }

}
