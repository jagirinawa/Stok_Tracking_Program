using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace StokProgramiApp
{
    public partial class Product_Add : Form
    {
        public Product_Add()
        {
            InitializeComponent();
        }
        private static readonly HttpClient client = new HttpClient();
        private async void button1_ClickAsync(object sender, EventArgs e)
        {          
        var values = new Dictionary<string, string>
                {
                    { "name", textBox1.Text },
                    { "id_product_type", textBox2.Text },
                    {"serial_no", textBox3.Text },
                    {"product_stock", textBox4.Text }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:54012/api/Products/1", content);

            var responseString = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                 {
                     MessageBox.Show("You have been Added a Product Successfully");
                 }
                 else
                     MessageBox.Show("Invalid Property Values");
            }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult select = MessageBox.Show("Are You Sure Want to Return Main Menu? ", "Main Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (select == DialogResult.No)
            {

                return;
            }
            this.Hide();
            new Main_Menu().Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult select = MessageBox.Show("Are You Sure Want to Exit? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (select == DialogResult.No)
            {

                return;
            }
            Application.Exit();
        }
    }
}
