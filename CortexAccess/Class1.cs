using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CortexAccess
{

    public enum MentalCommandEventType
    {
        NEUTRAL, PUSH, LIFT, LEFT, RIGHT, PULL, DROP, ROTATE_LEFT, ROTATE_RIGHT, ROTATE_FORWARDS, ROTATE_BACKWARDS,
        ROTATE_CLOCKWISE, ROTATE_ANTI_CLOCKWISE, DISAPPEAR
    }
    public class MentalCommandEventController
    {
        const int DebitNumber = 2;
        private static Process p;

        public static event EventHandler<MentalCommandEventType> OnMCEventReceived;

        public static void startListening(string Username, string Password, string LicenseId, string ProfileName)
        {
            if(p != null)
            {
                Console.WriteLine("You have already started a listening session, please close it before oppeing a new one");
                return;
            }

            Console.WriteLine("COMAND EVENT LOGGER");
            Console.WriteLine("Please wear Headset with good signal!!!");

            p = new Process();

            // Register Event
            p.OnComDataReceived += OnComDataReceived;
            p.SessionCtr.OnSubcribeComOK += OnComDataReceived;

            Thread.Sleep(10000); //wait for querrying user login, query headset
            if (String.IsNullOrEmpty(p.GetUserLogin()))
            {
                p.Login(Username, Password);
                Thread.Sleep(5000); //wait for logining
            }
            // Show username login
            Console.WriteLine("Username :" + p.GetUserLogin());

            if (p.AccessCtr.IsLogin)
            {
                // Send Authorize
                p.Authorize(LicenseId, DebitNumber);
                Thread.Sleep(5000); //wait for authorizing
            }

            if (!p.IsHeadsetConnected())
            {
                p.QueryHeadset();
                Thread.Sleep(10000); //wait for querying headset and create session
            }

            if (!p.IsCreateSession)
            {
                Console.WriteLine("DEBUG: SESSION IS BEEING CREATED AFTER HEADSET QUERY");//DEBUGING
                p.CreateSession();
                Thread.Sleep(5000);
            }

            // Query Profile
            p.QuerryProfiles();
            Thread.Sleep(5000);


            // Check Profile existed
            // Load an existing profile or create a new one
            if (p.IsProfilesExisted(ProfileName))
                p.LoadProfile(ProfileName);
            else
                p.CreateProfile(ProfileName);
            Thread.Sleep(2000);

            if (p.IsCreateSession)
            {
                // Subcribe Fac data
                p.SubcribeData("com");
                Thread.Sleep(5000);
            }

        }

        public static void stopListening()
        {
            if(p == null)
                Console.WriteLine("You were not listening!!");
            else
            {
                Console.WriteLine("Stop listening for mental commands, wait 3 seconds");
                // Unsubcribe stream, to stop receiving data
                p.UnSubcribeData("com");
                Thread.Sleep(3000);
                p = null;
            }
        }

        private static void OnComDataReceived(object sender, ArrayList comData)
        {
            Console.WriteLine((string)comData[0]);
           if (OnMCEventReceived == null) return;
           if(Convert.ToDouble((string)comData[1]) > 0.75){
                switch ((string)comData[0])
                {
                    case "neutral": OnMCEventReceived(null, MentalCommandEventType.NEUTRAL);//TODO: REMOVE p
                        break;
                    case "push":
                        OnMCEventReceived(null, MentalCommandEventType.PUSH);//TODO: REMOVE p
                        break;
                    case "pull":
                        OnMCEventReceived(null, MentalCommandEventType.PULL);//TODO: REMOVE p
                        break;
                    case "lift":
                        OnMCEventReceived(null, MentalCommandEventType.LIFT);//TODO: REMOVE p
                        break;
                    case "drop":
                        OnMCEventReceived(null, MentalCommandEventType.DROP);//TODO: REMOVE p
                        break;
                    case "right":
                        OnMCEventReceived(null, MentalCommandEventType.RIGHT);//TODO: REMOVE p
                        break;
                    case "left":
                        OnMCEventReceived(null, MentalCommandEventType.LEFT);//TODO: REMOVE p
                        break;
                    case "rotateLeft":
                        OnMCEventReceived(null, MentalCommandEventType.ROTATE_LEFT);//TODO: REMOVE p
                        break;
                    case "rotateRight":
                        OnMCEventReceived(null, MentalCommandEventType.ROTATE_RIGHT);//TODO: REMOVE p
                        break;
                    case "rotateClockwise":
                        OnMCEventReceived(null, MentalCommandEventType.ROTATE_CLOCKWISE);//TODO: REMOVE p
                        break;
                    case "rotateCounterClockwise":
                        OnMCEventReceived(null, MentalCommandEventType.ROTATE_ANTI_CLOCKWISE);//TODO: REMOVE p
                        break;
                    case "rotateForwards":
                        OnMCEventReceived(null, MentalCommandEventType.ROTATE_FORWARDS);//TODO: REMOVE p
                        break;
                    case "rotateReverse":
                        OnMCEventReceived(null, MentalCommandEventType.ROTATE_BACKWARDS);//TODO: REMOVE p
                        break;
                    case "disappear":
                        OnMCEventReceived(null, MentalCommandEventType.DISAPPEAR);//TODO: REMOVE p
                        break;




                }
            }
        }
    }
}
