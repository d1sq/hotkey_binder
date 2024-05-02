using System.Collections.ObjectModel;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;

namespace mic_switcher_gui
{

    public class AudioDeviceManager
    {
        private readonly CoreAudioController _controller = new();
        public ObservableCollection<string> GetAudioDevices()
        {
            ObservableCollection<string> deviceNames = [];

            var devices = _controller.GetDevices(DeviceType.Capture, DeviceState.Active);
            foreach (var device in devices)
            {
                deviceNames.Add(device.FullName);
            }

            return deviceNames;
        }
        
        public void SetDefaultCommunicationDevice(string deviceName)
        {
            var devices = _controller.GetDevices(DeviceType.Capture, DeviceState.Active);
            var desiredMicrophone = devices.FirstOrDefault(device => device.FullName == deviceName);

            desiredMicrophone?.SetAsDefaultCommunications();
            desiredMicrophone?.SetAsDefault();
        }
    }







}

