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
        MediaPlayer mediaPlayer = new MediaPlayer();
        ObservableCollection<Sound> sounds = new ObservableCollection<Sound>();

        public MainWindow()
        {
            InitializeComponent();
            MouseDown += MainWindow_MouseDown;

            this.lb_sounds.ItemsSource = sounds;
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void btn_changeSound_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_changeSoundName_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lb_sounds_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ellipse_soundButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.lb_sounds.SelectedIndex != -1)
            {
                if (this.sounds[this.lb_sounds.SelectedIndex].PathToSound != "Default3")
                {
                    mediaPlayer.Open(new Uri(this.sounds[this.lb_sounds.SelectedIndex].PathToSound));
                    mediaPlayer.Play();
                }
            }
        }

        private void changeSound(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.sounds[this.lb_sounds.SelectedIndex].PathToSound = openFileDialog.FileName;
            }
        }

        private void changeImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.sounds[this.lb_sounds.SelectedIndex].PathToImage = openFileDialog.FileName;
            }
        }

        private void mi_delete_Click(object sender, RoutedEventArgs e)
        {
            this.sounds.RemoveAt(this.lb_sounds.SelectedIndex);
        }
    }
}
