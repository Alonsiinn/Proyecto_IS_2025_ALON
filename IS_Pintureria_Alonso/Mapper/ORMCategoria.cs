using Dominio;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 using Acceso_Datos;
namespace Mapper
{
    public class ORMCategoria:iCrud<Categoria>
    {
        private CategoriaDAL categoriaDAL;
        public ORMCategoria()
        {
            categoriaDAL = new CategoriaDAL();
        }

        public void Add(Categoria categoria)
        {
            int newId = categoriaDAL.Insertar(categoria.Nombre, categoria.Descripcion);
            if (newId > 0)
            {
                categoria.IdCategoria = newId;
                
            }
        }

        public void Delete(Categoria categoria)
        {
            int filas = categoriaDAL.Eliminar(categoria.IdCategoria);
        }

        public List<Categoria> DevolverTodos()
        {
            DataTable dt = categoriaDAL.ListarTodas();
            List<Categoria> categorias = new List<Categoria>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Categoria cat = new Categoria();
                    cat.IdCategoria = (int)row["IdCategoria"];
                    cat.Nombre = (string)row["Nombre"];
                    cat.Descripcion = row.IsNull("Descripcion") ? null : (string)row["Descripcion"];
                    categorias.Add(cat);
                }
            }
            return categorias;
        }

        public bool Existe(string nombre)
        {
            return categoriaDAL.Existe(nombre);
        }

        public Categoria GetByID(int idCategoria)
        {
            DataTable dt = categoriaDAL.ObtenerPorId(idCategoria);
            Categoria cat = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cat = new Categoria();
                cat.IdCategoria = (int)row["IdCategoria"];
                cat.Nombre = (string)row["Nombre"];
                cat.Descripcion = row.IsNull("Descripcion") ? null : (string)row["Descripcion"];
            }
            return cat;
        }

        public void Update(Categoria categoria)
        {
            categoriaDAL.Actualizar(categoria.IdCategoria, categoria.Nombre, categoria.Descripcion);
        }
    }
}
