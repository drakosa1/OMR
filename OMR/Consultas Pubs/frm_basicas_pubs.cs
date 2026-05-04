using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OMR
{
    public partial class frm_basicas_pubs : Form
    {
        //string cadena1 = "Server=localhost;Database=pubs;Integrated Security=true;";
        string cadena1 = @"Server=.\SQLEXPRESS;Database=pubs;Integrated Security=true;";
        public frm_basicas_pubs()
        {
            InitializeComponent();
        }

        private void frm_basicas_pubs_Load(object sender, EventArgs e)
        {
            // Labels dinámicos
            Label lbl1 = new Label();
            lbl1.Text = "Buscar título por ID";
            lbl1.Location = new System.Drawing.Point(140, 10);
            this.Controls.Add(lbl1);

            Label lbl2 = new Label();
            lbl2.Text = "Precio mayor a:";
            lbl2.Location = new System.Drawing.Point(300, 10);
            this.Controls.Add(lbl2);

            Label lbl3 = new Label();
            lbl3.Text = "Editorial por país:";
            lbl3.Location = new System.Drawing.Point(460, 10);
            this.Controls.Add(lbl3);

            // Texto botones
            button1.Text = "Listar Autores";
            button2.Text = "Buscar Título";
            button3.Text = "Filtrar Precio";
            button4.Text = "Editorial por País";
        }
        // CONSULTA 1: LISTAR AUTORES
      
        /*private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena1))
                {
                    SqlCommand cmd = new SqlCommand("spPubs_ListarAutores", cn);
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
        }*/
        // CONSULTA 2: BUSCAR TÍTULO
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese ID del título (ej: BU1032)");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(cadena1))
                {
                    SqlCommand cmd = new SqlCommand("spPubs_BuscarTituloPorID", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@title_id", textBox1.Text);

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
        // CONSULTA 3: PRECIO MAYOR
        // =========================
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Ingrese precio mínimo");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(cadena1))
                {
                    SqlCommand cmd = new SqlCommand("spPubs_TitulosPrecioMayor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@price", decimal.Parse(textBox2.Text));

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
        // CONSULTA 4: EDITORIALES POR PAÍS
        // =========================
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Ingrese país (ej: USA)");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(cadena1))
                {
                    SqlCommand cmd = new SqlCommand("spPubs_EditorialesPorPais", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@country", textBox3.Text);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       private void button1_Click_1(object sender, EventArgs e)
       {
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena1))
                {
                    SqlCommand cmd = new SqlCommand("spPubs_ListarAutores", cn);
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
    }
}

