using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    internal class ConexionSQL
    {
        private static readonly string cadena = "Data Source=ALONPC\\SQLEXPRESS;Initial Catalog=P_Ing_Sof_Alonso25;Integrated Security=True;Trust Server Certificate=True";
        public ConexionSQL()
        {

        }
        public SqlConnection getConexion() => new SqlConnection(cadena);
        public SqlConnection DevolverConexion()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
    }
}
