﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokProgramiApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                var f3 = new Form3();
            f3.Show();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f4 = new Form4();
            f4.Show();

        }
    }
}
