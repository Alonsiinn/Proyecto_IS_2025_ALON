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
                var user = this.DelvoverTodos().FirstOrDefault(x => x.Username == username);
                if (user == null)
                {
                    throw new LoginException(LoginResult.UsuarioNoEncontrado);
                }
                if(!Encriptacion.GenerarSHA256(password).Equals(user.Password))
                {
                    throw new LoginException(LoginResult.CredencialesInvalidas);
                }
                if(user.Bloqueada)
                {
                    throw new LoginException(LoginResult.CuentaBloqueada);
                }
                if (user.Abierta)
                {
                    throw new LoginException(LoginResult.CuentaAbierta);
                }
                else
                {
                    SessionManager.GetInstance.Login(user);
                    return LoginResult.IngresoConfirmado;
                }


        
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo");
            }
            if (string.IsNullOrWhiteSpace(usuario.Username) || string.IsNullOrWhiteSpace(usuario.Password))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña son obligatorios");
            }
            if (DelvoverTodos().Any(u => u.Username == usuario.Username))
            {
                throw new Exception("El nombre de usuario ya está en uso");
            }
            userorm.Add(usuario);
        }
        public List<Usuario> DelvoverTodos()
        {
          return userorm.DevolverTodos();
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
