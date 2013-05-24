﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotsAndBoxes
{
    public partial class Form1 : Form
    {
        public Igrac ig1;
        public Igrac ig2;

        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.Blue;                 
        }
        
        private void panel1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                panel2.BackColor = colorDialog2.Color;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (panel1.BackColor.Equals(panel2.BackColor))
            {
                MessageBox.Show("Мора да изберете различни бои!");
            }
            else
            {
                ig1 = new Igrac(txtImeP1.Text, panel1.BackColor, 0);
                ig2 = new Igrac(txtImeP2.Text, panel2.BackColor, 0);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                NewGame ng = new NewGame(ig1, ig2);
                ng.ShowDialog();
            }
        }            
    }
}
