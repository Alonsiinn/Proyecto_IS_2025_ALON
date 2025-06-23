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
        UsuarioBLL usuarioBLL;

        public PermisoBLL()
        {
            ormPermiso = new ORMPermiso();
            usuarioBLL = new UsuarioBLL();
        }

        public List<IPermisoComponente> DevolverPermisos()
        {
            var todos = ormPermiso.DevolverTodos();
            var hijos = new HashSet<int>();

            foreach (var permiso in todos.OfType<PermisoCompuesto>())
                foreach (var hijo in permiso.ObtenerComponentes())
                    hijos.Add(hijo.Id);

            // Incluir todos los compuestos y los simples que no sean hijos
            return todos.Where(p => p is PermisoCompuesto || !hijos.Contains(p.Id)).ToList();
        }

        public List<IPermisoComponente> DevolverPermisosRaiz()
        {
            return ormPermiso.DevolverTodos().Where(p => p is PermisoCompuesto).ToList();
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

        public void AgregarPermisoACompuesto(PermisoCompuesto padre, IPermisoComponente hijo)
        {
            if (padre.ObtenerComponentes().Any(p => p.Id == hijo.Id)) return;
            

            padre.Agregar(hijo);
            ormPermiso.AgregarRelacion(padre.Id, hijo.Id); 
            ormPermiso.Update(padre);
        }
        private bool GenerariaCiclo(IPermisoComponente padre, IPermisoComponente posibleHijo)
        {
            if (padre == null || posibleHijo == null)
                return false;

            if (padre == posibleHijo)
                return true;

            if (padre is PermisoCompuesto compuesto)
            {
                foreach (var hijo in compuesto.ObtenerComponentes())
                {
                    if (GenerariaCiclo(hijo, posibleHijo))
                        return true;
                }
            }
            return false;
        }

        public void QuitarPermisoDeCompuesto(PermisoCompuesto compuesto, IPermisoComponente permiso)
        {
            compuesto.Eliminar(permiso);
            ormPermiso.EliminarRelacion(compuesto.Id, permiso.Id); 
            ormPermiso.Update(compuesto);
        }

        public void EliminarPermiso(IPermisoComponente permiso)
        {
            var usuarios =usuarioBLL.DelvoverTodos();
            foreach (var usuario in usuarios)
            {
               if(usuario.ObtenerPermisos().Any(p=>p.Id == permiso.Id))
                {
                    MessageBox.Show($"No se puede eliminar el permiso '{permiso.Nombre}' porque está asignado a un usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (permiso is PermisoCompuesto compuesto)
            {
             
                foreach (var hijo in compuesto.ObtenerComponentes())
                {
                    ormPermiso.EliminarRelacion(compuesto.Id, hijo.Id);
                   
                }
            }

            ormPermiso.Delete(permiso);
        }
    }
}
