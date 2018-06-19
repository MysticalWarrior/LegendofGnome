using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LegendofGnome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isRoom1 = true;
        public bool isRoom2 = false;
        public bool isRoom3 = false;
        public Point playerPoint = new Point(500, 500);
        public Random mapRandom = new Random();
        public Rectangle door1 = new Rectangle();
        public Rectangle door2 = new Rectangle();
        public Rectangle door3 = new Rectangle();
        public Rectangle wallTop1 = new Rectangle();
        public Rectangle wallTop2 = new Rectangle();
        public Rectangle wallBot1 = new Rectangle();
        public Rectangle wallBot2 = new Rectangle();
        public Rectangle wallLeft1 = new Rectangle();
        public Rectangle wallLeft2 = new Rectangle();
        public Rectangle wallRight1 = new Rectangle();
        public Rectangle wallRight2 = new Rectangle();
        public Point enemyPoint = new Point(1000, 1000);
        Map map = new Map();
        Player player = new Player();
        List<Projectile> projectiles = new List<Projectile>();
        List<Enemy> enemies = new List<Enemy>();
        DispatcherTimer GameTimer = new DispatcherTimer();
        DispatcherTimer projectileTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            bool isGenerated = false;
            if (isGenerated == false)
            {
                map.MapGenerate(Canvas, door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                enemies.Add(new Enemy(Canvas, enemyPoint));
                Melee melee = new Melee(Canvas, this, playerPoint);
                player.GeneratePlayer(Canvas, playerPoint);
                isGenerated = true;
            }

            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            GameTimer.Start();

            projectileTimer.Tick += MovementTimer_Tick;
            projectileTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            projectileTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            map.roomGenerate(isRoom1, isRoom2, isRoom3, door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);

            for (int i = 0; i < enemies.Count(); i++)
            {
                enemyPoint = enemies[i].Move(playerPoint, enemyPoint);
                if (checkCollision(enemyPoint, playerPoint, enemies[0].enemyRectangle, player.playerRectangle))
                {
                    //MessageBox.Show("hit");//troubleshooting
                }
            }

            playerPoint = player.Move(player.playerRectangle, Canvas, playerPoint, isRoom1, isRoom2, isRoom3, door1, door2, door3, wallTop1, wallTop2, wallLeft1, wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
            //Console.WriteLine(playerPoint.ToString());//troubleshooting
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            Canvas.Children.Remove(Melee.)
            if (playerPoint.X >= 350 & playerPoint.X <= 450)
            {
                if (playerPoint.Y <= 50 & Keyboard.IsKeyDown(Key.W))
                {

                    playerPoint.Y -= 10;
                    if (playerPoint.Y <= 0)
                    {
                        playerPoint.Y = 750;
                        if (isRoom1 == true)
                        {
                            isRoom1 = false;
                            isRoom2 = true;
                            isRoom3 = false;

                            map.room2Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            return;
                        }

                        if (isRoom2 == true)
                        {
                            isRoom1 = false;
                            isRoom2 = false;
                            isRoom3 = true;

                            map.room3Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                            return;
                        }
                    }

                }
                if (playerPoint.Y >= 700 & Keyboard.IsKeyDown(Key.S))
                {
                    if (isRoom2 == true)
                    {
                        playerPoint.Y = 55;
                        isRoom1 = true;
                        isRoom2 = false;
                        isRoom3 = false;

                        map.room1Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                            wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                        return;
                    }
                    if (isRoom3 == true)
                    {
                        playerPoint.Y = 55;
                        isRoom1 = false;
                        isRoom2 = true;
                        isRoom3 = false;
                        map.room2Generate(door1, door2, door3, wallTop1, wallTop2, wallLeft1,
                                wallLeft2, wallRight1, wallRight2, wallBot1, wallBot2);
                        return;
                    }
                }
            }

            for (int i = 0; i < projectiles.Count(); i++)
            {
                if (projectiles[i].checkCollision(enemyPoint, enemies[0].enemyRectangle))
                {
                    if (enemies[0].hit())
                    {
                        Canvas.Children.Remove(projectiles[i].projectile);
                    }
                }
                if (projectiles[i].move() == false)
                {
                    projectiles.Remove(projectiles[i]);
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                projectiles.Add(new Projectile(Canvas, this, playerPoint));
            }
            if (Mouse.RightButton == MouseButtonState.Pressed)
            {
                Melee melee = new Melee(Canvas, this, playerPoint);
            }
            //MessageBox.Show(e.GetPosition(Canvas).ToString());
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.C))
            {
                isRoom1 = true;
                isRoom2 = false;
                isRoom3 = false;
                //MessageBox.Show(map.roomNumber.ToString());
            }
            if (Keyboard.IsKeyDown(Key.X))
            {
                isRoom1 = false;
                isRoom2 = true;
                isRoom3 = false;
               // MessageBox.Show(map.roomNumber.ToString());
            }
            if (Keyboard.IsKeyDown(Key.Z))
            {
                isRoom1 = false;
                isRoom2 = false;
                isRoom3 = true;
               // MessageBox.Show(map.roomNumber.ToString());
            }
        }

        public bool checkCollision(Point t, Point s, Rectangle target, Rectangle source)
        {
            bool temp = false;

            if (t.X <= s.X + source.Width & t.Y <= s.Y + source.Height)
            {
                if (t.X + target.Width >= s.X & t.Y + target.Height >= s.Y)
                {
                    temp = true;
                }
            }
            return temp;
        }
    }
}
