using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMindGame
{
    class Player
    {
        private Coordinate coord;

        public Coordinate Coord
        {
            get
            {
                return coord;
            }

            set
            {
                coord = value;
            }
        }

        public void setCoord(Coordinate c)
        {
            coord = new Coordinate(c);
        }

        public void setCoord(int x, int y)
        {
            coord = new Coordinate(x, y);
        }

        public int X
        {
            get
            {
                return Coord.X;
            }

            
           
        }

        public int Y
        {
            get
            {
                return Coord.Y;
            }

            
        }


    }
}
