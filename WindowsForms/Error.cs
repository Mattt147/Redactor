﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Error : Form
    {
        public Error(string msg)
        {
            InitializeComponent();
            label2.Text = msg;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Error_Load(object sender, EventArgs e)
        {

        }
    }
}
