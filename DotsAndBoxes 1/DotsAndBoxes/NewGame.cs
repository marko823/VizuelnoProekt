using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Media;
using DotsAndBoxes.Properties;

namespace DotsAndBoxes
{
    public partial class NewGame : Form
    {        
        public Graphics dc;
        public GameState gs { get; set; }
        public int Turn;
        public int brRunda;
        public int Rundi;
        public KraenRez Rezultat = new KraenRez();
        

        public SoundPlayer My_sound1 = new SoundPlayer(Resources.button_15);
        public SoundPlayer My_sound2 = new SoundPlayer(Resources.TaDa);

        public NewGame(Igrac ig1, Igrac ig2, int tipIgra, int turn, int rundi, int brrunda)
        {
            InitializeComponent();
            dc = this.CreateGraphics();            

            ig1.Score = 0;
            ig2.Score = 0;
            txtP1score.Text = ig1.Score.ToString();
            txtP2score.Text = ig2.Score.ToString();

            Rundi = rundi;
            Turn = turn;

            brRunda = brrunda;            

            settings(ig1, ig2, turn, tipIgra);            
            gs = new GameState(ig1, ig2, turn, tipIgra); 
        }

        public void settings(Igrac ig1, Igrac ig2, int turn, int tIgra)
        {
            txtRez.Font = new System.Drawing.Font("Ariel", 30);
            txtP1.Text = ig1.Ime;
            txtP2.Text = ig2.Ime;            
            txtRez.Text = "0:0";
            if (turn == 1)
            {
                txtP1.BackColor = ig1.Boja;
                txtP2.BackColor = Color.WhiteSmoke;           
            }
            if (turn == 0)
            {
                txtP1.BackColor = Color.WhiteSmoke;
                txtP2.BackColor = ig2.Boja;
            }            

            if (tIgra == 0)
            {
                p01.BackColor = this.BackColor; p03.BackColor = this.BackColor; p05.BackColor = this.BackColor; p07.BackColor = this.BackColor;
                p10.BackColor = this.BackColor; p12.BackColor = this.BackColor; p14.BackColor = this.BackColor; p16.BackColor = this.BackColor; p18.BackColor = this.BackColor;
                p30.BackColor = this.BackColor; p50.BackColor = this.BackColor; p70.BackColor = this.BackColor;
                p21.BackColor = this.BackColor; p41.BackColor = this.BackColor; p61.BackColor = this.BackColor; p81.BackColor = this.BackColor;
                p49.BackColor = this.BackColor; p510.BackColor = this.BackColor; p69.BackColor = this.BackColor;
                p94.BackColor = this.BackColor; p105.BackColor = this.BackColor; p96.BackColor = this.BackColor;
            }
            if (tIgra == 1)
            {
                p49.BackColor = this.BackColor; p510.BackColor = this.BackColor; p69.BackColor = this.BackColor;
                p94.BackColor = this.BackColor; p105.BackColor = this.BackColor; p96.BackColor = this.BackColor;                
            }

            if (tIgra == 2)
            {
                p01.BackColor = this.BackColor; p03.BackColor = this.BackColor; p07.BackColor = this.BackColor;
                p10.BackColor = this.BackColor; p12.BackColor = this.BackColor; p18.BackColor = this.BackColor;
                p30.BackColor = this.BackColor; p70.BackColor = this.BackColor;
                p21.BackColor = this.BackColor; p81.BackColor = this.BackColor;                
            }                    
        }

