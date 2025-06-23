namespace IS_Pintureria_Alonso
{
    partial class FRMInicioSesion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIniciar = new Button();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnRegistrarse = new Button();
            lblUsuario = new Label();
            lblContrasena = new Label();
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(27, 289);
            btnIniciar.Margin = new Padding(4);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(136, 60);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar Sesion";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click_1;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(27, 94);
            txtUsuario.Margin = new Padding(4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(340, 27);
            txtUsuario.TabIndex = 1;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(27, 206);
            txtContrasena.Margin = new Padding(4);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(340, 27);
            txtContrasena.TabIndex = 2;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(231, 289);
            btnRegistrarse.Margin = new Padding(4);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(136, 60);
            btnRegistrarse.TabIndex = 3;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(26, 65);
            lblUsuario.Margin = new Padding(4, 0, 4, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(65, 19);
            lblUsuario.TabIndex = 4;
            lblUsuario.Text = "Usuario";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(26, 184);
            lblContrasena.Margin = new Padding(4, 0, 4, 0);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(98, 19);
            lblContrasena.TabIndex = 5;
            lblContrasena.Text = "Contraseña";
            // 
            // FRMInicioSesion
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 80, 200);
            ClientSize = new Size(406, 388);
            Controls.Add(lblContrasena);
            Controls.Add(lblUsuario);
            Controls.Add(btnRegistrarse);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(btnIniciar);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FRMInicioSesion";
            Text = "Iniciar Sesion";
            FormClosed += FRMInicioSesion_FormClosed;
            Load += FRMInicioSesion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciar;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnRegistrarse;
        private Label lblUsuario;
        private Label lblContrasena;
    }
}