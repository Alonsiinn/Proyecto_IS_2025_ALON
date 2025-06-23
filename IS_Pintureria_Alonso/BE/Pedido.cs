using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total 
        {
            get { return Detalles.Sum(d => d.Cantidad * d.PrecioUnitario); }
            set { /* No se usa, Total se calcula automáticamente */ }
        }
        public EstadoPedido Estado { get; set; }
        public List<DetallePedido> Detalles { get; set; }

        public Pedido()
        {
            Detalles = new List<DetallePedido>();
        }
    }
}
