using Servicios.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace IS_Pintureria_Alonso
{
    public partial class FRMMenuV2 : Form
    {
        public FRMMenuV2()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void BarraTitutlo_Paint(object sender, PaintEventArgs e)
        {


        }

        private void BarraTitutlo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            FRMInicioSesion frmInicioSesion = new FRMInicioSesion(this);

            frmInicioSesion.FormClosed += (s, args) => this.Show();
            this.Hide();
            frmInicioSesion.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SessionManager.GetInstance.Logout();
            ValidarForm();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FRMRegistroCliente frmRegistroCliente = new FRMRegistroCliente(this);
            frmRegistroCliente.FormClosed += (s, args) => this.Show();
            this.Hide();
            frmRegistroCliente.Show();
        }

        private void btnPermisos_Click(object sender, EventArgs e)
        {
            FRMSelectoPermiso frmSelectoPermiso = new FRMSelectoPermiso();
            frmSelectoPermiso.FormClosed += (s, args) => this.Show();
            this.Hide();
            frmSelectoPermiso.Show();
        }

        public void ValidarForm()
        {
            
            this.btnIniciarSesion.Enabled = !SessionManager.GetInstance.IsLogged();
            this.btnIniciarSesion.Visible = !SessionManager.GetInstance.IsLogged();
            this.btnCerrarSesion.Enabled = SessionManager.GetInstance.IsLogged();
            this.btnCerrarSesion.Visible = SessionManager.GetInstance.IsLogged();
            this.btnRegistrarse.Enabled = !SessionManager.GetInstance.IsLogged();
            this.btnRegistrarse.Visible = !SessionManager.GetInstance.IsLogged();
            this.panel7.Visible = !SessionManager.GetInstance.IsLogged();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            FRMRegistroUsuarioADM frmRegistroUsuarioADM = new FRMRegistroUsuarioADM();
            frmRegistroUsuarioADM.FormClosed += (s, args) => this.Show();
            this.Hide();
            frmRegistroUsuarioADM.Show();
        }

        private void btnIdentificarColor_Click(object sender, EventArgs e)
        {
            FRMDetectarColor frmDetectarColor = new FRMDetectarColor();
            frmDetectarColor.FormClosed += (s, args) => this.Show();
            this.Hide();
            frmDetectarColor.Show();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            FRMCatalogoPedido frmCatalogoPedido = new FRMCatalogoPedido();
            frmCatalogoPedido.FormClosed += (s, args) => this.Show();
            this.Hide();
            frmCatalogoPedido.Show();
        }
    }
}
