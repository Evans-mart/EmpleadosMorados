using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosMorados.Model
{
    public class Empleado
    {
        public int Id { get; set; } // ID del empleado
        public int IdPersona { get; set; } // ID de la persona asociada (en la tabla USUARIOS)
        public string Matricula { get; set; } // Matrícula del empleado (se puede usar en lugar de 'NumeroUsuario')
        public string Puesto { get; set; } // Puesto del empleado
        public string Departamento { get; set; } // Nombre del departamento (usando el nombre)
        public string IdDepartamento { get; set; } // ID del departamento (de la tabla DEPARTAMENTOS)
        public decimal Sueldo { get; set; } // Sueldo del empleado
        public string TipoContrato { get; set; } // Tipo de contrato (e.g. "Indefinido", "Temporal")
        public DateTime FechaIngreso { get; set; } // Fecha de ingreso del empleado
        public DateTime? FechaBaja { get; set; } // Fecha de baja del empleado (nullable)
        public bool SalarioFijo { get; set; } // Indica si el salario es fijo o no
        public string Estatus { get; set; } // 'ACTIVO' o 'BAJA' para indicar el estatus del empleado

        // Propiedad que almacena los datos personales del empleado
        public Persona DatosPersonales { get; set; } // Relación con la clase Persona

        // Constructor para inicializar el objeto Empleado con todos los campos
        public Empleado(int id, int idPersona, string matricula, string puesto, string departamento, string idDepartamento, decimal sueldo, string tipoContrato,
                        DateTime fechaIngreso, DateTime? fechaBaja, bool salarioFijo, string estatus, Persona datosPersonales)
        {
            Id = id;
            IdPersona = idPersona;
            Matricula = matricula;
            Puesto = puesto;
            Departamento = departamento;
            IdDepartamento = idDepartamento;
            Sueldo = sueldo;
            TipoContrato = tipoContrato;
            FechaIngreso = fechaIngreso;
            FechaBaja = fechaBaja;
            SalarioFijo = salarioFijo;
            Estatus = estatus;
            DatosPersonales = datosPersonales;
        }

        // Constructor predeterminado
        public Empleado()
        {
            IdPersona = 0;
            Matricula = string.Empty;
            Puesto = string.Empty;
            Departamento = string.Empty;
            IdDepartamento = string.Empty;
            Sueldo = 0.00m;
            TipoContrato = string.Empty;
            FechaIngreso = DateTime.Now;
            FechaBaja = null;
            SalarioFijo = true;  // Por defecto, salario fijo
            Estatus = "ACTIVO";  // Por defecto, empleado activo
        }

        // Constructor con campos obligatorios
        public Empleado(int idPersona, string matricula, string puesto, string departamento, string idDepartamento, decimal sueldo, string tipoContrato, DateTime fechaIngreso)
        {
            IdPersona = idPersona;
            Matricula = matricula;
            Puesto = puesto;
            Departamento = departamento;
            IdDepartamento = idDepartamento;
            Sueldo = sueldo;
            TipoContrato = tipoContrato;
            FechaIngreso = fechaIngreso;
            FechaBaja = null;  // El empleado no tiene baja al inicio
            SalarioFijo = true;  // Por defecto, salario fijo
            Estatus = "ACTIVO";  // Por defecto, empleado activo
        }

        // Constructor con todos los campos (para casos de inserción o actualización)
        public Empleado(int id, int idPersona, string matricula, string puesto, string departamento, string idDepartamento, decimal sueldo, string tipoContrato, DateTime fechaIngreso, DateTime? fechaBaja, bool salarioFijo, string estatus)
        {
            Id = id;
            IdPersona = idPersona;
            Matricula = matricula;
            Puesto = puesto;
            Departamento = departamento;
            IdDepartamento = idDepartamento;
            Sueldo = sueldo;
            TipoContrato = tipoContrato;
            FechaIngreso = fechaIngreso;
            FechaBaja = fechaBaja;
            SalarioFijo = salarioFijo;
            Estatus = estatus;
        }
    }
}
