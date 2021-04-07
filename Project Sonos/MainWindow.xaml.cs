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
using SonosLib;
using System.Collections.ObjectModel;

namespace Project_Sonos
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Sound> sounds = new ObservableCollection<Sound>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = sounds;
            this.lb_sounds.ItemsSource = sounds;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void lbl_windowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void lbl_windowClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void lb_sounds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_newSound_Click(object sender, RoutedEventArgs e)
        {
            this.sounds.Add(new Sound());
        }

        private void ellipse_soundButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.lb_sounds.SelectedIndex != -1)
            {
                this.sounds[this.lb_sounds.SelectedIndex].PlaySound();
            }
        }

        private void changeSound(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.sounds[this.lb_sounds.SelectedIndex].ChangeSound(openFileDialog.FileName);
            }
        }

        private void changeImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.sounds[this.lb_sounds.SelectedIndex].ChangeImage(openFileDialog.FileName);
            }
        }

        private void mi_delete_Click(object sender, RoutedEventArgs e)
        {
            this.sounds.RemoveAt(this.lb_sounds.SelectedIndex);
        }

        private void tb_changeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tb  = (TextBox)sender;
                Keyboard.ClearFocus();
            }
        }
    }
}
