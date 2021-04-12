using System;
using System.Collections.Generic;

namespace seaFight
{
    public class Map
    {
        public List<GameObject> GameObjects = new List<GameObject>();
        public Cell[,] point;
        public int Width = 440;
        public int Height = 440;
        static Random rnd = new Random();

        public Map()
        {
            CreateMap();
        }

        public void CreateMap()
        {
            point = new Cell[12, 12];
            for (int x = 1; x <= 11; x++)
                for (int y = 1; y <= 11; y++)
                {
                    point[x, y] = new Cell(x * 40, y * 40);
                }
        }
    }
}
