using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper;

namespace Aplicacion
{
    public class CategoriaBLL
    {
        private ORMCategoria ormCategoria;
        public CategoriaBLL()
        {
            ormCategoria = new ORMCategoria();
        }
        public void InsertarCategoria(Categoria categoria)
        {
             ormCategoria.Add(categoria);
        }
        public void ActualizarCategoria(Categoria categoria)
        {
             ormCategoria.Update(categoria);
        }
        public void EliminarCategoria(Categoria categoria)
        {
             ormCategoria.Delete(categoria);
        }
        public List<Categoria> ListarCategorias()
        {
            return ormCategoria.DevolverTodos();
        }
        public Categoria ObtenerCategoriaPorId(int idCategoria)
        {
             return ormCategoria.GetByID(idCategoria);
        }
    }
}
