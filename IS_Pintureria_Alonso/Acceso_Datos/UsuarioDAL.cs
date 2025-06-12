using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace Acceso_Datos
{
    public class UsuarioDAL
    {
        ConexionSQL cx;
        SqlDataAdapter useradapter;
        SqlCommandBuilder cmbd;
        DataSet ds;

        public UsuarioDAL()
        {
            cx = new ConexionSQL();
            useradapter = new SqlDataAdapter("SELECT * FROM Usuario", cx.getConexion());
            cmbd = new SqlCommandBuilder(useradapter);
            ds = new DataSet();
            useradapter.InsertCommand = cmbd.GetInsertCommand();
            useradapter.UpdateCommand = cmbd.GetUpdateCommand();
            useradapter.DeleteCommand = cmbd.GetDeleteCommand();
            useradapter.Fill(ds, "Usuarios");
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };
        }
        public DataSet DevolverDS()
        {
            return this.ds;
        }
        public void GuardarCambios()
        {
            useradapter.Update(ds.Tables[0]);
        }
    }
    
}
