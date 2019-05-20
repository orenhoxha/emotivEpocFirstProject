using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CortexAccessUtils;
using System.Collections;
using System;
using System.Text;

namespace TheMindGame
{
    static class Program
    {


        public static string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
        public static string resourcesPath = Path.Combine(projectPath, "Resources");
        public static MainMenu mainMenu;

        public static FileStream eegOutput;
        public static FileStream metOutput;
        public static FileStream comOutput;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            eegOutput = new FileStream(@"eegOutput.csv", FileMode.Append, FileAccess.Write);
            metOutput = new FileStream(@"metOutput.csv", FileMode.Append, FileAccess.Write);
            comOutput = new FileStream(@"comOutput.csv", FileMode.Append, FileAccess.Write);


            SimpleProcess sp = new SimpleProcess("ohoxha", "Password123", "636eb076-c25a-4970-9496-351a54464872", "OrenMental");

            
            if(sp != null && sp.P != null)
            {
                sp.P.OnPerfDataReceived += OnMetEventReceived;
                sp.P.SessionCtr.OnSubcribeMetOK += OnMetEventReceived;

                sp.P.OnEEGDataReceived += OnEEGEventReceived;
                sp.P.SessionCtr.OnSubcribeEEGOK += OnEEGEventReceived;

                sp.Subscribe("met");
                //sp.Subscribe("eeg");
            }



            Application.Run(mainMenu = new MainMenu(null));

            if (sp != null && sp.P != null)
                sp.Unsubscribe();

            if(eegOutput != null)
                eegOutput.Close();
            if (metOutput != null)
                metOutput.Close();
            if (comOutput != null)
                comOutput.Close();
                
        }

        private static void OnMetEventReceived(object sender, ArrayList data)
        {
            if (metOutput == null) return;
            WriteDataToFile(data, metOutput);

        }

        private static void OnEEGEventReceived(object sender, ArrayList data)
        {
            if (eegOutput == null) return;
            WriteDataToFile(data, eegOutput);
        }

        public static void WriteDataToFile(ArrayList data, FileStream outFileStream)
        {
            //write a row of data to the file
           
            for (int i = 0; i < data.Count; i++)
            {
                byte[] val = Encoding.UTF8.GetBytes(data[i].ToString() + ", ");

                if (outFileStream != null)
                    outFileStream.Write(val, 0, val.Length);
                else
                    break;
            }

            //add the current time for each row of data
            byte[] lastVal = Encoding.UTF8.GetBytes(CortexAccess.Utils.GetEpochTimeNowString() + "\n");
            if (outFileStream != null)
                outFileStream.Write(lastVal, 0, lastVal.Length);

        }


    }
}
