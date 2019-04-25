using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalMaze
{ 

    enum Case
    {
        EMPTY, WALL, EXIT, ENTER
    }

  
    class Game
    {

        private Case[ , ] map = new Case[20, 30];
        private int posX;
        private int posY;

        bool hasWon;

        public int PosX
        {
            get
            {
                return posX;
            }

            set
            {
                posX = value;
            }
        }

        public int PosY
        {
            get
            {
                return posY;
            }

            set
            {
                posY = value;
            }
        }

        public bool HasWon
        {
            get
            {
                return hasWon;
            }

            set
            {
                hasWon = value;
            }
        }

        public Game()
        {
            HasWon = false;
            PosX = 1;
            PosY = 1;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    map[i, j] = Case.EMPTY;
                    map[0, j] = Case.WALL;
                    map[19, j] = Case.WALL;


                }

                map[i, 0] = Case.WALL;
                map[i, 29] = Case.WALL;
            }


            for(int i = 1; i <= 15; i++)
            {
                map[i, 11] = Case.WALL;
                map[i, 23] = Case.WALL;
            }

            for (int i = 4; i <= 18; i++)
            {
                map[i, 16] = Case.WALL;
                map[i, 20] = Case.WALL;
                map[i, 26] = Case.WALL;
            }



            map[19, 28] = Case.EMPTY;
            map[1, 1] = Case.ENTER;
            map[19, 29] = Case.EXIT;


        }

        public void move(int dx, int dy)
        {
            int newX = PosX + dx;
            int newY = PosY + dy;

            if (newX < 0 || newX > 29) return;
            if (newY < 0 || newY > 19) return;

            if (map[newY, newX] == Case.WALL) return;

            PosX = newX;
            PosY = newY;
            if (map[newY, newX] == Case.EXIT) HasWon = true;

        }


    }
}
