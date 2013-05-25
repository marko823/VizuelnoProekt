using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DotsAndBoxes.Properties;
using System.Media;

namespace DotsAndBoxes
{
    public partial class numRound : Form
    {
        int numTicks = 0;        
        public SoundPlayer tick = new SoundPlayer(Resources.tick);
        public numRound(int brRunda)
        {
            InitializeComponent();            
            lblBrRunda.Text = brRunda.ToString();
            lblBroj.Visible = false;
            timer123.Start();            
        }

        private void timer123_Tick(object sender, EventArgs e)
        {
            numTicks++;
            if (numTicks == 1)
            {
                lblBrRunda.Visible = false;
                label1.Visible = false;
                lblBroj.Visible = true;
            }
            else if (numTicks == 5)
            {
                timer123.Stop();
                this.Close();            
            }
            else
            {
                tick.Play();
                lblBroj.Text = (numTicks - 1).ToString();            
            }                
        }
    }
}
