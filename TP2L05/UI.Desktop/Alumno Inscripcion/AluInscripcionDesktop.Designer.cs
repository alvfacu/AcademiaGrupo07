namespace UI.Desktop
{
    partial class AluInscripcionDesktop
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
            this.lblIDAlu = new System.Windows.Forms.Label();
            this.lblIDCurso = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtIDAlu = new System.Windows.Forms.TextBox();
            this.cmbIDCurso = new System.Windows.Forms.ComboBox();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.08696F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.91304F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIDAlu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIDCurso, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNota, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCondicion, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtIDAlu, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbIDCurso, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCondicion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtNota, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.83019F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.16981F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 163);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(9, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(72, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID Inscripción";
            // 
            // lblIDAlu
            // 
            this.lblIDAlu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDAlu.AutoSize = true;
            this.lblIDAlu.Location = new System.Drawing.Point(17, 38);
            this.lblIDAlu.Name = "lblIDAlu";
            this.lblIDAlu.Size = new System.Drawing.Size(56, 13);
            this.lblIDAlu.TabIndex = 1;
            this.lblIDAlu.Text = "ID Alumno";
            // 
            // lblIDCurso
            // 
            this.lblIDCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDCurso.AutoSize = true;
            this.lblIDCurso.Location = new System.Drawing.Point(28, 66);
            this.lblIDCurso.Name = "lblIDCurso";
            this.lblIDCurso.Size = new System.Drawing.Size(34, 13);
            this.lblIDCurso.TabIndex = 2;
            this.lblIDCurso.Text = "Curso";
            // 
            // lblNota
            // 
            this.lblNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(255, 97);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(30, 13);
            this.lblNota.TabIndex = 3;
            this.lblNota.Text = "Nota";
            // 
            // lblCondicion
            // 
            this.lblCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(18, 97);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(54, 13);
            this.lblCondicion.TabIndex = 4;
            this.lblCondicion.Text = "Condición";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(168, 125);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(78, 32);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(295, 125);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 32);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Location = new System.Drawing.Point(93, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(119, 20);
            this.txtID.TabIndex = 0;
            // 
            // txtIDAlu
            // 
            this.txtIDAlu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDAlu.Location = new System.Drawing.Point(93, 34);
            this.txtIDAlu.Name = "txtIDAlu";
            this.txtIDAlu.Size = new System.Drawing.Size(119, 20);
            this.txtIDAlu.TabIndex = 1;
            // 
            // cmbIDCurso
            // 
            this.cmbIDCurso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbIDCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIDCurso.FormattingEnabled = true;
            this.cmbIDCurso.Location = new System.Drawing.Point(93, 62);
            this.cmbIDCurso.Name = "cmbIDCurso";
            this.cmbIDCurso.Size = new System.Drawing.Size(134, 21);
            this.cmbIDCurso.TabIndex = 2;
            // 
            // txtCondicion
            // 
            this.txtCondicion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCondicion.Location = new System.Drawing.Point(93, 94);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(134, 20);
            this.txtCondicion.TabIndex = 3;
            // 
            // txtNota
            // 
            this.txtNota.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtNota.Location = new System.Drawing.Point(295, 94);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(44, 20);
            this.txtNota.TabIndex = 4;
            // 
            // AluInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 185);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AluInscripcionDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inscripción de Alumno ";
            this.Load += new System.EventHandler(this.AluInscripcionDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblIDAlu;
        private System.Windows.Forms.Label lblIDCurso;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtIDAlu;
        private System.Windows.Forms.ComboBox cmbIDCurso;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.TextBox txtNota;
    }
}