using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PermisoCompuesto: IPermisoComponente
    {
        public int Id { get; set; }
        public string Nombre { get; private set; }
        private List<IPermisoComponente> componentes = new();
        public PermisoCompuesto(string nombre)
        {
            Nombre = nombre;
 
        }

        public void Agregar(IPermisoComponente componente)
        {
            if(componente is PermisoCompuesto compuesto)
            {
                if(compuesto.componentes.Any(c => c.Nombre == this.Nombre))
                {
                    throw new InvalidOperationException($"El componente '{componente.Nombre}' contiene a '{this.Nombre}', por lo que habria un ciclo.");
                }
            }
            componentes.Add(componente);
        }

        public void Eliminar(IPermisoComponente componente)
        {
            componentes.Remove(componente);
        }

        public List<IPermisoComponente> ObtenerComponentes()
        {
            return componentes;
        }

        public bool TienePermiso(string permiso)
        {
            return componentes.Any(c => c.TienePermiso(permiso));
        }
    }

}
