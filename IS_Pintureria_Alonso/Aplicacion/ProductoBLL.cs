using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper;

namespace Aplicacion
{
    public class ProductoBLL
    {
        private ORMProducto ormProducto;
        public ProductoBLL()
        {
            ormProducto = new ORMProducto();
        }
        public void InsertarProducto(Producto producto)
        {
             ormProducto.Add(producto);
        }
        public void ActualizarProducto(Producto producto)
        {
            ormProducto.Update(producto);
        }
        public void EliminarProducto(Producto producto)
        {
            ormProducto.Delete(producto);
        }
        public List<Producto> ListarProductos()
        {
            return ormProducto.DevolverTodos();
        }
        public Producto ObtenerProductoPorId(int idProducto)
        {
            return ormProducto.GetByID(idProducto);
        }
    }
}
