using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;

namespace DotsAndBoxes
{
    public partial class NewGame : Form
    {
        public GameState gs {get; set;}
        public Igrac i1 { get; set; }
        public Igrac i2 { get; set; }
        public Graphics dc;

        public NewGame(Igrac ig1, Igrac ig2)
        {
            InitializeComponent();
            txtRez.Font = new System.Drawing.Font("Ariel", 30);
            lblP1.Font = new System.Drawing.Font("Ariel", 12);
            lblP2.Font = new System.Drawing.Font("Ariel", 12);
            lblP1.ForeColor = ig1.Boja;
            lblP2.ForeColor = ig2.Boja;
            lblP1.Text = ig1.Ime;
            lblP2.Text = ig2.Ime;            
            i1 = ig1;
            i2 = ig2;
            gs = new GameState(i1, i2, 1); 
        }

        // Boenje na panelite
        private void p12_Click(object sender, EventArgs e)
        {
            klik(p12, 1, 2);                              
        }
        
        private void p14_Click(object sender, EventArgs e)
        {
            klik(p14, 1, 4);
        }

        private void p16_Click(object sender, EventArgs e)
        {
            klik(p16, 1, 6);
        }

        private void p21_Click(object sender, EventArgs e)
        {
            klik(p21, 2, 1);   
        }

        private void p23_Click(object sender, EventArgs e)
        {
            klik(p23, 2, 3);   
        }

        private void p25_Click(object sender, EventArgs e)
        {
            klik(p25, 2, 5);
        }

        private void p27_Click(object sender, EventArgs e)
        {
            klik(p27, 2, 7);
        }

        private void p32_Click(object sender, EventArgs e)
        {
            klik(p32, 3, 2);
        }

        private void p34_Click(object sender, EventArgs e)
        {
            klik(p34, 3, 4);
        }

        private void p36_Click(object sender, EventArgs e)
        {
            klik(p36, 3, 6);
        }

        private void p41_Click(object sender, EventArgs e)
        {
            klik(p41, 4, 1); 
        }

        private void p43_Click(object sender, EventArgs e)
        {
            klik(p43, 4, 3);
        }

        private void p45_Click(object sender, EventArgs e)
        {
            klik(p45, 4, 5);
        }

        private void p47_Click(object sender, EventArgs e)
        {
            klik(p47, 4, 7);
        }

        private void p52_Click(object sender, EventArgs e)
        {
            klik(p52, 5, 2);
        }

        private void p54_Click(object sender, EventArgs e)
        {
            klik(p54, 5, 4);
        }

        private void p56_Click(object sender, EventArgs e)
        {
            klik(p56, 5, 6);
        }

        private void p61_Click(object sender, EventArgs e)
        {
            klik(p61, 6, 1);
        }

        private void p63_Click(object sender, EventArgs e)
        {
            klik(p63, 6, 3);
        }

        private void p65_Click(object sender, EventArgs e)
        {
            klik(p65, 6, 5);
        }

        private void p67_Click(object sender, EventArgs e)
        {
            klik(p67, 6, 7);
        }

        private void p72_Click(object sender, EventArgs e)
        {
            klik(p72, 7, 2);
        }

        private void p74_Click(object sender, EventArgs e)
        {
            klik(p74, 7, 4);
        }

        private void p76_Click(object sender, EventArgs e)
        {
            klik(p76, 7, 6);
        }

        
        //Funk pri klik
        public void klik(Panel pan, int x, int y)
        {
            if (pan.BackColor == Color.Gray)
            {
                
                    gs.matrix[x, y] = '1';
                    if (gs.turn == 1)
                    {
                        pan.BackColor = gs.ig1.Boja;
                        gs.turn = 0;
                    }
                    else
                    {
                        pan.BackColor = gs.ig2.Boja;
                        gs.turn = 1;
                    }                
                               

                if (gs.proveriAzurZatvoranje(x, y) != null)
                {
                    this.crtanjeX(gs.proveriAzurZatvoranje(x, y), pan);
                    if (gs.turn == 1)
                    {
                        gs.turn = 0;
                        if (gs.proveriAzurZatvoranje(x, y).Length == 2)
                            gs.ig2.Score += 2;
                        else gs.ig2.Score += 1;                        
                        txtRez.Text = string.Format("{0}:{1}", gs.ig1.Score, gs.ig2.Score);
                    }
                    else
                    {
                        gs.turn = 1;
                        if (gs.proveriAzurZatvoranje(x, y).Length == 2)
                            gs.ig1.Score += 2;
                        else gs.ig1.Score += 1;
                        txtRez.Text = string.Format("{0}:{1}", gs.ig1.Score, gs.ig2.Score);
                    }
                }
            }
        }


