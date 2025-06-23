using Dominio;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acceso_Datos;
using System.Reflection.Metadata.Ecma335;

namespace Mapper
{
    public class ORMStock : iCrud<Stock>
    {
        private StockDAL stockDAL;
        private SucursalDAL sucursalDAL;
        public ORMStock()
        {
            stockDAL = new StockDAL();
            sucursalDAL = new SucursalDAL();
        }
        public void Add(Stock stock)
        {
            stockDAL.Insertar(stock.IdSucursal, stock.IdProducto, stock.Cantidad);
        }

        public void Delete(Stock stock)
        {
            stockDAL.Eliminar(stock.IdSucursal, stock.IdProducto);
        }

        public List<Stock> DevolverTodos()
        {
            DataTable dt = stockDAL.ListarTodos();
            List<Stock> lista = new List<Stock>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Stock st = new Stock();
                    st.IdSucursal = (int)row["IdSucursal"];
                    st.IdProducto = (int)row["IdProducto"];
                    st.Cantidad = (int)row["Cantidad"];
                    lista.Add(st);
                }
            }
            return lista;
        }

        public bool Existe(string nombre)
        {
            throw new NotImplementedException();
        }

        public Stock GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Stock stock)
        {
            stockDAL.Actualizar(stock.IdSucursal, stock.IdProducto, stock.Cantidad);
        }
        public List<Stock> ListarPorSucursal(int idSucursal)
        {
            DataTable dt = stockDAL.ListarPorSucursal(idSucursal);
            List<Stock> lista = new List<Stock>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Stock st = new Stock();
                    if (row["Sucursal"].ToString() == "Almacen") { st.IdSucursal = 1; }
                    else { st.IdSucursal = sucursalDAL.DevolverIDPorNombre(row["Sucursal"].ToString());}
                        st.IdProducto = (int)row["IdProducto"];
                    st.Cantidad = (int)row["StockDisponible"];
                    st.Sucursal = new Sucursal { IdSucursal = st.IdSucursal, Nombre = (string)row["Sucursal"] };
                    st.Producto = new Producto
                    {
                        IdProducto = st.IdProducto,
                        Nombre = (string)row["Producto"],
                        Precio = (decimal)row["Precio"]
                    };
                    if (row.Table.Columns.Contains("Categoria"))
                    {
                        st.Producto.Categoria = new Categoria { Nombre = (string)row["Categoria"] };
                    }
                    lista.Add(st);
                }
            }
            return lista;
        }
    }
}
