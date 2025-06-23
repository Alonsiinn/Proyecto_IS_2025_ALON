using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        private string _username;
        private string _password;
        private string _nombre;
        private string _apellido;
        private string _email;
        private DateTime _fechaNacimiento;
        private string _telefono;
        private string _direccion_Fiscal;
        private string _DNI;
        private string _tipo_Usuario;
        private int _Id;
        private bool _abierta;
        private bool _bloqueada;
        private List<IPermisoComponente> Permisos = new();

        public Usuario() { }

        public Usuario(int id, string username, string password,string nombre, string apellido, string email, string dni, string telefono ,string direccionfiscal, string tipo,DateTime fechanacimiento )
        {
            Id = id;
            Username = username;
            Password = password;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            DNI = dni;
            Telefono = telefono;
            DireccionFiscal = direccionfiscal;
            TipoUsuario = tipo;
            FechaNacimiento = fechanacimiento;
            Abierta = false;
            Bloqueada = false;
        }
        public Usuario(int id, string username, string password, string nombre, string apellido, string email, string dni, string telefono, string direccionfiscal, string tipo, DateTime fechanacimiento,bool abierta,bool bloqueada)
        {
            Id = id;
            Username = username;
            Password = password;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            DNI = dni;
            Telefono = telefono;
            DireccionFiscal = direccionfiscal;
            TipoUsuario = tipo;
            FechaNacimiento = fechanacimiento;
            Abierta = abierta;
            Bloqueada = bloqueada;
        }

        #region Properties
        public int Id
        {
            get => _Id;
            set => _Id = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public string Apellido
        {
            get => _apellido;
            set => _apellido = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public DateTime FechaNacimiento
        {
            get => _fechaNacimiento;
            set => _fechaNacimiento = value;
        }

        public string Telefono
        {
            get => _telefono;
            set => _telefono = value;
        }

        public string DireccionFiscal
        {
            get => _direccion_Fiscal;
            set => _direccion_Fiscal = value;
        }

        public string DNI
        {
            get => _DNI;
            set => _DNI = value;
        }

        public string TipoUsuario
        {
            get => _tipo_Usuario;
            set => _tipo_Usuario = value;
        }
        public bool Abierta
        {
            get => _abierta;
            set => _abierta = value;
        }

        public bool Bloqueada
        {
            get => _bloqueada;
            set => _bloqueada = value;
        }
        #endregion
        public void SetID(int id) => Id = id;
        public int GetID() => Id;

        public void AgregarPermiso(IPermisoComponente permiso)
        {
            Permisos.Add(permiso);
        }

        public void EliminarPermiso(IPermisoComponente permiso)
        {
            Permisos.Remove(permiso);
        }

        public bool TienePermiso(string permiso)
        {
            return Permisos.Any(p => p.TienePermiso(permiso));
        }

        public List<IPermisoComponente> ObtenerPermisos()
        {
            return Permisos;
        }
        public bool Bloqueado()
        {
            return Bloqueada;
        }  
        public bool Abierto()
        {
            return Abierta;
        }
    }
}
