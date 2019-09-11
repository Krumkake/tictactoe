using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tre_på_rad_V1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[,] board = new string[3, 3];
        string player = "X";
        
        
        bool spiller1 = true; //Setter x
        private void btnBoard(object sender, EventArgs e)
        {
            Button b = sender as Button;

            
            if (b.Text == "")
            {
                setBoard(b);
                if (spiller1)
                {
                    b.Text = player;
                    player = "O";

                }
                else
                {
                    b.Text = player;
                    player = "X";
                }
                spiller1 = !spiller1;
            }
         if (checkWin())
            {
                label1.Text = "WIN";
            }
            
        }
        private void setBoard(Button btn)
        {
            int xpos = Convert.ToInt16(btn.Name[btn.Name.Length - 2]);
            int ypos = Convert.ToInt16(btn.Name[btn.Name.Length - 1]);
            board[xpos, ypos] = "player";
        }
        private bool checkWin()
        {
            if (checkHor() || checkVert())
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkHor()
        {
            for (int i = 0; 1 < 3; i++)
            {
                int count = 0;
                for (int x = 0; x < 2; x++)
                {
                    if (board[x, i] == board[x + 1, i] && board[x, i] == player)
                    {
                        count++;
                    }
                    if (count == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private bool checkVert()
        {
            for (int i = 0; 1 < 3; i++)
            {
                int count = 0;
                for (int y = 0; y < 2; y++)
                {
                    if (board[i, y] == board[i, y + 1] && board[i, y] == player)
                    {
                        count++;
                        if (count == 2)
                        {
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        }
        
    }
}
