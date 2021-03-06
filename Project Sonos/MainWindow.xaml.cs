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
    public partial class MainWindow : Window
    {
        private ObservableCollection<Sound> sounds;
        private bool keysActivated;

        public MainWindow()
        {
            InitializeComponent();
            this.sounds = new ObservableCollection<Sound>();
            DataContext = this.sounds;
            this.lb_sounds.ItemsSource = this.sounds;
            this.keysActivated = true;
            foreach (Sound s in SQLiteHandler.InitializeSQLite("sounds.sqlite"))
            {
                this.sounds.Add(s);
            }
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
            if (MessageBox.Show("Would you like to save your sounds before exiting the applications?", "Project Sonos", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.SaveSounds(null, null);
            }
            this.Close();
        }

        private void NewSound(object sender, RoutedEventArgs e)
        {
            this.sounds.Add(new Sound(this.slider_changeVolume.Value));
        }

        private void PlaySound(object sender, MouseButtonEventArgs e)
        {
            if (this.lb_sounds.SelectedIndex != -1)
            {
                this.sounds[this.lb_sounds.SelectedIndex].PlaySound();
            }
        }

        private void changeSound(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Sound files (*.mp3, *.wav)|*.mp3; *.wav" };
            if (openFileDialog.ShowDialog() == true)
            {
                this.sounds[this.lb_sounds.SelectedIndex].ChangeSound(openFileDialog.FileName);
            }
        }

        private void changeImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Image files (*.png, *.jpg, *.gif)|*.png; *.jpg; *.gif" };
            if (openFileDialog.ShowDialog() == true)
            {
                this.sounds[this.lb_sounds.SelectedIndex].ChangeImage(openFileDialog.FileName);
            }
        }

        private void DeleteSound(object sender, RoutedEventArgs e)
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

        private void OpenBindWindow(object sender, RoutedEventArgs e)
        {
            if (this.lb_sounds.SelectedIndex != -1)
            {
                KeyBind keyBind = new KeyBind((Sound)this.lb_sounds.SelectedItem);
                keyBind.ShowDialog();
            }
        }

        private void PlaySoundFromKey(object sender, KeyEventArgs e)
        {
            if (this.keysActivated)
            {
                if (this.sounds.Any(i => i.Key == e.Key))
                    this.sounds.First(i => i.Key == e.Key).PlaySound();
            }
        }

        private void ChangeSoundsVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (this.sounds != null)
            {
                foreach (Sound s in this.sounds)
                {
                    if (s.MediaPlayer != null)
                    {
                        s.MediaPlayer.Volume = this.slider_changeVolume.Value;
                    }
                }
            }
        }

        private void StopSounds(object sender, MouseButtonEventArgs e)
        {
            foreach (Sound s in this.sounds)
            {
                s.MediaPlayer.Stop();
            }
        }

        private void ChangeBindingsState(object sender, MouseButtonEventArgs e) 
        {
            if (this.keysActivated)
            {
                this.keysActivated = false;
                this.ellipse_bidingsAllowed.Fill = new SolidColorBrush(Color.FromRgb(187, 14, 14));
            }
            else
            {
                this.keysActivated = true;
                this.ellipse_bidingsAllowed.Fill = new SolidColorBrush(Color.FromRgb(31, 201, 23));
            }
        }

        private void SaveSounds(object sender, MouseButtonEventArgs e)
        {
            SQLiteHandler.SaveSoundsToDatabase(new List<Sound>(this.sounds));
        }

        private void SearchSounds(object sender, TextChangedEventArgs e)
        {
            if (this.tb_searchSounds.Text != "")
            {
                IEnumerable<Sound> sounds =
                    from sound in this.sounds
                    where sound.Name.Contains(this.tb_searchSounds.Text) == true
                    select sound;

                this.lb_sounds.ItemsSource = new ObservableCollection<Sound>(sounds);
            }
            else
            {
                this.lb_sounds.ItemsSource = this.sounds;
            }
        }
    }
}
