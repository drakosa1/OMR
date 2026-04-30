using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OMR
{
    public partial class frm_basicas_northwind : Form
    {
        string cadena = "Server=localhost;Database=Northwind;Integrated Security=true;";

        public frm_basicas_northwind()
        {
            InitializeComponent();
        }

        private void frm_basicas_northwind_Load(object sender, EventArgs e)
        {
            // 🔹 Labels agregados por código
            Label lbl1 = new Label();
            lbl1.Text = "Buscar Producto por ID";
            lbl1.Location = new System.Drawing.Point(140, 10);
            this.Controls.Add(lbl1);

            Label lbl2 = new Label();
            lbl2.Text = "Stock mayor a:";
            lbl2.Location = new System.Drawing.Point(300, 10);
            this.Controls.Add(lbl2);

            Label lbl3 = new Label();
            lbl3.Text = "Clientes por país:";
            lbl3.Location = new System.Drawing.Point(460, 10);
            this.Controls.Add(lbl3);

            // 🔹 Texto botones
            button1.Text = "Listar Clientes";
            button2.Text = "Buscar Producto";
            button3.Text = "Filtrar Stock";
            button4.Text = "Clientes por País";
        }

        // =========================
        // CONSULTA 1
        // =========================
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("spNW_ListarClientes", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================
        // CONSULTA 2
        // =========================
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese ID");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("spNW_BuscarProductoPorID", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductID", int.Parse(textBox1.Text));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================
        // CONSULTA 3
        // =========================
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Ingrese stock");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("spNW_ProductosStockMayor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Stock", int.Parse(textBox2.Text));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================
        // CONSULTA 4
        // =========================
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Ingrese país");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("spNW_ClientesPorPais", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Country", textBox3.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}