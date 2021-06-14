using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Windows.Forms;
using System.Web.Http;

using System.Net;
using System.Data.SqlClient;

namespace StokProgramiApp
{
    public partial class Product_Update : Form
    {
        SqlCommand command;
        SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int id = 0;
        public Product_Update()
        {
            
            InitializeComponent();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54012/");
            HttpResponseMessage response = client.GetAsync("api/Products").Result;
            var pro = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = pro;
        }
        private static readonly HttpClient client = new HttpClient();
       
        void DeleteProduct(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            string sql = "DELETE FROM Product WHERE id=@id";
            command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@id", id);
            con.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("Product Deleted Successfully");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54012/");
            HttpResponseMessage response = client.GetAsync("api/Products").Result;
            var pro = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = pro;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54012/");
            HttpResponseMessage response = client.GetAsync("api/Stocks").Result;
            var sto = response.Content.ReadAsAsync<IEnumerable<Stock>>().Result;
            dataGridView1.DataSource = sto;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                foreach (DataGridViewRow drow in dataGridView1.SelectedRows) 
                {
                    int id = Convert.ToInt32(drow.Cells[0].Value);
                    DeleteProduct(id);
                }
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:54012/");
                HttpResponseMessage response = client.GetAsync("api/Products").Result;
                var pro = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                dataGridView1.DataSource = pro;
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           // HttpClient client = new HttpClient();
           // client.BaseAddress = new Uri("http://localhost:54012/");
           // HttpResponseMessage response = client.GetAsync("api/Stocks").Result;
           // var sto = response.Content.ReadAsAsync<IEnumerable<Stock>>().Result;
           // dataGridView1.DataSource = sto;
        }

        private  void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RIKU\RIKU;Initial Catalog=StokKontrolProgrami;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
            SqlCommand cmd = new SqlCommand(" UPDATE Product  SET name = @name,id_product_type=@id_product_type,serial_no=@serial_no WHERE id=@id ", con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", textBox4.Text);
            cmd.Parameters.AddWithValue("@id_product_type", textBox2.Text);
            cmd.Parameters.AddWithValue("@serial_no", textBox3.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product Updated Successfully");
            con.Close();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54012/");
            HttpResponseMessage response = client.GetAsync("api/Products").Result;
            var pro = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = pro;
        }
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.ReadOnly = true;
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
