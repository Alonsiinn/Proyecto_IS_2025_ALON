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
        string conexion = "";
        public ConexionSQL()
        {
            conexion = "Data Source=ALONPC\\SQLEXPRESS;Initial Catalog=P_Ing_Sof_Alonso25;Integrated Security=True;Trust Server Certificate=True";
            //conexion = "Data Source=NANOLAPTOP\\SQLEXPRESS;Initial Catalog=P_Ing_Sof_Alonso25;Integrated Security=True;Trust Server Certificate=True";
        }
        public SqlConnection getConexion() => new SqlConnection(conexion);
    }
}
