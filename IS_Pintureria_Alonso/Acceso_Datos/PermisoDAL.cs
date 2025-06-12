using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class PermisoDAL
    {
        ConexionSQL cx;
        SqlDataAdapter adapter;
        SqlCommandBuilder cmbd;
        DataSet ds;

        public PermisoDAL()
        {
            cx = new ConexionSQL();
            adapter = new SqlDataAdapter("SELECT * FROM Permiso", cx.getConexion());
            cmbd = new SqlCommandBuilder(adapter);
            ds = new DataSet();

            adapter.InsertCommand = cmbd.GetInsertCommand();
            adapter.UpdateCommand = cmbd.GetUpdateCommand();
            adapter.DeleteCommand = cmbd.GetDeleteCommand();

            adapter.Fill(ds, "Permisos");
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["IdPermiso"] };
        }

        public DataSet DevolverDS() => ds;

        public void GuardarCambios()
        {
            adapter.Update(ds.Tables["Permisos"]);
        }
    }
}
