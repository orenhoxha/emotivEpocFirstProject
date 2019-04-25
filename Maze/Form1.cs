using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CortexAccess;

namespace Maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MentalCommandEventController.OnMCEventReceived += OnMCEventReceived;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                    IronMan.Top -= 20;
                    break;
                case Keys.Down:
                    IronMan.Top += 20;
                    break;
                case Keys.Left:
                    IronMan.Left -= 20;
                    break;
                case Keys.Right:
                    IronMan.Left += 20;
                    break;
            }
        }

        private void OnMCEventReceived(object sender, MentalCommandEventType e)
        {
            switch (e)
            {
                case MentalCommandEventType.UP:
                    SendKeys.SendWait("{UP}");
                    break;
                case MentalCommandEventType.DOWN:
                    SendKeys.SendWait("{DOWN}");
                    break;
                case MentalCommandEventType.LEFT:
                    SendKeys.SendWait("{LEFT}");
                    break;
                case MentalCommandEventType.RIGHT:
                    SendKeys.SendWait("{RIGHT}");
                    break;
            }

            
            /*
            switch (e)
            {
                case MentalCommandEventType.UP:
                    IronMan.Top -= 20;
                    break;
                case MentalCommandEventType.DOWN:
                    IronMan.Top += 20;
                    break;
                case MentalCommandEventType.LEFT:
                    IronMan.Left -= 20;
                    break;
                case MentalCommandEventType.RIGHT:
                    IronMan.Left += 20;
                    break;
            }*/
        }


    }
}
