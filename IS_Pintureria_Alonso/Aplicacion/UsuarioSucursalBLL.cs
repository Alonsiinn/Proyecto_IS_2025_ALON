using Dominio;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class UsuarioSucursalBLL
    {
        private ORMUsuarioSucursal ormUsuarioSucursal;
        public UsuarioSucursalBLL()
        {
            ormUsuarioSucursal = new ORMUsuarioSucursal();
        }
        public bool AsignarUsuarioASucursal(int idUsuario, int idSucursal)
        {
            // Asigna un usuario a una sucursal (relación N:M)
            return ormUsuarioSucursal.AsignarUsuarioASucursal(idUsuario, idSucursal);
        }
        public bool EliminarAsignacion(UsuarioSucursal asignacion)
        {
            // Elimina la relación entre un usuario y una sucursal
            return ormUsuarioSucursal.Eliminar(asignacion);
        }
        public List<Sucursal> ListarSucursalesPorUsuario(int idUsuario)
        {
            return ormUsuarioSucursal.ListarSucursalesPorUsuario(idUsuario);
        }
        public List<Usuario> ListarUsuariosPorSucursal(int idSucursal)
        {
            return ormUsuarioSucursal.ListarUsuariosPorSucursal(idSucursal);
        }
    }
}
