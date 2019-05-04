using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMindGame
{
    class Map
    {

        private Tile[, ] map;
        private List<Teleporter> teleporters;
        private int width;
        private int height;

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public Map(string mapPath, Player player)
        {
            string line;
            System.IO.StreamReader f = new System.IO.StreamReader(new FileStream(Path.Combine(mapPath,"map.txt"),FileMode.Open, FileAccess.Read));
            String sWidth = f.ReadLine();
            String sHeight = f.ReadLine();
            if (sWidth == null || sHeight == null) throw new Exception("oups");
            width = System.Convert.ToInt32(sWidth);
            height = System.Convert.ToInt32(sHeight);
            map = new Tile[Width, Height];
            teleporters = new List<Teleporter>();

      

            

            for(int y = 0; y < Height; y++)
            {

                line = f.ReadLine();
                
                

                for (int x = 0; x < Width; x++)
                {
                    char c = line[x];
                    switch (c)
                    {
                        case 'E':
                             map[x, y] = new Exit(x, y);
                             break;
                        case 'X':
                            player.setCoord(x*4, y*4);
                            map[x, y] = new Empty(x, y);
                            break;
                        case '#':
                            map[x, y] = new Wall(x, y);
                            break;
                        default:
                            map[x, y] = new Empty(x, y);
                            break;
                    }
                }
               
            }


            while((line = f.ReadLine()) != null)
            {

                
                string[] tmp = line.Split(',');

                Teleporter t = new Teleporter(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]),
                    System.Convert.ToInt32(tmp[2]), System.Convert.ToInt32(tmp[3]));

                teleporters.Add(t);
                map[t.X, t.Y] = t;

                t = new Teleporter(System.Convert.ToInt32(tmp[2]), System.Convert.ToInt32(tmp[3]),
                    System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));

                teleporters.Add(t);
                map[t.X, t.Y] = t;
            }
        }


        public TileType tileTypeAt(int x, int y)
        {
            return map[x, y].getType();
        }

        public Tile tileAt(int x, int y)
        {
            return map[x, y];
        }

    }
}
