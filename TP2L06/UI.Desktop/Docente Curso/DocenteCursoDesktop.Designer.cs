namespace UI.Desktop
{
    partial class DocenteCursoDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblID = new System.Windows.Forms.Label();
            this.lblIDCurso = new System.Windows.Forms.Label();
            this.lblIDDoc = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbCurso = new System.Windows.Forms.ComboBox();
            this.txtIDDocente = new System.Windows.Forms.TextBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.88889F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIDCurso, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIDDoc, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCargo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCurso, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDDocente, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbCargo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.05882F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.94118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 141);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(27, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblIDCurso
            // 
            this.lblIDCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDCurso.AutoSize = true;
            this.lblIDCurso.Location = new System.Drawing.Point(19, 42);
            this.lblIDCurso.Name = "lblIDCurso";
            this.lblIDCurso.Size = new System.Drawing.Size(34, 13);
            this.lblIDCurso.TabIndex = 1;
            this.lblIDCurso.Text = "Curso";
            // 
            // lblIDDoc
            // 
            this.lblIDDoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDDoc.AutoSize = true;
            this.lblIDDoc.Location = new System.Drawing.Point(5, 77);
            this.lblIDDoc.Name = "lblIDDoc";
            this.lblIDDoc.Size = new System.Drawing.Size(62, 13);
            this.lblIDDoc.TabIndex = 2;
            this.lblIDDoc.Text = "ID Docente";
            // 
            // lblCargo
            // 
            this.lblCargo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(207, 77);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(35, 13);
            this.lblCargo.TabIndex = 3;
            this.lblCargo.Text = "Cargo";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Location = new System.Drawing.Point(75, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(103, 20);
            this.txtID.TabIndex = 4;
            // 
            // cmbCurso
            // 
            this.cmbCurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurso.FormattingEnabled = true;
            this.cmbCurso.Location = new System.Drawing.Point(75, 38);
            this.cmbCurso.Name = "cmbCurso";
            this.cmbCurso.Size = new System.Drawing.Size(123, 21);
            this.cmbCurso.TabIndex = 5;
            // 
            // txtIDDocente
            // 
            this.txtIDDocente.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDDocente.Location = new System.Drawing.Point(75, 73);
            this.txtIDDocente.Name = "txtIDDocente";
            this.txtIDDocente.Size = new System.Drawing.Size(123, 20);
            this.txtIDDocente.TabIndex = 6;
            // 
            // cmbCargo
            // 
            this.cmbCargo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(252, 73);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(114, 21);
            this.cmbCargo.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(120, 104);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(78, 32);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(252, 104);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // DocenteCursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 160);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DocenteCursoDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Docente - Curso";
            this.Load += new System.EventHandler(this.DocenteCursoDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblIDCurso;
        private System.Windows.Forms.Label lblIDDoc;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbCurso;
        private System.Windows.Forms.TextBox txtIDDocente;
        private System.Windows.Forms.ComboBox cmbCargo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}