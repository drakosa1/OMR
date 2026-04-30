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
            frm_intermedias_norw frm = new frm_intermedias_norw();
            frm.Show();
        }

        private void consultasBásicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_basicas_northwind frm = new frm_basicas_northwind();
            frm.Show();
        }

        private void consultasAvanzadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_avanzadas_norw frm = new frm_avanzadas_norw();
            frm.Show();
        }

        private void consultasBásicasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_basicas_pubs frm = new frm_basicas_pubs();
            frm.Show();


        }

        private void consultasIntermediasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_intermedias_pubs frm = new frm_intermedias_pubs();
            frm.Show();
        }

        private void consultasAvanzadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_avanzadas_pubs frm = new frm_avanzadas_pubs();
            frm.Show();
        }
    }
}
