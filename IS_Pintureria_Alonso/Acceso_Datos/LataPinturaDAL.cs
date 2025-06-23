using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class LataPinturaDAL
    {
        private ConexionSQL cx;
        private string connectionString;
        public LataPinturaDAL()
        {
            cx = new ConexionSQL();
            connectionString = cx.getConexion().ConnectionString;
        }
        public int Insertar(string nombre, string descripcion, decimal precio, int idCategoria,
                             string color, decimal capacidadL, string marca, string tipoBase)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_InsertarLataPintura", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", (object)descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        cmd.Parameters.AddWithValue("@Color", color);
                        cmd.Parameters.AddWithValue("@CapacidadL", capacidadL);
                        cmd.Parameters.AddWithValue("@Marca", marca);
                        cmd.Parameters.AddWithValue("@TipoBase", (object)tipoBase ?? DBNull.Value);
                        conn.Open();
                        // Devuelve el IdProducto recién creado
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
        public int Actualizar(int idProducto, string nombre, string descripcion, decimal precio, int idCategoria,
                               string color, decimal capacidadL, string marca, string tipoBase)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarLataPintura", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", (object)descripcion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Precio", precio);
                        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                        cmd.Parameters.AddWithValue("@Color", color);
                        cmd.Parameters.AddWithValue("@CapacidadL", capacidadL);
                        cmd.Parameters.AddWithValue("@Marca", marca);
                        cmd.Parameters.AddWithValue("@TipoBase", (object)tipoBase ?? DBNull.Value);
                        conn.Open();
                        // Ejecuta ambas actualizaciones (Producto y LataPintura) dentro de la transacción del SP
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                return 0;
            }
        }
        public int Eliminar(int idProducto)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("usp_EliminarLataPintura", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
                        conn.Open();
                        // Elimina el registro en LataPintura y luego el Producto
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
                    string sql = "SELECT P.IdProducto, P.Nombre, P.Descripcion, P.Precio, P.IdCategoria," +
                                 " L.Color, L.CapacidadL, L.Marca, L.TipoBase," +
                                 " C.Nombre AS CatNombre, C.Descripcion AS CatDesc" +
                                 " FROM Producto P" +
                                 " INNER JOIN LataPintura L ON P.IdProducto = L.IdProducto" +
                                 " LEFT JOIN Categoria C ON P.IdCategoria = C.IdCategoria";
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
        public DataTable ObtenerPorId(int idProducto)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion())
                {
                    string sql = "SELECT P.IdProducto, P.Nombre, P.Descripcion, P.Precio, P.IdCategoria," +
                                 " L.Color, L.CapacidadL, L.Marca, L.TipoBase," +
                                 " C.Nombre AS CatNombre, C.Descripcion AS CatDesc" +
                                 " FROM Producto P" +
                                 " INNER JOIN LataPintura L ON P.IdProducto = L.IdProducto" +
                                 " LEFT JOIN Categoria C ON P.IdCategoria = C.IdCategoria" +
                                 " WHERE P.IdProducto = @IdProducto";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdProducto", idProducto);
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
        public bool Existe(string nombre)
        {
            try
            {
                using (SqlConnection conn = cx.getConexion( ))
                {
                    string sql = "SELECT COUNT(*) FROM Producto WHERE Nombre = @Nombre";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
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
