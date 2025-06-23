using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Mapper;

namespace Aplicacion
{
    public class LataPinturaBLL
    {
        private ORMLataPintura ormLataPintura;
        public LataPinturaBLL()
        {
            ormLataPintura = new ORMLataPintura();
        }
        public void InsertarLataPintura(LataPintura lataPintura)
        {
            ormLataPintura.Add(lataPintura);
        }
        public void ActualizarLataPintura(LataPintura lataPintura)
        {
            ormLataPintura.Update(lataPintura);
        }
        public void EliminarLataPintura(LataPintura lataPintura)
        {
            ormLataPintura.Delete(lataPintura);
        }
        public List<LataPintura> ListarLatasPintura()
        {
            return ormLataPintura.DevolverTodos();
        }
        public LataPintura ObtenerLataPinturaPorId(int idLataPintura)
        {
            return ormLataPintura.GetByID(idLataPintura);
        }
    }
}
