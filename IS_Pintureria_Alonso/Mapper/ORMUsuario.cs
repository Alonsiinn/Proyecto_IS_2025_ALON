using Acceso_Datos;
using Dominio;
using Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ORMUsuario : iCrud<Usuario>
    {
        private UsuarioDAL usuarioDAL;
        private UsuarioPermisoDAL usuarioPermisoDAL;
        private ORMPermiso ormPermiso;

        private DataTable dtUsuarios;
        private DataTable dtUsuarioPermiso;

        public ORMUsuario()
        {
            usuarioDAL = new UsuarioDAL();
            usuarioPermisoDAL = new UsuarioPermisoDAL();
            ormPermiso = new ORMPermiso();

            dtUsuarios = usuarioDAL.DevolverDS().Tables["Usuarios"];
            dtUsuarioPermiso = usuarioPermisoDAL.GetTable();
        }

        public void Add(Usuario usuario)
        {
            int nuevoID = usuarioDAL.InsertarUsuarioSP(
                usuario.Username,
                usuario.Password,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Email,
                usuario.FechaNacimiento,
                usuario.Telefono,
                usuario.DireccionFiscal,
                usuario.DNI,
                usuario.TipoUsuario
            );

            usuario.SetID(nuevoID);

            foreach (var permiso in usuario.ObtenerPermisos())
            {
                DataRow rel = dtUsuarioPermiso.NewRow();
                rel["ID_Usuario"] = nuevoID;
                rel["IdPermiso"] = permiso.Id;
                dtUsuarioPermiso.Rows.Add(rel);
            }

            usuarioPermisoDAL.GuardarCambios();
        }

        public void Update(Usuario usuario)
        {
            DataRow row = dtUsuarios.Rows.Find(usuario.GetID());
            if (row != null)
            {
                row["Username"] = usuario.Username;
                row["Password"] = usuario.Password;
                row["Nombre"] = usuario.Nombre;
                row["Apellido"] = usuario.Apellido;
                row["Email"] = usuario.Email;
                row["FechaNacimiento"] = usuario.FechaNacimiento;
                row["Telefono"] = usuario.Telefono;
                row["Direccion_Fiscal"] = usuario.DireccionFiscal;
                row["DNI"] = usuario.DNI;
                row["Tipo_Usuario"] = usuario.TipoUsuario;
                row["Abierta"] = usuario.Abierta;
                row["Bloqueada"] = usuario.Bloqueada;

                usuarioDAL.GuardarCambios();
            }

            foreach (DataRow rel in dtUsuarioPermiso.Select($"ID_Usuario = {usuario.GetID()}"))
                rel.Delete();

            foreach (var rol in usuario.ObtenerPermisos())
            {
                DataRow rel = dtUsuarioPermiso.NewRow();
                rel["ID_Usuario"] = usuario.GetID();
                rel["IdPermiso"] = rol.Id;
                dtUsuarioPermiso.Rows.Add(rel);
            }

            usuarioPermisoDAL.GuardarCambios();
        }

        public void Delete(Usuario usuario)
        {
            foreach (DataRow rel in dtUsuarioPermiso.Select($"ID_Usuario = {usuario.GetID()}"))
                rel.Delete();

            usuarioPermisoDAL.GuardarCambios();

            DataRow row = dtUsuarios.Rows.Find(usuario.GetID());
            if (row != null)
            {
                row.Delete();
                usuarioDAL.GuardarCambios();
            }
        }

        public Usuario GetByID(int id)
        {
            DataRow row = dtUsuarios.Rows.Find(id);
            if (row == null) return null;

            Usuario u = new Usuario(id, row["Username"].ToString(), row["Password"].ToString(), row["Nombre"].ToString(), row["Apellido"].ToString(), row["Email"].ToString(), row["DNI"].ToString(), row["Telefono"].ToString(), row["Direccion_Fiscal"].ToString(), row["Tipo_Usuario"].ToString(), Convert.ToDateTime(row["FechaNacimiento"]), Convert.ToBoolean(row["Abierta"]), Convert.ToBoolean(row["Bloqueada"]));

            foreach (DataRow r in dtUsuarioPermiso.Select($"ID_Usuario = {id}"))
            {
                int idPermiso = Convert.ToInt32(r["IdPermiso"]);
                var permiso = ormPermiso.GetByID(idPermiso);
                if (permiso != null)
                    u.AgregarPermiso(permiso);
            }

            return u;
        }

        public List<Usuario> DevolverTodos()
        {
            List<Usuario> lista = new();
            foreach (DataRow dr in dtUsuarios.Rows)
            {
                int id = Convert.ToInt32(dr["ID_Usuario"]);
                lista.Add(GetByID(id));
            }
            return lista;
        }

        public bool Existe(string username)
        {
            return dtUsuarios.AsEnumerable().Any(r => r["Username"].ToString() == username);
        }

    }
}

