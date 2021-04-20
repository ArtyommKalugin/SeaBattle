using System;
using System.Collections.Generic;

namespace seaFight
{
    public class Cell
    {
        public int x;
        public int y;
        public bool blocked;
        public Deck deck;

        public Cell(int X, int Y)
        {
            x = X;
            y = Y;
            blocked = false;
        }
    }
}
