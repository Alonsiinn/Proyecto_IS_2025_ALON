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
    public class ORMLataPintura : iCrud<LataPintura>
    {
        private LataPinturaDAL lataPinturaDAL;
        public ORMLataPintura()
        {
            lataPinturaDAL = new LataPinturaDAL();
        }
        public void Add(LataPintura lata)
        {
            int newId = lataPinturaDAL.Insertar(lata.Nombre, lata.Descripcion, lata.Precio, lata.IdCategoria,
                                     lata.Color, lata.CapacidadL, lata.Marca, lata.TipoBase);
            if (newId > 0)
            {
                lata.IdProducto = newId;
                
            }
        }

        public void Delete(LataPintura lata)
        {
            lataPinturaDAL.Eliminar(lata.IdProducto);
            
        }

        public List<LataPintura> DevolverTodos()
        {
            DataTable dt = lataPinturaDAL.ListarTodas();
            List<LataPintura> latas = new List<LataPintura>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    LataPintura lata = new LataPintura();
                    lata.IdProducto = (int)row["IdProducto"];
                    lata.Nombre = (string)row["Nombre"];
                    lata.Descripcion = row.IsNull("Descripcion") ? null : (string)row["Descripcion"];
                    lata.Precio = (decimal)row["Precio"];
                    lata.IdCategoria = (int)row["IdCategoria"];
                    // Datos específicos de LataPintura
                    lata.Color = (string)row["Color"];
                    lata.CapacidadL = (decimal)row["CapacidadL"];
                    lata.Marca = (string)row["Marca"];
                    lata.TipoBase = row.IsNull("TipoBase") ? null : (string)row["TipoBase"];
                    // Asignar categoría si está presente en la consulta
                    if (row.Table.Columns.Contains("CatNombre"))
                    {
                        lata.Categoria = new Categoria
                        {
                            IdCategoria = lata.IdCategoria,
                            Nombre = (string)row["CatNombre"],
                            Descripcion = row.IsNull("CatDesc") ? null : (string)row["CatDesc"]
                        };
                    }
                    latas.Add(lata);
                }
            }
            return latas;
        }

        public bool Existe(string nombre)
        {
           
            return lataPinturaDAL.Existe(nombre);
        }

        public LataPintura GetByID(int id)
        {
            DataTable datos = lataPinturaDAL.ObtenerPorId(id);
            LataPintura prod = new LataPintura()
            {
                IdProducto = (int)datos.Rows[0]["IdProducto"],
                Nombre = (string)datos.Rows[0]["Nombre"],
                Descripcion = datos.Rows[0].IsNull("Descripcion") ? null : (string)datos.Rows[0]["Descripcion"],
                Precio = (decimal)datos.Rows[0]["Precio"],
                IdCategoria = (int)datos.Rows[0]["IdCategoria"],
                Color = (string)datos.Rows[0]["Color"],
                CapacidadL = (decimal)datos.Rows[0]["CapacidadL"],
                Marca = (string)datos.Rows[0]["Marca"],
                TipoBase = datos.Rows[0].IsNull("TipoBase") ? null : (string)datos.Rows[0]["TipoBase"],
                Categoria = new Categoria
                {
                    IdCategoria = (int)datos.Rows[0]["IdCategoria"],
                    Nombre = datos.Rows[0].IsNull("CatNombre") ? null : (string)datos.Rows[0]["CatNombre"],
                    Descripcion = datos.Rows[0].IsNull("CatDesc") ? null : (string)datos.Rows[0]["CatDesc"]
                }

            };


            return prod as LataPintura;
        }

        public void Update(LataPintura lata)
        {
            lataPinturaDAL.Actualizar(lata.IdProducto, lata.Nombre, lata.Descripcion, lata.Precio, lata.IdCategoria,
                                        lata.Color, lata.CapacidadL, lata.Marca, lata.TipoBase);
        }
    }
}
