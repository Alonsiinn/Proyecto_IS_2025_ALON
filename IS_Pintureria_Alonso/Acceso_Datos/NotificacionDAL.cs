using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class NotificacionDAL
    {
        private ConexionSQL cx;
        private string connectionString;
        public NotificacionDAL()
        {
            cx = new ConexionSQL();
            connectionString = cx.getConexion().ConnectionString;
        }
        public int Insertar(int idUsuario, string mensaje)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertarNotificacion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@Mensaje", mensaje);
                        conn.Open();
                        // Devuelve el nuevo IdNotificacion
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
        public int Actualizar(int idNotificacion, bool? marcadaLeida, string nuevoMensaje)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarNotificacion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdNotificacion", idNotificacion);
                        cmd.Parameters.AddWithValue("@MarcadaLeida", (object)marcadaLeida ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NuevoMensaje", (object)nuevoMensaje ?? DBNull.Value);
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
        public int Eliminar(int idNotificacion)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_EliminarNotificacion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdNotificacion", idNotificacion);
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
        public DataTable ListarPorUsuario(int idUsuario, bool soloNoLeidas)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ListarNotificacionesPorUsuario", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@SoloNoLeidas", soloNoLeidas ? 1 : 0);
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
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Notificacion", conn))
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
        public DataTable ObtenerPorId(int idNotificacion)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion( ))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Notificacion WHERE IdNotificacion = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", idNotificacion);
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
