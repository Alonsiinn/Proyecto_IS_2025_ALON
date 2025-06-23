using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso_Datos;

namespace Mapper
{
    public class ORMDetallePedido
    {
        private DetallePedidoDAL detallepedidoDAL;
        public ORMDetallePedido()
        {
            detallepedidoDAL = new DetallePedidoDAL();
        }
        public bool Insertar(DetallePedido detalle)
        {
            int filas = detallepedidoDAL.Insertar(detalle.IdPedido, detalle.IdProducto, detalle.Cantidad, detalle.PrecioUnitario);
            return (filas > 0);
        }
        public bool Actualizar(DetallePedido detalle)
        {
            int filas = detallepedidoDAL.Actualizar(detalle.IdPedido, detalle.IdProducto, detalle.Cantidad, detalle.PrecioUnitario);
            return (filas > 0);
        }
        public bool Eliminar(DetallePedido detalle)
        {
            int filas = detallepedidoDAL.Eliminar(detalle.IdPedido, detalle.IdProducto);
            return (filas > 0);
        }
        public List<DetallePedido> Listar()
        {
            DataTable dt = detallepedidoDAL.ListarTodos();
            List<DetallePedido> detalles = new List<DetallePedido>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DetallePedido det = new DetallePedido();
                    det.IdPedido = (int)row["IdPedido"];
                    det.IdProducto = (int)row["IdProducto"];
                    det.Cantidad = (int)row["Cantidad"];
                    det.PrecioUnitario = (decimal)row["PrecioUnitario"];
                    detalles.Add(det);
                }
            }
            return detalles;
        }
        public List<DetallePedido> ListarPorPedido(int idPedido)
        {
            DataTable dt = detallepedidoDAL.ListarPorPedido(idPedido);
            List<DetallePedido> detalles = new List<DetallePedido>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DetallePedido det = new DetallePedido();
                    det.IdPedido = (int)row["IdPedido"];
                    det.IdProducto = (int)row["IdProducto"];
                    det.Cantidad = (int)row["Cantidad"];
                    det.PrecioUnitario = (decimal)row["PrecioUnitario"];
                    // Información del producto (nombre y precio unitario actual) incluida en la consulta
                    det.Producto = new Producto
                    {
                        IdProducto = det.IdProducto,
                        Nombre = (string)row["Producto"],
                        Precio = (decimal)row["PrecioUnitario"]
                    };
                    detalles.Add(det);
                }
            }
            return detalles;
        }
   
    }
}
    