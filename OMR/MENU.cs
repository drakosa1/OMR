using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMR
{
    public partial class MENU : Form
    {
        public MENU()
        {
            InitializeComponent();
        }

        private void consultasIntermediasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_intermedias_norw frm = new frm_intermedias_norw();
            //frm.Show();
            AbrirFormularioEnPanel(new frm_intermedias_norw());

        }

        private void consultasBásicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_basicas_northwind frm = new frm_basicas_northwind();
            //frm.Show();
            AbrirFormularioEnPanel(new frm_basicas_northwind());

        }

        private void consultasAvanzadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm_avanzadas_norw frm = new frm_avanzadas_norw();
            //frm.Show();
            AbrirFormularioEnPanel(new frm_avanzadas_norw());

        }

        private void consultasBásicasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frm_basicas_pubs frm = new frm_basicas_pubs();
            //frm.Show();
            AbrirFormularioEnPanel(new frm_basicas_pubs());


        }

        private void consultasIntermediasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frm_intermedias_pubs frm = new frm_intermedias_pubs();
            //frm.Show();
            AbrirFormularioEnPanel(new frm_intermedias_pubs());

        }

        private void consultasAvanzadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frm_avanzadas_pubs frm = new frm_avanzadas_pubs();
            //frm.Show();

            AbrirFormularioEnPanel(new frm_avanzadas_pubs());
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            panel_contenedor.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panel_contenedor.Controls.Add(formulario);
            panel_contenedor.Tag = formulario;

            formulario.Show();
        }

        private void panel_contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
