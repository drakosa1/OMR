using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OMR
{
    public partial class frm_intermedias_norw : Form
    {
        string cadena = "Server=localhost;Database=Northwind;Integrated Security=true;";

        public frm_intermedias_norw()
        {
            InitializeComponent();
        }

        // CONSULTA 1: Total de pedidos por cliente
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("spNW_TotalPedidosPorCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en consulta 1: " + ex.Message);
            }
        }

        // CONSULTA 2: Pedidos entre fechas
        // textBox1 = fecha inicio, ejemplo: 1996-07-01
        // textBox2 = fecha fin, ejemplo: 1997-01-01
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese fecha inicio y fecha fin");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("spNW_PedidosEntreFechas", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FechaInicio", DateTime.Parse(textBox1.Text.Trim()));
                    cmd.Parameters.AddWithValue("@FechaFin", DateTime.Parse(textBox2.Text.Trim()));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en consulta 2: " + ex.Message);
            }
        }

        // CONSULTA 3: Productos con categoría y proveedor
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("spNW_ProductosCategoriaProveedor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en consulta 3: " + ex.Message);
            }
        }
    }
}
