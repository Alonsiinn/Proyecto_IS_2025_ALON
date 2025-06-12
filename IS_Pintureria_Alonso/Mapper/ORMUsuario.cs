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
            DataRow dr = dtUsuarios.NewRow();
            dr["Username"] = usuario.Username;
            dr["Password"] = usuario.Password;
            dr["Nombre"] = usuario.Nombre;
            dtUsuarios.Rows.Add(dr);
            usuarioDAL.GuardarCambios();
            usuario.SetID(Convert.ToInt32(dtUsuarios.Rows[^1]["ID_Usuario"]));

            foreach (var rol in usuario.ObtenerPermisos())
            {
                DataRow rel = dtUsuarioPermiso.NewRow();
                rel["IdUsuario"] = usuario.GetID();
                rel["IdPermiso"] = rol.Id;
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
                usuarioDAL.GuardarCambios();
            }

            foreach (DataRow rel in dtUsuarioPermiso.Select($"IdUsuario = {usuario.GetID()}"))
                rel.Delete();

            foreach (var rol in usuario.ObtenerPermisos())
            {
                DataRow rel = dtUsuarioPermiso.NewRow();
                rel["IdUsuario"] = usuario.GetID();
                rel["IdPermiso"] = rol.Id;
                dtUsuarioPermiso.Rows.Add(rel);
            }

            usuarioPermisoDAL.GuardarCambios();
        }

        public void Delete(Usuario usuario)
        {
            foreach (DataRow rel in dtUsuarioPermiso.Select($"IdUsuario = {usuario.GetID()}"))
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

            Usuario u = new Usuario(id, row["Username"].ToString(), row["Password"].ToString())
            {
                Nombre = row["Nombre"].ToString()
            };

            foreach (DataRow r in dtUsuarioPermiso.Select($"IdUsuario = {id}"))
            {
                int idPermiso = Convert.ToInt32(r["IdPermiso"]);
                var permiso = ormPermiso.GetByID(idPermiso);
                if (permiso is PermisoCompuesto pc)
                    u.AgregarPermiso(pc);
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
            return dtUsuarios.Select($"Username = '{username}'").Length > 0;
        }
    }
}

