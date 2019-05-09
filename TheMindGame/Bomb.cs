using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMindGame
{
    class Bomb
    {
        private Coordinate coord;
        private bool isActivated;
        private int radius;


        public Bomb(int x, int y)
        {
            this.Coord = new Coordinate(x, y);
            IsActivated = false;
            Radius = 3;
        }

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

        public bool IsActivated
        {
            get
            {
                return isActivated;
            }

            set
            {
                isActivated = value;
            }
        }

        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
            }
        }
    }
}
