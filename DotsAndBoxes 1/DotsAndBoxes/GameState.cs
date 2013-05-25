using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotsAndBoxes
{
    public class GameState
    {
        public char[,] matrix;
        public Igrac ig1;
        public Igrac ig2;
        public int turn;
        public int tipIgra;
        
        
        public GameState(Igrac i1, Igrac i2, int t, int tIgra)
        {
            ig1 = i1;
            ig2 = i2;
            turn = t;
            tipIgra = tIgra;
            matrix = new char [11,11];
            inicMatrica();
        }
        
        // Implementacija
        public string proveriAzurZatvoranje(int x, int y)
        {
            if (tipIgra == 1 && (x % 2 == 1) && y == 2 && this.provAzurRight(x, y) && this.provAzurLeft(x, y))
                return "rl";
            else if (tipIgra == 2 && ((x == 5 && y == 2) || (x == 5 && y == 8)) && this.provAzurRight(x, y) && this.provAzurLeft(x, y))
                return "rl";            

            else if ((x % 2 == 1) && (y % 2 == 0) && (x != 1 && x != 9) && (y != 0 && y != 10)) // prov Left Right
            {
                if (y != 2 && y != 8 && this.provAzurLeft(x, y) && this.provAzurRight(x, y))
                    return "rl";
                else if (y != 8 && this.provAzurRight(x, y))
                    return "r";
                else if (y == 8 && this.provAzurLeft(x, y))
                    return "l";
                else if (y != 2 && this.provAzurLeft(x, y))
                    return "l";
                else if (y == 2 && this.provAzurRight(x, y))
                    return "r";
            }

            else if (tipIgra == 1 && x == 2 && (y % 2 == 1) && this.provAzurUp(x, y) && this.provAzurDown(x, y))
                return "ud";
            else if (tipIgra == 2 && ((x == 2 && y == 5) || (x == 8 && y == 5)) && this.provAzurUp(x, y) && this.provAzurDown(x, y))
                return "ud";

            else if ((x % 2 == 0) && (y % 2 == 1) && (x != 0 && x != 10) && (y != 1 && y != 9)) // prov Up Down
            {
                if (x != 2 && x != 8 && this.provAzurUp(x, y) && this.provAzurDown(x, y))
                    return "ud";
                else if (x != 2 && this.provAzurUp(x, y))
                    return "u";
                else if (x == 2 && this.provAzurDown(x, y))
                    return "d";
                else if (x != 8 && this.provAzurDown(x, y))
                    return "d";
                else if (x == 8 && this.provAzurUp(x, y))
                    return "u";
            }

            //za kvadrat 4 x 4
            if (tipIgra == 1 && x != 10 && y != 9)
            {
                if ((x % 2 == 0) && (y % 2 == 1))// Up Down
                {
                    if (((x == 0) || (y == 1 && x != 8)) && this.provAzurDown(x, y))
                        return "d";
                    else if (((x == 2) || (y == 1 && x != 2 && x != 0)) && this.provAzurUp(x, y))
                        return "u";
                }

                else if ((x % 2 == 1) && (y % 2 == 0))
                {
                    if ((y == 0 || (x == 1 && y != 0 && y != 8)) && this.provAzurRight(x, y))
                        return "r";
                    else if ((y == 2 || (x == 1 && y != 0)) && this.provAzurLeft(x, y))
                        return "l"; 
                }
            }

            //za romb
            else if (tipIgra == 2)
            {
                if (((x == 5 && y == 0) || (x == 1 && y == 4) || (x == 9 && y == 4) || (x == 5 && y == 8)) && this.provAzurRight(x, y))
                    return "r";
                else if (((x == 5 && y == 10) || (x == 1 && y == 6) || (x == 9 && y == 6) || (x == 5 && y == 2)) && this.provAzurLeft(x, y))
                    return "l";
                else if (((x == 0 && y == 5) || (x == 4 && y == 1) || (x == 4 && y == 9) || (x == 8 && y == 5)) && this.provAzurDown(x, y))
                    return "d";
                else if (((x == 6 && y == 1) || (x == 10 && y == 5) || (x == 6 && y == 9) || (x == 2 && y == 5)) && this.provAzurUp(x, y))
                    return "u";                
            }
            return null;
        }        
        

        public bool provAzurUp(int x, int y)
        {
            if (matrix[x - 1, y - 1] == '1' && matrix[x - 2, y] == '1' && matrix[x - 1, y + 1] == '1')
            {
                matrix[x - 1, y] = 'T';
                return true;
            }
            else return false;      
        }

        public bool provAzurDown(int x, int y)
        {
            if (matrix[x + 1, y - 1] == '1' && matrix[x + 2, y] == '1' && matrix[x + 1, y + 1] == '1')
            {
                matrix[x + 1, y] = 'T';
                return true;
            }
            else return false; 
        }

        public bool provAzurLeft(int x, int y)
        {
            if (matrix[x - 1, y - 1] == '1' && matrix[x, y-2] == '1' && matrix[x + 1, y - 1] == '1')
            {
                matrix[x, y - 1] = 'T';
                return true;
            }
            else return false;
        }

        public bool provAzurRight(int x, int y)
        {
            if (matrix[x - 1, y + 1] == '1' && matrix[x, y + 2] == '1' && matrix[x + 1, y + 1] == '1')
            {
                matrix[x, y + 1] = 'T';
                return true;
            }
            else return false; 
        }
        
        public void inicMatrica()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (i != 0 && i != 1 && i != 9 && i != 10 && j != 0 && j != 1 && j != 9 && j != 10)// go popolnuva kvadratot za 3 x 3
                    {
                        if ((i % 2 == 0) && (j % 2 == 1))
                            matrix[i, j] = '0';
                        else if ((i % 2 == 1) && (j % 2 == 0))
                            matrix[i, j] = '0';
                        else matrix[i, j] = 'x';
                    }
                    else matrix[i, j] = 'x';// se drugo go stava x

                    if (tipIgra == 1) // dodava 1 redica i 1 kolana za 4 x 4
                    {

                        if ((i != 9 && i != 10) && (j != 9 && j != 10) && (i % 2 == 0) && (j % 2 == 1))
                            matrix[i, j] = '0';
                        else if ((j != 9 && j != 10) && (i != 9 && i != 10) && (i % 2 == 1) && (j % 2 == 0))
                            matrix[i, j] = '0';
                    }

                    else if (tipIgra == 2)// dodava 4 kvadrati za dijamant
                    {
                        matrix[1, 4] = '0';
                        matrix[0, 5] = '0';
                        matrix[1, 6] = '0';

                        matrix[4, 1] = '0';
                        matrix[5, 0] = '0';
                        matrix[6, 1] = '0';

                        matrix[4, 9] = '0';
                        matrix[5, 10] = '0';
                        matrix[6, 9] = '0';

                        matrix[9, 4] = '0';
                        matrix[10, 5] = '0';
                        matrix[9, 6] = '0';
                    }
                }
            }        
        }
    }
}
