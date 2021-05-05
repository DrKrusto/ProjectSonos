using Microsoft.Win32;
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
using System.Collections.ObjectModel;

namespace Project_Sonos
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class KeyBind : Window
    {
        private Sound sound;

        public KeyBind(Sound sound)
        {
            InitializeComponent();
            this.sound = sound;
            this.lbl_Key.DataContext = this.sound;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ChangeKeyBind(object sender, KeyEventArgs e)
        {
            this.sound.Key = e.Key;
        }
    }
}
