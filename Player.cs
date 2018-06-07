using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Player
    {
        
        Point point = new Point(0, 0);
        public Rectangle player_rectangle = new Rectangle();

        public void Move(Rectangle player_rectangle, Canvas canvas)
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                if (point.Y >= 0)
                {
                    Console.WriteLine("w");
                    point.Y = point.Y - 1;

                   
                    

                }
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                if (point.Y <= 910)
                {
                    Console.WriteLine("s");
                    point.Y += 1;
                    
                }
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                if (point.X >= 0)
                {
                    Console.WriteLine("a");
                    point.X -= 1;
                }
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                if (point.X <= 1230)
                {
                    Console.WriteLine("d");
                    point.X += 1;
                }
            }
            Update(player_rectangle, canvas);
        }

        public void Update(Rectangle player_rectangle, Canvas canvas)
        {
            Canvas.SetLeft(player_rectangle, point.X);
            Canvas.SetTop(player_rectangle, point.Y);
        }

        public void GeneratePlayer(Canvas canvas)
        {
            player_rectangle.Height = 50;
            player_rectangle.Width = 50;
            canvas.Children.Add(player_rectangle);
            Canvas.SetLeft(player_rectangle, point.X);
            Canvas.SetTop(player_rectangle, point.Y);
            player_rectangle.Fill = Brushes.Red;
        }
    }

}
