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
    public class ORMNotificacion: iCrud<Notificacion>
    {
        private NotificacionDAL notificacionDAL;
        public ORMNotificacion()
        {
            notificacionDAL = new NotificacionDAL();
        }

        public void Add(Notificacion notificacion)
        {
            int newId = notificacionDAL.Insertar(notificacion.IdUsuario, notificacion.Mensaje);
            if (newId > 0)
            {
                notificacion.IdNotificacion = newId;
                notificacion.FechaCreacion = DateTime.Now;
                notificacion.Leida = false;
            }
        }

        public void Delete(Notificacion notificacion)
        {
            notificacionDAL.Eliminar(notificacion.IdNotificacion);
        }

        public List<Notificacion> DevolverTodos()
        {
            DataTable dt = notificacionDAL.ListarTodas();
            List<Notificacion> notificaciones = new List<Notificacion>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Notificacion notif = new Notificacion();
                    notif.IdNotificacion = (int)row["IdNotificacion"];
                    notif.IdUsuario = (int)row["ID_Usuario"];
                    notif.Mensaje = (string)row["Mensaje"];
                    notif.FechaCreacion = (System.DateTime)row["FechaCreacion"];
                    notif.Leida = (bool)row["Leida"];
                    notificaciones.Add(notif);
                }
            }
            return notificaciones;
        }

        public bool Existe(string nombre)
        {
            throw new NotImplementedException();
        }

        public Notificacion GetByID(int id)
        {
            DataTable dt = notificacionDAL.ObtenerPorId(id);
            Notificacion notif = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                notif = new Notificacion();
                notif.IdNotificacion = (int)row["IdNotificacion"];
                notif.IdUsuario = (int)row["ID_Usuario"];
                notif.Mensaje = (string)row["Mensaje"];
                notif.FechaCreacion = (System.DateTime)row["FechaCreacion"];
                notif.Leida = (bool)row["Leida"];
            }
            return notif;
        }

        public List<Notificacion> ListarPorUsuario(int idUsuario, bool soloNoLeidas = false)
        {
            DataTable dt = notificacionDAL.ListarPorUsuario(idUsuario, soloNoLeidas);
            List<Notificacion> notificaciones = new List<Notificacion>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Notificacion notif = new Notificacion();
                    notif.IdNotificacion = (int)row["IdNotificacion"];
                    notif.IdUsuario = idUsuario;
                    notif.Mensaje = (string)row["Mensaje"];
                    notif.FechaCreacion = (System.DateTime)row["FechaCreacion"];
                    notif.Leida = (bool)row["Leida"];
                    notificaciones.Add(notif);
                }
            }
            return notificaciones;
        }

        public void Update(Notificacion notificacion)
        {
            notificacionDAL.Actualizar(notificacion.IdNotificacion, notificacion.Leida, notificacion.Mensaje);
        }
    }
}
