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

        public GameState(Igrac i1, Igrac i2, int t)
        {
            ig1 = i1;
            ig2 = i2;
            turn = t;
            matrix = new char [8,8];
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    if ((i % 2 == 0) && (j % 2 == 1))
                        matrix[i,j] = '0';
                    else if ((i % 2 == 1) && (j % 2 == 0))
                        matrix[i,j] = '0';
                    else matrix[i, j] = 'x';
                }
            }
        }
        
        // Implementacija so konkretni indexi
        public string proveriAzurZatvoranje(int x, int y)
        {
            if ((x % 2 == 0) && (y % 2 == 1)) // prov Left Right
            {
                if (y!=1 && y!=7 && this.provAzurLeft(x, y) && this.provAzurRight(x, y))
                    return "rl";
                else if (y!=7 && this.provAzurRight(x, y))
                    return "r";
                else if (y == 7 && this.provAzurLeft(x, y))
                    return "l";
                else if (y!=1 && this.provAzurLeft(x, y))
                    return "l";
                else if (y == 1 && this.provAzurRight(x, y))
                    return "r";
            }

            else if ((x % 2 == 1) && (y % 2 == 0)) // prov Up Down
            {
                if (x!=1 && x!=7 && this.provAzurUp(x, y) && this.provAzurDown(x, y))
                    return "ud";
                else if (x != 1 && this.provAzurUp(x, y))
                    return "u";
                else if (x == 1 && this.provAzurDown(x, y))
                    return "d";
                else if (x != 7 && this.provAzurDown(x, y))
                    return "d";
                else if (x == 7 && this.provAzurUp(x, y))
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
    }
}
