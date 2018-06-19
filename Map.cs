using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LegendofGnome
{
    class Map
    {
        public Random mapRandom = new Random();
        public Point doorPoint = new Point(0,0);
        public Rectangle door1 = new Rectangle();
        public Rectangle door2 = new Rectangle();
        public Rectangle Room1wallTop1 = new Rectangle();
        public Rectangle Room1wallTop2 = new Rectangle();
        public Rectangle Room1wallBot1 = new Rectangle();
        public Rectangle Room1wallBot2 = new Rectangle();
        public Rectangle Room1wallLeft = new Rectangle();
        public Rectangle Room1wallRight = new Rectangle();
        public Point wallPoint = new Point(0,0);

        public void MapGenerate(Rectangle door1, Canvas canvas, bool isRoom1)
        {
            Room1wallTop1.Height = 50;
            Room1wallTop1.Width = 450;
            canvas.Children.Add(Room1wallTop1);

            Room1wallRight.Height = 1000;
            Room1wallRight.Width = 50;
            canvas.Children.Add(Room1wallRight);

            Room1wallLeft.Height = 1000;
            Room1wallLeft.Width = 50;
            canvas.Children.Add(Room1wallLeft);

            Room1wallTop2.Height = 50;
            Room1wallTop2.Width = 450;
            canvas.Children.Add(Room1wallTop2);

            Room1wallBot1.Height = 50;
            Room1wallBot1.Width = 450;
            canvas.Children.Add(Room1wallBot1);

            Room1wallBot2.Height = 50;
            Room1wallBot2.Width = 450;
            canvas.Children.Add(Room1wallBot2);

            door1.Height = 25;
            door1.Width = 100;
            canvas.Children.Add(door1);

            door2.Height = 25;
            door2.Width = 100;
            canvas.Children.Add(door2);
        }

        public void room1Generate()
        {
            door1.Fill = Brushes.Red;
            Canvas.SetLeft(door1, doorPoint.X + 450);
            Canvas.SetTop(door1, doorPoint.Y);
          
            door2.Fill = Brushes.Red;
            Canvas.SetLeft(door2, doorPoint.X + 450);
            Canvas.SetTop(door2, doorPoint.Y +  940);

            Room1wallTop1.Fill = Brushes.Black;

            Room1wallTop2.Fill = Brushes.Black;
            Canvas.SetLeft(Room1wallTop2, wallPoint.X + 550);

            Room1wallBot1.Fill = Brushes.Black;
            Canvas.SetTop(Room1wallBot1, wallPoint.Y + 915);

            Room1wallBot2.Fill = Brushes.Black;
            Canvas.SetLeft(Room1wallBot2, wallPoint.X + 550);
            Canvas.SetTop(Room1wallBot2, wallPoint.Y + 915);

            Room1wallLeft.Fill = Brushes.Black;

            Room1wallRight.Fill = Brushes.Black;
            Canvas.SetLeft(Room1wallLeft, wallPoint.X + 935);
        }

        public void roomGenerate(bool isRoom1, bool isRoom2, bool isRoom3)
        {
            if (isRoom1 == true)
            {
                //MessageBox.Show("yay");
                room1Generate();
            }
            if(isRoom2 == true)
            {
                door1.Fill = Brushes.Blue;
                door2.Fill = Brushes.Blue;
                //MessageBox.Show("yay2");
            }
            if(isRoom3 == true)
            {
                door1.Fill = Brushes.Green;
                door2.Fill = Brushes.Green;
                //MessageBox.Show("yay3");
            }
        }
    }
}
