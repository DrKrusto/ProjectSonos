using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SonosLib
{
    public class Sound
    {
        private ImageBrush image;
        private MediaPlayer mediaPlayer;

        public Sound()
        {
            this.Name = "New sound";
            this.Key = "Default2";
            this.PathToSound = "none";
            this.image = null;
            this.mediaPlayer = new MediaPlayer();
        }

        public string Name { get; set; }
        public string PathToSound { get; set; }
        public string Key { get; set; }
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
                    bit.UriSource = new Uri(@"C:\Users\evanr\source\repos\Project Sonos\Project Sonos\1200px-Button_Icon_Red.svg.png");
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

        public override string ToString()
        {
            return this.Name;
        }
    }
}
