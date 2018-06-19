using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Player
    {
        public Rectangle playerRectangle = new Rectangle();
        Map map = new Map();

        public Point Move(Rectangle playerRectangle, Canvas canvas, Point playerPoint, bool isRoom1, bool isRoom2, bool isRoom3)
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                if (playerPoint.Y >= 55)
                {
                    
                    Console.WriteLine("w");
                    playerPoint.Y = playerPoint.Y - 10;

                }
                if (isRoom1 == true)
                {
                    if (playerPoint.Y <= 55 & playerPoint.X >= 450 & playerPoint.X <= 550)
                    {
                       // MessageBox.Show("wrong!");
                        playerPoint.Y -= 10;
                        if (playerPoint.Y == -50)
                        {
                            playerPoint.Y = 1000;
                        }
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (playerPoint.Y <= 860)
                {
                    Console.WriteLine("s");
                    playerPoint.Y += 10;

                }
                else if (isRoom1 == true)
                {
                    if (playerPoint.Y >= 850 & playerPoint.X >= 450 & playerPoint.X <= 550)
                    {
                        playerPoint.Y += 10;
                        {
                            if (playerPoint.Y == 1050)
                            {
                                playerPoint.Y = 0;
                            }
                        }
                    }
                }
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                if (playerPoint.X >= 60)
                {
                    Console.WriteLine("a");
                    playerPoint.X -= 10;
                }
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (playerPoint.X <= 880)
                {
                    Console.WriteLine("d");
                    playerPoint.X += 10;
                }
            }
            Update(playerRectangle, canvas, playerPoint);
            return playerPoint;
        }

        public void Update(Rectangle playerRectangle, Canvas canvas, Point playerPoint)
        {
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            Canvas.SetTop(playerRectangle, playerPoint.Y);
           
        }

        public void GeneratePlayer(Canvas canvas, Point playerPoint)
        {
            playerRectangle.Height = 50;
            playerRectangle.Width = 50;
            BitmapImage bitmapBackground = new BitmapImage(new Uri("Wizard Sprite.png", UriKind.Relative));
            ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            playerRectangle.Fill = backgroundBrush;
            canvas.Children.Add(playerRectangle);
            Canvas.SetLeft(playerRectangle, playerPoint.X);
            Canvas.SetTop(playerRectangle, playerPoint.Y);
            
        }
    }

}
