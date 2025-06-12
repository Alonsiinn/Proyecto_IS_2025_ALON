using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public interface IPermisoComponente
    {
        int Id { get; set; }
        string Nombre { get; }
        void Agregar(IPermisoComponente componente);
        void Eliminar(IPermisoComponente componente);
        List<IPermisoComponente> ObtenerComponentes();
        bool TienePermiso(string permiso);
    }
}
