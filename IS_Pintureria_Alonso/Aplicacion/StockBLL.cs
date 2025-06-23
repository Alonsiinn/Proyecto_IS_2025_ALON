using Dominio;
using Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class StockBLL
    {
        private ORMStock ormStock;
        public StockBLL()
        {
            ormStock = new ORMStock();
        }
        public void InsertarStock(Stock stock)
        {
             ormStock.Add(stock);
        }
        public void ActualizarStock(Stock stock)
        {
             ormStock.Update(stock);
        }
        public void EliminarStock(Stock stock)
        {
             ormStock.Delete(stock);
        }
        public List<Stock> ListarStockPorSucursal(int idSucursal)
        {
            return ormStock.ListarPorSucursal(idSucursal);
        }
    }
}
