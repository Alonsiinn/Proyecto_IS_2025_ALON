namespace IS_Pintureria_Alonso.ControlesUsuario
{
    partial class CamposUsuario
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtEmail = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtDireccionFiscal = new TextBox();
            txtTelefono = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            lblNombre = new Label();
            lblApellido = new Label();
            lblFechaNacimiento = new Label();
            lblDNI = new Label();
            lblTelefono = new Label();
            lblEmail = new Label();
            lblDireccionFiscal = new Label();
            lblUsuario = new Label();
            lblDisponibilidadUsuario = new Label();
            lblContrasena = new Label();
            lblSeguridadContrasena = new Label();
            lblEstadoFormulario = new Label();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 39);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(192, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(227, 39);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(192, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(12, 153);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(192, 23);
            txtDni.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 205);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(407, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(12, 344);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(192, 23);
            txtUsername.TabIndex = 4;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 413);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(192, 23);
            txtPassword.TabIndex = 5;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // txtDireccionFiscal
            // 
            txtDireccionFiscal.Location = new Point(12, 250);
            txtDireccionFiscal.Name = "txtDireccionFiscal";
            txtDireccionFiscal.Size = new Size(192, 23);
            txtDireccionFiscal.TabIndex = 6;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(227, 153);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(192, 23);
            txtTelefono.TabIndex = 7;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(12, 98);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(237, 23);
            dtpFechaNacimiento.TabIndex = 8;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 21);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(227, 21);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 10;
            lblApellido.Text = "Apellido";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(12, 80);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(119, 15);
            lblFechaNacimiento.TabIndex = 11;
            lblFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Location = new Point(12, 135);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(27, 15);
            lblDNI.TabIndex = 12;
            lblDNI.Text = "DNI";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(227, 135);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(53, 15);
            lblTelefono.TabIndex = 13;
            lblTelefono.Text = "Telefono";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 187);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 14;
            lblEmail.Text = "Email";
            // 
            // lblDireccionFiscal
            // 
            lblDireccionFiscal.AutoSize = true;
            lblDireccionFiscal.Location = new Point(12, 232);
            lblDireccionFiscal.Name = "lblDireccionFiscal";
            lblDireccionFiscal.Size = new Size(89, 15);
            lblDireccionFiscal.TabIndex = 15;
            lblDireccionFiscal.Text = "Direccion Fiscal";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(12, 326);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(110, 15);
            lblUsuario.TabIndex = 16;
            lblUsuario.Text = "Nombre de Usuario";
            // 
            // lblDisponibilidadUsuario
            // 
            lblDisponibilidadUsuario.AutoSize = true;
            lblDisponibilidadUsuario.Location = new Point(210, 352);
            lblDisponibilidadUsuario.Name = "lblDisponibilidadUsuario";
            lblDisponibilidadUsuario.Size = new Size(83, 15);
            lblDisponibilidadUsuario.TabIndex = 17;
            lblDisponibilidadUsuario.Text = "Disponibilidad";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(12, 395);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(67, 15);
            lblContrasena.TabIndex = 18;
            lblContrasena.Text = "Contraseña";
            // 
            // lblSeguridadContrasena
            // 
            lblSeguridadContrasena.AutoSize = true;
            lblSeguridadContrasena.Location = new Point(210, 421);
            lblSeguridadContrasena.Name = "lblSeguridadContrasena";
            lblSeguridadContrasena.Size = new Size(60, 15);
            lblSeguridadContrasena.TabIndex = 19;
            lblSeguridadContrasena.Text = "Seguridad";
            // 
            // lblEstadoFormulario
            // 
            lblEstadoFormulario.AutoSize = true;
            lblEstadoFormulario.Location = new Point(12, 453);
            lblEstadoFormulario.Name = "lblEstadoFormulario";
            lblEstadoFormulario.Size = new Size(42, 15);
            lblEstadoFormulario.TabIndex = 20;
            lblEstadoFormulario.Text = "Estado";
            // 
            // CamposUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblEstadoFormulario);
            Controls.Add(lblSeguridadContrasena);
            Controls.Add(lblContrasena);
            Controls.Add(lblDisponibilidadUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblDireccionFiscal);
            Controls.Add(lblEmail);
            Controls.Add(lblTelefono);
            Controls.Add(lblDNI);
            Controls.Add(lblFechaNacimiento);
            Controls.Add(lblApellido);
            Controls.Add(lblNombre);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccionFiscal);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtEmail);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Name = "CamposUsuario";
            Size = new Size(429, 490);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtEmail;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtDireccionFiscal;
        private TextBox txtTelefono;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblFechaNacimiento;
        private Label lblDNI;
        private Label lblTelefono;
        private Label lblEmail;
        private Label lblDireccionFiscal;
        private Label lblUsuario;
        private Label lblDisponibilidadUsuario;
        private Label lblContrasena;
        private Label lblSeguridadContrasena;
        private Label lblEstadoFormulario;
    }
}
