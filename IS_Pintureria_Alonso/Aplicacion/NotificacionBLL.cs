using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper; // Assuming ORMProducto is in the Mapper namespace


namespace Aplicacion
{
    public class NotificacionBLL
    {
        private ORMNotificacion ormNotificacion;
        public NotificacionBLL()
        {
            ormNotificacion = new ORMNotificacion();
        }
        public void InsertarNotificacion(Notificacion notificacion)
        {
             ormNotificacion.Add(notificacion);
        }
        public void ActualizarNotificacion(Notificacion notificacion)
        {
             ormNotificacion.Update(notificacion);
        }
        public void EliminarNotificacion(Notificacion notificacion)
        {
             ormNotificacion.Delete(notificacion);
        }
        public List<Notificacion> ListarNotificacionesPorUsuario(int idUsuario, bool soloNoLeidas = false)
        {
            return ormNotificacion.ListarPorUsuario(idUsuario, soloNoLeidas);
        }
    }
}
