using Acceso_Datos;
using Dominio;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapper
{
    public class ORMPedido:iCrud<Pedido>
    {
        PedidoDAL pedidoDAL;
        public ORMPedido()
        {
            pedidoDAL = new PedidoDAL();
        }

        public void Add(Pedido pedido)
        {
            int newId = pedidoDAL.Insertar(pedido.IdUsuario, pedido.Total, (byte)pedido.Estado);
            if (newId > 0)
            {
                pedido.IdPedido = newId;
                // Insertar los detalles asociados (si los hay)
                if (pedido.Detalles != null)
                {
                    ORMDetallePedido ormDetallePedido = new ORMDetallePedido();
                    foreach (DetallePedido det in pedido.Detalles)
                    {
                        det.IdPedido = pedido.IdPedido;
                        ormDetallePedido.Insertar(det);
                    }
                }
                
            }
        }

        public void Delete(Pedido pedido)
        {
            pedidoDAL.Eliminar(pedido.IdPedido);
        }

        public List<Pedido> DevolverTodos()
        {
            DataTable dt = pedidoDAL.ListarTodos();
            List<Pedido> pedidos = new List<Pedido>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Pedido ped = new Pedido();
                    ped.IdPedido = (int)row["IdPedido"];
                    ped.IdUsuario = (int)row["ID_Usuario"];
                    ped.Fecha = (System.DateTime)row["Fecha"];
                    ped.Total = (decimal)row["Total"];
                    ped.Estado = (EstadoPedido)(int)row["Estado"];
                    // Incluir datos del usuario si fueron consultados (Nombre, Apellido)
                    if (row.Table.Columns.Contains("NombreUsuario"))
                    {
                        ped.Cliente = new Usuario
                        {
                            Id = ped.IdUsuario,
                            Nombre = (string)row["NombreUsuario"],
                            Apellido = row.Table.Columns.Contains("ApellidoUsuario") ? (string)row["ApellidoUsuario"] : null
                        };
                    }
                    pedidos.Add(ped);
                }
            }
            return pedidos;
        }

        public bool Existe(string nombre)
        {
            return pedidoDAL.Existe(Convert.ToInt32(nombre));
        }

        public Pedido GetByID(int id)
        {
            DataTable dt = pedidoDAL.ObtenerPorId(id);
            Pedido ped = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                ped = new Pedido();
                ped.IdPedido = (int)row["IdPedido"];
                ped.IdUsuario = (int)row["ID_Usuario"];
                ped.Fecha = (System.DateTime)row["Fecha"];
                ped.Total = (decimal)row["Total"];
                ped.Estado = (EstadoPedido)(int)row["Estado"];
            }
            return ped;
        }

        public void Update(Pedido pedido)
        {
            pedidoDAL.Actualizar(pedido.IdPedido, pedido.Total, (byte)pedido.Estado);
        }
        public List<Pedido> ListarPorUsuario(int idUsuario)
        {
            DataTable dt = pedidoDAL.ListarPorUsuario(idUsuario);
            List<Pedido> pedidos = new List<Pedido>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Pedido ped = new Pedido();
                    ped.IdPedido = (int)row["IdPedido"];
                    ped.IdUsuario = (int)row["ID_Usuario"];
                    ped.Fecha = (System.DateTime)row["Fecha"];
                    ped.Total = (decimal)row["Total"];
                    ped.Estado = (EstadoPedido)(int)row["Estado"];
                    // En este caso, la consulta incluyó el nombre del cliente
                    if (row.Table.Columns.Contains("Cliente"))
                    {
                        ped.Cliente = new Usuario { Nombre = (string)row["Cliente"] };
                    }
                    pedidos.Add(ped);
                }
            }
            return pedidos;
        }
    }
}
