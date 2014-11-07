namespace UI.Desktop
{
    partial class ModuloUsuarioDesktop
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
            this.lblIDUsr = new System.Windows.Forms.Label();
            this.lblIDMod = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbIDMod = new System.Windows.Forms.ComboBox();
            this.txtIDUsr = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkAlta = new System.Windows.Forms.CheckBox();
            this.chkMod = new System.Windows.Forms.CheckBox();
            this.chkConsulta = new System.Windows.Forms.CheckBox();
            this.chkBaja = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.88889F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIDUsr, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIDMod, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbIDMod, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDUsr, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.2963F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.7037F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(413, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(30, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblIDUsr
            // 
            this.lblIDUsr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDUsr.AutoSize = true;
            this.lblIDUsr.Location = new System.Drawing.Point(10, 62);
            this.lblIDUsr.Name = "lblIDUsr";
            this.lblIDUsr.Size = new System.Drawing.Size(57, 13);
            this.lblIDUsr.TabIndex = 1;
            this.lblIDUsr.Text = "ID Usuario";
            // 
            // lblIDMod
            // 
            this.lblIDMod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDMod.AutoSize = true;
            this.lblIDMod.Location = new System.Drawing.Point(11, 33);
            this.lblIDMod.Name = "lblIDMod";
            this.lblIDMod.Size = new System.Drawing.Size(56, 13);
            this.lblIDMod.TabIndex = 2;
            this.lblIDMod.Text = "ID Modulo";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Location = new System.Drawing.Point(81, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(145, 20);
            this.txtID.TabIndex = 3;
            // 
            // cmbIDMod
            // 
            this.cmbIDMod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbIDMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIDMod.FormattingEnabled = true;
            this.cmbIDMod.Location = new System.Drawing.Point(81, 29);
            this.cmbIDMod.Name = "cmbIDMod";
            this.cmbIDMod.Size = new System.Drawing.Size(74, 21);
            this.cmbIDMod.TabIndex = 4;
            // 
            // txtIDUsr
            // 
            this.txtIDUsr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIDUsr.Location = new System.Drawing.Point(81, 58);
            this.txtIDUsr.Name = "txtIDUsr";
            this.txtIDUsr.Size = new System.Drawing.Size(74, 20);
            this.txtIDUsr.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.68944F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.31056F));
            this.tableLayoutPanel2.Controls.Add(this.chkAlta, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkMod, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkConsulta, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkBaja, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(81, 86);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(322, 49);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // chkAlta
            // 
            this.chkAlta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAlta.AutoSize = true;
            this.chkAlta.Location = new System.Drawing.Point(3, 3);
            this.chkAlta.Name = "chkAlta";
            this.chkAlta.Size = new System.Drawing.Size(82, 17);
            this.chkAlta.TabIndex = 0;
            this.chkAlta.Text = "Permite Alta";
            this.chkAlta.UseVisualStyleBackColor = true;
            // 
            // chkMod
            // 
            this.chkMod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkMod.AutoSize = true;
            this.chkMod.Location = new System.Drawing.Point(163, 28);
            this.chkMod.Name = "chkMod";
            this.chkMod.Size = new System.Drawing.Size(124, 17);
            this.chkMod.TabIndex = 1;
            this.chkMod.Text = "Permite Modificación";
            this.chkMod.UseVisualStyleBackColor = true;
            // 
            // chkConsulta
            // 
            this.chkConsulta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkConsulta.AutoSize = true;
            this.chkConsulta.Location = new System.Drawing.Point(3, 28);
            this.chkConsulta.Name = "chkConsulta";
            this.chkConsulta.Size = new System.Drawing.Size(105, 17);
            this.chkConsulta.TabIndex = 2;
            this.chkConsulta.Text = "Permite Consulta";
            this.chkConsulta.UseVisualStyleBackColor = true;
            // 
            // chkBaja
            // 
            this.chkBaja.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkBaja.AutoSize = true;
            this.chkBaja.Location = new System.Drawing.Point(163, 3);
            this.chkBaja.Name = "chkBaja";
            this.chkBaja.Size = new System.Drawing.Size(85, 17);
            this.chkBaja.TabIndex = 3;
            this.chkBaja.Text = "Permite Baja";
            this.chkBaja.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnAceptar, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(81, 141);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(329, 36);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(38, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 27);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(167, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ModuloUsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 193);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ModuloUsuarioDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modulo Usuario";
            this.Load += new System.EventHandler(this.ModuloUsuarioDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblIDUsr;
        private System.Windows.Forms.Label lblIDMod;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbIDMod;
        private System.Windows.Forms.TextBox txtIDUsr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkAlta;
        private System.Windows.Forms.CheckBox chkMod;
        private System.Windows.Forms.CheckBox chkConsulta;
        private System.Windows.Forms.CheckBox chkBaja;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}