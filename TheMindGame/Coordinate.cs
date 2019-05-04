using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMindGame
{
    public class Coordinate
    {

        private int x;
        private int y;

        public Coordinate()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinate(Coordinate c)
        {
            this.X = c.X;
            this.Y = c.Y;
        }

        public int Compare(Coordinate c)
        {
            if (y < c.Y)
                return -1;
            else if (y == c.Y)
            {
                if (x < c.X)
                    return -1;
                else if (x == c.X)
                    return 0;
                else
                    return 1;
            }
            else
                return 1;
        }


        public Coordinate Add(Coordinate c)
        {
            return new Coordinate(x + c.X, y + c.Y);
        }

        public Coordinate Add(int dx, int dy)
        {
            return new Coordinate(x + dx, y + dy);
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }
    }
}
