namespace UI.Desktop
{
    partial class Modulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modulos));
            this.tcModulos = new System.Windows.Forms.ToolStripContainer();
            this.tpModulos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvModulos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsModulos = new System.Windows.Forms.ToolStrip();
            this.tbsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tbsEditar = new System.Windows.Forms.ToolStripButton();
            this.tbsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcModulos.ContentPanel.SuspendLayout();
            this.tcModulos.TopToolStripPanel.SuspendLayout();
            this.tcModulos.SuspendLayout();
            this.tpModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
            this.tsModulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcModulos
            // 
            // 
            // tcModulos.ContentPanel
            // 
            this.tcModulos.ContentPanel.Controls.Add(this.tpModulos);
            this.tcModulos.ContentPanel.Size = new System.Drawing.Size(501, 267);
            this.tcModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModulos.Location = new System.Drawing.Point(0, 0);
            this.tcModulos.Name = "tcModulos";
            this.tcModulos.Size = new System.Drawing.Size(501, 292);
            this.tcModulos.TabIndex = 0;
            this.tcModulos.Text = "toolStripContainer1";
            // 
            // tcModulos.TopToolStripPanel
            // 
            this.tcModulos.TopToolStripPanel.Controls.Add(this.tsModulos);
            // 
            // tpModulos
            // 
            this.tpModulos.ColumnCount = 2;
            this.tpModulos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpModulos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tpModulos.Controls.Add(this.dgvModulos, 0, 0);
            this.tpModulos.Controls.Add(this.btnActualizar, 0, 1);
            this.tpModulos.Controls.Add(this.btnSalir, 1, 1);
            this.tpModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpModulos.Location = new System.Drawing.Point(0, 0);
            this.tpModulos.Name = "tpModulos";
            this.tpModulos.RowCount = 2;
            this.tpModulos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpModulos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tpModulos.Size = new System.Drawing.Size(501, 267);
            this.tpModulos.TabIndex = 0;
            // 
            // dgvModulos
            // 
            this.dgvModulos.AllowUserToAddRows = false;
            this.dgvModulos.AllowUserToDeleteRows = false;
            this.dgvModulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModulos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Descripcion});
            this.tpModulos.SetColumnSpan(this.dgvModulos, 2);
            this.dgvModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulos.Location = new System.Drawing.Point(3, 3);
            this.dgvModulos.MultiSelect = false;
            this.dgvModulos.Name = "dgvModulos";
            this.dgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulos.Size = new System.Drawing.Size(495, 223);
            this.dgvModulos.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(336, 232);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(78, 32);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(420, 232);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 32);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsModulos
            // 
            this.tsModulos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsModulos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbsNuevo,
            this.tbsEditar,
            this.tbsEliminar});
            this.tsModulos.Location = new System.Drawing.Point(3, 0);
            this.tsModulos.Name = "tsModulos";
            this.tsModulos.Size = new System.Drawing.Size(81, 25);
            this.tsModulos.TabIndex = 0;
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
            this.tbsEditar.Text = "toolStripButton1";
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
            this.tbsEliminar.Text = "toolStripButton1";
            this.tbsEliminar.ToolTipText = "Eliminar";
            this.tbsEliminar.Click += new System.EventHandler(this.tbsEliminar_Click);
            // 
            // Modulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 292);
            this.Controls.Add(this.tcModulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Modulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulos";
            this.Load += new System.EventHandler(this.Modulos_Load);
            this.tcModulos.ContentPanel.ResumeLayout(false);
            this.tcModulos.TopToolStripPanel.ResumeLayout(false);
            this.tcModulos.TopToolStripPanel.PerformLayout();
            this.tcModulos.ResumeLayout(false);
            this.tcModulos.PerformLayout();
            this.tpModulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
            this.tsModulos.ResumeLayout(false);
            this.tsModulos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcModulos;
        private System.Windows.Forms.TableLayoutPanel tpModulos;
        private System.Windows.Forms.DataGridView dgvModulos;
        private System.Windows.Forms.ToolStrip tsModulos;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.ToolStripButton tbsNuevo;
        private System.Windows.Forms.ToolStripButton tbsEditar;
        private System.Windows.Forms.ToolStripButton tbsEliminar;

    }
}