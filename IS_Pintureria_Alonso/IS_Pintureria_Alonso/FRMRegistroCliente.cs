using Aplicacion;
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
using Servicios;
using Servicios.Seguridad;

namespace IS_Pintureria_Alonso
{
    public partial class FRMRegistroCliente : Form
    {
        FRMMenuV2 menu;
        UsuarioBLL _usuarioBLL;
        public FRMRegistroCliente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _usuarioBLL = new UsuarioBLL();
        }
        public FRMRegistroCliente(FRMMenuV2 Menu)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _usuarioBLL = new UsuarioBLL();
            menu = Menu;
            this.FormClosed += FRMRegistroCliente_FormClosed;
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                CUsuarios.ValidarCampos(out string mensajeError);
                if (!string.IsNullOrEmpty(mensajeError))
                {
                    MessageBox.Show(mensajeError, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var datos = CUsuarios.Datos();
                var user = new Usuario(0, datos[6], Encriptacion.GenerarSHA256(datos[7]), datos[0], datos[1], datos[4], datos[2], datos[3], datos[5], "CLI", Convert.ToDateTime(datos[8]));

                _usuarioBLL.RegistrarUsuario(user);
                MessageBox.Show("Registro exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _usuarioBLL.Login(datos[6], datos[7]);
                FRMMenuV2 menu = (FRMMenuV2)this.MdiParent;
                menu.ValidarForm();
                menu.Show();
                this.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrarse: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FRMRegistroCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();

        }
    }
}
