using System;
using System.Collections.Generic;

namespace seaFight
{
    public class Cell
    {
        public int x;
        public int y;
        public GameObject ship;

        public Cell(int X, int Y)
        {
            x = X;
            y = Y;
            ship = null;
        }
    }
}
