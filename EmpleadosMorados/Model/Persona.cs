using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosMorados.Model
{
    public class Persona
    {
        public int Id { get; set; } // ID en la tabla USUARIOS
        public string NombreCompleto { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Rfc { get; set; }
        public string Curp { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; } // Para almacenar el género: MASCULINO, FEMENINO, OTRO
        public string Estatus { get; set; } // 'ACTIVO' o 'BAJA'
        public string IdDepartamento { get; set; } // ID del departamento de la tabla DEPARTAMENTOS
        public string NombreDepartamento { get; set; } // Nombre del departamento, ya que también puede ser útil

        // Constructor predeterminado
        public Persona(string nombreCompleto, string correo, string telefono, string curp)
        {
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Telefono = telefono;
            Curp = curp;
            Estatus = "ACTIVO"; // Por defecto, el estatus es 'ACTIVO'
        }

        // Constructor con campos básicos
        public Persona(string nombreCompleto, string correo, string telefono, string rfc, string curp)
        {
            Id = 0;
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Telefono = telefono;
            Rfc = rfc;
            Curp = curp;
            Direccion = string.Empty;
            FechaNacimiento = null;
            Estatus = "ACTIVO";
        }

        // Constructor completo
        public Persona(int id, string nombreCompleto, string correo, string telefono, string rfc, string curp, DateTime? fechaNacimiento, string direccion, string sexo, string estatus, string idDepartamento, string nombreDepartamento)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Correo = correo;
            Telefono = telefono;
            Rfc = rfc;
            Curp = curp;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Sexo = sexo;
            Estatus = estatus;
            IdDepartamento = idDepartamento;
            NombreDepartamento = nombreDepartamento;
        }

        public Persona()
        {
        }
    }
}
