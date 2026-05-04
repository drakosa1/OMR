using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace OMR
{
    public partial class frm_basicas_northwind : Form
    {
        //string cadena = "Server=localhost;Database=Northwind;Integrated Security=true;";
        string cadena = @"Server=.\SQLEXPRESS;Database=Northwind;Integrated Security=true;";
        public frm_basicas_northwind()
        {
            InitializeComponent();
        }

        private void frm_basicas_northwind_Load(object sender, EventArgs e)
        {
            this.Text = "Consultas Básicas - Northwind";
            this.BackColor = Color.WhiteSmoke;

            // TITULO
            Label titulo = new Label();
            titulo.Text = "CONSULTAS BÁSICAS - NORTHWIND";
            titulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            titulo.AutoSize = true;
            titulo.Location = new Point(250, 20);
            this.Controls.Add(titulo);

            // LABELS
            Label lbl1 = new Label() { Text = "ID Producto:", Location = new Point(250, 55), AutoSize = true };
            Label lbl2 = new Label() { Text = "Stock mínimo:", Location = new Point(400, 55), AutoSize = true };
            Label lbl3 = new Label() { Text = "País:", Location = new Point(550, 55), AutoSize = true };

            this.Controls.Add(lbl1);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl3);

            // TEXTBOX
            textBox1.Location = new Point(250, 75);
            textBox2.Location = new Point(400, 75);
            textBox3.Location = new Point(550, 75);

            textBox1.Text = "1";
            textBox2.Text = "10";
            textBox3.Text = "USA";

            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox3.TextAlign = HorizontalAlignment.Center;

            // BOTONES
            button1.Text = "Listar Clientes";
            button2.Text = "Buscar Producto";
            button3.Text = "Filtrar Stock";
            button4.Text = "Clientes por País";

            button1.Location = new Point(100, 110);
            button2.Location = new Point(250, 110);
            button3.Location = new Point(400, 110);
            button4.Location = new Point(550, 110);

            button1.Size = new Size(120, 32);
            button2.Size = new Size(130, 32);
            button3.Size = new Size(120, 32);
            button4.Size = new Size(140, 32);

            // ESTILO BOTONES PROFESIONAL
            Button[] botones = { button1, button2, button3, button4 };

            foreach (Button btn in botones)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(170, 190, 200);
                btn.ForeColor = Color.FromArgb(40, 40, 40);
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.UseVisualStyleBackColor = false;
            }

            //COLORES PASTEL
            button1.BackColor = Color.FromArgb(218, 238, 255); // celeste
            button2.BackColor = Color.FromArgb(222, 246, 222); // verde
            button3.BackColor = Color.FromArgb(255, 239, 213); // durazno
            button4.BackColor = Color.FromArgb(230, 225, 255); // lila

            // EFECTO HOVER
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(190, 225, 250);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(195, 235, 195);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 220, 185);
            button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 205, 245);

            // EFECTO CLICK
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(170, 210, 240);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(175, 220, 175);
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(235, 205, 165);
            button4.FlatAppearance.MouseDownBackColor = Color.FromArgb(195, 190, 235);

            // GRID
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
        }

        // CONSULTA 1

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