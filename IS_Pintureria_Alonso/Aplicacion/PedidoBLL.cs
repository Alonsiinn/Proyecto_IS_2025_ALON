using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper; 
namespace Aplicacion
{
    public class PedidoBLL
    {
        private ORMPedido ormPedido;
        public PedidoBLL()
        {
            ormPedido = new ORMPedido();
        }
        public void InsertarPedido(Pedido pedido)
        {
             ormPedido.Add(pedido);
        }
        public void ActualizarPedido(Pedido pedido)
        {
             ormPedido.Update(pedido);
        }
        public void EliminarPedido(Pedido pedido)
        {
             ormPedido.Delete(pedido);
        }
        public List<Pedido> ListarPedidosPorUsuario(int idUsuario)
        {
            return ormPedido.ListarPorUsuario(idUsuario);
        }
        public List<Pedido> ListarTodosPedidos()
        {
            return ormPedido.DevolverTodos();
        }
        public Pedido ObtenerPedidoPorId(int idPedido)
        {
            return ormPedido.GetByID(idPedido);
        }
    
    }
}
