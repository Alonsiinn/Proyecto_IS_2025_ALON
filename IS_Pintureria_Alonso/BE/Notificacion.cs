using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Notificacion
    {
        public int IdNotificacion { get; set; }
        public int IdUsuario { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Leida { get; set; }
        public Usuario Usuario { get; set; }
    }
}
