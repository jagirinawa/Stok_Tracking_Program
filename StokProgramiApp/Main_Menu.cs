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


namespace StokProgramiApp
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                var f3 = new Product_Update();
            this.Hide();
            f3.Show();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f4 = new Product_Add();
            this.Hide();
            f4.Show();

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            var f6 = new Add_Stock();
            this.Hide();
            f6.Show();
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
    }
}
