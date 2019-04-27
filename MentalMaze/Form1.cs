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
using CortexAccessUtils;
using System.Collections;
using System.IO;

namespace MentalMaze
{
    public partial class Form1 : Form
    {
        private SimpleProcess sp;
        Game game;
        private static FileStream OutFileStream;
        const string OutFilePath = @"TestEmotion.csv";


        private bool isMovingUP = false;
        private bool isMovingDOWN = false;
        private bool isMovingLEFT = false;
        private bool isMovingRIGHT = false;




        public Form1(SimpleProcess sp)
        {
            /*
            if (File.Exists(OutFilePath))
            {

                File.Delete(OutFilePath);
            }*/
            OutFileStream = new FileStream(OutFilePath, FileMode.Append, FileAccess.Write);
            this.sp = sp;

            sp.P.OnComDataReceived += OnMCEventReceived;
            sp.P.SessionCtr.OnSubcribeComOK += OnMCEventReceived;
            sp.P.OnPerfDataReceived += OnMetEventReceived;
            sp.P.SessionCtr.OnSubcribeMetOK += OnMetEventReceived;

            sp.Subscribe("com");
            sp.Subscribe("met");

            game = new Game();
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(1200, 800);


            
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
            //if (isMoving) return;
            /*
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

            */

            
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (isMovingUP) return;
                    isMovingUP = true;
                    game.move(0, -1);
                    timerUP.Start();
                    break;
                case Keys.Down:
                    if (isMovingDOWN) return;
                    isMovingDOWN = true;
                    game.move(0, 1);
                    timerDOWN.Start();
                    break;
                case Keys.Left:
                    if (isMovingLEFT) return;
                    isMovingLEFT = true;
                    game.move(-1, 0);
                    timerLEFT.Start();
                    break;
                case Keys.Right:
                    if (isMovingRIGHT) return;
                    isMovingRIGHT = true;
                    game.move(1, 0);
                    timerRIGHT.Start();
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

        private void OnMCEventReceived(object sender, ArrayList data)
        {
            Console.WriteLine((string)data[0]);
            switch ((string)data[0])
            {
                case "push":
                    SendKeys.SendWait("{UP}");
                    break;
                case "lift":
                    SendKeys.SendWait("{DOWN}");
                    break;
                case "left":
                    SendKeys.SendWait("{LEFT}");
                    break;
                case "right":
                    SendKeys.SendWait("{RIGHT}");
                    break;
            }

        }
        private static void OnMetEventReceived(object sender, ArrayList eegData)
        {
            WriteDataToFile(eegData);
        }
        private static void WriteDataToFile(ArrayList data)
        {
            //write a row of data to the file
            int i = 0;
            for (; i < data.Count; i++)
            {
                byte[] val = Encoding.UTF8.GetBytes(data[i].ToString() + ", ");

                if (OutFileStream != null)
                    OutFileStream.Write(val, 0, val.Length);
                else
                    break;
            }

            //add the current time for each row of data
            byte[] lastVal = Encoding.UTF8.GetBytes(Utils.GetEpochTimeNowString() + "\n");
            if (OutFileStream != null)
                OutFileStream.Write(lastVal, 0, lastVal.Length);

        }

        private void timerUP_Tick(object sender, EventArgs e)
        {
            game.move(0, -1);
            drawIronMan();
        }

        private void timerDOWN_Tick(object sender, EventArgs e)
        {
            game.move(0, 1);
            drawIronMan();
        }

        private void timerRIGHT_Tick(object sender, EventArgs e)
        {
            game.move(1, 0);
            drawIronMan();
        }

        private void timerLEFT_Tick(object sender, EventArgs e)
        {
            game.move(-1, 0);
            drawIronMan();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
           // isMoving = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    isMovingUP = false;
                    timerUP.Stop();
                    break;
                case Keys.Down:
                    isMovingDOWN = false;
                    timerDOWN.Stop();
                    break;
                case Keys.Left:
                    isMovingLEFT = false;
                    timerLEFT.Stop();
                    break;
                case Keys.Right:
                    isMovingRIGHT = false;
                    timerRIGHT.Stop();
                    break;
            }
        }
    }
}
