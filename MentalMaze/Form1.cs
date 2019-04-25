using CortexAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MentalMaze
{
    public partial class Form1 : Form
    {

        Game game;

        public Form1()
        {

            game = new Game();

            InitializeComponent(1200, 800);
            MentalCommandEventController.OnMCEventReceived += OnMCEventReceived;

            drawIronMan();


        }


        private void drawIronMan()
        {
            int posX = game.PosX;
            int posY = game.PosY;

            ironManIcon.Location = new Point(posX * 40, posY * 40);
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.Up:
                    game.move(0, -1);
                    break;
                case Keys.Down:
                    game.move(0, 1);
                    break;
                case Keys.Left:
                    game.move(-1, 0);
                    break;
                case Keys.Right:
                    game.move(1, 0);
                    break;
            }

            

            if (game.HasWon)
            {
                game.PosX = 1;
                game.PosY = 1;
                game.HasWon = false;
            }
            drawIronMan();


        }

        private void OnMCEventReceived(object sender, MentalCommandEventType e)
        {
            switch (e)
            {
                case MentalCommandEventType.PUSH:
                    SendKeys.SendWait("{UP}");
                    break;
                case MentalCommandEventType.LIFT:
                    SendKeys.SendWait("{DOWN}");
                    break;
                case MentalCommandEventType.LEFT:
                    SendKeys.SendWait("{LEFT}");
                    break;
                case MentalCommandEventType.RIGHT:
                    SendKeys.SendWait("{RIGHT}");
                    break;
            }

        }
    }
}
