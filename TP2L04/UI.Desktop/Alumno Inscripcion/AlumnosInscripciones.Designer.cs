namespace UI.Desktop
{
    partial class AlumnosInscripciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlumnosInscripciones));
            this.tcInscripciones = new System.Windows.Forms.ToolStripContainer();
            this.tlInscripciones = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInscripciones = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDAlu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tbsEditar = new System.Windows.Forms.ToolStripButton();
            this.tbsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcInscripciones.ContentPanel.SuspendLayout();
            this.tcInscripciones.TopToolStripPanel.SuspendLayout();
            this.tcInscripciones.SuspendLayout();
            this.tlInscripciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcInscripciones
            // 
            // 
            // tcInscripciones.ContentPanel
            // 
            this.tcInscripciones.ContentPanel.Controls.Add(this.tlInscripciones);
            this.tcInscripciones.ContentPanel.Size = new System.Drawing.Size(545, 241);
            this.tcInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tcInscripciones.Name = "tcInscripciones";
            this.tcInscripciones.Size = new System.Drawing.Size(545, 266);
            this.tcInscripciones.TabIndex = 0;
            this.tcInscripciones.Text = "toolStripContainer1";
            // 
            // tcInscripciones.TopToolStripPanel
            // 
            this.tcInscripciones.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tlInscripciones
            // 
            this.tlInscripciones.ColumnCount = 2;
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlInscripciones.Controls.Add(this.dgvInscripciones, 0, 0);
            this.tlInscripciones.Controls.Add(this.btnActualizar, 0, 1);
            this.tlInscripciones.Controls.Add(this.btnSalir, 1, 1);
            this.tlInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlInscripciones.Location = new System.Drawing.Point(0, 0);
            this.tlInscripciones.Name = "tlInscripciones";
            this.tlInscripciones.RowCount = 2;
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlInscripciones.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlInscripciones.Size = new System.Drawing.Size(545, 241);
            this.tlInscripciones.TabIndex = 0;
            // 
            // dgvInscripciones
            // 
            this.dgvInscripciones.AllowUserToAddRows = false;
            this.dgvInscripciones.AllowUserToDeleteRows = false;
            this.dgvInscripciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInscripciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvInscripciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInscripciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDAlu,
            this.IDCurso,
            this.Condicion,
            this.Nota});
            this.tlInscripciones.SetColumnSpan(this.dgvInscripciones, 2);
            this.dgvInscripciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripciones.Location = new System.Drawing.Point(3, 3);
            this.dgvInscripciones.Name = "dgvInscripciones";
            this.dgvInscripciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInscripciones.Size = new System.Drawing.Size(539, 197);
            this.dgvInscripciones.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // IDAlu
            // 
            this.IDAlu.DataPropertyName = "IDAlumno";
            this.IDAlu.HeaderText = "ID Alumno";
            this.IDAlu.Name = "IDAlu";
            // 
            // IDCurso
            // 
            this.IDCurso.DataPropertyName = "IDCurso";
            this.IDCurso.HeaderText = "ID Curso";
            this.IDCurso.Name = "IDCurso";
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condición";
            this.Condicion.Name = "Condicion";
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(380, 206);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(78, 32);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(464, 206);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 32);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbsNuevo,
            this.tbsEditar,
            this.tbsEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tbsNuevo
            // 
            this.tbsNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbsNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tbsNuevo.Image")));
            this.tbsNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsNuevo.Name = "tbsNuevo";
            this.tbsNuevo.Size = new System.Drawing.Size(23, 22);
            this.tbsNuevo.Text = "toolStripButton1";
            this.tbsNuevo.ToolTipText = "Nuevo";
            this.tbsNuevo.Click += new System.EventHandler(this.tbsNuevo_Click);
            // 
            // tbsEditar
            // 
            this.tbsEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbsEditar.Image = ((System.Drawing.Image)(resources.GetObject("tbsEditar.Image")));
            this.tbsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsEditar.Name = "tbsEditar";
            this.tbsEditar.Size = new System.Drawing.Size(23, 22);
            this.tbsEditar.Text = "toolStripButton2";
            this.tbsEditar.ToolTipText = "Editar";
            this.tbsEditar.Click += new System.EventHandler(this.tbsEditar_Click);
            // 
            // tbsEliminar
            // 
            this.tbsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tbsEliminar.Image")));
            this.tbsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsEliminar.Name = "tbsEliminar";
            this.tbsEliminar.Size = new System.Drawing.Size(23, 22);
            this.tbsEliminar.Text = "toolStripButton3";
            this.tbsEliminar.ToolTipText = "Eliminar";
            this.tbsEliminar.Click += new System.EventHandler(this.tbsEliminar_Click);
            // 
            // AlumnosInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 266);
            this.Controls.Add(this.tcInscripciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AlumnosInscripciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inscripciones de Alumnos";
            this.Load += new System.EventHandler(this.AlumnosInscripciones_Load);
            this.tcInscripciones.ContentPanel.ResumeLayout(false);
            this.tcInscripciones.TopToolStripPanel.ResumeLayout(false);
            this.tcInscripciones.TopToolStripPanel.PerformLayout();
            this.tcInscripciones.ResumeLayout(false);
            this.tcInscripciones.PerformLayout();
            this.tlInscripciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripciones)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcInscripciones;
        private System.Windows.Forms.TableLayoutPanel tlInscripciones;
        private System.Windows.Forms.DataGridView dgvInscripciones;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbsNuevo;
        private System.Windows.Forms.ToolStripButton tbsEditar;
        private System.Windows.Forms.ToolStripButton tbsEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAlu;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
    }
}