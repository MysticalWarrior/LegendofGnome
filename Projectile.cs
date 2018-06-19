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
    class Projectile
    {
        public double speed_X;
        public double speed_Y;
        private Canvas canvas;
        public Ellipse projectile;
        public Point arrow_pos = new Point(250, 144);
        public Point playerPoint;
        public bool moving;

        public Projectile(Canvas c, Window window, Point pP)
        {
            canvas = c;
            playerPoint = pP;
            projectile = new Ellipse();
            projectile.Height = 20;
            projectile.Width = 20;

            BitmapImage bitmapBackground = new BitmapImage(new Uri("Shuriken Projectile.png", UriKind.Relative));
            ImageBrush backgroundBrush = new ImageBrush(bitmapBackground);
            projectile.Fill = backgroundBrush;
            canvas.Children.Add(projectile);
            FindSlope(window);
            Canvas.SetLeft(this.projectile, playerPoint.X + 25);
            Canvas.SetTop(this.projectile, playerPoint.Y + 25);
            moving = true;
        }

        public void FindSlope(Window window)
        {
            double Click_X = Mouse.GetPosition(window).X - playerPoint.X;
            double Click_Y = Mouse.GetPosition(window).Y - playerPoint.Y;
            //MessageBox.Show(Click_X.ToString() + " " + Click_Y.ToString());

            double angle = Math.Atan2(Click_Y, Click_X);
            //find the length of lines on preset circle that coresponds with the angle.(changing circle width changes speed of projectiles)
            speed_Y = Math.Sin(angle) * 60; //sin(angle) = x/100 * 100 = x
            speed_X = Math.Cos(angle) * 60; //cos(angle) = y/100 * 100 = y
            //Console.WriteLine("speed of projectile " + speed_X + " " + speed_Y);
        }

        public bool move()
        {
            if (moving)
            {
                if (arrow_pos.X >= 50 & arrow_pos.X <= 950 & arrow_pos.Y >= 50 & arrow_pos.Y <= 750)
                {
                    arrow_pos.X = Canvas.GetLeft(this.projectile) + speed_X;
                    Canvas.SetLeft(this.projectile, arrow_pos.X);
                    arrow_pos.Y = Canvas.GetTop(this.projectile) + speed_Y;
                    Canvas.SetTop(this.projectile, arrow_pos.Y);
                }
                else
                {
                    moving = false;
                    canvas.Children.Remove(this.projectile);
                }
            }
            return moving;
        }

        public bool checkCollision(Point s, Rectangle source)
        {
            bool temp = false;
            Point t = arrow_pos;
            Ellipse target = projectile;

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
