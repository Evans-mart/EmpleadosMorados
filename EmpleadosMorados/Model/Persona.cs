using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Data;
using System.Collections.Generic;

namespace EmpleadosMorados.Model
{
    public class Persona
    {
        // Propiedades de la persona...
        public int Id { get; set; } // NUMERO_USUARIO
        public string NombreCompleto { get; set; } // NOMBRE
        public string ApellidoPaterno { get; set; } // APELLIDO_PAT
        public string ApellidoMaterno { get; set; } // APELLIDO_MAT
        public string Curp { get; set; } // CURP
        public string Rfc { get; set; } // RFC
        public string Telefono { get; set; } // TELEFONO
        public string Sexo { get; set; } // SEXO
        public string Estatus { get; set; } // ESTATUS
        public string CorreoPrincipal { get; set; } // CORREOS (PRINCIPAL)
        public string CorreoSecundario { get; set; } // CORREOS (SECUNDARIO)
        public Domicilio Domicilio { get; set; } // DOMICILIOS
        public string IdDepartamento { get; set; } // ID_DEPTO

        public string IdPuesto { get; set; } // ID_DEPTO
        public string NombreDepartamento { get; set; } // Nombre para la lectura

        // Constructor por defecto (para uso de ORM/mapeo)
        public Persona()
        {
            Domicilio = new Domicilio();
            Estatus = "ACTIVO";
        }

        // Constructor con campos mínimos (Nombre, CURP, Teléfono, Correo Principal)
        public Persona(string nombreCompleto, string apellidoPaterno, string curp, string telefono, string correoPrincipal)
        {
            NombreCompleto = nombreCompleto;
            ApellidoPaterno = apellidoPaterno;
            Curp = curp;
            Telefono = telefono;
            CorreoPrincipal = correoPrincipal;

            Domicilio = new Domicilio();
            Estatus = "ACTIVO";
        }

        // Constructor con campos básicos (Incluye RFC y Sexo)
        public Persona(string nombreCompleto, string apellidoPaterno, string apellidoMaterno, string curp, string rfc, string telefono, string sexo, string correoPrincipal, string idDepartamento, string idPuesto)
        {
            NombreCompleto = nombreCompleto;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Curp = curp;
            Rfc = rfc;
            Telefono = telefono;
            Sexo = sexo;
            CorreoPrincipal = correoPrincipal;
            IdDepartamento = idDepartamento;
            IdPuesto = idDepartamento;
            Domicilio = new Domicilio();
            Estatus = "ACTIVO";
        }

        // Constructor completo (para obtener datos de la BD o actualización total)
        public Persona(int id, string nombreCompleto, string apellidoPaterno, string apellidoMaterno, string curp, string rfc, string telefono, string sexo, string estatus, string correoPrincipal, string correoSecundario, Domicilio domicilio, string idDepartamento, string nombreDepartamento, string idPuesto)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Curp = curp;
            Rfc = rfc;
            Telefono = telefono;
            Sexo = sexo;
            Estatus = estatus;
            CorreoPrincipal = correoPrincipal;
            CorreoSecundario = correoSecundario;
            Domicilio = domicilio;
            IdDepartamento = idDepartamento;
            IdPuesto = idPuesto;
            NombreDepartamento = nombreDepartamento;
        }
    }
}
