using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class UsuarioPermisoDAL
    {
        private ConexionSQL cx;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder builder;
        private DataSet ds;

        public UsuarioPermisoDAL()
        {
            cx = new ConexionSQL();
            adapter = new SqlDataAdapter("SELECT * FROM Usuario_Permiso", cx.getConexion());
            builder = new SqlCommandBuilder(adapter);
            ds = new DataSet();
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.Fill(ds, "UsuarioPermisos");
        }

        public DataTable GetTable() => ds.Tables["UsuarioPermisos"];

        public void GuardarCambios() => adapter.Update(ds.Tables["UsuarioPermisos"]);
    }
}

