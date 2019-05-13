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

namespace TheMindGame
{
    public partial class MainMenu : Form
    {

        public static string selectedCharacterPath;
        private List<string> allCharactersPath;
        private static string charactersPath = Path.Combine(Program.resourcesPath, "characters");

        public MainMenu()
        {
            allCharactersPath = new List<string>();
            loadCharacterPaths();
            if (allCharactersPath.Count() < 1) throw new Exception("No character found");
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
        private void loadCharacterPaths()
        {
            DirectoryInfo charDirectoryInfo = new DirectoryInfo(charactersPath);
            DirectoryInfo[] charDirectoryInfos = charDirectoryInfo.GetDirectories();

            foreach (DirectoryInfo di in charDirectoryInfos)
            {
                allCharactersPath.Add(di.FullName);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            LevelSelection levelSelection = new LevelSelection();
            levelSelection.Location = this.Location;
            this.Visible = false;
            levelSelection.Show();
        }
    }
}
