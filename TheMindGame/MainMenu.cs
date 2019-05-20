using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CortexAccess;
using CortexAccessUtils;
using System.Collections;

namespace TheMindGame
{
    public partial class MainMenu : Form
    {
        public const double MIN_MC_POWER = 0.75;

        private SimpleProcess sp;

        public static string selectedCharacterPath;
        private List<string> allCharactersPath;
        private static string charactersPath = Path.Combine(Program.resourcesPath, "characters");

        public MainMenu(SimpleProcess sp)
        {
            if(sp != null && sp.P != null)
            {
                this.sp = sp;
                sp.P.OnComDataReceived += OnMCEventReceived;
                sp.P.SessionCtr.OnSubcribeComOK += OnSubscribeComOKventReceived;

                sp.Subscribe("com");
            }
            
           


            allCharactersPath = new List<string>();
            loadCharacterPaths();

            if (allCharactersPath.Count() < 3) throw new Exception("Less than 3 characters found");
            selectedCharacterPath = allCharactersPath[0];

            if (BackgroundImage != null) BackgroundImage.Dispose();
            BackgroundImage = Image.FromFile(Path.Combine(allCharactersPath[0], "character.jpg"));

            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(1200, 800);

            ToolTip characterToolTip = new ToolTip();
            characterToolTip.SetToolTip(this.characterButton, "Click here to change the character");
            characterButton.Location = new Point(this.Width / 2 - characterButton.Width/2, this.Height / 2 - characterButton.Height /2);

            startButton.Location = new Point(this.Width/2 - startButton.Width/2, 650);
        }

        private void loadCharacterPaths()
        {
            DirectoryInfo charDirectoryInfo = new DirectoryInfo(charactersPath);
            DirectoryInfo[] charDirectoryInfos = charDirectoryInfo.GetDirectories();

            foreach (DirectoryInfo di in charDirectoryInfos)
            {
                allCharactersPath.Add(di.FullName);
            }
        }

        private void characterButton_Click(object sender, EventArgs e)
        {
            CharacterSelection characterSelection = new CharacterSelection(allCharactersPath);
            characterSelection.Location = this.Location;
            this.Visible = false;
            characterSelection.Show();
        }

        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if(selectedCharacterPath != null)
            {
                characterButton.BackgroundImage = Image.FromFile(Path.Combine(selectedCharacterPath,"character.jpg"));
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            LevelSelection levelSelection = new LevelSelection();
            levelSelection.Location = this.Location;
            this.Visible = false;
            levelSelection.Show();
        }

        private void OnMCEventReceived(object sender, ArrayList data)
        {
            if (Program.comOutput != null)
                Program.WriteDataToFile(data, Program.comOutput);


            if (Convert.ToDouble((string)data[1]) < MIN_MC_POWER) return;

            string command = "{NEUTRAL}";

            Console.WriteLine((string)data[0]);
            switch ((string)data[0])
            {
                case "push":
                    command = "{UP}";
                    break;
                case "lift":
                    command = "{DOWN}";
                    break;
                case "left":
                    command = "{LEFT}";
                    break;
                case "right":
                    command = "{RIGHT}";
                    break;
            }

            for(int i = 0; i < Utils.MOVES_PER_TILE / 2; i++)
                SendKeys.SendWait(command);

        }

        private void OnSubscribeComOKventReceived(object sender, ArrayList data)
        {
            if (Program.comOutput != null)
                Program.WriteDataToFile(data, Program.comOutput);
        }
        



    }
}
