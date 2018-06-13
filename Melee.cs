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
        public Rectangle[] sword = new Rectangle[5];
        public Point sword_tip = new Point(250, 144);
        public Point playerPoint;

        public Melee(Canvas c, Window window, Point pP)
        {
            canvas = c;
            playerPoint = pP;
            for (int i = 0; i < 5; i++)
            {
                sword[i].Height = 20;
                sword[i].Width = 20;
                //BitmapImage bitmapBackground = new BitmapImage(new Uri("Fireball Projectile.png", UriKind.Relative));
                //ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
                sword[i].Fill = Brushes.Gray; //backgroundBrush;
                canvas.Children.Add(sword[i]);
                double direction_x = Mouse.GetPosition(window).X;
                double direction_y = Mouse.GetPosition(window).Y;
                if (direction_x <= 0)
                {
                    Canvas.SetLeft(this.sword[i], playerPoint.X + 25);
                }
                Canvas.SetTop(this.sword[i], playerPoint.Y + 25);
            }
        }
    }
}
