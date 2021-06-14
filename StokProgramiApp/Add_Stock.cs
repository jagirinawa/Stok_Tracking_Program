
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http;

namespace StokProgramiApp
{
    public partial class Add_Stock : Form
    {
        public event System.Windows.Forms.DataGridViewCellMouseEventHandler RowHeaderMouseClick;

        SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        
        SqlDataAdapter adapt;
        DataTable dt;

        public Add_Stock()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54012/");
            HttpResponseMessage response = client.GetAsync("api/Products").Result;
            var pro = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = pro;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            con.Open();
            adapt = new SqlDataAdapter("select * from Product", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            con.Open();
            SqlCommand cmd = new SqlCommand(" UPDATE Product  SET product_Stock = product_stock + @a2 WHERE serial_no = @a3 ", con);
            cmd.Parameters.Add("a2", Convert.ToInt32(textBox2.Text));
            cmd.Parameters.Add("a3", textBox1.Text);
            cmd.ExecuteNonQuery();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54012/");
            HttpResponseMessage response = client.GetAsync("api/Products").Result;
            var pro = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = pro;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            con.Open();
            adapt = new SqlDataAdapter("select * from Product where name like '" + textBox3.Text + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["serial_no"].Value.ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            con.Open();
            adapt = new SqlDataAdapter("select * from Product where serial_no like '" + textBox4.Text + "%'", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            con.Open();
            SqlCommand cmd = new SqlCommand(" UPDATE Product  SET product_Stock = product_stock - @a2 WHERE serial_no = @a3 ", con);
            cmd.Parameters.Add("a2", Convert.ToInt32(textBox2.Text));
            cmd.Parameters.Add("a3", textBox1.Text);
            cmd.ExecuteNonQuery();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54012/");
            HttpResponseMessage response = client.GetAsync("api/Products").Result;
            var pro = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = pro;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult select = MessageBox.Show("Are You Sure Want to Exit? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (select == DialogResult.No)
            {

                return;
            }
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult select = MessageBox.Show("Are You Sure Want to Return Main Menu? ", "Main Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (select == DialogResult.No)
            {

                return;
            }
            this.Hide();
            new Main_Menu().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}