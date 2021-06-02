using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;

namespace Project_Sonos
{
    public static class SQLiteHandler
    {
        private static SQLiteConnection cnx;

        public static List<Sound> InitializeSQLite(string pathToDB)
        {
            if (!File.Exists(pathToDB))
            {
                SQLiteConnection.CreateFile(pathToDB);
                cnx = new SQLiteConnection(String.Format("Data Source={0};Version=3;", pathToDB));
                CreateTables();
            }
            else
            {
                cnx = new SQLiteConnection(String.Format("Data Source={0};Version=3;", pathToDB));
                return SQLiteHandler.FetchSounds();
            }
            return new List<Sound>();
        }

        private static void CreateTables()
        {
            cnx.Open();
            string cmdS = "CREATE TABLE sounds (name VARCHAR(30), pathToSound VARCHAR(80), pathToImage VARCHAR(80), key VARCHAR(40))";
            SQLiteCommand cmd = new SQLiteCommand(cmdS, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public static List<Sound> FetchSounds()
        {
            cnx.Open();
            List<Sound> sounds = new List<Sound>();
            SQLiteCommand cmd = new SQLiteCommand(cnx) { CommandText = "SELECT name, pathToSound, pathToImage, key FROM sounds;" };
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.IsDBNull(3))
                {
                    sounds.Add(SQLiteHandler.CreateSoundFromSQL(reader.GetString(0), reader.GetString(1), reader.GetString(2), null));
                }
                else
                {
                    sounds.Add(SQLiteHandler.CreateSoundFromSQL(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }
            }
            reader.Close();
            cnx.Close();
            return sounds;
        }

        private static Sound CreateSoundFromSQL(string name, string pathToSound, string pathToImage, string key)
        {
            Key? definedKey = null;
            if (key != null)
            {
                definedKey = (Key)Enum.Parse(typeof(Key), key);
            }
            Sound sound = new Sound(0.5) { Name = name, PathToSound = pathToSound, PathToImage = pathToImage, Key = definedKey };
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bit.CacheOption = BitmapCacheOption.OnLoad;
            try
            {
                bit.UriSource = new Uri(pathToImage);
            }
            catch
            {
                bit.UriSource = new Uri("pack://application:,,,/Resources/1200px-Button_Icon_Red.svg.png");
            }
            bit.EndInit();
            sound.Image.ImageSource = bit;
            return sound;
        } 

        public static void SaveSoundsToDatabase(List<Sound> sounds)
        {
            cnx.Open();
            SQLiteCommand cmd = new SQLiteCommand(cnx) { CommandText = "DELETE FROM sounds;" };
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO sounds(name, pathToSound, pathToImage, key) VALUES (@name, @pathToSound, @pathToImage, @key);";
            cmd.Parameters.Add(new SQLiteParameter("@name"));
            cmd.Parameters.Add(new SQLiteParameter("@pathToSound"));
            cmd.Parameters.Add(new SQLiteParameter("@pathToImage"));
            cmd.Parameters.Add(new SQLiteParameter("@key"));
            foreach (Sound s in sounds)
            {
                cmd.Parameters["@name"].Value = s.Name;
                cmd.Parameters["@pathToSound"].Value = s.PathToSound;
                cmd.Parameters["@pathToImage"].Value = s.PathToImage;
                if (s.Key == null)
                    cmd.Parameters["@key"].Value = DBNull.Value;
                else
                    cmd.Parameters["@key"].Value = s.Key.ToString();
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            cnx.Close();
            MessageBox.Show("Sounds saved.");
        }
    }
}
