using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotsAndBoxes.Properties;
using System.Media;

namespace DotsAndBoxes
{
    public partial class KraenRezultat : Form
    {
        public SoundPlayer My_sound2 = new SoundPlayer(Resources.TaDa); 

        public KraenRezultat(string kraenRez, int rezp1, int rezp2, string pob)
        {
            InitializeComponent();            
            textBox1.Text = kraenRez;
            lblRez.Text = string.Format("{0} : {1}", rezp1, rezp2);
            lblPobednik.Text = pob;
            My_sound2.Play();           
            
        }

        protected override void OnClosed(EventArgs e)
        {
            
        }

        
    }
}
