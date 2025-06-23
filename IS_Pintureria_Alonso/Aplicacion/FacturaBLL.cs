using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Aplicacion
{
    public class FacturaBLL
    {
        private ORMFactura ormFactura;
        public FacturaBLL()
        {
            ormFactura = new ORMFactura();
        }
        public void InsertarFactura(Factura factura)
        {
             ormFactura.Add(factura);
        }
        public void ActualizarFactura(Factura factura)
        {
             ormFactura.Update(factura);
        }
        public void EliminarFactura(Factura factura)
        {
            ormFactura.Delete(factura);
        }
        public List<Factura> ListarFacturasPorUsuario(int idUsuario)
        {
            return ormFactura.ListarPorUsuario(idUsuario);
        }
        public Factura ObtenerFacturaPorPedido(int idPedido)
        {
            return ormFactura.ObtenerPorPedido(idPedido);
        }
        public List<Factura> ListarTodasFacturas()
        {
            return ormFactura.DevolverTodos();
        }
    }
}
