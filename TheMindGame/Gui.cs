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
        public class BombAnimationStruct
        {
            public Coordinate coord;
            public int cmp;

            public BombAnimationStruct(Coordinate coord, int cmp)
            {
                this.coord = coord;
                this.cmp = cmp;
            }
        }

        private LevelSelection levelSelectionForm;
        private GameEventArgs gameState;

        private int winTick = 0;
        private PictureBox winPictureBox;
        private bool isMovingUP = false;
        private bool isMovingLEFT = false;
        private bool isMovingDOWN = false;
        private bool isMovingRIGHT = false;

        private List<System.Windows.Forms.Timer> bombTimers;
        private Dictionary<Bomb, Timer> bombTimerDict;
        private Dictionary<Timer, int> timerSizeDict;
        private Dictionary<Timer, BombAnimationStruct> explosionTimerDict;

        private Image[] imgs;
        Image currentImage;

        Image blockImage = Image.FromFile(Path.Combine(Program.resourcesPath, "block.png"));
        Image unbreakableBlockImage = Image.FromFile(Path.Combine(Program.resourcesPath, "unbreakable_block.png"));
        Image teleportImage = Image.FromFile(Path.Combine(Program.resourcesPath, "teleport.png"));
        Image exitImage = Image.FromFile(Path.Combine(Program.resourcesPath, "exit.png"));
        Image activatedBombImage = Image.FromFile(Path.Combine(Program.resourcesPath, "bomb_activated.png"));
        Image desactivatedBombImage = Image.FromFile(Path.Combine(Program.resourcesPath, "bomb.png"));
        Image explosionImage = Image.FromFile(Path.Combine(Program.resourcesPath, "explosion.png"));
        private Game game;

        public Gui(Game game, LevelSelection levelSelectionForm)
        {
            this.levelSelectionForm = levelSelectionForm;
            gameState = GameEventArgs.START;
            this.game = game;
            game.OnGameEventReceived += this.OnDraw;
            LoadCharactersImages();
            currentImage = imgs[0];
            bombTimers = new List<Timer>();
            bombTimerDict = new Dictionary<Bomb, Timer>();
            timerSizeDict = new Dictionary<Timer, int>();
            explosionTimerDict = new Dictionary<Timer, BombAnimationStruct>();

            InitializeComponent();


            timerDOWN.Interval = Utils.PLAYER_SPEED;
            timerUP.Interval = Utils.PLAYER_SPEED;
            timerRIGHT.Interval = Utils.PLAYER_SPEED;
            timerLEFT.Interval = Utils.PLAYER_SPEED;



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
                    gameState = GameEventArgs.START;
                    int width = game.Map.Width;
                    int height = game.Map.Height;
                    ClientSize = new System.Drawing.Size(width * Utils.TILE_SIZE, height * Utils.TILE_SIZE);

                    bombNumberImagePB.Location = new Point(this.Width / 2 - (bombNumberImagePB.Width + bombNumberPB.Width) / 2, 0);
                    bombNumberPB.Location = new Point(bombNumberImagePB.Location.X + bombNumberImagePB.Width, 0);

                    break;
                case GameEventArgs.DRAW:
                    gameState = GameEventArgs.DRAW;
                    Invalidate();
                    break;
                case GameEventArgs.WIN:
                    gameState = GameEventArgs.WIN;

                    timerDOWN.Stop();
                    timerUP.Stop();
                    timerLEFT.Stop();
                    timerRIGHT.Stop();

                    Invalidate();

                    KeyDown -= Gui_KeyDown;
                    KeyUp -= Gui_KeyUp;

                    timerWIN.Start();

                    break;
                case GameEventArgs.STARTBOMBTIMER:

                    Timer timer = new Timer();
                    timer.Interval = 5000;
                    timer.Tick += new EventHandler(bombTimer_Tick);

                    bombTimers.Add(timer);


                    Timer animationTimer = new Timer();
                    animationTimer.Interval = 650;
                    animationTimer.Tick += new EventHandler(bombAnimationTimer_Tick);

                    bombTimerDict.Add(game.ActivatedBombs[game.ActivatedBombs.Count - 1], animationTimer);
                    timerSizeDict.Add(animationTimer, 2);

                    timer.Enabled = true;
                    animationTimer.Enabled = true;
                    break;
            }


        }


        private void bombAnimationTimer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            if (timer.Interval > 50)
                timer.Interval -= 50;


            timerSizeDict[timer] = (timerSizeDict[timer] + 1) % 3;



            Invalidate();
        }

        private void bombTimer_Tick(object sender, EventArgs e)
        {

            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += new EventHandler(explosionTimer_Tick);
            explosionTimerDict.Add(timer, new BombAnimationStruct(game.ActivatedBombs[0].Coord, 0));

            timer.Enabled = true;




            bombTimers[0].Enabled = false;
            bombTimers.RemoveAt(0);


            bombTimerDict[game.ActivatedBombs[0]].Enabled = false;
            timerSizeDict.Remove(bombTimerDict[game.ActivatedBombs[0]]);
            bombTimerDict.Remove(game.ActivatedBombs[0]);



            game.exploseBomb();
        }

        private void explosionTimer_Tick(object sender, EventArgs e)
        {

            Timer timer = (Timer)sender;


            explosionTimerDict[timer].cmp++;
            if (explosionTimerDict[timer].cmp >= 3)
            {

                timer.Enabled = false;
                explosionTimerDict.Remove(timer);
            }

            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int width = game.Map.Width;
            int height = game.Map.Height;

            List<Bomb> bombs = game.Map.Bombs;
            foreach (Bomb b in bombs)
            {

                if (b.IsActivated)
                    e.Graphics.DrawImage(activatedBombImage, new Point(b.Coord.X * Utils.TILE_SIZE, b.Coord.Y * Utils.TILE_SIZE));

                else
                    e.Graphics.DrawImage(desactivatedBombImage, new Rectangle(b.Coord.X * Utils.TILE_SIZE, b.Coord.Y * Utils.TILE_SIZE, Utils.TILE_SIZE, Utils.TILE_SIZE));


            }

            List<Bomb> activatedBombs = game.ActivatedBombs;
            foreach (Bomb b in activatedBombs)
            {
                if (b.IsActivated)
                    e.Graphics.DrawImage(activatedBombImage, new Rectangle(b.Coord.X * Utils.TILE_SIZE + 5 * (2 - timerSizeDict[bombTimerDict[b]]),
                                                                              b.Coord.Y * Utils.TILE_SIZE + 5 * (2 - timerSizeDict[bombTimerDict[b]]),

                                                                              Utils.TILE_SIZE - 20 + 10 * timerSizeDict[bombTimerDict[b]],
                                                                              Utils.TILE_SIZE - 20 + 10 * timerSizeDict[bombTimerDict[b]]));
                else
                    e.Graphics.DrawImage(desactivatedBombImage, new Point(b.Coord.X * Utils.TILE_SIZE, b.Coord.Y * Utils.TILE_SIZE));

            }



            foreach (Teleporter t in game.Map.Teleporters)
            {
                Rectangle rect = new Rectangle(t.X * Utils.TILE_SIZE, t.Y * Utils.TILE_SIZE, Utils.TILE_SIZE, Utils.TILE_SIZE);
                e.Graphics.DrawImage(teleportImage, rect);// new Point(t.X * Utils.TILE_SIZE, t.Y * Utils.TILE_SIZE));
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Rectangle rect = new Rectangle(x * Utils.TILE_SIZE, y * Utils.TILE_SIZE, Utils.TILE_SIZE, Utils.TILE_SIZE);
                    switch (game.Map.tileTypeAt(x, y))
                    {
                        case TileType.WALL:
                            if (((Wall)game.Map.tileAt(x, y)).IsBreakable)
                                e.Graphics.DrawImage(blockImage, rect);// new Point(x * Utils.TILE_SIZE, y * Utils.TILE_SIZE));

                            else
                                e.Graphics.DrawImage(unbreakableBlockImage, rect);// new Point(x * Utils.TILE_SIZE, y * Utils.TILE_SIZE));
                            break;
                        case TileType.EXIT:
                            e.Graphics.DrawImage(exitImage, rect);// new Point(x * Utils.TILE_SIZE, y * Utils.TILE_SIZE));
                            break;

                        default:
                            break;
                    }
                }
            }
            if (currentImage != null)
                e.Graphics.DrawImage(currentImage, new Rectangle(game.Player.X * Utils.TILE_SIZE / Utils.MOVES_PER_TILE, game.Player.Y * Utils.TILE_SIZE / Utils.MOVES_PER_TILE, Utils.TILE_SIZE, Utils.TILE_SIZE));



            foreach (KeyValuePair<Timer, BombAnimationStruct> item in explosionTimerDict)
            {
                Coordinate c = item.Value.coord;

                int radius = item.Value.cmp;

                int sx = c.X - radius;
                int fx = c.X + radius;
                int sy = c.Y - radius;
                int fy = c.Y + radius;

                for (int x = sx; x <= fx; x++)
                {
                    for (int y = sy; y <= fy; y++)
                    {

                        if (x < width && y < height && x >= 0 && y >= 0)
                        {
                            Rectangle rect = new Rectangle(x * Utils.TILE_SIZE, y * Utils.TILE_SIZE, Utils.TILE_SIZE, Utils.TILE_SIZE);
                            e.Graphics.DrawImage(explosionImage, rect);// new Point(x * Utils.TILE_SIZE, y * Utils.TILE_SIZE));


                        }


                    }
                }
            }
            drawBombNumber();
        }

        private void drawBombNumber()
        {

            if (bombNumberPB.Image != null) bombNumberPB.Image.Dispose();
            var image = new Bitmap(bombNumberPB.Width, bombNumberPB.Height);

            var graphics = Graphics.FromImage(image);
            var font = new Font("TimesNewRoman", 12, FontStyle.Regular);
            graphics.DrawString("x" + game.Player.Bombs.Count, font, Brushes.Black, new Point(0, 6));
            bombNumberPB.Image = image;
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
                    if (!(gameState == GameEventArgs.WIN))
                        timerUP.Start();
                    break;
                case Keys.Down:
                    if (isMovingDOWN) return;
                    currentImage = imgs[0];
                    isMovingDOWN = true;
                    game.move(MovingDirection.DOWN);
                    if (!(gameState == GameEventArgs.WIN))
                        timerDOWN.Start();
                    break;
                case Keys.Left:
                    if (isMovingLEFT) return;
                    currentImage = imgs[1];
                    isMovingLEFT = true;
                    game.move(MovingDirection.LEFT);
                    if (!(gameState == GameEventArgs.WIN))
                        timerLEFT.Start();
                    break;
                case Keys.Right:
                    if (isMovingRIGHT) return;
                    currentImage = imgs[2];
                    isMovingRIGHT = true;
                    game.move(MovingDirection.RIGHT);
                    if (!(gameState == GameEventArgs.WIN))
                        timerRIGHT.Start();
                    break;
                case Keys.B:
                    game.PutBomb();
                    break;
            }

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
            currentImage = imgs[1];
            game.move(MovingDirection.LEFT);
        }

        private void timerRIGHT_Tick(object sender, EventArgs e)
        {
            currentImage = imgs[2];
            game.move(MovingDirection.RIGHT);
        }

        private void timerDOWN_Tick(object sender, EventArgs e)
        {
            currentImage = imgs[0];
            game.move(MovingDirection.DOWN);
        }

        private void timerUP_Tick(object sender, EventArgs e)
        {
            currentImage = imgs[3];
            game.move(MovingDirection.UP);
        }

        private void timerWIN_Tick(object sender, EventArgs e)
        {
            if (winTick == 0)
            {
                currentImage = null;
                winPictureBox = new PictureBox();
                winPictureBox.BackgroundImage = imgs[3];
                winPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                winPictureBox.BackColor = Color.Transparent;
                winPictureBox.Size = new Size(Utils.TILE_SIZE, Utils.TILE_SIZE);
                winPictureBox.Location = new Point(game.Player.X * Utils.TILE_SIZE / Utils.MOVES_PER_TILE, game.Player.Y * Utils.TILE_SIZE / Utils.MOVES_PER_TILE);
                this.Controls.Add(winPictureBox);

            }

            winPictureBox.Size = new Size(Utils.TILE_SIZE - 10 * winTick, Utils.TILE_SIZE - 10 * winTick);
            if (winTick != 0)
                winPictureBox.Location = new Point(winPictureBox.Location.X + 5, winPictureBox.Location.Y + 5);

            if (winTick == 4)
            {
                winTick = 0;
                timerWIN.Stop();

                handleWin();
            }
            winTick++;
        }

        private void Gui_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }


        private void handleWin()
        {
            //loadLevel(0);
            //exitApplication();
            restart();
            //showWinMessage("                       You won");
            //backToLevelSelection();

        }

        private void backToLevelSelection()
        {
            this.Dispose();
        }

        private void showWinMessage(string message)
        {
            PictureBox p = new PictureBox();
            p.Width = this.Width;
            p.Height = this.Height;
            this.Controls.Add(p);
            p.BackColor = Color.Transparent;

            p.Location = new Point(0, 0);

            var image = new Bitmap(p.Width, p.Height);
            var font = new Font("TimesNewRoman", 25, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(message, font, Brushes.Aqua, new Point(0, p.Height / 2 - 20));

            // p.ImageLayout = ImageLayout.Stretch;
            p.Image = image;

        }



        private void exitApplication()
        {
            Application.Exit();
        }

        private void loadLevel(int n)
        {

            if (n == -1 || levelSelectionForm.setSelectedLevel(n))
            {
                this.Dispose();
                levelSelectionForm.startButton.PerformClick();

            }

        }

        private void restart()
        {
            loadLevel(-1);
        }
    }
}
