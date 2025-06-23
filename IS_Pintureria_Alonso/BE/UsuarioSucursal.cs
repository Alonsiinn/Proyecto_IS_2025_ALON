using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioSucursal
    {
        public int IdUsuario { get; set; }
        public int IdSucursal { get; set; }
        public Usuario Usuario { get; set; }
        public Sucursal Sucursal { get; set; }
    }
}
