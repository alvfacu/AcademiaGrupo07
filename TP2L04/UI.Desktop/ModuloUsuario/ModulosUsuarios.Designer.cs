namespace UI.Desktop
{
    partial class ModulosUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModulosUsuarios));
            this.tcModulos = new System.Windows.Forms.ToolStripContainer();
            this.tlModulos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvModulosUsuarios = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PermiteAlta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PermiteBaja = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PermiteConsulta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PermiteModificacion = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsModulos = new System.Windows.Forms.ToolStrip();
            this.tbsNuevo = new System.Windows.Forms.ToolStripButton();
            this.tbsEditar = new System.Windows.Forms.ToolStripButton();
            this.tbsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcModulos.ContentPanel.SuspendLayout();
            this.tcModulos.TopToolStripPanel.SuspendLayout();
            this.tcModulos.SuspendLayout();
            this.tlModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).BeginInit();
            this.tsModulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcModulos
            // 
            // 
            // tcModulos.ContentPanel
            // 
            this.tcModulos.ContentPanel.Controls.Add(this.tlModulos);
            this.tcModulos.ContentPanel.Size = new System.Drawing.Size(859, 320);
            this.tcModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcModulos.Location = new System.Drawing.Point(0, 0);
            this.tcModulos.Name = "tcModulos";
            this.tcModulos.Size = new System.Drawing.Size(859, 345);
            this.tcModulos.TabIndex = 0;
            this.tcModulos.Text = "toolStripContainer1";
            // 
            // tcModulos.TopToolStripPanel
            // 
            this.tcModulos.TopToolStripPanel.Controls.Add(this.tsModulos);
            // 
            // tlModulos
            // 
            this.tlModulos.ColumnCount = 2;
            this.tlModulos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlModulos.Controls.Add(this.dgvModulosUsuarios, 0, 0);
            this.tlModulos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlModulos.Controls.Add(this.btnSalir, 1, 1);
            this.tlModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlModulos.Location = new System.Drawing.Point(0, 0);
            this.tlModulos.Name = "tlModulos";
            this.tlModulos.RowCount = 2;
            this.tlModulos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlModulos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlModulos.Size = new System.Drawing.Size(859, 320);
            this.tlModulos.TabIndex = 0;
            // 
            // dgvModulosUsuarios
            // 
            this.dgvModulosUsuarios.AllowUserToAddRows = false;
            this.dgvModulosUsuarios.AllowUserToDeleteRows = false;
            this.dgvModulosUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModulosUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvModulosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulosUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.IDModulo,
            this.IDUsuario,
            this.PermiteAlta,
            this.PermiteBaja,
            this.PermiteConsulta,
            this.PermiteModificacion});
            this.tlModulos.SetColumnSpan(this.dgvModulosUsuarios, 2);
            this.dgvModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulosUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvModulosUsuarios.MultiSelect = false;
            this.dgvModulosUsuarios.Name = "dgvModulosUsuarios";
            this.dgvModulosUsuarios.ReadOnly = true;
            this.dgvModulosUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulosUsuarios.Size = new System.Drawing.Size(853, 276);
            this.dgvModulosUsuarios.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // IDModulo
            // 
            this.IDModulo.DataPropertyName = "IDModulo";
            this.IDModulo.HeaderText = "ID Módulo";
            this.IDModulo.Name = "IDModulo";
            this.IDModulo.ReadOnly = true;
            // 
            // IDUsuario
            // 
            this.IDUsuario.DataPropertyName = "IDUsuario";
            this.IDUsuario.HeaderText = "ID Usuario";
            this.IDUsuario.Name = "IDUsuario";
            this.IDUsuario.ReadOnly = true;
            // 
            // PermiteAlta
            // 
            this.PermiteAlta.DataPropertyName = "PermiteAlta";
            this.PermiteAlta.HeaderText = "Permite Alta";
            this.PermiteAlta.Name = "PermiteAlta";
            this.PermiteAlta.ReadOnly = true;
            this.PermiteAlta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PermiteAlta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PermiteBaja
            // 
            this.PermiteBaja.DataPropertyName = "PermiteBaja";
            this.PermiteBaja.HeaderText = "Permite Baja";
            this.PermiteBaja.Name = "PermiteBaja";
            this.PermiteBaja.ReadOnly = true;
            this.PermiteBaja.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PermiteBaja.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PermiteConsulta
            // 
            this.PermiteConsulta.DataPropertyName = "PermiteConsulta";
            this.PermiteConsulta.HeaderText = "Permite Consulta";
            this.PermiteConsulta.Name = "PermiteConsulta";
            this.PermiteConsulta.ReadOnly = true;
            this.PermiteConsulta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PermiteConsulta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PermiteModificacion
            // 
            this.PermiteModificacion.DataPropertyName = "PermiteModificacion";
            this.PermiteModificacion.HeaderText = "Permite Modificación";
            this.PermiteModificacion.Name = "PermiteModificacion";
            this.PermiteModificacion.ReadOnly = true;
            this.PermiteModificacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PermiteModificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(694, 285);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(78, 32);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(778, 285);
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
            this.tbsEliminar.ToolTipText = "Eliminar";
            this.tbsEliminar.Click += new System.EventHandler(this.tbsEliminar_Click);
            // 
            // ModulosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 345);
            this.Controls.Add(this.tcModulos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ModulosUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulos Usuario";
            this.Load += new System.EventHandler(this.Modulos_Load);
            this.tcModulos.ContentPanel.ResumeLayout(false);
            this.tcModulos.TopToolStripPanel.ResumeLayout(false);
            this.tcModulos.TopToolStripPanel.PerformLayout();
            this.tcModulos.ResumeLayout(false);
            this.tcModulos.PerformLayout();
            this.tlModulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).EndInit();
            this.tsModulos.ResumeLayout(false);
            this.tsModulos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcModulos;
        private System.Windows.Forms.TableLayoutPanel tlModulos;
        private System.Windows.Forms.ToolStrip tsModulos;
        private System.Windows.Forms.DataGridView dgvModulosUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUsuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermiteAlta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermiteBaja;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermiteConsulta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermiteModificacion;
        private System.Windows.Forms.ToolStripButton tbsNuevo;
        private System.Windows.Forms.ToolStripButton tbsEditar;
        private System.Windows.Forms.ToolStripButton tbsEliminar;
    }
}