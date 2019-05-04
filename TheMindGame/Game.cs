using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TheMindGame
{

    public enum MovingDirection
    {
        UP, DOWN, LEFT, RIGHT
    }

    public enum GameEventArgs
    {
        START, DRAW, WIN
    }


    public class Game
    {
        public event EventHandler<GameEventArgs> OnGameEventReceived;

        private Player player;
        private Map map;

        internal Player Player
        {
            get
            {
                return player;
            }

          
        }

        internal Map Map
        {
            get
            {
                return map;
            }
        }

        public Game()
        {
            player = new TheMindGame.Player();

            map = new Map(TheMindGame.LevelSelection.selectedlevelPath, Player);

               
        }

        public void start()
        {
            OnGameEventReceived(this, GameEventArgs.START);
        }


        private Coordinate toTileCoordinate(Coordinate c)
        {
            return new Coordinate(c.X / 4, c.Y / 4);
                
        }

        private bool outOfMap(Coordinate tmp)
        {
           return(tmp.X >= Map.Width || tmp.Y >= Map.Height || tmp.X < 0 || tmp.Y < 0);
        }

      

        public void move(MovingDirection direction)
        {
            switch (direction)
            {
                case MovingDirection.LEFT:
                    move(-1, 0, -1, 0, -1, 3);
                    break;
                case MovingDirection.RIGHT:
                    move(1, 0, 4, 0, 4, 3);
                    break;
                case MovingDirection.DOWN:
                    move(0, 1, 0, 4, 3, 4);
                    break;
                case MovingDirection.UP:
                    move(0, -1, 0, -1, 3, -1);
                    break;
            }


        }

        private void move(int dX, int dY, int dx1, int dy1, int dx2, int dy2)
        {
            Coordinate tmp1, tmp2;

            tmp1 = toTileCoordinate(new Coordinate(Player.X + dx1, Player.Y + dy1));
            tmp2 = toTileCoordinate(new Coordinate(Player.X + dx2, Player.Y + dy2));
            if (outOfMap(tmp1) || outOfMap(tmp2) ||
                !Map.tileAt(tmp1.X, tmp1.Y).IsTraversable || !Map.tileAt(tmp2.X, tmp2.Y).IsTraversable)
            {
                OnGameEventReceived(this, GameEventArgs.DRAW);
                return;
            }

            Coordinate c = new Coordinate(Player.X + dX, Player.Y + dY);
            tmp1 = toTileCoordinate(c);

            if (Map.tileAt(tmp1.X, tmp1.Y).getType() == TileType.TELEPORTER && (c.X % 4) == 0 && (c.Y % 4) == 0)
            {
                Teleporter t = (Teleporter)Map.tileAt(tmp1.X, tmp1.Y);
                Coordinate dest = t.Destination;
                Player.setCoord(dest.X * 4, dest.Y * 4);
            }
            else if (Map.tileAt(tmp1.X,tmp2.Y).getType() == TileType.EXIT && (c.X % 4) == 0 && (c.Y % 4) == 0)
            {
                Player.setCoord(Player.X + dX, Player.Y + dY);
                OnGameEventReceived(this, GameEventArgs.WIN);
                return;
            }
            else
                Player.setCoord(Player.X + dX, Player.Y + dY);

            OnGameEventReceived(this, GameEventArgs.DRAW);
        }
    }
}
