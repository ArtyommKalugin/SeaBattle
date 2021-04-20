using System;

namespace seaFight
{
    public class Deck
    {
        public int x;
        public int y;
        public Ship ship;

        public Deck(Ship Ship,int X,int Y)
        {
            ship = Ship;
            x = X;
            y = Y;
        }
    }
}
