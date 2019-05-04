using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMindGame
{
    public enum TileType
    {
        EMPTY, WALL, TELEPORTER, MUD, EXIT
    }


    public abstract class Tile
    {
        private Coordinate pos;
        private bool isTraversable;
        public int X
        {
            get
            {
                return pos.X;
            }

         
        }
        public int Y
        {
            get
            {
                return pos.Y;
            }


        }




        public abstract TileType getType();

        protected Coordinate Pos
        {
            get
            {
                return pos;
            }

            set
            {
                pos = value;
            }
        }

        public  bool IsTraversable
        {
            get
            {
                return isTraversable;
            }

            set
            {
                isTraversable = value;
            }
        }

        protected Tile(int x, int y, bool isTraversable)
        {
            Pos = new Coordinate(x, y);
            this.IsTraversable = isTraversable;
                
        }

    }

    public class Empty : Tile
    {
        public Empty(int x, int y) : base(x, y, true)
        {
            
        }

        override
        public TileType getType()
        {
            return TileType.EMPTY;
        }
    }

    public class Wall : Tile
    {
        public Wall(int x, int y) : base(x, y, false)
        {

        }
        override
        public TileType getType()
        {
            return TileType.WALL;
        }
    }


    public class Teleporter : Tile
    {

        private Coordinate destination;
        public Teleporter(int x, int y, int destX, int destY) : base(x, y, true)
        {
            this.destination = new Coordinate(destX, destY);
        }

        public Coordinate Destination
        {
            get
            {
                return destination;
            }
        }

        override
        public TileType getType()
        {
            return TileType.TELEPORTER;
        }
    }

    public class Mud : Tile
    {
        public Mud(int x, int y) : base(x, y, true)
        {

        }

        override
        public TileType getType()
        {
            return TileType.MUD;
        }
    }
    public class Exit : Tile
    {
        public Exit(int x, int y) : base(x, y, true)
        {

        }

        override
        public TileType getType()
        {
            return TileType.EXIT;
        }
    }
}
