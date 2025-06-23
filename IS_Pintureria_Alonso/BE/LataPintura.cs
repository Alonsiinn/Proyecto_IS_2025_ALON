using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LataPintura : Producto
    {
        public string Color { get; set; }
        public decimal CapacidadL { get; set; }
        public string Marca { get; set; }
        public string TipoBase { get; set; }
    }
}
