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
        Player player = new Player();
        Rectangle player_rectangle = new Rectangle();
        public int y_pos = 0;
        public int x_pos = 0;
        DispatcherTimer GameTimer = new DispatcherTimer();

        public MainWindow()
        {


            InitializeComponent();
           
            player.GeneratePlayer(canvas);
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);//fps
            GameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            player.Move(player_rectangle);
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double player_X = 250;
            double player_Y = 144;

            Click_X = Mouse.GetPosition(this).X;
            Click_Y = Mouse.GetPosition(this).Y;
            MessageBox.Show(Click_X.ToString() + " " + Click_Y.ToString());

            double slope_Y = (player_Y - Click_Y);
            double slope_X = (player_X - Click_X);
            MessageBox.Show((slope_Y/slope_X).ToString());

            //takes 2 seconds for a projectile to get somwhere
            double radius = 50;
            clicked = true;
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
