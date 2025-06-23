namespace IS_Pintureria_Alonso
{
    partial class FRMSelectoPermiso
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
            treeViewPermisos = new TreeView();
            txtNombrePermiso = new TextBox();
            txtNombreCompuesto = new TextBox();
            btnCrearPermisoSimple = new Button();
            btnCrearPermisoCompuesto = new Button();
            btnEliminarPermiso = new Button();
            btnQuitarPermisoDeCompuesto = new Button();
            btnAgregarPermisoACompuesto = new Button();
            treeViewCompuesto = new TreeView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // treeViewPermisos
            // 
            treeViewPermisos.Location = new Point(318, 52);
            treeViewPermisos.Margin = new Padding(4, 4, 4, 4);
            treeViewPermisos.Name = "treeViewPermisos";
            treeViewPermisos.Size = new Size(343, 539);
            treeViewPermisos.TabIndex = 0;
            treeViewPermisos.AfterSelect += treeViewPermisos_AfterSelect;
            // 
            // txtNombrePermiso
            // 
            txtNombrePermiso.Location = new Point(15, 52);
            txtNombrePermiso.Margin = new Padding(4, 4, 4, 4);
            txtNombrePermiso.Name = "txtNombrePermiso";
            txtNombrePermiso.Size = new Size(255, 27);
            txtNombrePermiso.TabIndex = 1;
            // 
            // txtNombreCompuesto
            // 
            txtNombreCompuesto.Location = new Point(15, 151);
            txtNombreCompuesto.Margin = new Padding(4, 4, 4, 4);
            txtNombreCompuesto.Name = "txtNombreCompuesto";
            txtNombreCompuesto.Size = new Size(255, 27);
            txtNombreCompuesto.TabIndex = 2;
            // 
            // btnCrearPermisoSimple
            // 
            btnCrearPermisoSimple.Location = new Point(15, 89);
            btnCrearPermisoSimple.Margin = new Padding(4, 4, 4, 4);
            btnCrearPermisoSimple.Name = "btnCrearPermisoSimple";
            btnCrearPermisoSimple.Size = new Size(256, 29);
            btnCrearPermisoSimple.TabIndex = 3;
            btnCrearPermisoSimple.Text = "Crear Simple";
            btnCrearPermisoSimple.UseVisualStyleBackColor = true;
            btnCrearPermisoSimple.Click += btnCrearPermisoSimple_Click;
            // 
            // btnCrearPermisoCompuesto
            // 
            btnCrearPermisoCompuesto.Location = new Point(15, 187);
            btnCrearPermisoCompuesto.Margin = new Padding(4, 4, 4, 4);
            btnCrearPermisoCompuesto.Name = "btnCrearPermisoCompuesto";
            btnCrearPermisoCompuesto.Size = new Size(256, 29);
            btnCrearPermisoCompuesto.TabIndex = 4;
            btnCrearPermisoCompuesto.Text = "Crear Compuesto";
            btnCrearPermisoCompuesto.UseVisualStyleBackColor = true;
            btnCrearPermisoCompuesto.Click += btnCrearPermisoCompuesto_Click;
            // 
            // btnEliminarPermiso
            // 
            btnEliminarPermiso.Location = new Point(15, 562);
            btnEliminarPermiso.Margin = new Padding(4, 4, 4, 4);
            btnEliminarPermiso.Name = "btnEliminarPermiso";
            btnEliminarPermiso.Size = new Size(256, 29);
            btnEliminarPermiso.TabIndex = 5;
            btnEliminarPermiso.Text = "Eliminar Permiso";
            btnEliminarPermiso.UseVisualStyleBackColor = true;
            btnEliminarPermiso.Click += btnEliminarPermiso_Click;
            // 
            // btnQuitarPermisoDeCompuesto
            // 
            btnQuitarPermisoDeCompuesto.Location = new Point(669, 89);
            btnQuitarPermisoDeCompuesto.Margin = new Padding(4, 4, 4, 4);
            btnQuitarPermisoDeCompuesto.Name = "btnQuitarPermisoDeCompuesto";
            btnQuitarPermisoDeCompuesto.Size = new Size(256, 29);
            btnQuitarPermisoDeCompuesto.TabIndex = 6;
            btnQuitarPermisoDeCompuesto.Text = "Quitar de Compuesto";
            btnQuitarPermisoDeCompuesto.UseVisualStyleBackColor = true;
            btnQuitarPermisoDeCompuesto.Click += btnQuitarPermisoDeCompuesto_Click;
            // 
            // btnAgregarPermisoACompuesto
            // 
            btnAgregarPermisoACompuesto.Location = new Point(669, 52);
            btnAgregarPermisoACompuesto.Margin = new Padding(4, 4, 4, 4);
            btnAgregarPermisoACompuesto.Name = "btnAgregarPermisoACompuesto";
            btnAgregarPermisoACompuesto.Size = new Size(256, 29);
            btnAgregarPermisoACompuesto.TabIndex = 7;
            btnAgregarPermisoACompuesto.Text = "Agregar a Compuesto";
            btnAgregarPermisoACompuesto.UseVisualStyleBackColor = true;
            btnAgregarPermisoACompuesto.Click += btnAgregarPermisoACompuesto_Click;
            // 
            // treeViewCompuesto
            // 
            treeViewCompuesto.Location = new Point(943, 52);
            treeViewCompuesto.Margin = new Padding(4, 4, 4, 4);
            treeViewCompuesto.Name = "treeViewCompuesto";
            treeViewCompuesto.Size = new Size(330, 539);
            treeViewCompuesto.TabIndex = 9;
            treeViewCompuesto.AfterSelect += treeViewCompuesto_AfterSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(75, 19);
            label1.TabIndex = 10;
            label1.Text = "Permisos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(943, 29);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(233, 19);
            label2.TabIndex = 11;
            label2.Text = "Permisos Compuestos Destino";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 29);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(126, 19);
            label3.TabIndex = 12;
            label3.Text = "Permiso Simple";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 122);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(162, 19);
            label4.TabIndex = 13;
            label4.Text = "Permiso Compuesto";
            // 
            // FRMSelectoPermiso
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 80, 200);
            ClientSize = new Size(1290, 611);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(treeViewCompuesto);
            Controls.Add(btnAgregarPermisoACompuesto);
            Controls.Add(btnQuitarPermisoDeCompuesto);
            Controls.Add(btnEliminarPermiso);
            Controls.Add(btnCrearPermisoCompuesto);
            Controls.Add(btnCrearPermisoSimple);
            Controls.Add(txtNombreCompuesto);
            Controls.Add(txtNombrePermiso);
            Controls.Add(treeViewPermisos);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FRMSelectoPermiso";
            Text = "FRMSelectoPermiso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeViewPermisos;
        private TextBox txtNombrePermiso;
        private TextBox txtNombreCompuesto;
        private Button btnCrearPermisoSimple;
        private Button btnCrearPermisoCompuesto;
        private Button btnEliminarPermiso;
        private Button btnQuitarPermisoDeCompuesto;
        private Button btnAgregarPermisoACompuesto;
        private TreeView treeViewCompuesto;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}