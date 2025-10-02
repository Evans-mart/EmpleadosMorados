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

        //public int ModificarDatosUsuario(Empleado empleado)
        //{
        //    if (empleado?.DatosPersonales == null || empleado.IdPersona <= 0)
        //    {
        //        _logger.Error("Datos del empleado nulos o ID de Persona no válido para la modificación.");
        //        return -1;
        //    }

            // --------------------------------------------------------------------------
            // ÚNICO PASO: MODIFICAR Datos de la Persona/Usuario (solo tabla USUARIOS)
            // --------------------------------------------------------------------------

            // Se asume que este método en PersonasDataAccess actualiza dinámicamente
            // los campos de la tabla principal de Usuarios (o la tabla de personas)
            // basándose en los datos no nulos del objeto 'DatosPersonales'.
            //int filasAfectadasUsuario = _personasData.ModificarUsuario(empleado.DatosPersonales);

            //if (filasAfectadasUsuario < 0)
            //{
            //    _logger.Error($"Fallo interno al modificar los datos del usuario con ID: {empleado.IdPersona}.");
            //    return -1; // Indica error
            //}

            //_logger.Info($"Modificación de datos de usuario exitosa para ID: {empleado.IdPersona}. Filas afectadas: {filasAfectadasUsuario}");

            //// Si la actualización es exitosa, se devuelve el número de filas afectadas (0 o 1).
            //return filasAfectadasUsuario;

        }
    }
        // ...

        // (El resto de métodos como ObtenerTodosLosEmpleados, deben ser refactorizados para usar TRAY_LAB y la nueva estructura de Persona/Domicilio)
  
