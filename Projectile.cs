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

namespace *Namespace*
{
    class Projectile
    {
        public Cursor LOLHand;
        public double Click_X;
        public double Click_Y;
        public double slope_X;
        public double slope_Y;
        public Rectangle arrow = new Rectangle();
        public Point arrow_pos = new Point(250,144);
        public Projectile()
        {
            FileStream fileStream;//set cursor
            fileStream = new FileStream("LOLHand.cur", FileMode.Open);
            LOLHand = new Cursor(fileStream);
        }
        public void shoot(Canvas canvas)
        {
            arrow.Height = 5;
            arrow.Width = 5;
            arrow.Fill = Brushes.Black;
            canvas.Children.Add(arrow);
            arrow_pos.X = 250;
            arrow_pos.Y = 144;
            Canvas.SetLeft(arrow, arrow_pos.X);
            Canvas.SetTop(arrow, arrow_pos.Y);


        }

        public void FindSlope(Window window)
        {
            double player_X = 250;
            double player_Y = 144;

            Click_X = Mouse.GetPosition(window).X;
            Click_Y = Mouse.GetPosition(window).Y;
            //MessageBox.Show(Click_X.ToString() + " " + Click_Y.ToString());

            slope_Y = (player_Y - Click_Y);
            slope_X = (player_X - Click_X);
            //MessageBox.Show(slope_Y.ToString() + " " + slope_X.ToString());
            
            MainWindow.clicked = true;
        }

        public void Move(Canvas canvas)
        {
            arrow_pos.X = arrow_pos.X - (slope_X / 2);
            //Console.WriteLine(arrow_pos.X);
            Canvas.SetLeft(arrow, arrow_pos.X);
            arrow_pos.Y = arrow_pos.Y - (slope_Y / 2);
            Canvas.SetTop(arrow, arrow_pos.Y);
            //Console.WriteLine(arrow_pos.Y);
        }
    }
}
