using Aplicacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Pintureria_Alonso
{
    public partial class FRMRegistroUsuarioADM : Form
    {
        PermisoBLL permisoService;
        public FRMRegistroUsuarioADM()
        {
            InitializeComponent();
            permisoService = new PermisoBLL();
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarRoles();
        }

        public void CargarRoles()
        {
            foreach (var permiso in permisoService.DevolverPermisosRaiz())
            {
                if (permiso is Dominio.PermisoCompuesto)
                {
                    cmbRol.Items.Add(permiso.Nombre);
                }
            }
        }
    }
}
