using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Servicios;
using Servicios.Login;
using Aplicacion;

namespace IS_Pintureria_Alonso
{
    public partial class FRMInicioSesion : Form
    {
        UsuarioBLL _usuarioBLL;
        public FRMInicioSesion()
        {
            InitializeComponent();
            _usuarioBLL = new UsuarioBLL();   
        }

        private void FRMInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            try 
            { 
            var user = _usuarioBLL.Login(txtUsuario.Text, txtContrasena.Text);
            FRMMenu menu = (FRMMenu)this.MdiParent;
            menu.ValidarForm();
                //menu.ShowDialog();
            
            this.Close();
        
            }
            catch(LoginException ex)
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
    }
}
