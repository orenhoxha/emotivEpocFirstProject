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
    public partial class CharacterSelection : Form
    {
        private bool exitApplication = true;
        private List<string> allCharactersPath;
        private int currPos = 1;

        public CharacterSelection(List<string> allCharactersPath)
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(1200, 800);

            initComponentPosition();


            this.allCharactersPath = allCharactersPath;
      
            updateView();
        }


        private void initComponentPosition()
        {
            int middleHeight = this.Height / 2;
            int middleWidth = this.Width / 2;


            pictureBoxCenter.Location = new Point(middleWidth - pictureBoxCenter.Width / 2, middleHeight - pictureBoxCenter.Height / 2);

            pictureBoxLeft.Location = new Point(pictureBoxCenter.Location.X - pictureBoxLeft.Width - 20, middleHeight - pictureBoxLeft.Height / 2);
            pictureBoxRight.Location = new Point(pictureBoxCenter.Location.X + pictureBoxCenter.Width + 20, middleHeight - pictureBoxRight.Height / 2);


            selectCharacterOk.Location = new Point(this.Width / 2 - selectCharacterOk.Width / 2, 650);


            arrowLeft.Location = new Point(pictureBoxLeft.Location.X - 30 - arrowLeft.Width, middleHeight - arrowLeft.Height / 2);
            arrowRight.Location = new Point(pictureBoxRight.Location.X + pictureBoxRight.Width + 30, middleHeight - arrowRight.Height / 2);

        }




        private int mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        private void updateView()
        {
            int a = (currPos - 1) % allCharactersPath.Count;

            if (pictureBoxLeft.BackgroundImage != null) pictureBoxLeft.BackgroundImage.Dispose();
            pictureBoxLeft.BackgroundImage = Image.FromFile(Path.Combine(allCharactersPath[mod(currPos - 1, allCharactersPath.Count)], "character.jpg"));
            if (pictureBoxCenter.BackgroundImage != null) pictureBoxCenter.BackgroundImage.Dispose();
            pictureBoxCenter.BackgroundImage = Image.FromFile(Path.Combine(allCharactersPath[currPos], "character.jpg"));
            if (pictureBoxRight.BackgroundImage != null) pictureBoxRight.BackgroundImage.Dispose();
            pictureBoxRight.BackgroundImage = Image.FromFile(Path.Combine(allCharactersPath[mod(currPos + 1, allCharactersPath.Count)], "character.jpg"));

        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            currPos = mod(currPos + 1, allCharactersPath.Count);
            updateView();
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            currPos = mod(currPos - 1, allCharactersPath.Count);
            updateView();
        }
        private void pictureBoxRight_Click(object sender, EventArgs e)
        {
            arrowRight_Click(sender, e);
        }

        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            arrowLeft_Click(sender, e);
        }

        

        private void selectCharacterOk_Click(object sender, EventArgs e)
        {
            MainMenu.selectedCharacterPath = allCharactersPath[currPos];
            Program.mainMenu.Location = this.Location;
            Program.mainMenu.Visible = true;

            exitApplication = false;
            this.Dispose();

        }

        private void CharacterSelection_FormClosed(object sender, FormClosedEventArgs e)
        {

            if(exitApplication) Application.Exit();

        }
    }
}
