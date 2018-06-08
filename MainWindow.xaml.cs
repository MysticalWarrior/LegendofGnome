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
        bool isPlayerGenerated = false;
        Player player = new Player();
        DispatcherTimer GameTimer = new DispatcherTimer();
        DispatcherTimer movementTimer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            player.GeneratePlayer(Canvas);

            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 9000);//fps
            GameTimer.Start();
            
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000/6);
            movementTimer.Start();

            this.Cursor = projectile.LOLHand;
            this.ForceCursor = true;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

            player.Move(player.player_rectangle, Canvas);
        }
        
        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            projectile.Move(Canvas);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas.Children.Remove(projectile.arrow);
            projectile.shoot(Canvas);
            projectile.FindSlope(this);
        }
    }
}
