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
        public int InsertarUsuarioSP(string username, string password, string nombre, string apellido, string email,
                              DateTime fechaNacimiento, string telefono, string direccionFiscal, string dni, string tipoUsuario)
        {
            int idGenerado = 0;
            using (SqlConnection conn = cx.getConexion())
            using (SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@DireccionFiscal", direccionFiscal);
                cmd.Parameters.AddWithValue("@DNI", dni);
                cmd.Parameters.AddWithValue("@TipoUsuario", tipoUsuario);

                SqlParameter outParam = new SqlParameter("@IdUsuario", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(outParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                idGenerado = (int)outParam.Value;
            
            }
            return idGenerado;
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
