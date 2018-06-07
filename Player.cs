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
        int x_pos = 0;
        int y_pos = 0;
        public void Move(Rectangle player_rectangle)
        {
            if(Keyboard.IsKeyDown(Key.W))
            {
                if (y_pos < 850)
                {
                    MessageBox.Show("w");
                    y_pos -= 2;

                }

            }
            if(Keyboard.IsKeyDown(Key.S))
            {
                if (y_pos > 0)
                {
                    y_pos += 2; 
                }
            }
            if(Keyboard.IsKeyDown(Key.A))
            {
                if (x_pos > 0)
                {
                    x_pos -= 2;
                }
            }
            if(Keyboard.IsKeyDown(Key.D))
            {
                if(x_pos <850)
                {
                    x_pos += 2;
                }
            }
            Canvas.SetLeft(player_rectangle, x_pos);
            Canvas.SetTop(player_rectangle, y_pos);

        }
        public void GeneratePlayer(Canvas canvas)
        {
            Rectangle player_rectangle = new Rectangle();
            player_rectangle.Height = 50;
            player_rectangle.Width = 50;
            canvas.Children.Add(player_rectangle);
            Canvas.SetLeft(player_rectangle, x_pos);
            Canvas.SetTop(player_rectangle, y_pos);
            player_rectangle.Fill = Brushes.Red;
            
        }
    }

}
