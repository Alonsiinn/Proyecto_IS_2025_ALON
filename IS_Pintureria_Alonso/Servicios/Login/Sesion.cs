using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Login
{
    public class Session
    {
        private Usuario _usuario { get; set; }

        public Usuario GetUsuario
        {
            get
            {
                return _usuario;
            }
        }

        public void Login(Usuario usuario)
        {
                _usuario = usuario;
        }

        public void Logout()
        {
            _usuario = null;
        }

        public bool IsLogged()
        {
            return _usuario != null;
        }

    }
}
