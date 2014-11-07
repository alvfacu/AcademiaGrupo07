namespace UI.Desktop
{
    partial class formPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMMateriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMMóduloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMEspecialidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMAlumnoInscripciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMModuloUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMDocenteCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMComisiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(626, 24);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbrir,
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(55, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuAbrir
            // 
            this.mnuAbrir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMUsuarioToolStripMenuItem,
            this.aBMCursoToolStripMenuItem,
            this.aBMMateriaToolStripMenuItem,
            this.aBMPersonaToolStripMenuItem,
            this.aBMComisiónToolStripMenuItem,
            this.aBMPlanToolStripMenuItem,
            this.aBMMóduloToolStripMenuItem,
            this.aBMEspecialidadToolStripMenuItem,
            this.aBMAlumnoInscripciónToolStripMenuItem,
            this.aBMModuloUsuarioToolStripMenuItem,
            this.aBMDocenteCursoToolStripMenuItem});
            this.mnuAbrir.Name = "mnuAbrir";
            this.mnuAbrir.Size = new System.Drawing.Size(152, 22);
            this.mnuAbrir.Text = "Abrir";
            // 
            // aBMUsuarioToolStripMenuItem
            // 
            this.aBMUsuarioToolStripMenuItem.Name = "aBMUsuarioToolStripMenuItem";
            this.aBMUsuarioToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMUsuarioToolStripMenuItem.Text = "ABM Usuario";
            this.aBMUsuarioToolStripMenuItem.Click += new System.EventHandler(this.aBMUsuarioToolStripMenuItem_Click);
            // 
            // aBMCursoToolStripMenuItem
            // 
            this.aBMCursoToolStripMenuItem.Name = "aBMCursoToolStripMenuItem";
            this.aBMCursoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMCursoToolStripMenuItem.Text = "ABM Curso";
            this.aBMCursoToolStripMenuItem.Click += new System.EventHandler(this.aBMCursoToolStripMenuItem_Click);
            // 
            // aBMMateriaToolStripMenuItem
            // 
            this.aBMMateriaToolStripMenuItem.Name = "aBMMateriaToolStripMenuItem";
            this.aBMMateriaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMMateriaToolStripMenuItem.Text = "ABM Materia";
            this.aBMMateriaToolStripMenuItem.Click += new System.EventHandler(this.aBMMateriaToolStripMenuItem_Click);
            // 
            // aBMPersonaToolStripMenuItem
            // 
            this.aBMPersonaToolStripMenuItem.Name = "aBMPersonaToolStripMenuItem";
            this.aBMPersonaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMPersonaToolStripMenuItem.Text = "ABM Persona";
            this.aBMPersonaToolStripMenuItem.Click += new System.EventHandler(this.aBMPersonaToolStripMenuItem_Click);
            // 
            // aBMPlanToolStripMenuItem
            // 
            this.aBMPlanToolStripMenuItem.Name = "aBMPlanToolStripMenuItem";
            this.aBMPlanToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMPlanToolStripMenuItem.Text = "ABM Plan";
            this.aBMPlanToolStripMenuItem.Click += new System.EventHandler(this.aBMPlanToolStripMenuItem_Click);
            // 
            // aBMMóduloToolStripMenuItem
            // 
            this.aBMMóduloToolStripMenuItem.Name = "aBMMóduloToolStripMenuItem";
            this.aBMMóduloToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMMóduloToolStripMenuItem.Text = "ABM Módulo";
            this.aBMMóduloToolStripMenuItem.Click += new System.EventHandler(this.aBMMóduloToolStripMenuItem_Click);
            // 
            // aBMEspecialidadToolStripMenuItem
            // 
            this.aBMEspecialidadToolStripMenuItem.Name = "aBMEspecialidadToolStripMenuItem";
            this.aBMEspecialidadToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMEspecialidadToolStripMenuItem.Text = "ABM Especialidad";
            this.aBMEspecialidadToolStripMenuItem.Click += new System.EventHandler(this.aBMEspecialidadToolStripMenuItem_Click);
            // 
            // aBMAlumnoInscripciónToolStripMenuItem
            // 
            this.aBMAlumnoInscripciónToolStripMenuItem.Name = "aBMAlumnoInscripciónToolStripMenuItem";
            this.aBMAlumnoInscripciónToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMAlumnoInscripciónToolStripMenuItem.Text = "ABM Alumno-Inscripción";
            this.aBMAlumnoInscripciónToolStripMenuItem.Click += new System.EventHandler(this.aBMAlumnoInscripciónToolStripMenuItem_Click);
            // 
            // aBMModuloUsuarioToolStripMenuItem
            // 
            this.aBMModuloUsuarioToolStripMenuItem.Name = "aBMModuloUsuarioToolStripMenuItem";
            this.aBMModuloUsuarioToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMModuloUsuarioToolStripMenuItem.Text = "ABM Modulo-Usuario";
            this.aBMModuloUsuarioToolStripMenuItem.Click += new System.EventHandler(this.aBMModuloUsuarioToolStripMenuItem_Click);
            // 
            // aBMDocenteCursoToolStripMenuItem
            // 
            this.aBMDocenteCursoToolStripMenuItem.Name = "aBMDocenteCursoToolStripMenuItem";
            this.aBMDocenteCursoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMDocenteCursoToolStripMenuItem.Text = "ABM Docente-Curso";
            this.aBMDocenteCursoToolStripMenuItem.Click += new System.EventHandler(this.aBMDocenteCursoToolStripMenuItem_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(152, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // aBMComisiónToolStripMenuItem
            // 
            this.aBMComisiónToolStripMenuItem.Name = "aBMComisiónToolStripMenuItem";
            this.aBMComisiónToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aBMComisiónToolStripMenuItem.Text = "ABM Comisión";
            this.aBMComisiónToolStripMenuItem.Click += new System.EventHandler(this.aBMComisiónToolStripMenuItem_Click);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 371);
            this.Controls.Add(this.mnsPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Name = "formPrincipal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.formPrincipal_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrir;
        private System.Windows.Forms.ToolStripMenuItem aBMUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMMateriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMPersonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMEspecialidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMAlumnoInscripciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMModuloUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMDocenteCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem aBMMóduloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMComisiónToolStripMenuItem;
    }
}