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
        public Sound()
        {
            this.Name = "Default1";
            this.Key = "Default2";
            this.PathToSound = "Default3";
            this.Image = null;
        }

        public string Name { get; set; }
        public string PathToSound { get; set; }
        public string Key { get; set; }
        public BitmapImage Image { get; set; }

        public BitmapImage ChangeImage(string path)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(path));
            this.Image = bitmap;
            return bitmap;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
