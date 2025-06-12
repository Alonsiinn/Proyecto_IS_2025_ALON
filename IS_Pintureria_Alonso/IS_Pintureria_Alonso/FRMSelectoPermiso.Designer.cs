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
            SuspendLayout();
            // 
            // treeViewPermisos
            // 
            treeViewPermisos.Location = new Point(330, 12);
            treeViewPermisos.Name = "treeViewPermisos";
            treeViewPermisos.Size = new Size(458, 426);
            treeViewPermisos.TabIndex = 0;
            // 
            // txtNombrePermiso
            // 
            txtNombrePermiso.Location = new Point(12, 12);
            txtNombrePermiso.Name = "txtNombrePermiso";
            txtNombrePermiso.Size = new Size(199, 23);
            txtNombrePermiso.TabIndex = 1;
            // 
            // txtNombreCompuesto
            // 
            txtNombreCompuesto.Location = new Point(12, 90);
            txtNombreCompuesto.Name = "txtNombreCompuesto";
            txtNombreCompuesto.Size = new Size(199, 23);
            txtNombreCompuesto.TabIndex = 2;
            // 
            // btnCrearPermisoSimple
            // 
            btnCrearPermisoSimple.Location = new Point(12, 41);
            btnCrearPermisoSimple.Name = "btnCrearPermisoSimple";
            btnCrearPermisoSimple.Size = new Size(199, 23);
            btnCrearPermisoSimple.TabIndex = 3;
            btnCrearPermisoSimple.Text = "Crear Simple";
            btnCrearPermisoSimple.UseVisualStyleBackColor = true;
            btnCrearPermisoSimple.Click += btnCrearPermisoSimple_Click;
            // 
            // btnCrearPermisoCompuesto
            // 
            btnCrearPermisoCompuesto.Location = new Point(12, 119);
            btnCrearPermisoCompuesto.Name = "btnCrearPermisoCompuesto";
            btnCrearPermisoCompuesto.Size = new Size(199, 23);
            btnCrearPermisoCompuesto.TabIndex = 4;
            btnCrearPermisoCompuesto.Text = "Crear Compuesto";
            btnCrearPermisoCompuesto.UseVisualStyleBackColor = true;
            btnCrearPermisoCompuesto.Click += btnCrearPermisoCompuesto_Click;
            // 
            // btnEliminarPermiso
            // 
            btnEliminarPermiso.Location = new Point(12, 250);
            btnEliminarPermiso.Name = "btnEliminarPermiso";
            btnEliminarPermiso.Size = new Size(148, 23);
            btnEliminarPermiso.TabIndex = 5;
            btnEliminarPermiso.Text = "Eliminar Permiso";
            btnEliminarPermiso.UseVisualStyleBackColor = true;
            btnEliminarPermiso.Click += btnEliminarPermiso_Click;
            // 
            // btnQuitarPermisoDeCompuesto
            // 
            btnQuitarPermisoDeCompuesto.Location = new Point(12, 221);
            btnQuitarPermisoDeCompuesto.Name = "btnQuitarPermisoDeCompuesto";
            btnQuitarPermisoDeCompuesto.Size = new Size(148, 23);
            btnQuitarPermisoDeCompuesto.TabIndex = 6;
            btnQuitarPermisoDeCompuesto.Text = "Quitar de Compuesto";
            btnQuitarPermisoDeCompuesto.UseVisualStyleBackColor = true;
            btnQuitarPermisoDeCompuesto.Click += btnQuitarPermisoDeCompuesto_Click;
            // 
            // btnAgregarPermisoACompuesto
            // 
            btnAgregarPermisoACompuesto.Location = new Point(12, 192);
            btnAgregarPermisoACompuesto.Name = "btnAgregarPermisoACompuesto";
            btnAgregarPermisoACompuesto.Size = new Size(148, 23);
            btnAgregarPermisoACompuesto.TabIndex = 7;
            btnAgregarPermisoACompuesto.Text = "Agregar a Compuesto";
            btnAgregarPermisoACompuesto.UseVisualStyleBackColor = true;
            btnAgregarPermisoACompuesto.Click += btnAgregarPermisoACompuesto_Click;
            // 
            // FRMSelectoPermiso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAgregarPermisoACompuesto);
            Controls.Add(btnQuitarPermisoDeCompuesto);
            Controls.Add(btnEliminarPermiso);
            Controls.Add(btnCrearPermisoCompuesto);
            Controls.Add(btnCrearPermisoSimple);
            Controls.Add(txtNombreCompuesto);
            Controls.Add(txtNombrePermiso);
            Controls.Add(treeViewPermisos);
            Name = "FRMSelectoPermiso";
            Text = "FRMSelectoPermiso";
            Load += FRMSelectoPermiso_Load;
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
    }
}