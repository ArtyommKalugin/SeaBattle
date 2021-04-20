using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace seaFight
{
    public partial class Form1 : Form
    {
        public Graphics graphics;

        public Graphics graphics2;

        public bool gameStarted = false;

        Pen mypen = new Pen(Brushes.Black);

        Font myFont = new Font("Arial", 14);

        public String[] letters = new String[] { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К" };

        public String[] numbers = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        public Player player;

        public Player bot;

        public static Random rnd;

        public Form1()
        {
            InitializeComponent();
            player = new Player();
            bot = new Player();
            player.map = new Map();
            bot.map = new Map();

            pictureBox1.Image = new Bitmap(440, 440);

            graphics = Graphics.FromImage(pictureBox1.Image);

            graphics.Clear(Color.White);

            for (int i = 0; i < 12; i++)
            {
                graphics.DrawLine(mypen, 0, 40 * (i + 1), pictureBox1.Width, 40 * (i + 1));
            }

            for (int i = 0; i < 10; i++)
            {
                graphics.DrawString(letters[i], myFont, Brushes.Black, new Point(10, 40 * (i + 2) - 30));
            }

            for (int i = 0; i < 12; i++)
            {
                graphics.DrawLine(mypen, 40 * (i + 1), 0, 40 * (i + 1), pictureBox1.Width);
            }

            for (int i = 0; i < 10; i++)
            {
                graphics.DrawString(numbers[i], myFont, Brushes.Black, new Point(40 * (i + 2) - 30, 10));
            }

            pictureBox2.Image = new Bitmap(440, 440);

            graphics2 = Graphics.FromImage(pictureBox2.Image);

            graphics2.Clear(Color.White);

            for (int i = 0; i < 12; i++)
            {
                graphics2.DrawLine(mypen, 0, 40 * (i + 1), pictureBox2.Width, 40 * (i + 1));
            }

            for (int i = 0; i < 10; i++)
            {
                graphics2.DrawString(letters[i], myFont, Brushes.Black, new Point(10, 40 * (i + 2) - 30));
            }

            for (int i = 0; i < 12; i++)
            {
                graphics2.DrawLine(mypen, 40 * (i + 1), 0, 40 * (i + 1), pictureBox2.Width);
            }

            for (int i = 0; i < 10; i++)
            {
                graphics2.DrawString(numbers[i], myFont, Brushes.Black, new Point(40 * (i + 2) - 30, 10));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                Point Cordinate = ((MouseEventArgs)e).Location;
                int X = Cordinate.X / 40;
                int Y = Cordinate.Y / 40;

                if (X >= 1 && Y >= 1 && player.map.point[X, Y].blocked == false)
                {
                    if (player.Ships.Count == 0)
                    {
                        SpawnShip(X, Y, 4);
                    }
                    else if (player.Ships.Count >= 1 && player.Ships.Count <= 2)
                    {
                        SpawnShip(X, Y, 3);
                    }
                    else if (player.Ships.Count >= 3 && player.Ships.Count <= 5)
                    {
                        SpawnShip(X, Y, 2);
                    }
                    else if (player.Ships.Count <= 9)
                    {
                        SpawnShip(X, Y, 1);
                    }
                }
            }
        }


        private void SpawnShip(int X, int Y, int length)
        {
            Ship ship = new Ship();
            player.Ships.Add(ship);

            if (CheckRight(X, Y, length))
            {
                for (int i = 0; i < length; i++)
                {
                    ship.decks.Add(new Deck(ship, X + i, Y));
                    player.map.point[X + i, Y].deck = ship.decks[i];
                    graphics.FillRectangle(Brushes.Red, player.map.point[X + i, Y].x + 1, player.map.point[X + i, Y].y + 1, 39, 39);
                }
            }
            else
            if (CheckLeft(X, Y, length))
            {
                for (int i = 0; i < length; i++)
                {
                    ship.decks.Add(new Deck(ship, X - i, Y));
                    player.map.point[X - i, Y].deck = ship.decks[i];
                    graphics.FillRectangle(Brushes.Red, player.map.point[X - i, Y].x + 1, player.map.point[X - i, Y].y + 1, 39, 39);
                }
            }
            else
            if (CheckTop(X, Y, length))
            {
                for (int i = 0; i < length; i++)
                {
                    ship.decks.Add(new Deck(ship, X, Y - i));
                    player.map.point[X, Y - i].deck = ship.decks[i];
                    graphics.FillRectangle(Brushes.Red, player.map.point[X, Y - i].x + 1, player.map.point[X, Y - i].y + 1, 39, 39);
                }
            }
            else
            if (CheckBottom(X, Y, length))
            {
                for (int i = 0; i < length; i++)
                {
                    ship.decks.Add(new Deck(ship, X, Y + i));
                    player.map.point[X, Y + i].deck = ship.decks[i];
                    graphics.FillRectangle(Brushes.Red, player.map.point[X, Y + i].x + 1, player.map.point[X, Y + i].y + 1, 39, 39);
                }
            }


            pictureBox1.Refresh();
        }


        private bool CheckRight(int X, int Y, int length)
        {
            if (X > 11 - length)
                return false;

            for (int x = X; x <= X + length - 1; x++)
            {
                if (x >= 1 && player.map.point[x, Y].blocked)
                    return false;
            }

            return true;
        }

        private bool CheckLeft(int X, int Y, int length)
        {
            if (X < length)
                return false;

            for (int x = X; x >= X - length + 1; x--)
            {
                if (x <= 10 && player.map.point[x, Y].blocked)
                    return false;
            }

            return true;
        }

        private bool CheckTop(int X, int Y, int length)
        {
            if (Y < length)
                return false;

            for (int y = Y; y >= Y - length + 1; y--)
            {
                if (y <= 10 && player.map.point[X, y].blocked)
                    return false;
            }

            return true;
        }

        private bool CheckBottom(int X, int Y, int length)
        {
            if (Y > 11 - length)
                return false;

            for (int y = Y; y <= Y + length - 1; y++)
            {
                if (y >= 1 && player.map.point[X, y].blocked)
                    return false;
            }

            return true;
        }

    }
}
