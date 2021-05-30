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
using NAudio.Wave;

namespace Project_Sonos
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class OutputDevices : Window
    {
        private List<OutputDevice> outputDevices;

        public OutputDevices(List<OutputDevice> outputDevices)
        {
            InitializeComponent();
            this.outputDevices = outputDevices;
            this.lv_outputDevices.ItemsSource = this.outputDevices;
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
            foreach (OutputDevice device in this.outputDevices)
            {
                Sound.OutputDevices.Clear();
                if (device.IsEnabled)
                {
                    
                }
            }
            this.Close();
        }
    }
}
