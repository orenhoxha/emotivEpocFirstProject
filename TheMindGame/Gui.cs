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
    public partial class Gui : Form
    {
        private int winTick = 0;
        private PictureBox winPictureBox;
        private bool isMovingUP = false;
        private bool isMovingLEFT = false;
        private bool isMovingDOWN = false;
        private bool isMovingRIGHT = false;

        private Image[] imgs;
        Image currentImage;

        Image blockImage = Image.FromFile(Path.Combine(Program.resourcesPath, "block.png"));
        Image teleportImage = Image.FromFile(Path.Combine(Program.resourcesPath, "teleport.png"));
        Image exitImage = Image.FromFile(Path.Combine(Program.resourcesPath, "exit.png"));

        private Game game;
        public Gui(Game game)
        {
            this.game = game;
            game.OnGameEventReceived += this.OnDraw;
            LoadCharactersImages();
            currentImage = imgs[0];
            InitializeComponent();

        }

        private void LoadCharactersImages()
        {
            imgs = new Image[4];
            string characterPath = TheMindGame.MainMenu.selectedCharacterPath;
            imgs[0] = Image.FromFile(Path.Combine(characterPath, "down.png"));
            imgs[1] = Image.FromFile(Path.Combine(characterPath, "left.png"));
            imgs[2] = Image.FromFile(Path.Combine(characterPath, "right.png"));
            imgs[3] = Image.FromFile(Path.Combine(characterPath, "up.png"));
        }

        public void OnDraw(object sender, GameEventArgs args)
        {
            
            switch (args)
            {
               case GameEventArgs.START:
                    int width = game.Map.Width;
                    int height = game.Map.Height;
                    ClientSize = new System.Drawing.Size(width * 40, height * 40);
                    break;
                case GameEventArgs.DRAW:
                    Invalidate();
                    break;
                case GameEventArgs.WIN:
                    

                    timerDOWN.Stop();
                    timerUP.Stop();
                    timerLEFT.Stop();
                    timerRIGHT.Stop();

                    Invalidate();

                    KeyDown -= Gui_KeyDown;
                    KeyUp -= Gui_KeyUp;

                    timerWIN.Start();

                    break;
            }


        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
                int width = game.Map.Width;
                int height = game.Map.Height;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        switch (game.Map.tileTypeAt(x, y))
                        {
                            case TileType.WALL:
                                e.Graphics.DrawImage(blockImage, new Point(x * 40, y * 40));
                                break;
                            case TileType.EXIT:
                                e.Graphics.DrawImage(exitImage, new Point(x * 40, y * 40));
                                break;
                            case TileType.TELEPORTER:
                                e.Graphics.DrawImage(teleportImage, new Point(x * 40, y * 40));
                                break;
                            default:
                                break;
                        }
                    }
                }
                if(currentImage != null)
                    e.Graphics.DrawImage(currentImage, new Point(game.Player.X * 10, game.Player.Y * 10));
            }



        private void Gui_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (isMovingUP) return;
                    currentImage = imgs[3];
                    isMovingUP = true;
                    game.move(MovingDirection.UP);
                    timerUP.Start();
                    break;
                case Keys.Down:
                    if (isMovingDOWN) return;
                    currentImage = imgs[0];
                    isMovingDOWN = true;
                    game.move(MovingDirection.DOWN);
                    timerDOWN.Start();
                    break;
                case Keys.Left:
                    if (isMovingLEFT) return;
                    currentImage = imgs[1];
                    isMovingLEFT = true;
                    game.move(MovingDirection.LEFT);
                    timerLEFT.Start();
                    break;
                case Keys.Right:
                    if (isMovingRIGHT) return;
                    currentImage = imgs[2];
                    isMovingRIGHT = true;
                    game.move(MovingDirection.RIGHT);
                    timerRIGHT.Start();
                    break;
            }
            //CHECK WIN
        }

        private void Gui_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    isMovingUP = false;
                    timerUP.Stop();
                    break;
                case Keys.Down:
                    isMovingDOWN = false;
                    timerDOWN.Stop();
                    break;
                case Keys.Left:
                    isMovingLEFT = false;
                    timerLEFT.Stop();
                    break;
                case Keys.Right:
                    isMovingRIGHT = false;
                    timerRIGHT.Stop();
                    break;
            }
        }

        private void timerLEFT_Tick(object sender, EventArgs e)
        {
            game.move(MovingDirection.LEFT);
        }

        private void timerRIGHT_Tick(object sender, EventArgs e)
        {
            game.move(MovingDirection.RIGHT);
        }

        private void timerDOWN_Tick(object sender, EventArgs e)
        {
            game.move(MovingDirection.DOWN);
        }

        private void timerUP_Tick(object sender, EventArgs e)
        {
            game.move(MovingDirection.UP);
        }

        private void timerWIN_Tick(object sender, EventArgs e)
        {
            if(winTick == 0)
            {
                currentImage = null;
                winPictureBox = new PictureBox();
                winPictureBox.BackgroundImage = imgs[3];
                winPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                winPictureBox.BackColor = Color.Transparent;
                winPictureBox.Size = new Size(40, 40);
                winPictureBox.Location = new Point(game.Player.X * 10, game.Player.Y * 10);
                this.Controls.Add(winPictureBox);

            }

            winPictureBox.Size = new Size(40 - 10 * winTick, 40 - 10 * winTick);
            if(winTick != 0)
                winPictureBox.Location = new Point(winPictureBox.Location.X +5, winPictureBox.Location.Y + 5);

            if (winTick == 4)
            {
                winTick = 0;
                timerWIN.Stop();
            }
            winTick++;
        }
    }
}
