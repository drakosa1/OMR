namespace OMR
{
    partial class MENU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MENU));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aRCHIVOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.northwindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasBásicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasIntermediasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasAvanzadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pubsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasBásicasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasIntermediasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasAvanzadasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_contenedor = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aRCHIVOToolStripMenuItem,
            this.northwindToolStripMenuItem,
            this.pubsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aRCHIVOToolStripMenuItem
            // 
            this.aRCHIVOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sALIRToolStripMenuItem});
            this.aRCHIVOToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aRCHIVOToolStripMenuItem.Image")));
            this.aRCHIVOToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aRCHIVOToolStripMenuItem.Name = "aRCHIVOToolStripMenuItem";
            this.aRCHIVOToolStripMenuItem.Size = new System.Drawing.Size(123, 29);
            this.aRCHIVOToolStripMenuItem.Text = "ARCHIVO";
            // 
            // sALIRToolStripMenuItem
            // 
            this.sALIRToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sALIRToolStripMenuItem.Image")));
            this.sALIRToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.sALIRToolStripMenuItem.Name = "sALIRToolStripMenuItem";
            this.sALIRToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.sALIRToolStripMenuItem.Text = "SALIR";
            this.sALIRToolStripMenuItem.Click += new System.EventHandler(this.sALIRToolStripMenuItem_Click);
            // 
            // northwindToolStripMenuItem
            // 
            this.northwindToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasBásicasToolStripMenuItem,
            this.consultasIntermediasToolStripMenuItem,
            this.consultasAvanzadasToolStripMenuItem});
            this.northwindToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("northwindToolStripMenuItem.Image")));
            this.northwindToolStripMenuItem.Name = "northwindToolStripMenuItem";
            this.northwindToolStripMenuItem.Size = new System.Drawing.Size(158, 29);
            this.northwindToolStripMenuItem.Text = "NORTHWIND";
            // 
            // consultasBásicasToolStripMenuItem
            // 
            this.consultasBásicasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultasBásicasToolStripMenuItem.Image")));
            this.consultasBásicasToolStripMenuItem.Name = "consultasBásicasToolStripMenuItem";
            this.consultasBásicasToolStripMenuItem.Size = new System.Drawing.Size(273, 30);
            this.consultasBásicasToolStripMenuItem.Text = "Consultas Básicas";
            this.consultasBásicasToolStripMenuItem.Click += new System.EventHandler(this.consultasBásicasToolStripMenuItem_Click);
            // 
            // consultasIntermediasToolStripMenuItem
            // 
            this.consultasIntermediasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultasIntermediasToolStripMenuItem.Image")));
            this.consultasIntermediasToolStripMenuItem.Name = "consultasIntermediasToolStripMenuItem";
            this.consultasIntermediasToolStripMenuItem.Size = new System.Drawing.Size(273, 30);
            this.consultasIntermediasToolStripMenuItem.Text = "Consultas intermedias";
            this.consultasIntermediasToolStripMenuItem.Click += new System.EventHandler(this.consultasIntermediasToolStripMenuItem_Click);
            // 
            // consultasAvanzadasToolStripMenuItem
            // 
            this.consultasAvanzadasToolStripMenuItem.Image = global::OMR.Properties.Resources.icons8_consultar_64__2_;
            this.consultasAvanzadasToolStripMenuItem.Name = "consultasAvanzadasToolStripMenuItem";
            this.consultasAvanzadasToolStripMenuItem.Size = new System.Drawing.Size(273, 30);
            this.consultasAvanzadasToolStripMenuItem.Text = "Consultas Avanzadas";
            this.consultasAvanzadasToolStripMenuItem.Click += new System.EventHandler(this.consultasAvanzadasToolStripMenuItem_Click);
            // 
            // pubsToolStripMenuItem
            // 
            this.pubsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultasBásicasToolStripMenuItem1,
            this.consultasIntermediasToolStripMenuItem1,
            this.consultasAvanzadasToolStripMenuItem1});
            this.pubsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pubsToolStripMenuItem.Image")));
            this.pubsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pubsToolStripMenuItem.Name = "pubsToolStripMenuItem";
            this.pubsToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.pubsToolStripMenuItem.Text = "PUBS";
            // 
            // consultasBásicasToolStripMenuItem1
            // 
            this.consultasBásicasToolStripMenuItem1.Image = global::OMR.Properties.Resources.icons8_consultar_64__2_;
            this.consultasBásicasToolStripMenuItem1.Name = "consultasBásicasToolStripMenuItem1";
            this.consultasBásicasToolStripMenuItem1.Size = new System.Drawing.Size(274, 30);
            this.consultasBásicasToolStripMenuItem1.Text = "Consultas Básicas";
            this.consultasBásicasToolStripMenuItem1.Click += new System.EventHandler(this.consultasBásicasToolStripMenuItem1_Click);
            // 
            // consultasIntermediasToolStripMenuItem1
            // 
            this.consultasIntermediasToolStripMenuItem1.Image = global::OMR.Properties.Resources.icons8_consulta_48;
            this.consultasIntermediasToolStripMenuItem1.Name = "consultasIntermediasToolStripMenuItem1";
            this.consultasIntermediasToolStripMenuItem1.Size = new System.Drawing.Size(274, 30);
            this.consultasIntermediasToolStripMenuItem1.Text = "Consultas Intermedias";
            this.consultasIntermediasToolStripMenuItem1.Click += new System.EventHandler(this.consultasIntermediasToolStripMenuItem1_Click);
            // 
            // consultasAvanzadasToolStripMenuItem1
            // 
            this.consultasAvanzadasToolStripMenuItem1.Name = "consultasAvanzadasToolStripMenuItem1";
            this.consultasAvanzadasToolStripMenuItem1.Size = new System.Drawing.Size(274, 30);
            this.consultasAvanzadasToolStripMenuItem1.Text = "Consultas Avanzadas";
            this.consultasAvanzadasToolStripMenuItem1.Click += new System.EventHandler(this.consultasAvanzadasToolStripMenuItem1_Click);
            // 
            // panel_contenedor
            // 
            this.panel_contenedor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_contenedor.BackgroundImage")));
            this.panel_contenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_contenedor.Location = new System.Drawing.Point(0, 27);
            this.panel_contenedor.Name = "panel_contenedor";
            this.panel_contenedor.Size = new System.Drawing.Size(853, 481);
            this.panel_contenedor.TabIndex = 2;
            this.panel_contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_contenedor_Paint);
            // 
            // MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 506);
            this.Controls.Add(this.panel_contenedor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MENU";
            this.Text = "Form4";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aRCHIVOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sALIRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem northwindToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasBásicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasIntermediasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pubsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasAvanzadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasBásicasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultasIntermediasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultasAvanzadasToolStripMenuItem1;
        private System.Windows.Forms.Panel panel_contenedor;
    }
}