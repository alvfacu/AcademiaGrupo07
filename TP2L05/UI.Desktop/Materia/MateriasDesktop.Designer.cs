namespace UI.Desktop
{
    partial class MateriasDesktop
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblHSSemanales = new System.Windows.Forms.Label();
            this.txtHSSemanales = new System.Windows.Forms.TextBox();
            this.txtHSTotales = new System.Windows.Forms.TextBox();
            this.lblHSTotales = new System.Windows.Forms.Label();
            this.lblIDPlan = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbIDPlan = new System.Windows.Forms.ComboBox();
            this.planAdapterBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.planBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planAdapterBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.5974F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.4026F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDescripcion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHSSemanales, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHSSemanales, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHSTotales, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblHSTotales, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblIDPlan, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbIDPlan, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0566F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.9434F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 171);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(31, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Location = new System.Drawing.Point(84, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(123, 20);
            this.txtID.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(9, 33);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(84, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(271, 20);
            this.txtDescripcion.TabIndex = 3;
            // 
            // lblHSSemanales
            // 
            this.lblHSSemanales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHSSemanales.AutoSize = true;
            this.lblHSSemanales.Location = new System.Drawing.Point(3, 61);
            this.lblHSSemanales.Name = "lblHSSemanales";
            this.lblHSSemanales.Size = new System.Drawing.Size(75, 13);
            this.lblHSSemanales.TabIndex = 4;
            this.lblHSSemanales.Text = "Hs Semanales";
            // 
            // txtHSSemanales
            // 
            this.txtHSSemanales.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHSSemanales.Location = new System.Drawing.Point(84, 57);
            this.txtHSSemanales.Name = "txtHSSemanales";
            this.txtHSSemanales.Size = new System.Drawing.Size(54, 20);
            this.txtHSSemanales.TabIndex = 5;
            // 
            // txtHSTotales
            // 
            this.txtHSTotales.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHSTotales.Location = new System.Drawing.Point(84, 85);
            this.txtHSTotales.Name = "txtHSTotales";
            this.txtHSTotales.Size = new System.Drawing.Size(54, 20);
            this.txtHSTotales.TabIndex = 6;
            // 
            // lblHSTotales
            // 
            this.lblHSTotales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHSTotales.AutoSize = true;
            this.lblHSTotales.Location = new System.Drawing.Point(11, 89);
            this.lblHSTotales.Name = "lblHSTotales";
            this.lblHSTotales.Size = new System.Drawing.Size(58, 13);
            this.lblHSTotales.TabIndex = 7;
            this.lblHSTotales.Text = "Hs Totales";
            // 
            // lblIDPlan
            // 
            this.lblIDPlan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDPlan.AutoSize = true;
            this.lblIDPlan.Location = new System.Drawing.Point(26, 116);
            this.lblIDPlan.Name = "lblIDPlan";
            this.lblIDPlan.Size = new System.Drawing.Size(28, 13);
            this.lblIDPlan.TabIndex = 8;
            this.lblIDPlan.Text = "Plan";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(267, 140);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 27);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(373, 140);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbIDPlan
            // 
            this.cmbIDPlan.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbIDPlan.FormattingEnabled = true;
            this.cmbIDPlan.Location = new System.Drawing.Point(84, 112);
            this.cmbIDPlan.Name = "cmbIDPlan";
            this.cmbIDPlan.Size = new System.Drawing.Size(78, 21);
            this.cmbIDPlan.TabIndex = 12;
            // 
            // planAdapterBindingSource2
            // 
            this.planAdapterBindingSource2.DataSource = typeof(Data.Database.PlanAdapter);
            // 
            // planBindingSource
            // 
            this.planBindingSource.DataSource = typeof(Business.Entities.Plan);
            // 
            // planAdapterBindingSource
            // 
            this.planAdapterBindingSource.DataSource = typeof(Data.Database.PlanAdapter);
            // 
            // planAdapterBindingSource1
            // 
            this.planAdapterBindingSource1.DataSource = typeof(Data.Database.PlanAdapter);
            // 
            // MateriasDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 197);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MateriasDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materia";
            this.Load += new System.EventHandler(this.MateriasDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblHSSemanales;
        private System.Windows.Forms.TextBox txtHSSemanales;
        private System.Windows.Forms.TextBox txtHSTotales;
        private System.Windows.Forms.Label lblHSTotales;
        private System.Windows.Forms.Label lblIDPlan;
        private System.Windows.Forms.BindingSource planBindingSource;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource planAdapterBindingSource;
        private System.Windows.Forms.BindingSource planAdapterBindingSource1;
        private System.Windows.Forms.BindingSource planAdapterBindingSource2;
        private System.Windows.Forms.ComboBox cmbIDPlan;
    }
}