        // Za crtanje na x vo osvojuvacka boja
        public void crtanjeX(string str, Panel pan)
        {
            
            if (str.Equals("u"))
            {
                Point dL = new Point(pan.Location.X + 10, pan.Location.Y - 10);
                Point dD = new Point(pan.Location.X + 60, pan.Location.Y - 10);
                Point gL = new Point(pan.Location.X + 10, pan.Location.Y - 60);
                Point gD = new Point(pan.Location.X + 60, pan.Location.Y - 60);
                
                Pen p = new Pen(pan.BackColor,10);
                Graphics dc = this.CreateGraphics();
                dc.DrawLine(p, gL, dD);
                dc.DrawLine(p, gD, dL);
            }
            else if (str.Equals("d"))
            {
                Point dL = new Point(pan.Location.X + 10, pan.Location.Y + 70);
                Point dD = new Point(pan.Location.X + 60, pan.Location.Y + 70);
                Point gL = new Point(pan.Location.X + 10, pan.Location.Y + 20);
                Point gD = new Point(pan.Location.X + 60, pan.Location.Y + 20);

                Pen p = new Pen(pan.BackColor, 10);
                Graphics dc = this.CreateGraphics();
                dc.DrawLine(p, gL, dD);
                dc.DrawLine(p, gD, dL);                
            }
            else if (str.Equals("l"))
            {
                Point dL = new Point(pan.Location.X - 60, pan.Location.Y + 60);
                Point dD = new Point(pan.Location.X - 10, pan.Location.Y + 60);
                Point gL = new Point(pan.Location.X - 60, pan.Location.Y + 10);
                Point gD = new Point(pan.Location.X - 10, pan.Location.Y + 10);

                Pen p = new Pen(pan.BackColor, 10);
                Graphics dc = this.CreateGraphics();
                dc.DrawLine(p, gL, dD);
                dc.DrawLine(p, gD, dL);            
            }
            else if (str.Equals("r"))
            {
                Point dL = new Point(pan.Location.X + 20, pan.Location.Y + 60);
                Point dD = new Point(pan.Location.X + 70, pan.Location.Y + 60);
                Point gL = new Point(pan.Location.X + 20, pan.Location.Y + 10);
                Point gD = new Point(pan.Location.X + 70, pan.Location.Y + 10);

                Pen p = new Pen(pan.BackColor, 10);
                Graphics dc = this.CreateGraphics();
                dc.DrawLine(p, gL, dD);
                dc.DrawLine(p, gD, dL);
            }
            else if (str.Equals("rl"))
            {
                Point dL = new Point(pan.Location.X - 60, pan.Location.Y + 60);
                Point dD = new Point(pan.Location.X - 10, pan.Location.Y + 60);
                Point gL = new Point(pan.Location.X - 60, pan.Location.Y + 10);
                Point gD = new Point(pan.Location.X - 10, pan.Location.Y + 10);

                Point dL1 = new Point(pan.Location.X + 20, pan.Location.Y + 60);
                Point dD1 = new Point(pan.Location.X + 70, pan.Location.Y + 60);
                Point gL1 = new Point(pan.Location.X + 20, pan.Location.Y + 10);
                Point gD1 = new Point(pan.Location.X + 70, pan.Location.Y + 10);

                Pen p = new Pen(pan.BackColor, 10);
                Graphics dc = this.CreateGraphics();
                dc.DrawLine(p, gL, dD);
                dc.DrawLine(p, gD, dL);
                dc.DrawLine(p, gL1, dD1);
                dc.DrawLine(p, gD1, dL1);
                
            }
            else if (str.Equals("ud"))
            {
                Point dL = new Point(pan.Location.X + 10, pan.Location.Y - 10);
                Point dD = new Point(pan.Location.X + 60, pan.Location.Y - 10);
                Point gL = new Point(pan.Location.X + 10, pan.Location.Y - 60);
                Point gD = new Point(pan.Location.X + 60, pan.Location.Y - 60);

                Point dL1 = new Point(pan.Location.X + 10, pan.Location.Y + 70);
                Point dD1 = new Point(pan.Location.X + 60, pan.Location.Y + 70);
                Point gL1 = new Point(pan.Location.X + 10, pan.Location.Y + 20);
                Point gD1 = new Point(pan.Location.X + 60, pan.Location.Y + 20);

                Pen p = new Pen(pan.BackColor, 10);
                Graphics dc = this.CreateGraphics();
                dc.DrawLine(p, gL, dD);
                dc.DrawLine(p, gD, dL);
                dc.DrawLine(p, gL1, dD1);
                dc.DrawLine(p, gD1, dL1);
            }
        }

        
        
     }
}
