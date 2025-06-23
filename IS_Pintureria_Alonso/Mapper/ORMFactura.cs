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
    public class ORMFactura : iCrud<Factura>
    {
        private FacturaDAL facturaDAL;
        public ORMFactura()
        {
            facturaDAL = new FacturaDAL();
        }

        public void Add(Factura factura)
        {
            int newId = facturaDAL.Insertar(factura.IdPedido, factura.MontoTotal);
            if (newId > 0)
            {
                factura.IdFactura = newId;
            }
        }

        public void Delete(Factura entidad)
        {
            throw new NotImplementedException();
        }

        public List<Factura> DevolverTodos()
        {
            DataTable dt = facturaDAL.ListarTodas();
            List<Factura> facturas = new List<Factura>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Factura fac = new Factura();
                    fac.IdFactura = (int)row["IdFactura"];
                    fac.IdPedido = (int)row["IdPedido"];
                    fac.Fecha = (System.DateTime)row["Fecha"];
                    fac.MontoTotal = (decimal)row["MontoTotal"];
                    // Crear objeto Pedido con datos básicos y cliente
                    fac.Pedido = new Pedido
                    {
                        IdPedido = (int)row["IdPedido"],
                        Fecha = (System.DateTime)row["FechaPedido"],
                        Total = (decimal)row["TotalPedido"],
                        Cliente = new Usuario { Nombre = (string)row["NombreUsuario"] }
                    };
                    facturas.Add(fac);
                }
            }
            return facturas;
        }
        public List<Factura> ListarPorUsuario(int idUsuario)
        {
            DataTable dt = facturaDAL.ListarPorUsuario(idUsuario);
            List<Factura> facturas = new List<Factura>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Factura fac = new Factura();
                    fac.IdFactura = (int)row["IdFactura"];
                    fac.IdPedido = (int)row["IdPedido"];
                    fac.Fecha = (System.DateTime)row["Fecha"];
                    fac.MontoTotal = (decimal)row["MontoTotal"];
                    // Incluir información mínima del pedido
                    fac.Pedido = new Pedido
                    {
                        IdPedido = (int)row["IdPedido"],
                        Fecha = (System.DateTime)row["FechaPedido"],
                        Total = (decimal)row["TotalPedido"]
                    };
                    facturas.Add(fac);
                }
            }
            return facturas;
        }
        public Factura ObtenerPorPedido(int idPedido)
        {
            DataTable dt = facturaDAL.ObtenerPorPedido(idPedido);
            Factura fac = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                fac = new Factura();
                fac.IdFactura = (int)row["IdFactura"];
                fac.IdPedido = (int)row["IdPedido"];
                fac.Fecha = (System.DateTime)row["Fecha"];
                fac.MontoTotal = (decimal)row["MontoTotal"];
                // Construir el objeto Pedido asociado, con nombre del cliente
                fac.Pedido = new Pedido
                {
                    IdPedido = (int)row["IdPedido"],
                    Fecha = (System.DateTime)row["FechaPedido"],
                    Total = (decimal)row["TotalPedido"],
                    Cliente = new Usuario { Nombre = (string)row["Cliente"] }
                };
            }
            return fac;
        }
        public bool Existe(string nombre)
        {
            throw new NotImplementedException();
        }

        public Factura GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Factura factura)
        {
            facturaDAL.Actualizar(factura.IdFactura, factura.MontoTotal);
        }
    }
}
