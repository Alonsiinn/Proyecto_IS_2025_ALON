using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion;

namespace IS_Pintureria_Alonso
{
    public partial class FRMSelectoPermiso : Form
    {
        private PermisoBLL permisoService;
        public IPermisoComponente Seleccionado { get; private set; } 

        public FRMSelectoPermiso()
        {
            InitializeComponent();
            permisoService = new PermisoBLL();
            CargarArbol();
        }

        public FRMSelectoPermiso(PermisoBLL permisoService) : this() 
        {
            this.permisoService = permisoService;
        }

        private void CargarArbol()
        {
            treeViewPermisos.Nodes.Clear();
            List<IPermisoComponente> permisos = permisoService.DevolverPermisosRaiz();

            foreach (var permiso in permisos)
            {
                TreeNode nodo = CrearNodoDesdePermiso(permiso);
                treeViewPermisos.Nodes.Add(nodo);
            }
            treeViewPermisos.ExpandAll();
        }

        private TreeNode CrearNodoDesdePermiso(IPermisoComponente permiso)
        {
            TreeNode nodo = new TreeNode(permiso.Nombre) { Tag = permiso };

            if (permiso is PermisoCompuesto comp)
            {
                foreach (var hijo in comp.ObtenerComponentes())
                    nodo.Nodes.Add(CrearNodoDesdePermiso(hijo));
            }

            return nodo;
        }

        private void btnCrearPermisoSimple_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            permisoService.CrearPermisoSimple(nombre);
            CargarArbol();
        }

        private void btnCrearPermisoCompuesto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreCompuesto.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            permisoService.CrearPermisoCompuesto(nombre);
            CargarArbol();
        }

        private void btnAgregarPermisoACompuesto_Click(object sender, EventArgs e)
        {
            if (treeViewPermisos.SelectedNode == null) return;

            IPermisoComponente? destino = treeViewPermisos.SelectedNode.Tag as IPermisoComponente; 
            if (destino is not PermisoCompuesto compuesto) return;

            var selector = new FRMSelectoPermiso(permisoService);
            if (selector.ShowDialog() == DialogResult.OK)
            {
                IPermisoComponente? seleccionado = selector.Seleccionado;  
                if (seleccionado != null && seleccionado.Id != compuesto.Id)
                {
                    permisoService.AgregarPermisoACompuesto(compuesto, seleccionado);
                    CargarArbol();
                }
            }
        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            if (treeViewPermisos.SelectedNode == null) return;

            IPermisoComponente? permiso = treeViewPermisos.SelectedNode.Tag as IPermisoComponente; 
            if (permiso == null) return;

            var confirm = MessageBox.Show($"Seguro que desea eliminar '{permiso.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                permisoService.EliminarPermiso(permiso);
                CargarArbol();
            }
        }

        private void btnQuitarPermisoDeCompuesto_Click(object sender, EventArgs e)
        {
            if (treeViewPermisos.SelectedNode == null || treeViewPermisos.SelectedNode.Parent == null) return;

            var padre = treeViewPermisos.SelectedNode.Parent.Tag as PermisoCompuesto;
            var hijo = treeViewPermisos.SelectedNode.Tag as IPermisoComponente;
            if (padre == null || hijo == null) return;

            permisoService.QuitarPermisoDeCompuesto(padre, hijo);
            CargarArbol();
        }

        private void FRMSelectoPermiso_Load(object sender, EventArgs e)
        {

        }
    }

}
