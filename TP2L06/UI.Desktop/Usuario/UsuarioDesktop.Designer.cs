namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            this.lblConfirmClave = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.cmbPersonas = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkPass = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.64286F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.35714F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblConfirmClave, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmarClave, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbPersonas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUsuario, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkHabilitado, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblClave, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtClave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkPass, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.73134F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.26866F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(626, 185);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(19, 11);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblConfirmClave
            // 
            this.lblConfirmClave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConfirmClave.AutoSize = true;
            this.lblConfirmClave.Location = new System.Drawing.Point(296, 115);
            this.lblConfirmClave.Name = "lblConfirmClave";
            this.lblConfirmClave.Size = new System.Drawing.Size(81, 13);
            this.lblConfirmClave.TabIndex = 7;
            this.lblConfirmClave.Text = "Confirmar Clave";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(70, 8);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(201, 20);
            this.txtID.TabIndex = 10;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmarClave.Location = new System.Drawing.Point(406, 111);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.PasswordChar = '•';
            this.txtConfirmarClave.Size = new System.Drawing.Size(201, 20);
            this.txtConfirmarClave.TabIndex = 6;
            // 
            // cmbPersonas
            // 
            this.cmbPersonas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonas.FormattingEnabled = true;
            this.cmbPersonas.Location = new System.Drawing.Point(72, 41);
            this.cmbPersonas.Name = "cmbPersonas";
            this.cmbPersonas.Size = new System.Drawing.Size(197, 21);
            this.cmbPersonas.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Location = new System.Drawing.Point(406, 41);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(201, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(321, 45);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 102;
            this.label1.Text = "Persona";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(6, 79);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsuario.Location = new System.Drawing.Point(70, 75);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(201, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(300, 9);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 1;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(293, 148);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 27);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblClave
            // 
            this.lblClave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(11, 115);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(34, 13);
            this.lblClave.TabIndex = 3;
            this.lblClave.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtClave.Location = new System.Drawing.Point(70, 111);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '•';
            this.txtClave.Size = new System.Drawing.Size(201, 20);
            this.txtClave.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.Location = new System.Drawing.Point(463, 148);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 27);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkPass
            // 
            this.chkPass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkPass.AutoSize = true;
            this.chkPass.Location = new System.Drawing.Point(114, 153);
            this.chkPass.Name = "chkPass";
            this.chkPass.Size = new System.Drawing.Size(114, 17);
            this.chkPass.TabIndex = 100;
            this.chkPass.Text = "Mostrar caracteres";
            this.chkPass.UseVisualStyleBackColor = true;
            this.chkPass.CheckedChanged += new System.EventHandler(this.chkPass_CheckedChanged);
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 195);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UsuarioDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.UsuarioDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblConfirmClave;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.CheckBox chkPass;
        private System.Windows.Forms.ComboBox cmbPersonas;
        private System.Windows.Forms.Label label1;

    }
}