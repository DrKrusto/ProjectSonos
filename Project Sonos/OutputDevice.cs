using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Sonos
{
    public class OutputDevice
    {
        public WaveOutCapabilities WaveOutCap { get; set; }
        public bool IsEnabled { get; set; }

        static public List<WaveOutCapabilities> FetchWaveOutCapabilities()
        {
            List<WaveOutCapabilities> outputDevices = new List<WaveOutCapabilities>();
            for (int n = 0; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                outputDevices.Add(caps);
            }
            return outputDevices;
        }

        static public List<OutputDevice> FetchOutputDevices()
        {
            List<OutputDevice> outputDevices = new List<OutputDevice>();
            for (int n = 0; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                outputDevices.Add(new OutputDevice { WaveOutCap = caps, IsEnabled = false });
            }
            return outputDevices;
        }
    }
}
