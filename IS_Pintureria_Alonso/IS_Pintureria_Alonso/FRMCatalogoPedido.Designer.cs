namespace IS_Pintureria_Alonso
{
    partial class FRMCatalogoPedido
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
            dgvCatalogo = new DataGridView();
            clmNombre = new DataGridViewTextBoxColumn();
            clmId = new DataGridViewTextBoxColumn();
            clmPrecio = new DataGridViewTextBoxColumn();
            clmCategoria = new DataGridViewTextBoxColumn();
            clmDescripcion = new DataGridViewTextBoxColumn();
            txtNombre = new TextBox();
            textBox1 = new TextBox();
            txtHexa = new TextBox();
            lblNombre = new Label();
            lblHexa = new Label();
            lblCodigo = new Label();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).BeginInit();
            SuspendLayout();
            // 
            // dgvCatalogo
            // 
            dgvCatalogo.AllowUserToAddRows = false;
            dgvCatalogo.AllowUserToDeleteRows = false;
            dgvCatalogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCatalogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalogo.Columns.AddRange(new DataGridViewColumn[] { clmNombre, clmId, clmPrecio, clmCategoria, clmDescripcion });
            dgvCatalogo.Location = new Point(12, 115);
            dgvCatalogo.Name = "dgvCatalogo";
            dgvCatalogo.ReadOnly = true;
            dgvCatalogo.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvCatalogo.Size = new Size(926, 353);
            dgvCatalogo.TabIndex = 0;
            dgvCatalogo.CellMouseDoubleClick += dgvCatalogo_CellMouseDoubleClick;
            // 
            // clmNombre
            // 
            clmNombre.HeaderText = "Nombre";
            clmNombre.Name = "clmNombre";
            clmNombre.ReadOnly = true;
            clmNombre.Width = 80;
            // 
            // clmId
            // 
            clmId.HeaderText = "Codigo";
            clmId.Name = "clmId";
            clmId.ReadOnly = true;
            clmId.Width = 76;
            // 
            // clmPrecio
            // 
            clmPrecio.HeaderText = "Precio";
            clmPrecio.Name = "clmPrecio";
            clmPrecio.ReadOnly = true;
            clmPrecio.Width = 70;
            // 
            // clmCategoria
            // 
            clmCategoria.HeaderText = "Categoria";
            clmCategoria.Name = "clmCategoria";
            clmCategoria.ReadOnly = true;
            clmCategoria.Width = 91;
            // 
            // clmDescripcion
            // 
            clmDescripcion.HeaderText = "Descripcion";
            clmDescripcion.Name = "clmDescripcion";
            clmDescripcion.ReadOnly = true;
            clmDescripcion.Width = 102;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(16, 87);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(265, 22);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(321, 87);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Numerico";
            textBox1.Size = new Size(107, 22);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // txtHexa
            // 
            txtHexa.Location = new Point(471, 87);
            txtHexa.Name = "txtHexa";
            txtHexa.PlaceholderText = "Sin #";
            txtHexa.Size = new Size(265, 22);
            txtHexa.TabIndex = 3;
            txtHexa.TextChanged += textBox2_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(16, 68);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(112, 16);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Filtrar por Nombre";
            // 
            // lblHexa
            // 
            lblHexa.AutoSize = true;
            lblHexa.Location = new Point(471, 68);
            lblHexa.Name = "lblHexa";
            lblHexa.Size = new Size(144, 16);
            lblHexa.TabIndex = 5;
            lblHexa.Text = "Filtrar por Hexadecimal";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(321, 68);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(107, 16);
            lblCodigo.TabIndex = 6;
            lblCodigo.Text = "Filtrar por codigo";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(863, 12);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // FRMCatalogoPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 80, 200);
            ClientSize = new Size(958, 480);
            Controls.Add(btnActualizar);
            Controls.Add(lblCodigo);
            Controls.Add(lblHexa);
            Controls.Add(lblNombre);
            Controls.Add(txtHexa);
            Controls.Add(textBox1);
            Controls.Add(txtNombre);
            Controls.Add(dgvCatalogo);
            Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "FRMCatalogoPedido";
            Text = "FRMCatalogoPedido";
            Load += FRMCatalogoPedido_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCatalogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCatalogo;
        private DataGridViewTextBoxColumn clmNombre;
        private DataGridViewTextBoxColumn clmId;
        private DataGridViewTextBoxColumn clmPrecio;
        private DataGridViewTextBoxColumn clmCategoria;
        private DataGridViewTextBoxColumn clmDescripcion;
        private TextBox txtNombre;
        private TextBox textBox1;
        private TextBox txtHexa;
        private Label lblNombre;
        private Label lblHexa;
        private Label lblCodigo;
        private Button btnActualizar;
    }
}