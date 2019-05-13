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
    public partial class LevelSelection : Form
    {
        private bool exitApplication = true;
        public static string selectedlevelPath;
         
        private static string levelsPath = Path.Combine(Program.resourcesPath, "levels");

        private List<string> allLevelsPath;
        private int currPos;
        private int selectedLevel;

        private PictureBox[] boxes = new PictureBox[6];

        public int SelectedLevel
        {
            get
            {
                return selectedLevel;
            }

            set
            {
                selectedLevel = value;
            }
        }

        public LevelSelection()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(1200, 800);
            allLevelsPath = new List<string>();
            currPos = 0;
            SelectedLevel = 0;
            boxes[0] = pictureBox1;
            boxes[1] = pictureBox2;
            boxes[2] = pictureBox3;
            boxes[3] = pictureBox4;
            boxes[4] = pictureBox5;
            boxes[5] = pictureBox6;
            initComponentPosition();

            loadLevelPaths();

            updateView();
        }

        private void updateView()
        {
            if (allLevelsPath == null || allLevelsPath.Count == 0) return;

            if(selectedLevelPictureBox.BackgroundImage != null)
                selectedLevelPictureBox.BackgroundImage.Dispose();
            selectedLevelPictureBox.BackgroundImage = Image.FromFile(Path.Combine(allLevelsPath[SelectedLevel], "image.png"));
            
            arrowUp.Visible = (currPos == 0) ? false : true;
            arrowDown.Visible = (currPos + 6 >= allLevelsPath.Count) ? false : true;
            
            for(int i = 0; i < boxes.Length; i++)
            {
                if(currPos + i < allLevelsPath.Count)
                {
                    if(boxes[i].BackgroundImage != null)
                        boxes[i].BackgroundImage.Dispose();
                    boxes[i].BackgroundImage = Image.FromFile(Path.Combine(allLevelsPath[currPos + i], "image.png"));
                    boxes[i].Visible = true;
                }
                else
                {
                    boxes[i].Visible = false;
                }
            }
            
       
        }

        private void loadLevelPaths()
        {
            DirectoryInfo charDirectoryInfo = new DirectoryInfo(levelsPath);
            DirectoryInfo[] charDirectoryInfos = charDirectoryInfo.GetDirectories();

            foreach (DirectoryInfo di in charDirectoryInfos)
            {
                    allLevelsPath.Add(di.FullName);
            }
        }

        private void initComponentPosition()
        {
            int middleHeight = this.ClientSize.Height / 2;
            int middleWidth = this.ClientSize.Width / 2;

            selectedLevelPictureBox.Location = new Point(50, middleHeight - (selectedLevelPictureBox.Height + 30 + startButton.Height) / 2);
            startButton.Location = new Point(50 + (selectedLevelPictureBox.Width - startButton.Width) / 2,
                                        selectedLevelPictureBox.Location.Y + selectedLevelPictureBox.Height + 30);

            int x = this.ClientSize.Width - 50 - 2 * pictureBox1.Width - 30;

            pictureBox1.Location = new Point(x, middleHeight - (3 * pictureBox1.Height + 60) / 2);
            pictureBox3.Location = new Point(x, pictureBox1.Location.Y + pictureBox1.Height + 30);
            pictureBox5.Location = new Point(x, pictureBox3.Location.Y + pictureBox3.Height + 30);

            pictureBox2.Location = new Point(pictureBox1.Location.X + pictureBox1.Width + 30, middleHeight - (3 * pictureBox1.Height + 60) / 2);
            pictureBox4.Location = new Point(pictureBox3.Location.X + pictureBox3.Width + 30, pictureBox1.Location.Y + pictureBox1.Height + 30);
            pictureBox6.Location = new Point(pictureBox5.Location.X + pictureBox5.Width + 30, pictureBox3.Location.Y + pictureBox3.Height + 30);

            int arrowX = this.ClientSize.Width - 50 - pictureBox1.Width - 15 - arrowDown.Width / 2;
            arrowDown.Location = new Point(arrowX, pictureBox5.Location.Y + pictureBox5.Height + 30);
            arrowUp.Location = new Point(arrowX, pictureBox1.Location.Y - 30 - arrowUp.Height);

            titlePictureBox.Location = new Point(selectedLevelPictureBox.Location.X + (selectedLevelPictureBox.Width - titlePictureBox.Width) / 2, 60);

        }

        private void titlePictureBox_Click(object sender, EventArgs e)
        {
            Program.mainMenu.Location = this.Location;
            Program.mainMenu.Visible = true;
            exitApplication = false;
            this.Dispose();
        }

        private void arrowUp_Click(object sender, EventArgs e)
        {

            currPos -= 2;
            updateView();
        }

        private void arrowDown_Click(object sender, EventArgs e)
        {
            currPos += 2;
            updateView();
        }


        private void levelClicked(int x)
        {
            int selected = currPos + x;
            if (selected < 0 || selected >= allLevelsPath.Count) return;

            SelectedLevel = selected;
            updateView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            levelClicked(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            levelClicked(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            levelClicked(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            levelClicked(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            levelClicked(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            levelClicked(5);
        }

       

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox o = (PictureBox)sender;
            o.Size = new Size(249, 166);
            o.Location = new Point(o.Location.X - 13, o.Location.Y - 9);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox o = (PictureBox)sender;
            o.Size = new Size(222, 148);
            o.Location = new Point(o.Location.X + 13, o.Location.Y + 9);
        }

        public bool setSelectedLevel(int n)
        {
            if (n < 0 || n >= allLevelsPath.Count) return false;
            selectedLevel = n;  
            return true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            selectedlevelPath = allLevelsPath[SelectedLevel];
            try
            {
                Game game = new TheMindGame.Game();
                Gui gui = new TheMindGame.Gui(game, this);

                game.start();
                gui.Location = this.Location;
                gui.Show();

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
                return;
            }
            

            

            

        }

        private void LevelSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(exitApplication) Application.Exit();

        }
    }
}
