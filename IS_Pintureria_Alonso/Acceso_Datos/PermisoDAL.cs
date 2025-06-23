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

        public int InsertarPermisoSP(string nombre, bool esCompuesto)
        {
            int idGenerado = 0;
            using (SqlConnection conn = cx.getConexion())
            using (SqlCommand cmd = new SqlCommand("sp_InsertarPermiso", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@EsCompuesto", esCompuesto);

                SqlParameter outParam = new SqlParameter("@IdPermiso", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                idGenerado = (int)outParam.Value;
               
            }
           
            return idGenerado;
        }

        public DataSet DevolverDS() {Recargar(); return ds;}

        public void GuardarCambios()
        {
            adapter.Update(ds.Tables["Permisos"]);
        }
        public void Recargar()
        {
            ds.Tables["Permisos"].Clear();
            adapter.Fill(ds, "Permisos");
        }
    }
}
