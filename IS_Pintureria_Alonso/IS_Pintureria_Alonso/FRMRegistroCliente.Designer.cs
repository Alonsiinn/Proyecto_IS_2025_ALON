namespace IS_Pintureria_Alonso
{
    partial class FRMRegistroCliente
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
            CUsuarios = new IS_Pintureria_Alonso.ControlesUsuario.CamposUsuario();
            btnRegistrarse = new Button();
            SuspendLayout();
            // 
            // CUsuarios
            // 
            CUsuarios.Location = new Point(15, 15);
            CUsuarios.Margin = new Padding(4, 4, 4, 4);
            CUsuarios.Name = "CUsuarios";
            CUsuarios.Size = new Size(552, 621);
            CUsuarios.TabIndex = 0;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(73, 693);
            btnRegistrarse.Margin = new Padding(4, 4, 4, 4);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(442, 29);
            btnRegistrarse.TabIndex = 1;
            btnRegistrarse.Text = "Crear cuenta";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // FRMRegistroCliente
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 80, 200);
            ClientSize = new Size(594, 794);
            Controls.Add(btnRegistrarse);
            Controls.Add(CUsuarios);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FRMRegistroCliente";
            Text = "FRMRegistroCliente";
            FormClosed += FRMRegistroCliente_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private ControlesUsuario.CamposUsuario CUsuarios;
        private Button btnRegistrarse;
    }
}