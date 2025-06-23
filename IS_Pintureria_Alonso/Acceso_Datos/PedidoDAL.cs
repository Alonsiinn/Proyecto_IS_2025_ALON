using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class PedidoDAL
    {
        private ConexionSQL cx;
        private string connectionString;
        public PedidoDAL()
        {
            cx = new ConexionSQL();
            connectionString = cx.getConexion().ConnectionString;
        }
        public int Insertar(int idUsuario, decimal total, byte estado)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion( ))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertarPedido", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.Parameters.AddWithValue("@Estado", estado);
                        conn.Open();
                        // SP inserta con fecha actual y devuelve el nuevo Id
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
        public int Actualizar(int idPedido, decimal nuevoTotal, byte nuevoEstado)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarPedido", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmd.Parameters.AddWithValue("@NuevoTotal", nuevoTotal);
                        cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@NuevoIdUsuario", DBNull.Value);
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
        public int Eliminar(int idPedido)
        {
            try
            {
                using (SqlConnection conn =     cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_EliminarPedido", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
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
                    string sql = "SELECT P.IdPedido, P.ID_Usuario, P.Fecha, P.Total, P.Estado," +
                                 " U.Nombre AS NombreUsuario, U.Apellido AS ApellidoUsuario" +
                                 " FROM Pedido P JOIN Usuario U ON P.ID_Usuario = U.ID_Usuario";
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
        public DataTable ListarPorUsuario(int idUsuario)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ListarPedidosPorCliente", conn))
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
        public DataTable ObtenerPorId(int idPedido)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pedido WHERE IdPedido = @IdPedido", conn))
                    {
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
        public bool Existe(int idPedido)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion( ))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Pedido WHERE IdPedido = @IdPedido", conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
