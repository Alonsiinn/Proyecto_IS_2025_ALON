namespace IS_Pintureria_Alonso
{
    partial class FRMRegistroUsuarioADM
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
            camposUsuario1 = new IS_Pintureria_Alonso.ControlesUsuario.CamposUsuario();
            cmbRol = new ComboBox();
            lblRol = new Label();
            SuspendLayout();
            // 
            // camposUsuario1
            // 
            camposUsuario1.Location = new Point(15, 15);
            camposUsuario1.Margin = new Padding(4, 4, 4, 4);
            camposUsuario1.Name = "camposUsuario1";
            camposUsuario1.Size = new Size(552, 621);
            camposUsuario1.TabIndex = 0;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(575, 64);
            cmbRol.Margin = new Padding(4, 4, 4, 4);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(154, 27);
            cmbRol.TabIndex = 1;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(575, 42);
            lblRol.Margin = new Padding(4, 0, 4, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(32, 19);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol";
            // 
            // FRMRegistroUsuarioADM
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 80, 200);
            ClientSize = new Size(770, 639);
            Controls.Add(lblRol);
            Controls.Add(cmbRol);
            Controls.Add(camposUsuario1);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FRMRegistroUsuarioADM";
            Text = "FRMRegistroUsuarioADM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ControlesUsuario.CamposUsuario camposUsuario1;
        private ComboBox cmbRol;
        private Label lblRol;
    }
}