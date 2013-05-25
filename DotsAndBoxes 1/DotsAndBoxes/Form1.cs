using System;
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
        public int turn = 1;
        public int Rundi = 1;
        

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
            if (cBoxTipIgra.SelectedIndex == -1)
            {
                MessageBox.Show("Мора да изберете тип на игра");
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                ig1 = new Igrac(txtImeP1.Text, panel1.BackColor, 0);
                ig2 = new Igrac(txtImeP2.Text, panel2.BackColor, 0);
                NewGame ng = new NewGame(ig1, ig2, cBoxTipIgra.SelectedIndex, turn, Rundi, 1 );
                ng.Show();                
            }
        }

        private void rBtnP1_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnP1.Checked == true)
            {
                turn = 1;
                rBtnP2.Checked = false;
            }
            else turn = 0;
        }

        private void rBtnP2_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnP2.Checked == true)
            {
                turn = 0;
                rBtnP1.Checked = false;
            }
            else turn = 1;
        }

        private void txtBrRundi_TextChanged(object sender, EventArgs e)
        {
            if (txtBrRundi.Text.Trim().Length != 0)
            {
                Rundi = int.Parse(txtBrRundi.Text);                
            }            
        }          
    }
}