        //Funk pri klik
        public void klik(Panel pan, int x, int y)
        {            
            if (pan.BackColor == Color.Gray)
            {
                gs.matrix[x, y] = '1';                
                if (gs.proveriAzurZatvoranje(x, y) != null)
                {
                    My_sound1.Play();
                    if (gs.turn == 1)
                    {
                        pan.BackColor = gs.ig1.Boja;
                        txtP1.BackColor = gs.ig1.Boja;
                        txtP2.BackColor = Color.WhiteSmoke;
                        this.crtanjeX(gs.proveriAzurZatvoranje(x, y), pan);
                        if (gs.proveriAzurZatvoranje(x, y).Length == 2)
                            gs.ig1.Score += 2;
                        else gs.ig1.Score += 1;                        
                    }
                    else
                    {
                        pan.BackColor = gs.ig2.Boja;
                        txtP2.BackColor = gs.ig2.Boja;
                        txtP1.BackColor = Color.WhiteSmoke;
                        this.crtanjeX(gs.proveriAzurZatvoranje(x, y), pan);
                        if (gs.proveriAzurZatvoranje(x, y).Length == 2)
                            gs.ig2.Score += 2;
                        else gs.ig2.Score += 1;                        
                    }
                    txtRez.Text = string.Format("{0}:{1}", gs.ig1.Score, gs.ig2.Score);
                }
                    
                else if (gs.turn == 1)
                {
                    pan.BackColor = gs.ig1.Boja;
                    txtP2.BackColor = gs.ig2.Boja;
                    txtP1.BackColor = Color.WhiteSmoke;
                    gs.turn = 0;
                }
                else
                {
                    pan.BackColor = gs.ig2.Boja;
                    txtP1.BackColor = gs.ig1.Boja;
                    txtP2.BackColor = Color.WhiteSmoke;
                    gs.turn = 1;
                }                
            }
        }


