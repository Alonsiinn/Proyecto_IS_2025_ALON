using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class StockDAL
    {
        private ConexionSQL cx;
        private string connectionString;
        public StockDAL()
        {
            cx = new ConexionSQL();
            connectionString = cx.getConexion().ToString();
        }
        public int Insertar(int idSucursal, int idProducto, int cantidad)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertarStock", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return 0;
            }
        }
        public int Actualizar(int idSucursal, int idProducto, int nuevaCantidad)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarStock", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.Parameters.AddWithValue("@NuevaCantidad", nuevaCantidad);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return 0;
            }
        }
        public int Eliminar(int idSucursal, int idProducto)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_EliminarStock", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return 0;
            }
        }
        public DataTable ListarTodos()
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Stock", conn))
                    {
                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public DataTable ListarPorSucursal(int idSucursal)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ListarProductosPorSucursal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
                        conn.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                        return dt;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
