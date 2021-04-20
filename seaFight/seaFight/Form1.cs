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

        Pen mypen = new Pen(Brushes.Black);

        Font myFont = new Font("Arial", 14);

        public String[] letters = new String[] { "А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "К" };

        public String[] numbers = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

        public Player player;

        public Player bot;

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

    }
}
