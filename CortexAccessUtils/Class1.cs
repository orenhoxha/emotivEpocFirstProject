using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CortexAccess;
using System.Threading;

namespace CortexAccessUtils
{
    public class SimpleProcess
    {
        const int DebitNumber = 2;


        private Process p;

        public Process P
        {
            get
            {
                return p;
            }

        }

        public SimpleProcess(string Username, string Password, string LicenseId, string ProfileName)
        {
            if (P != null)
            {
                Console.WriteLine("You have already started a listening session, please close it before oppeing a new one");
                return;
            }

            Console.WriteLine("COMAND EVENT LOGGER");
            Console.WriteLine("Please wear Headset with good signal!!!");

            p = new Process();

            // Register Event
            //p.OnComDataReceived += OnComDataReceived;
            //p.SessionCtr.OnSubcribeComOK += OnComDataReceived;

            Thread.Sleep(10000); //wait for querrying user login, query headset
            if (String.IsNullOrEmpty(P.GetUserLogin()))
            {
                P.Login(Username, Password);
                Thread.Sleep(5000); //wait for logining
            }
            // Show username login
            Console.WriteLine("Username :" + P.GetUserLogin());

            if (P.AccessCtr.IsLogin)
            {
                // Send Authorize
                P.Authorize(LicenseId, DebitNumber);
                Thread.Sleep(5000); //wait for authorizing
            }

            if (!P.IsHeadsetConnected())
            {
                P.QueryHeadset();
                Thread.Sleep(10000); //wait for querying headset and create session
            }

            if (!P.IsCreateSession)
            {
                Console.WriteLine("DEBUG: SESSION IS BEEING CREATED AFTER HEADSET QUERY");//DEBUGING
                P.CreateSession();
                Thread.Sleep(5000);
            }

            // Query Profile
            P.QuerryProfiles();
            Thread.Sleep(5000);


            // Check Profile existed
            // Load an existing profile or create a new one
            if (P.IsProfilesExisted(ProfileName))
                P.LoadProfile(ProfileName);
            else
                P.CreateProfile(ProfileName);
            Thread.Sleep(2000);

            

        }

        //TODO: Implement this method
        public void SubscribeAll()
        {

        }

        public void Subscribe(string dataType)
        {
            if (P.IsCreateSession)
            {
                // Subcribe data
                P.SubcribeData(dataType);
                Thread.Sleep(5000);
            }
        }


        public void Unsubscribe(string dataType)
        {
            if (p == null)
                Console.WriteLine("You were not listening!!");
            else
            {
                // Unsubcribe stream, to stop receiving data
                p.UnSubcribeData(dataType);
                Thread.Sleep(3000);
            }
        }

        public void Unsubscribe()
        {
            p.UnSubcribeData("com");
            p.UnSubcribeData("fac");
            p.UnSubcribeData("met");
            p.UnSubcribeData("eeg");
            p.UnSubcribeData("mot");
            p.UnSubcribeData("dev");
            p.UnSubcribeData("sys");
            p.UnSubcribeData("pow");

            Thread.Sleep(3000);
        }


    }
}
