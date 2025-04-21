﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image2Text
{
    public partial class TextDialog : Form
    {
        public TextDialog()
        {
            InitializeComponent();         
        }

        private void buttonCopyClose_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox.Text);
            this.Close();
        }
    }
}
