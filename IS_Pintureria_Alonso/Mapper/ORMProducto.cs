using Acceso_Datos;
using Dominio;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Mapper
{
    public class ORMProducto:iCrud<Producto>
    {
        private ProductoDAL productoDAL;
        public ORMProducto()
        {
            productoDAL = new ProductoDAL();
        }

        public void Add(Producto producto)
        {
            int newId = productoDAL.Insertar(producto.Nombre, producto.Descripcion, producto.Precio, producto.IdCategoria);
            if (newId > 0)
            {
                producto.IdProducto = newId;
                
            }
            
        }

        public void Delete(Producto producto)
        {
            int filas = productoDAL.Eliminar(producto.IdProducto);
        }

        public List<Producto> DevolverTodos()
        {
            DataTable dt = productoDAL.ListarTodos();
            List<Producto> productos = new List<Producto>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Determinar si el producto es una lata de pintura (tiene datos en LataPintura)
                    Producto prod;
                    if (!row.IsNull("Color"))
                    {
                        // Si la fila tiene Color, es una LataPintura
                        LataPintura lata = new LataPintura();
                        lata.Color = (string)row["Color"];
                        lata.CapacidadL = (decimal)row["CapacidadL"];
                        lata.Marca = (string)row["Marca"];
                        lata.TipoBase = row.IsNull("TipoBase") ? null : (string)row["TipoBase"];
                        prod = lata;
                    }
                    else
                    {
                        prod = new Producto();
                    }
                    // Llenar campos básicos de Producto
                    prod.IdProducto = (int)row["IdProducto"];
                    prod.Nombre = (string)row["Nombre"];
                    prod.Descripcion = row.IsNull("Descripcion") ? null : (string)row["Descripcion"];
                    prod.Precio = (decimal)row["Precio"];
                    prod.IdCategoria = (int)row["IdCategoria"];
                    // Si la consulta incluyó datos de categoría, asignar el objeto Categoria
                    if (row.Table.Columns.Contains("CatNombre"))
                    {
                        prod.Categoria = new Categoria
                        {
                            IdCategoria = prod.IdCategoria,
                            Nombre = (string)row["CatNombre"],
                            Descripcion = row.IsNull("CatDesc") ? null : (string)row["CatDesc"]
                        };
                    }
                    productos.Add(prod);
                }
            }
            return productos;
        }

        public bool Existe(string nombre)
        {
            return productoDAL.Existe(nombre);
        }

        public Producto GetByID(int idProducto)
        {
            DataTable dt = productoDAL.ObtenerPorId(idProducto);
            Producto prod = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                // Instanciar según corresponda (LataPintura o Producto base)
                if (!row.IsNull("Color"))
                {
                    LataPintura lata = new LataPintura();
                    lata.Color = (string)row["Color"];
                    lata.CapacidadL = (decimal)row["CapacidadL"];
                    lata.Marca = (string)row["Marca"];
                    lata.TipoBase = row.IsNull("TipoBase") ? null : (string)row["TipoBase"];
                    prod = lata;
                }
                else
                {
                    prod = new Producto();
                }
                // Completar campos del producto
                prod.IdProducto = (int)row["IdProducto"];
                prod.Nombre = (string)row["Nombre"];
                prod.Descripcion = row.IsNull("Descripcion") ? null : (string)row["Descripcion"];
                prod.Precio = (decimal)row["Precio"];
                prod.IdCategoria = (int)row["IdCategoria"];
                prod.Categoria = new Categoria
                {
                    IdCategoria = prod.IdCategoria,
                    Nombre = (string)row["CatNombre"],
                    Descripcion = row.IsNull("CatDesc") ? null : (string)row["CatDesc"]
                };
            }
            return prod;
        }

        public void Update(Producto producto)
        {
            int filas = productoDAL.Actualizar(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.IdCategoria);
        }
    }
}
