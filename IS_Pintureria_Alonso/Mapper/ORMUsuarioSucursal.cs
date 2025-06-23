using Acceso_Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ORMUsuarioSucursal
    {
        private UsuarioSucursalDAL sucursalDAL;
        public ORMUsuarioSucursal()
        {
            sucursalDAL = new UsuarioSucursalDAL();
        }
        public bool AsignarUsuarioASucursal(int idUsuario, int idSucursal)
        {
            int filas = sucursalDAL.AsignarUsuarioASucursal(idUsuario, idSucursal);
            return (filas > 0);
        }
        public bool Eliminar(UsuarioSucursal asignacion)
        {
            int filas = sucursalDAL.Eliminar(asignacion.IdUsuario, asignacion.IdSucursal);
            return (filas > 0);
        }
        public List<Sucursal> ListarSucursalesPorUsuario(int idUsuario)
        {
            DataTable dt = sucursalDAL.ListarSucursalesPorUsuario(idUsuario);
            List<Sucursal> sucursales = new List<Sucursal>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Sucursal suc = new Sucursal();
                    suc.IdSucursal = (int)row["IdSucursal"];
                    suc.Nombre = (string)row["Nombre"];
                    suc.Ciudad = (string)row["Ciudad"];
                    sucursales.Add(suc);
                }
            }
            return sucursales;
        }
        public List<Usuario> ListarUsuariosPorSucursal(int idSucursal)
        {
            DataTable dt = sucursalDAL.ListarUsuariosPorSucursal(idSucursal);
            List<Usuario> usuarios = new List<Usuario>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Usuario user = new Usuario();
                    user.Id = (int)row["ID_Usuario"];
                    user.Nombre = (string)row["Nombre"];
                    user.Apellido = (string)row["Apellido"];
                    user.Username = (string)row["Username"];
                    usuarios.Add(user);
                }
            }
            return usuarios;
        }
    }
}
