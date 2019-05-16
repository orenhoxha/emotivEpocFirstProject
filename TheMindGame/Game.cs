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
        START, DRAW, WIN, STARTBOMBTIMER
    }


    public class Game
    {
        public event EventHandler<GameEventArgs> OnGameEventReceived;

        private Player player;
        private Map map;
        private List<Bomb> activatedBombs;

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

        internal List<Bomb> ActivatedBombs
        {
            get
            {
                return activatedBombs;
            }

            
        }

        public Game()
        {
            player = new TheMindGame.Player();
            activatedBombs = new List<Bomb>();

            map = new Map(TheMindGame.LevelSelection.selectedlevelPath, Player);

               
        }

        public void start()
        {
            OnGameEventReceived(this, GameEventArgs.START);
        }


        private Coordinate toTileCoordinate(Coordinate c)
        {
            return new Coordinate(c.X / Utils.MOVES_PER_TILE, c.Y / Utils.MOVES_PER_TILE);
                
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
                    move(-1, 0, -1, 0, -1, Utils.MOVES_PER_TILE-1);
                    break;
                case MovingDirection.RIGHT:
                    move(1, 0, Utils.MOVES_PER_TILE, 0, Utils.MOVES_PER_TILE, Utils.MOVES_PER_TILE-1);
                    break;
                case MovingDirection.DOWN:
                    move(0, 1, 0, Utils.MOVES_PER_TILE, Utils.MOVES_PER_TILE-1, Utils.MOVES_PER_TILE);
                    break;
                case MovingDirection.UP:
                    move(0, -1, 0, -1, Utils.MOVES_PER_TILE-1, -1);
                    break;
            }

            takeBomb();
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

            Teleporter t = map.teleporterAt(tmp1.X, tmp1.Y);

            if ( t != null && (c.X % Utils.MOVES_PER_TILE) == 0 && (c.Y % Utils.MOVES_PER_TILE) == 0)
            {
                Coordinate dest = t.Destination;
                Player.setCoord(dest.X * Utils.MOVES_PER_TILE, dest.Y * Utils.MOVES_PER_TILE);
            }

            else if (Map.tileAt(tmp1.X,tmp2.Y).getType() == TileType.EXIT && (c.X % Utils.MOVES_PER_TILE) == 0 && (c.Y % Utils.MOVES_PER_TILE) == 0)
            {
                Player.setCoord(Player.X + dX, Player.Y + dY);
                OnGameEventReceived(this, GameEventArgs.WIN);
                return;
            }
            else
                Player.setCoord(Player.X + dX, Player.Y + dY);

            OnGameEventReceived(this, GameEventArgs.DRAW);
        }


        private void takeBomb()
        {
            Bomb b = map.bombAt(toTileCoordinate(player.Coord));
            if (b != null)
            {
                map.removeBomb(b);
                player.Bombs.Add(b);
            }
        }





        public void PutBomb()
        {
            List<Bomb> playerBombs = player.Bombs;

            if (playerBombs != null && playerBombs.Count > 0)
            {

                Bomb bomb = playerBombs[0];
                bomb.Coord = toTileCoordinate(player.Coord);
                playerBombs.RemoveAt(0);
                bomb.IsActivated = true;
                ActivatedBombs.Add(bomb);

                OnGameEventReceived(this, GameEventArgs.STARTBOMBTIMER);
                OnGameEventReceived(this, GameEventArgs.DRAW);

            }
        }

        public void exploseBomb()
        {
            Bomb bomb = activatedBombs[0];
            activatedBombs.RemoveAt(0);

            Map.destroyInRadius(bomb.Coord, bomb.Radius);

            OnGameEventReceived(this, GameEventArgs.DRAW);
        }

    }




}




