using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper; 

namespace Aplicacion
{
    public class DetallePedidoBLL
    {
        private ORMDetallePedido ormDetallePedido;
        public DetallePedidoBLL()
        {
            ormDetallePedido = new ORMDetallePedido();
        }
        public bool InsertarDetalle(DetallePedido detalle)
        {
            return ormDetallePedido.Insertar(detalle);
        }
        public bool ActualizarDetalle(DetallePedido detalle)
        {
            return ormDetallePedido.Actualizar(detalle);
        }
        public bool EliminarDetalle(DetallePedido detalle)
        {
            return ormDetallePedido.Eliminar(detalle);
        }
        public List<DetallePedido> ListarDetallesPorPedido(int idPedido)
        {
            return ormDetallePedido.ListarPorPedido(idPedido);
        }
    }
}
