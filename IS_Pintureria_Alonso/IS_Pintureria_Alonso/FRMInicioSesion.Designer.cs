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
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(53, 100);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(184, 47);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar Sesion";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click_1;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(12, 26);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(265, 23);
            txtUsuario.TabIndex = 1;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(12, 71);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(265, 23);
            txtContrasena.TabIndex = 2;
            // 
            // FRMInicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 189);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(btnIniciar);
            Name = "FRMInicioSesion";
            Text = "Iniciar Sesion";
            Load += FRMInicioSesion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciar;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
    }
}