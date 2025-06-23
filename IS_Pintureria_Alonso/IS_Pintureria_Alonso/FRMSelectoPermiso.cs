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
            public IPermisoComponente Compuesto { get; private set; }

        FRMMenuV2 menuV2;
        public FRMSelectoPermiso()
            {
                InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            permisoService = new PermisoBLL();
                CargarArbol();
                treeViewPermisos.AfterSelect += treeViewPermisos_AfterSelect;
                treeViewCompuesto.AfterSelect += treeViewCompuesto_AfterSelect;
            }

        public FRMSelectoPermiso(FRMMenuV2 menu)
        {
            InitializeComponent();
            this.menuV2 = menu;
            this.StartPosition = FormStartPosition.CenterScreen;
            permisoService = new PermisoBLL();
            CargarArbol();
            treeViewPermisos.AfterSelect += treeViewPermisos_AfterSelect;
            treeViewCompuesto.AfterSelect += treeViewCompuesto_AfterSelect;
        }

        public FRMSelectoPermiso(PermisoBLL permisoService) : this()
            {
                this.permisoService = permisoService;
            }

            private void CargarArbol()
            {
                treeViewPermisos.Nodes.Clear();
                List<IPermisoComponente> permisos = permisoService.DevolverPermisos();
                foreach (var permiso in permisos)
                {
                    TreeNode nodo = CrearNodoDesdePermiso(permiso);
                    treeViewPermisos.Nodes.Add(nodo);
                }
                treeViewPermisos.ExpandAll();

                treeViewCompuesto.Nodes.Clear();
                List<IPermisoComponente> pcompuesto = permisoService.DevolverPermisosRaiz();
                foreach (var permiso in pcompuesto)
                {
                    TreeNode nodo = CrearNodoDesdePermiso(permiso);
                    treeViewCompuesto.Nodes.Add(nodo);
                }
              
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
                txtNombrePermiso.Clear();
        }

            private void btnCrearPermisoCompuesto_Click(object sender, EventArgs e)
            {
                string nombre = txtNombreCompuesto.Text.Trim();
                if (string.IsNullOrEmpty(nombre)) return;

                permisoService.CrearPermisoCompuesto(nombre);
                CargarArbol();
                txtNombreCompuesto.Clear();
        }

            private void btnAgregarPermisoACompuesto_Click(object sender, EventArgs e)
            {
                if (Seleccionado == null || Compuesto == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso y un permiso compuesto.");
                    return;
                }

                if (Seleccionado.Id == Compuesto.Id)
                {
                    MessageBox.Show("No se puede agregar un permiso a sí mismo.");
                    return;
                }

                if (EsHijo(Seleccionado, Compuesto))
                {
                    MessageBox.Show("El permiso ya forma parte de la jerarquía del compuesto.");
                    return;
                }

                if (Compuesto is PermisoCompuesto permisoCompuesto)
                {
                    permisoService.AgregarPermisoACompuesto(permisoCompuesto, Seleccionado);
                    CargarArbol();
                    RestaurarSeleccion(treeViewCompuesto, Compuesto);
                }
            }

            private void btnEliminarPermiso_Click(object sender, EventArgs e)
            {
                if (Seleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso para eliminar.");
                    return;
                }

                var confirm = MessageBox.Show($"¿Seguro que desea eliminar '{Seleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    permisoService.EliminarPermiso(Seleccionado);
                    CargarArbol();
                }
            }

            private void btnQuitarPermisoDeCompuesto_Click(object sender, EventArgs e)
            {
                if (treeViewCompuesto.SelectedNode == null || treeViewCompuesto.SelectedNode.Parent == null)
                {
                    MessageBox.Show("Debe seleccionar un permiso dentro de un compuesto.");
                    return;
                }

                var padre = treeViewCompuesto.SelectedNode.Parent.Tag as PermisoCompuesto;
                var hijo = treeViewCompuesto.SelectedNode.Tag as IPermisoComponente;

                if (padre == null || hijo == null) return;

                permisoService.QuitarPermisoDeCompuesto(padre, hijo);
                CargarArbol();
                RestaurarSeleccion(treeViewCompuesto, padre);
            }

            private void treeViewPermisos_AfterSelect(object sender, TreeViewEventArgs e)
            {
                Seleccionado = treeViewPermisos.SelectedNode?.Tag as IPermisoComponente;
            }

            private void treeViewCompuesto_AfterSelect(object sender, TreeViewEventArgs e)
            {
                Compuesto = treeViewCompuesto.SelectedNode?.Tag as IPermisoComponente;
            }

            private void RestaurarSeleccion(TreeView treeView, IPermisoComponente permisoSeleccionado)
            {
                foreach (TreeNode nodo in treeView.Nodes)
                {
                    if (RestaurarSeleccionRecursivo(nodo, permisoSeleccionado))
                    {
                        return;
                    }
                }
            }

            private bool RestaurarSeleccionRecursivo(TreeNode nodo, IPermisoComponente permisoSeleccionado)
            {
                if (nodo.Tag is IPermisoComponente permiso && permiso.Id == permisoSeleccionado.Id)
                {
                    nodo.TreeView.SelectedNode = nodo;
                    return true;
                }

                foreach (TreeNode hijo in nodo.Nodes)
                {
                    if (RestaurarSeleccionRecursivo(hijo, permisoSeleccionado))
                    {
                        return true;
                    }
                }

                return false;
            }

            private bool EsHijo(IPermisoComponente padre, IPermisoComponente posibleHijo)
            {
                if (padre is PermisoCompuesto compuesto)
                {
                    foreach (var hijo in compuesto.ObtenerComponentes())
                    {
                        if (hijo.Id == posibleHijo.Id)
                            return true;

                        if (EsHijo(hijo, posibleHijo))
                            return true;
                    }
                }
                return false;
            }
        }
    }
    
