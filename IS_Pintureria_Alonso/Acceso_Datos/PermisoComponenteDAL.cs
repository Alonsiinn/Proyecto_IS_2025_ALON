using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class PermisoComponenteDAL
    {
        private ConexionSQL cx;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder cmbd;
        private DataSet ds;

        public PermisoComponenteDAL()
        {
            cx = new ConexionSQL();
            adapter = new SqlDataAdapter("SELECT * FROM Permiso_Componente", cx.getConexion());
            cmbd = new SqlCommandBuilder(adapter);
            ds = new DataSet();

            adapter.InsertCommand = cmbd.GetInsertCommand();
            adapter.UpdateCommand = cmbd.GetUpdateCommand();
            adapter.DeleteCommand = cmbd.GetDeleteCommand();

            adapter.Fill(ds, "PermisoComponentes");
        }

        public DataSet DevolverDS() => ds;

        public void GuardarCambios()
        {
            adapter.Update(ds.Tables["PermisoComponentes"]);
        }
    }
}
