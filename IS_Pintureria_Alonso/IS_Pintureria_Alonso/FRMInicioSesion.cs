using Aplicacion;
using Dominio;
using Servicios;
using Servicios.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace IS_Pintureria_Alonso
{
    public partial class FRMInicioSesion : Form
    {
        FRMMenuV2 menu;
        UsuarioBLL _usuarioBLL;
        public FRMInicioSesion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _usuarioBLL = new UsuarioBLL();
            
        }

        public FRMInicioSesion(FRMMenuV2 Menu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _usuarioBLL = new UsuarioBLL();
            menu = Menu;
        }

        private void FRMInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            try
            {
                _usuarioBLL.Login(txtUsuario.Text, txtContrasena.Text);
                menu.ValidarForm();
                menu.Show();


                this.Close();

            }
            catch (LoginException ex)
            {
                switch (ex.Result)
                {
                    case LoginResult.UsuarioNoEncontrado:
                        MessageBox.Show("Usuario no encontrado");
                        break;
                    case LoginResult.CredencialesInvalidas:
                        MessageBox.Show("Contraseña incorrecta");
                        break;
                    case LoginResult.CuentaBloqueada:
                        MessageBox.Show("Usuario bloqueado");
                        break;
                    case LoginResult.CuentaAbierta:
                        MessageBox.Show("Cuenta abierta, no puede iniciar sesión");
                        break;
                    default:
                        MessageBox.Show("Error desconocido");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /* try
             {
                 SessionManager.GetInstance.Login(user);
                 this.Hide();
                 FRMMenu menu = new FRMMenu();
                 menu.ShowDialog();
                 this.Close();
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FRMRegistroCliente fRMRegistroCliente = new FRMRegistroCliente(menu);
            fRMRegistroCliente.Show();
            this.Hide();
        }

        private void FRMInicioSesion_FormClosed(object sender, FormClosedEventArgs e)
        {
            
         
        }
    }
}
