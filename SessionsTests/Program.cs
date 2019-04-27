using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CortexAccessUtils;
using System.Collections;
using System.IO;
using CortexAccess;

namespace SessionsTests
{
    class Program
    {
        private static FileStream OutFileStream;
        const string OutFilePath = @"SessionTest.csv";
        static void Main(string[] args)
        {
            if (File.Exists(OutFilePath))
            {

                File.Delete(OutFilePath);
            }
            OutFileStream = new FileStream(OutFilePath, FileMode.Append, FileAccess.Write);
            SimpleProcess sp = new SimpleProcess("ohoxha", "Password123", "636eb076-c25a-4970-9496-351a54464872", "MentalTest1");
            sp.P.OnComDataReceived += OnMCEventReceived;
            sp.P.SessionCtr.OnSubcribeComOK += OnMCEventReceived;
            sp.P.OnFacDataReceived += OnMCEventReceived;
            sp.P.SessionCtr.OnSubcribeFacOK += OnMCEventReceived;
            sp.Subscribe("com");
            sp.Subscribe("fac");


        




            Console.ReadKey();
            sp.Unsubscribe();
        }

        private static void OnMCEventReceived(object sender, ArrayList eegData)
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
    }
}
