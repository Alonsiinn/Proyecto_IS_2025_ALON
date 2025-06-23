using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Stock
    {
        public int IdSucursal { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public Sucursal Sucursal { get; set; }
        public Producto Producto { get; set; }
    }
}
