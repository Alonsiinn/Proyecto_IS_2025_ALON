using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class SucursalDAL
    {
        private ConexionSQL cx;

        public SucursalDAL()
        {
            cx = new ConexionSQL();

        }
        public int Insertar(string nombre, string direccion, string ciudad)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertarSucursal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@Ciudad", ciudad);
                        conn.Open();
                        // Devuelve el nuevo IdSucursal
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
        public int Actualizar(int idSucursal, string nombre, string direccion, string ciudad)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarSucursal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@Ciudad", ciudad);
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
        public int Eliminar(int idSucursal)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_EliminarSucursal", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSucursal", idSucursal);
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
        public DataTable ListarTodas()
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sucursal", conn))
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
        public DataTable ObtenerPorId(int idSucursal)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sucursal WHERE IdSucursal = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", idSucursal);
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
        public int DevolverIDPorNombre(string nombreSucursal)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT IdSucursal FROM Sucursal WHERE Nombre = @Nombre", conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombreSucursal);
                        conn.Open();
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
    }
}

