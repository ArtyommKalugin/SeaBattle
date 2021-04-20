using System;
using System.Collections.Generic;

namespace sea​Fight
{
    public class Player
    {
        public Map map;
        public List<Ship> Ships = new List<Ship>();

        public Player()
        {
            map = new Map();
        }
    }
}
