using Servicios.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Mapper;
using Servicios.Seguridad;

namespace Aplicacion
{
    public class UsuarioBLL
    {
        ORMUsuario userorm;
        public UsuarioBLL()
        {
             userorm = new ORMUsuario(); 
        }
        public LoginResult Login(string username, string password)
        {
          
                if (SessionManager.GetInstance.IsLogged())
                {
                    throw new Exception("Ya hay una sesion iniciada");
                }
                var user = userorm.DevolverTodos().FirstOrDefault(x => x.Username == username);
                if (user == null)
                {
                    throw new LoginException(LoginResult.UsuarioNoEncontrado);
                }
                if(!Encriptacion.GenerarMD5(password).Equals(user.Password))
                {
                    throw new LoginException(LoginResult.CredencialesInvalidas);
                }
                else
                {
                    SessionManager.GetInstance.Login(user);
                    return LoginResult.IngresoConfirmado;
                }


        
        }

        public void Logout()
        {
            if (SessionManager.GetInstance.IsLogged())
            {
                SessionManager.GetInstance.Logout();
            }
            else
            {
                throw new Exception("No hay una sesion iniciada");
            }
        }
    }
}
