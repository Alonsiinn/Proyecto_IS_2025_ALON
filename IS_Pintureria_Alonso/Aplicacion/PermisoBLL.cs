using Dominio;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{

    public class PermisoBLL
    {
        private readonly ORMPermiso ormPermiso;

        public PermisoBLL()
        {
            ormPermiso = new ORMPermiso();
        }

        public List<IPermisoComponente> DevolverPermisosRaiz()
        {
            var permisos = ormPermiso.DevolverTodos();
            return permisos.FindAll(p => p is PermisoCompuesto);
        }

        public void CrearPermisoSimple(string nombre)
        {
            var permisoSimple = new PermisoSimple(nombre);
            ormPermiso.Add(permisoSimple);
        }

        public void CrearPermisoCompuesto(string nombre)
        {
            var permisoCompuesto = new PermisoCompuesto(nombre);
            ormPermiso.Add(permisoCompuesto);
        }

        public void AgregarPermisoACompuesto(PermisoCompuesto compuesto, IPermisoComponente permiso)
        {
            compuesto.Agregar(permiso);
            ormPermiso.Update(compuesto);
        }

        public void QuitarPermisoDeCompuesto(PermisoCompuesto compuesto, IPermisoComponente permiso)
        {
            compuesto.Eliminar(permiso);
            ormPermiso.Update(compuesto);
        }

        public void EliminarPermiso(IPermisoComponente permiso)
        {
            ormPermiso.Delete(permiso);
        }
    }

}
