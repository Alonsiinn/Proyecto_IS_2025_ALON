using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class PermisoSimple:IPermisoComponente
    {
        public int Id { get; set; }
        public string Nombre { get; private set; }

        public PermisoSimple(string nombre)
        {
            Nombre = nombre;
        }

        public void Agregar(IPermisoComponente componente)
        {
            throw new NotImplementedException("No se pueden agregar componentes a un permiso simple.");
        }

        public void Eliminar(IPermisoComponente componente)
        {
            throw new NotImplementedException("No se pueden eliminar componentes de un permiso simple.");
        }

        public List<IPermisoComponente> ObtenerComponentes()
        {
            return new List<IPermisoComponente> { this };
        }

        public bool TienePermiso(string permiso)
        {
            return Nombre == permiso;
        }
    }
}
