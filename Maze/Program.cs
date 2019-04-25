using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CortexAccess;
namespace Maze
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("START LISTENING FOR MENTAL COMMANDS");
            MentalCommandEventController.startListening("ohoxha", "Oren5862", "636eb076-c25a-4970-9496-351a54464872", "MentalTest1");
            Application.Run(new Form1());
            Console.WriteLine("END LISTEING");
            MentalCommandEventController.stopListening();
            
        }
    }
}
