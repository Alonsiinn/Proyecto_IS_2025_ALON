namespace IS_Pintureria_Alonso
{
    partial class FRMDetectarColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMDetectarColor));
            btnCargarImagen = new Button();
            pictureBoxImagen = new PictureBox();
            lblColorARGB = new Label();
            lblNombreColor = new Label();
            panelVistaColor = new Panel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCargarImagen
            // 
            btnCargarImagen.Location = new Point(15, 365);
            btnCargarImagen.Margin = new Padding(4);
            btnCargarImagen.Name = "btnCargarImagen";
            btnCargarImagen.Size = new Size(330, 53);
            btnCargarImagen.TabIndex = 0;
            btnCargarImagen.Text = "Cargar Imagen ";
            btnCargarImagen.UseVisualStyleBackColor = true;
            btnCargarImagen.Click += btnCargarImagen_Click;
            // 
            // pictureBoxImagen
            // 
            pictureBoxImagen.Image = (Image)resources.GetObject("pictureBoxImagen.Image");
            pictureBoxImagen.InitialImage = (Image)resources.GetObject("pictureBoxImagen.InitialImage");
            pictureBoxImagen.Location = new Point(0, 4);
            pictureBoxImagen.Margin = new Padding(4);
            pictureBoxImagen.Name = "pictureBoxImagen";
            pictureBoxImagen.Size = new Size(261, 193);
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxImagen.TabIndex = 1;
            pictureBoxImagen.TabStop = false;
            pictureBoxImagen.MouseMove += pictureBoxImagen_MouseMove;
            // 
            // lblColorARGB
            // 
            lblColorARGB.AutoSize = true;
            lblColorARGB.Location = new Point(440, 15);
            lblColorARGB.Margin = new Padding(4, 0, 4, 0);
            lblColorARGB.Name = "lblColorARGB";
            lblColorARGB.Size = new Size(0, 19);
            lblColorARGB.TabIndex = 2;
            // 
            // lblNombreColor
            // 
            lblNombreColor.AutoSize = true;
            lblNombreColor.Location = new Point(440, 86);
            lblNombreColor.Margin = new Padding(4, 0, 4, 0);
            lblNombreColor.Name = "lblNombreColor";
            lblNombreColor.Size = new Size(0, 19);
            lblNombreColor.TabIndex = 3;
            // 
            // panelVistaColor
            // 
            panelVistaColor.Location = new Point(421, 164);
            panelVistaColor.Name = "panelVistaColor";
            panelVistaColor.Size = new Size(200, 142);
            panelVistaColor.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pictureBoxImagen);
            panel1.Location = new Point(10, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(405, 295);
            panel1.TabIndex = 5;
            // 
            // FRMDetectarColor
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 80, 200);
            ClientSize = new Size(760, 432);
            Controls.Add(panel1);
            Controls.Add(panelVistaColor);
            Controls.Add(lblNombreColor);
            Controls.Add(lblColorARGB);
            Controls.Add(btnCargarImagen);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FRMDetectarColor";
            Text = "FRMDetectarColor";
            Load += FRMDetectarColor_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxImagen).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCargarImagen;
        private PictureBox pictureBoxImagen;
        private Label lblColorARGB;
        private Label lblNombreColor;
        private Panel panelVistaColor;
        private Panel panel1;
    }
}