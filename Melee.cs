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
using System.IO;

namespace LegendofGnome
{
    class Melee
    {
        private Canvas canvas;
        public Rectangle sword = new Rectangle();
        public bool hit;

        public Melee(Canvas c, Window window, Point Point)
        {
            sword.Height = 20;
            sword.Width = 20;
            //BitmapImage bitmapBackground = new BitmapImage(new Uri("Fireball Projectile.png", UriKind.Relative));
            //ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            sword.Fill = Brushes.Gray; //backgroundBrush;
            canvas.Children.Add(sword);
            double direction_x = Mouse.GetPosition(window).X;
            double direction_y = Mouse.GetPosition(window).Y;
            if (direction_x <= 0)
            {
                Canvas.SetLeft(this.sword, Point.X + 25);
            }
            Canvas.SetTop(this.sword, Point.Y + 25);
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