        // Za crtanje na x ili o vo osvojuvacka boja
        public void crtanjeX(string str, Panel pan)
        {
            Graphics dc = this.CreateGraphics();
            if (str.Equals("u"))
            {
                
                if (gs.ig1.Boja == pan.BackColor)
                {
                    Point dL = new Point(pan.Location.X + 10, pan.Location.Y - 10);
                    Point dD = new Point(pan.Location.X + 60, pan.Location.Y - 10);
                    Point gL = new Point(pan.Location.X + 10, pan.Location.Y - 60);
                    Point gD = new Point(pan.Location.X + 60, pan.Location.Y - 60);

                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawLine(p, gL, dD);
                    dc.DrawLine(p, gD, dL);
                }
                else
                { 
                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawEllipse(p, pan.Location.X + 10, pan.Location.Y - 60, 50, 50);
                }
                
            }
            else if (str.Equals("d"))
            {
                
                if (gs.ig1.Boja == pan.BackColor)
                {
                    Point dL = new Point(pan.Location.X + 10, pan.Location.Y + 70);
                    Point dD = new Point(pan.Location.X + 60, pan.Location.Y + 70);
                    Point gL = new Point(pan.Location.X + 10, pan.Location.Y + 20);
                    Point gD = new Point(pan.Location.X + 60, pan.Location.Y + 20);

                    Pen p = new Pen(pan.BackColor, 10);                    
                    dc.DrawLine(p, gL, dD);
                    dc.DrawLine(p, gD, dL);                
                }
                else
                {
                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawEllipse(p, pan.Location.X + 10, pan.Location.Y + 20, 50, 50);
                }                             
            }
            
            else if (str.Equals("l"))
            {
                
                if (gs.ig1.Boja == pan.BackColor)
                {
                    Point dL = new Point(pan.Location.X - 60, pan.Location.Y + 60);
                    Point dD = new Point(pan.Location.X - 10, pan.Location.Y + 60);
                    Point gL = new Point(pan.Location.X - 60, pan.Location.Y + 10);
                    Point gD = new Point(pan.Location.X - 10, pan.Location.Y + 10);

                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawLine(p, gL, dD);
                    dc.DrawLine(p, gD, dL);
                }
                else
                {
                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawEllipse(p, pan.Location.X - 60, pan.Location.Y + 10, 50, 50);                    
                }
                
            }
            else if (str.Equals("r"))
            {
                
                if (gs.ig1.Boja == pan.BackColor)
                {
                    Point dL = new Point(pan.Location.X + 20, pan.Location.Y + 60);
                    Point dD = new Point(pan.Location.X + 70, pan.Location.Y + 60);
                    Point gL = new Point(pan.Location.X + 20, pan.Location.Y + 10);
                    Point gD = new Point(pan.Location.X + 70, pan.Location.Y + 10);

                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawLine(p, gL, dD);
                    dc.DrawLine(p, gD, dL);
                }
                else
                {
                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawEllipse(p, pan.Location.X + 20, pan.Location.Y + 10, 50, 50);                    
                }
                
            }
            else if (str.Equals("rl"))
            {
                if (gs.ig1.Boja == pan.BackColor)
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
                    dc.DrawLine(p, gL, dD);
                    dc.DrawLine(p, gD, dL);
                    dc.DrawLine(p, gL1, dD1);
                    dc.DrawLine(p, gD1, dL1);
                }
                else
                {
                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawEllipse(p, pan.Location.X + 20, pan.Location.Y + 10, 50, 50);
                    dc.DrawEllipse(p, pan.Location.X - 60, pan.Location.Y + 10, 50, 50);                     
                }        

            }
            else if (str.Equals("ud"))
            {
                if (gs.ig1.Boja == pan.BackColor)
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
                    dc.DrawLine(p, gL, dD);
                    dc.DrawLine(p, gD, dL);
                    dc.DrawLine(p, gL1, dD1);
                    dc.DrawLine(p, gD1, dL1);
                }
                else 
                {
                    Pen p = new Pen(pan.BackColor, 10);
                    dc.DrawEllipse(p, pan.Location.X + 10, pan.Location.Y - 60, 50, 50);
                    dc.DrawEllipse(p, pan.Location.X + 10, pan.Location.Y + 20, 50, 50);                
                }                
            }
        }

        private void p23_Click(object sender, EventArgs e)
        {
            klik(p23, 2, 3);
            provPob();
        }

        private void p25_Click(object sender, EventArgs e)
        {
            klik(p25, 2, 5);
            provPob();
        }

        private void p27_Click(object sender, EventArgs e)
        {
            klik(p27, 2, 7);
            provPob();
        }

        private void p32_Click(object sender, EventArgs e)
        {
            klik(p32, 3, 2);
            provPob();
        }

        private void p34_Click(object sender, EventArgs e)
        {
            klik(p34, 3, 4);
            provPob();
        }

        private void p36_Click(object sender, EventArgs e)
        {
            klik(p36, 3, 6);
            provPob();
        }

        private void p38_Click(object sender, EventArgs e)
        {
            klik(p38, 3, 8);
            provPob();
        }

        private void p43_Click(object sender, EventArgs e)
        {
            klik(p43, 4, 3);
            provPob();
        }

        private void p45_Click(object sender, EventArgs e)
        {
            klik(p45, 4, 5);
            provPob();
        }

        private void p47_Click(object sender, EventArgs e)
        {
            klik(p47, 4, 7);
            provPob();
        }

        private void p52_Click(object sender, EventArgs e)
        {
            klik(p52, 5, 2);
            provPob();
        }

        private void p54_Click(object sender, EventArgs e)
        {
            klik(p54, 5, 4);
            provPob();
        }

        private void p56_Click(object sender, EventArgs e)
        {
            klik(p56, 5, 6);
            provPob();
        }

        private void p58_Click(object sender, EventArgs e)
        {
            klik(p58, 5, 8);
            provPob();
        }

        private void p63_Click(object sender, EventArgs e)
        {
            klik(p63, 6, 3);
            provPob();
        }

        private void p65_Click(object sender, EventArgs e)
        {
            klik(p65, 6, 5);
            provPob();
        }

        private void p67_Click(object sender, EventArgs e)
        {
            klik(p67, 6, 7);
            provPob();
        }

        private void p72_Click(object sender, EventArgs e)
        {
            klik(p72, 7, 2);
            provPob();
        }

        private void p74_Click(object sender, EventArgs e)
        {
            klik(p74, 7, 4);
            provPob();
        }

        private void p76_Click(object sender, EventArgs e)
        {
            klik(p76, 7, 6);
            provPob();
        }

        private void p78_Click(object sender, EventArgs e)
        {
            klik(p78, 7, 8);
            provPob();
        }

        private void p83_Click(object sender, EventArgs e)
        {
            klik(p83, 8, 3);
            provPob();
        }

        private void p85_Click(object sender, EventArgs e)
        {
            klik(p85, 8, 5);
            provPob();
        }

        private void p87_Click(object sender, EventArgs e)
        {
            klik(p87, 8, 7);
            provPob();
        }

        private void p01_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p01, 0, 1);
            provPob();
        }

        private void p03_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p03, 0, 3);
            provPob();
        }

        private void p07_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p07, 0, 7);
            provPob();
        }

        private void p10_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p10, 1, 0);
            provPob();
        }

        private void p12_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p12, 1, 2);
            provPob();
        }

        private void p18_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p18, 1, 8);
            provPob();
        }

        private void p21_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p21, 2, 1);
            provPob();
        }

        private void p30_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p30, 3, 0);
            provPob();
        }

        private void p70_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p70, 7, 0);
            provPob();
        }

        private void p81_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1)
                klik(p81, 8, 1);
            provPob();
        }

        private void p05_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1 || gs.tipIgra==2)
                klik(p05, 0, 5);
            provPob();
        }

        private void p14_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1 || gs.tipIgra == 2)
                klik(p14, 1, 4);
            provPob();
        }

        private void p16_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1 || gs.tipIgra == 2)
                klik(p16, 1, 6);
            provPob();
        }

        private void p41_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1 || gs.tipIgra == 2)
                klik(p41, 4, 1);
            provPob();
        }

        private void p50_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1 || gs.tipIgra == 2)
                klik(p50, 5, 0);
            provPob();
        }

        private void p61_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 1 || gs.tipIgra == 2)
                klik(p61, 6, 1);
            provPob();
        }

        private void p49_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 2)
                klik(p49, 4, 9);
            provPob();
        }

        private void p510_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 2)
                klik(p510, 5, 10);
            provPob();
        }

        private void p69_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 2)
                klik(p69, 6, 9);
            provPob();
        }

        private void p94_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 2)
                klik(p94, 9, 4);
            provPob();
        }

        private void p105_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 2)
                klik(p105, 10, 5);
            provPob();
        }

        private void p96_Click(object sender, EventArgs e)
        {
            if (gs.tipIgra == 2)
                klik(p96, 9, 6);
            provPob();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            dc.Clear(this.BackColor);
            foreach (var pan in this.Controls.OfType<Panel>())
            {
                pan.BackColor = Color.Gray;
            }

            gs.ig1.Score = 0;
            gs.ig2.Score = 0;            
            settings(gs.ig1, gs.ig2, Turn, gs.tipIgra);
            gs = new GameState(gs.ig1, gs.ig2, Turn, gs.tipIgra);            
        }

        public void provPob()
        {
            int total = gs.ig1.Score + gs.ig2.Score;
            int pbr = 0;
            Igrac pob;
            if (gs.ig1.Score > gs.ig2.Score)
            {
                pob = gs.ig1;
                pbr = 1;
            }
            else
            {
                pob = gs.ig2;
                pbr = 2;            
            }

            if (gs.tipIgra == 0 && total == 9)
            {
                My_sound2.Play();
                Rezultat.dodRezPob(txtRez.Text, pbr);
                MessageBox.Show("Победник е " + pob.Ime);
                this.Dispose();                
                if (brRunda + 1 > Rundi)
                    MessageBox.Show(Rezultat.ToString());
                else
                {
                    NewGame ng = new NewGame(gs.ig1, gs.ig2, gs.tipIgra, Turn, Rundi, brRunda + 1);
                    ng.ShowDialog();                
                }                
            }                
            else if (gs.tipIgra == 1 && total == 16)
            {
                My_sound2.Play();
                Rezultat.dodRezPob(txtRez.Text, pbr);
                MessageBox.Show("Победник е " + pob.Ime);
                this.Dispose();               
                if (brRunda + 1 > Rundi)
                    MessageBox.Show(Rezultat.ToString());
                else
                {
                    NewGame ng = new NewGame(gs.ig1, gs.ig2, gs.tipIgra, Turn, Rundi, brRunda + 1);
                    ng.ShowDialog();
                }                
            }
            else if (gs.tipIgra == 2 && total == 13)
            {
                My_sound2.Play();
                Rezultat.dodRezPob(txtRez.Text, pbr);
                MessageBox.Show("Победник е " + pob.Ime);
                this.Dispose();                
                if (brRunda + 1 > Rundi)
                    MessageBox.Show(Rezultat.ToString());
                else
                {
                    NewGame ng = new NewGame(gs.ig1, gs.ig2, gs.tipIgra, Turn, Rundi, brRunda + 1);
                    ng.ShowDialog();
                }                
            }
            
        }

        private void NewGame_Load(object sender, EventArgs e)
        {
            numRound runda = new numRound(brRunda);
            runda.TopMost = true;
            runda.Owner = this;
            runda.ShowDialog();
        }
     }
}
