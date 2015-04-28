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

namespace TitleScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bgm.Play();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            EnterLeaveGame();
        }

        private void XButton_Click(object sender, RoutedEventArgs e)
        {
            EnterLeaveGame();
        }

        private void TitleBarTip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void TitleBarButt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void LeaveGameOkButton_Click(object sender, RoutedEventArgs e)
        {
            // shuts down the instance of the wpf application.
            Application.Current.Shutdown();
        }

        private void LeaveGameCancelButton_Click(object sender, RoutedEventArgs e)
        {
            bgm.Volume = 0.5;
            LeaveGameCancelButton.Visibility = Visibility.Hidden;
            LeaveGameOkButton.Visibility = Visibility.Hidden;
            LeaveGameLabel.Visibility = Visibility.Hidden;
            LeaveGamePopUp.Visibility = Visibility.Hidden;
            BlackOut.Visibility = Visibility.Hidden;
        }

        private void bgm_MediaEnded(object sender, RoutedEventArgs e)
        {
            bgm.Position = TimeSpan.Zero;
            bgm.Play();
        }

        private void EnterLeaveGame()
        {
            BlackOut.Visibility = Visibility.Visible;
            LeaveGamePopUp.Visibility = Visibility.Visible;
            LeaveGameLabel.Visibility = Visibility.Visible;
            LeaveGameOkButton.Visibility = Visibility.Visible;
            LeaveGameCancelButton.Visibility = Visibility.Visible;
            bgm.Volume = 0.2;
        }
    }
}
