using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Dominio
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int IdPedido { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoTotal { get; set; }
        public Pedido Pedido { get; set; }
    }
}
