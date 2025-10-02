using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace EmpleadosMorados.Model
{
    public class Empleado
    {
        public int Id { get; set; } // ID de la tabla TRAY_LAB (o IdPersona si no tiene un PK propio)
        public int IdPersona { get; set; } // NUMERO_USUARIO de la tabla USUARIOS
        public DateTime FechaIngreso { get; set; } // FECHA_ALTA en TRAY_LAB

        // Asumiendo que estos campos son requeridos por el sistema, aunque no están explícitamente en TRAY_LAB DDL.
        public string Matricula { get; set; }
        public string Puesto { get; set; }
        public decimal Sueldo { get; set; }
        public string TipoContrato { get; set; }
        public bool SalarioFijo { get; set; }
        public DateTime? FechaBaja { get; set; }

        // Propiedades de acceso directo para datos clave
        public string IdDepartamento => DatosPersonales?.IdDepartamento;
        public string Estatus => DatosPersonales?.Estatus;

        public Persona DatosPersonales { get; set; }

        // Constructor por defecto
        public Empleado()
        {
            DatosPersonales = new Persona();
            FechaIngreso = DateTime.Now;
        }

        // Constructor con campos mínimos laborales (FechaIngreso, DatosPersonales)
        public Empleado(DateTime fechaIngreso, Persona datosPersonales)
        {
            FechaIngreso = fechaIngreso;
            DatosPersonales = datosPersonales;
            Matricula = string.Empty;
            Puesto = string.Empty;
            Sueldo = 0.00m;
            TipoContrato = "INDEFINIDO";
            SalarioFijo = true;
        }

        // Constructor básico (Incluye datos laborales clave)
        public Empleado(DateTime fechaIngreso, string matricula, string puesto, decimal sueldo, string tipoContrato, Persona datosPersonales)
        {
            FechaIngreso = fechaIngreso;
            Matricula = matricula;
            Puesto = puesto;
            Sueldo = sueldo;
            TipoContrato = tipoContrato;
            DatosPersonales = datosPersonales;
            SalarioFijo = true;
        }

        // Constructor completo (para obtener de la BD o actualización)
        public Empleado(int id, int idPersona, DateTime fechaIngreso, string matricula, string puesto, decimal sueldo, string tipoContrato, bool salarioFijo, DateTime? fechaBaja, Persona datosPersonales)
        {
            Id = id;
            IdPersona = idPersona;
            FechaIngreso = fechaIngreso;
            Matricula = matricula;
            Puesto = puesto;
            Sueldo = sueldo;
            TipoContrato = tipoContrato;
            SalarioFijo = salarioFijo;
            FechaBaja = fechaBaja;
            DatosPersonales = datosPersonales;
        }
    }
}
