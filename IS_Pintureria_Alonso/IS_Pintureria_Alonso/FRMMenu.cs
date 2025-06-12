using Aplicacion;
using Servicios.Login;

namespace IS_Pintureria_Alonso
{
    public partial class FRMMenu : Form
    {
        UsuarioBLL _usuarioBLL;
        public FRMMenu()
        {
            InitializeComponent();
            ValidarForm();
        }

        private void FRMMenu_Load(object sender, EventArgs e)
        {

        }

        private void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMInicioSesion inciarSesion = new FRMInicioSesion();
            inciarSesion.MdiParent = this;
            inciarSesion.Show();
        }
        public void ValidarForm()
        {
            this.iniciarSesionToolStripMenuItem.Enabled = !SessionManager.GetInstance.IsLogged();
            this.iniciarSesionToolStripMenuItem.Visible = !SessionManager.GetInstance.IsLogged();
            this.cerrarSesionToolStripMenuItem.Enabled = SessionManager.GetInstance.IsLogged();
            this.cerrarSesionToolStripMenuItem.Visible = SessionManager.GetInstance.IsLogged();
            this.registrarseToolStripMenuItem.Enabled = !SessionManager.GetInstance.IsLogged();
            this.registrarseToolStripMenuItem.Visible = !SessionManager.GetInstance.IsLogged();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionManager.GetInstance.Logout();
            ValidarForm();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMSelectoPermiso frmSelectoPermiso = new FRMSelectoPermiso();
            frmSelectoPermiso.MdiParent = this;
            frmSelectoPermiso.Show();
        }
    }
}
