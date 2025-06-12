using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Login
{
    public static class SessionManager
    {


        private static Session _session;

        private static Object _lock = new object();

       /* public Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }*/

        public static Session GetInstance
        {
            get
            {   
                lock(_lock)  
                {
                    if (_session == null)
                    { _session = new Session(); }

                }
                return _session;
            }
        }

       

       /* public static void Login(Usuario usuario)
        {

            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new SessionManager();
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;
                }
                else
                {
                    throw new Exception("Sesion no iniciada");
                }
            }

        }*/

        /*public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("Sesion no iniciada");
                }
            }

        }*/

        /*private SessionManager()
        {

        }*/
    }
}
