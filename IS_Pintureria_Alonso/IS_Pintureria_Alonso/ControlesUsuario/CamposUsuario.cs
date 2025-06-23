using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion;
using Servicios;
using Servicios.Seguridad;

namespace IS_Pintureria_Alonso.ControlesUsuario
{
    public partial class CamposUsuario : UserControl
    {
      
        UsuarioBLL usuariobll;
        public CamposUsuario()
        {
            InitializeComponent();
            usuariobll = new UsuarioBLL();
            foreach (var txt in new[] { txtNombre, txtApellido, txtDni, txtTelefono, txtEmail, txtDireccionFiscal, txtUsername, txtPassword })
            {
                txt.TextChanged += (s, e) => Estado();
            }
            dtpFechaNacimiento.ValueChanged += (s, e) => Estado();

 
        }
        public bool ValidarCampos(out string mensaje)
        {
            mensaje = "";
            foreach (TextBox txt in new[]
            {
                txtNombre,txtApellido,txtDni,txtTelefono,txtEmail,txtDireccionFiscal,txtUsername,txtPassword
            })
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    mensaje = "Todos los campos deben estar completos.";
                    return false;
                }

                if (txt.Text.Length > 100)
                {
                    mensaje = $"El campo '{txt.Name}' supera los 100 caracteres.";
                    return false;
                }

                if (!EsEntradaSegura(txt.Text))
                {
                    mensaje = $"El campo '{txt.Name}' contiene caracteres inválidos.";
                    return false;
                }

            }
            if (txtTelefono.Text.Length > 13)
            {
                mensaje = "El teléfono no puede superar los 13 caracteres.";
                return false;
            }

            if (!Regex.IsMatch(txtTelefono.Text, @"^\d{1,13}$"))
            {
                mensaje = "El teléfono solo puede contener números.";
                return false;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                mensaje = "El formato del email es inválido.";
                return false;
            }

            return true;
        }
        private bool EsEntradaSegura(string input)
        {
            try
            {
                string patronInseguro = @"('|;|--|\b(OR|AND)\b\s+\w+\s*=\s*\w+|/\*|\*/|xp_)";
                return !Regex.IsMatch(input, patronInseguro, RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                return false; // Si ocurre un error en la validación, consideramos que la entrada  es segura.
            }
        }

        public void LimpiarCampos()
        {
            foreach (TextBox txt in new[]
            {
                txtNombre,txtApellido,txtDni,txtTelefono,txtEmail,txtDireccionFiscal,txtUsername,txtPassword
            })
            {
                txt.Clear();
            }
        }

        public bool ValidarUsuario()
        {
            var validar = txtUsername.Text;
            return !usuariobll.DelvoverTodos().All(x => x.Username != validar);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (!ValidarUsuario())
            {
                lblDisponibilidadUsuario.ForeColor = Color.Green;
            }
            else
            {
                lblDisponibilidadUsuario.ForeColor = Color.Red;
            }
        }

        public bool ValidarContrasena()
        {
            var validar = txtPassword.Text;
            return validar.Length >= 8 && Regex.IsMatch(validar, @"[A-Z]") && Regex.IsMatch(validar, @"[a-z]") &&
                   Regex.IsMatch(validar, @"\d") && Regex.IsMatch(validar, @"[\W_]");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (ValidarContrasena())
            {
                lblSeguridadContrasena.ForeColor = Color.Green;
            }
            else
            {
                lblSeguridadContrasena.ForeColor = Color.Red;
            }
        }

        public void Estado()
        {
            if (ValidarCampos(out string vacio) && !ValidarUsuario() && ValidarContrasena())
            {
                lblEstadoFormulario.ForeColor = Color.Green;
            }
            else
            {
                lblEstadoFormulario.ForeColor = Color.Red;
            }
        }

        public string[] Datos()
        {
            return new string[] {
                txtNombre.Text.Trim(),
                txtApellido.Text.Trim(),
                txtDni.Text.Trim(),
                txtTelefono.Text.Trim(),
                txtEmail.Text.Trim(),
                txtDireccionFiscal.Text.Trim(),
                txtUsername.Text.Trim(),
                txtPassword.Text.Trim(),
                dtpFechaNacimiento.Value.ToString("yyyy-MM-dd")
            };
        }

 

    }
}
