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

        public Map playerMap;

        public Form1()
        {
            InitializeComponent();
            playerMap = new Map();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
