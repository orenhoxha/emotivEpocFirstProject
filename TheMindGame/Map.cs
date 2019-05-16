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

        private Tile[,] map;
        private List<Teleporter> teleporters;
        private List<Bomb> bombs;
        private int width;
        private int height;

        public Map(string mapPath, Player player)
        {
            System.IO.StreamReader f = new System.IO.StreamReader(new FileStream(Path.Combine(mapPath, "map.txt"), FileMode.Open, FileAccess.Read));

            String sWidth = f.ReadLine();
            String sHeight = f.ReadLine();

            if (sWidth == null || sHeight == null) throw new Exception("Unexpected end of file");

            width = System.Convert.ToInt32(sWidth);
            height = System.Convert.ToInt32(sHeight);

            map = new Tile[Width, Height];

            teleporters = new List<Teleporter>();
            bombs = new List<Bomb>();

            parseMapfile(f, player);

            f.Close();
        }

        private void parseMapfile(StreamReader f, Player player)
        {
            string line;
            for (int y = 0; y < Height; y++)
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
                            player.setCoord(x * Utils.MOVES_PER_TILE, y * Utils.MOVES_PER_TILE);
                            map[x, y] = new Empty(x, y);
                            break;
                        case '#':
                            map[x, y] = new Wall(x, y);
                            break;
                        case '$':
                            map[x, y] = new Wall(x, y, false);
                            break;
                        default:
                            map[x, y] = new Empty(x, y);
                            break;


                    }
                }

            }

            int nbTeleporters = System.Convert.ToInt32(f.ReadLine());

            for (int i = 0; i < nbTeleporters; i++)
            {
                line = f.ReadLine();

                string[] tmp = line.Split(',');

                Teleporter t = new Teleporter(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]),
                    System.Convert.ToInt32(tmp[2]), System.Convert.ToInt32(tmp[3]));

                teleporters.Add(t);

            }

            int nbBombs = System.Convert.ToInt32(f.ReadLine());
            for (int i = 0; i < nbBombs; i++)
            {
                line = f.ReadLine();

                string[] tmp = line.Split(',');

                Bomb b = new Bomb(System.Convert.ToInt32(tmp[0]), System.Convert.ToInt32(tmp[1]));

                Bombs.Add(b);
            }

        }

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

        public List<Bomb> Bombs
        {
            get
            {
                return bombs;
            }
        }

        public List<Teleporter> Teleporters
        {
            get
            {
                return teleporters;
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

        public Bomb bombAt(Coordinate c)
        {
            foreach (Bomb b in bombs)
            {
                if (b.Coord.Compare(c) == 0)
                    return b;
            }

            return null;
        }

        public Teleporter teleporterAt(int x, int y)
        {

            foreach (Teleporter t in teleporters)
            {
                if (t.Pos.Compare(new Coordinate(x, y)) == 0) return t;

            }
            return null;
        }

        public void removeBomb(Bomb b)
        {
            bombs.Remove(b);
        }


        public void destroyInRadius(Coordinate c, int radius)
        {
            int sx = c.X - (radius - 1);
            int fx = c.X + (radius - 1);
            int sy = c.Y - (radius - 1);
            int fy = c.Y + (radius - 1);

            for (int x = sx; x <= fx; x++)
            {
                for (int y = sy; y <= fy; y++)
                {

                    if (x < width && y < height && x >= 0 && y >= 0)
                        if (map[x, y].getType() == TileType.WALL && ((Wall)map[x, y]).IsBreakable)
                            map[x, y] = new Empty(x, y);
                }
            }


        }

    }
}
