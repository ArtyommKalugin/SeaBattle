using System;
using System.Collections.Generic;

namespace sea​Fight
{
    public class Ship
    {
        public List<Deck> decks = new List<Deck>();
        public Player player;

        public Ship(Player Player)
        {
            player = Player;
        }

        public void Die()
        {
            player.Ships.Remove(this);
        }
    }
}
