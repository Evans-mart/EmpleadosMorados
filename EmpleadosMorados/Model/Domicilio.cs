using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleadosMorados.Model
{
    public class Domicilio
    {
        public string Calle { get; set; }
        public string NoExterior { get; set; }
        public string NoInterior { get; set; }
        public string CodigoPostal { get; set; }
        public string Colonia { get; set; }
        public string Estado { get; set; } // Nombre del Estado (Catálogo)
        public string Municipio { get; set; } // Nombre del Municipio (Catálogo)
        public string IdMunicipio { get; set; } // Clave foránea para la tabla DOMICILIOS

        // Constructor por defecto
        public Domicilio()
        {
            NoInterior = "N/A"; // Valor por defecto del DDL
            // Se asume que IdMunicipio se obtendrá aparte
        }

        // Constructor con campos obligatorios de inserción (para usar al crear un nuevo empleado)
        public Domicilio(string calle, string noExterior, string codigoPostal, string colonia, string idMunicipio)
        {
            Calle = calle;
            NoExterior = noExterior;
            NoInterior = "N/A";
            CodigoPostal = codigoPostal;
            Colonia = colonia;
            IdMunicipio = idMunicipio;
        }

        // Constructor completo (incluye NoInterior y nombres de catálogo para lectura)
        public Domicilio(string calle, string noExterior, string noInterior, string codigoPostal, string colonia, string idMunicipio, string estado, string municipio)
        {
            Calle = calle;
            NoExterior = noExterior;
            NoInterior = noInterior;
            CodigoPostal = codigoPostal;
            Colonia = colonia;
            IdMunicipio = idMunicipio;
            Estado = estado;
            Municipio = municipio;
        }
    }
}