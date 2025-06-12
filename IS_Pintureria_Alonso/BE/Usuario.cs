using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Nombre { get; set; }

        private int Id;

        private List<IPermisoComponente> Permisos = new();

        public Usuario()
        {

        }
        public void SetID(int id) => this.Id = id;

        public Usuario(int id,string username,string password)
        {
            Username = username;
            Password = password;
            this.Id = id;
        }
        public int GetID()
        {
           return this.Id;
        }

        public void AgregarPermiso(IPermisoComponente permiso)
        {
            Permisos.Add(permiso);
        }
        public bool TienePermiso(string permiso)
        {
            return Permisos.Any(p => p.TienePermiso(permiso));
        }
        public List<IPermisoComponente> ObtenerPermisos()
        {
            return Permisos;
        }

    }
}
