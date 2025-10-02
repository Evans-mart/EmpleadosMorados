using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpleadosMorados.Data;

namespace EmpleadosMorados.Bussines
{
    internal class DelUser
    {
        private readonly ElimUserRepo _usuarioRepository;

        public DelUser()
        {
            // Creamos una instancia de nuestro repositorio para usarlo.
            _usuarioRepository = new ElimUserRepo();
        }

        /// <summary>
        /// Verifica si un usuario existe y devuelve su nombre completo.
        /// </summary>
        /// <param name="usuarioId">El ID del usuario a verificar.</param>
        /// <returns>El nombre completo del usuario si existe; de lo contrario, null.</returns>
        public string VerificarYObtenerNombreUsuario(int usuarioId)
        {
            // Llama a la capa de datos para obtener la información.
            DataTable tablaUsuario = _usuarioRepository.ObtenerUsuarioPorId(usuarioId);

            // Regla de Negocio: Si la tabla tiene filas, el usuario existe.
            if (tablaUsuario != null && tablaUsuario.Rows.Count > 0)
            {
                // Regla de Negocio: Formatear el nombre completo.
                string nombre = tablaUsuario.Rows[0]["NOMBRE"].ToString();
                string apellido = tablaUsuario.Rows[0]["APELLIDO_PAT"].ToString();
                return $"{nombre} {apellido}";
            }

            // Si no hay filas, el usuario no existe.
            return null;
        }

        public DataTable BuscarUsuariosPorNombreYApellido(string nombre, string apellido)
        {
            var repo = new ElimUserRepo();
            // Simplemente pasamos los datos a la capa de acceso a datos
            return repo.BuscarPorNombreYApellidoExacto(nombre, apellido);
        }

        public void EliminarUsuarioPermanentemente(int usuarioId)
        {
            var repo = new ElimUserRepo();
            // Lógica de negocio aquí (ej. verificar si el usuario es un admin)
            repo.EliminarFisicamente(usuarioId);
        }

        public void DarDeBajaUsuario(int usuarioId)
        {
            var repo = new ElimUserRepo();
            // Lógica de negocio aquí (ej. verificar permisos)
            repo.DarDeBajaLogica(usuarioId);
        }

    }
    }
