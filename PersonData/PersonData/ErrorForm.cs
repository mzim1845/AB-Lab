﻿using System;
using System.Windows.Forms;

namespace People
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string error)
        {
            InitializeComponent();
            rtbError.Text = error;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
