using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Project_Sonos
{
    public class Sound : INotifyPropertyChanged
    {
        private ImageBrush image;
        private MediaPlayer mediaPlayer;
        private Key? key;
        private string name;
        private string pathToSound;
        private string pathToImage;
        public event PropertyChangedEventHandler PropertyChanged;

        public Sound(double volume)
        {
            this.Name = "New sound";
            this.Key = null;
            this.PathToSound = "none";
            this.PathToImage = "none";
            this.image = null;
            this.mediaPlayer = new MediaPlayer() { Volume = volume };
        }

        public MediaPlayer MediaPlayer
        {
            get { return this.mediaPlayer; }
        }

        public string Name {
            get { return this.name; }
            set { this.name = value; }
        }

        public string PathToImage {
            get { return this.pathToImage; }
            set { this.pathToImage = value; }
        }

        public string PathToSound {
            get { return this.pathToSound; } 
            set { this.pathToSound = value; }
        }

        public Key? Key {
            get { return this.key; } 
            set { 
                this.key = value;
                OnPropertyChanged();
            } 
        }

        public ImageBrush Image
        {
            get
            {
                if (this.image == null)
                {
                    image = new ImageBrush();
                    BitmapImage bit = new BitmapImage();
                    bit.BeginInit();
                    bit.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    bit.CacheOption = BitmapCacheOption.OnLoad;
                    bit.UriSource = new Uri("pack://application:,,,/Resources/1200px-Button_Icon_Red.svg.png");
                    bit.EndInit();
                    image.ImageSource = bit;
                }
                return image;
            }
            set
            {
                this.image = value;
            }
        }

        public void ChangeImage(string path)
        {
            this.pathToImage = path;
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bit.CacheOption = BitmapCacheOption.OnLoad;
            bit.UriSource = new Uri(path);
            bit.EndInit();
            this.image.ImageSource = bit;
        }

        public void ChangeSound(string path)
        {
            this.PathToSound = path;
        }

        public void PlaySound()
        {
            if (this.PathToSound != "none")
            {
                mediaPlayer.Open(new Uri(this.PathToSound));
                mediaPlayer.Play();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string key = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
