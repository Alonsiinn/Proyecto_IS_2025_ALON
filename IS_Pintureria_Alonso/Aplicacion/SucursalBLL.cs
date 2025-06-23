using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Aplicacion
{
    public class SucursalBLL
    {
        private ORMSucursal ormSucursal;
        public SucursalBLL()
        {
            ormSucursal = new ORMSucursal();
        }
        public void InsertarSucursal(Sucursal sucursal)
        {
            ormSucursal.Add(sucursal);
        }
        public void ActualizarSucursal(Sucursal sucursal)
        {
            ormSucursal.Update(sucursal);
        }
        public void EliminarSucursal(Sucursal sucursal)
        {
            ormSucursal.Delete(sucursal);
        }
        public List<Sucursal> ListarSucursales()
        {
            return ormSucursal.DevolverTodos();
        }
        public Sucursal ObtenerSucursalPorId(int idSucursal)
        {
            return ormSucursal.GetByID(idSucursal);
        }
    }
}
