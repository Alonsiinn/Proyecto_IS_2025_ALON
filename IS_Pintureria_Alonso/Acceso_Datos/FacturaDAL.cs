using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class FacturaDAL
    {
        private ConexionSQL cx;
        private string connectionString;
        public FacturaDAL()
        {
            cx = new ConexionSQL();
            connectionString = cx.getConexion().ConnectionString;
        }
        public int Insertar(int idPedido, decimal montoTotal)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertarFactura", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmd.Parameters.AddWithValue("@MontoTotal", montoTotal);
                        conn.Open();
                        // Devuelve SCOPE_IDENTITY() del nuevo IdFactura
                        object result = cmd.ExecuteScalar();
                        return (result != null) ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }
        public int Actualizar(int idFactura, decimal nuevoMontoTotal)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarFactura", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdFactura", idFactura);
                        cmd.Parameters.AddWithValue("@NuevoMontoTotal", nuevoMontoTotal);
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
        public int Eliminar(int idFactura)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_EliminarFactura", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdFactura", idFactura);
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
        public DataTable ListarPorUsuario(int idUsuario)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ListarFacturasPorUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Usuario", idUsuario);
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
        public DataTable ListarTodas()
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    string sql = "SELECT F.IdFactura, F.IdPedido, F.Fecha, F.MontoTotal," +
                                 " P.Fecha AS FechaPedido, P.Total AS TotalPedido," +
                                 " U.Nombre AS NombreUsuario" +
                                 " FROM Factura F" +
                                 " JOIN Pedido P ON F.IdPedido = P.IdPedido" +
                                 " JOIN Usuario U ON P.ID_Usuario = U.ID_Usuario";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
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
        public DataTable ObtenerPorPedido(int idPedido)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion( ))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ObtenerFacturaPorPedido", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
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

