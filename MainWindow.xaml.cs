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

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
    }
}
