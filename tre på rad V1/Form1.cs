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
        int turnCount = 1;
        private void btnBoard(object sender, EventArgs e)
        {
            Button b = sender as Button;


            if (b.Text == "")
            {
                setBoard(b);
                b.Text = player;

            }
            if (checkWin())
            {
                label1.ForeColor = Color.Green;
                label1.Text = "spiller " + player + " Vant!";
                disable();
            }
            else
            {
                if (player == "X")
                {
                    player = "O";
                }
                else
                {
                    player = "X";
                }
                label1.Text = "spiller " + player + " runde";
            }
            turnCount++;
            b.Enabled = false;
            if (turnCount == 9)
            {
                label1.ForeColor = Color.Yellow;
                label1.Text = "UAVGJORT!";
                disable();
            }
        }
        private void setBoard(Button btn)
        {
            int xpos = btn.Name[btn.Name.Length - 2] - '0';
            int ypos = btn.Name[btn.Name.Length - 1] - '0';
            board[xpos, ypos] = player;
        }
        private bool checkWin()
        {
            if (checkHor() || checkVert() || checkDiagonal())
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        #region check
        private bool checkHor()
        {
            for (int i = 0; i < 3; i++)
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
            for (int i = 0; i < 3; i++)
            {
                int count = 0;
                for (int y = 0; y < 2; y++)
                {
                    if (board[i, y] == board[i, y + 1] && board[i, y] == player)
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
        private bool checkDiagonal()
        {
            int counter = 0;
            for (int i = 0; i < 2; i++) // Sjekker "\" diagonal
            {
                if (board[i, i] == board[i + 1, i + 1] && board[i, i] == player)
                    counter++;
            }
            if (counter == 2)
                return true;
            counter = 0;
            for (int i = 0; i < 2; i++) // Sjekker "/" diagonal
            {
                if (board[2 - i, i] == board[1 - i, i + 1] && board[2 - i, i] == player)
                    counter++;
            }
            if (counter == 2)
                return true;
            return false;
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnNyttSpill_Click(object sender, EventArgs e)
        {
            enable();
        }
        
        private void disable()
        {
            foreach (Control c in boardPanel.Controls)
            {
                if (c is Button)
                    c.Enabled = false;
            }
        }
        private void enable()
        {
            foreach (Control c in boardPanel.Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                    c.Enabled = true;
                }
                   
            }
            label1.Text = "spiller X runde";
            player = "X";
            turnCount = 1;
            label1.ForeColor = Color.Black;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = null;
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
