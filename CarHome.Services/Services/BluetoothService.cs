using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using bluez.DBus;
using Tmds.DBus;

namespace CarHome.Services
{
    public class BluetoothService
    {
        private IMediaPlayer1 _mediaController;
        public BluetoothService()
        {
            var systemConnection = Connection.System;
            _mediaController = systemConnection.CreateProxy<IMediaPlayer1>("org.bluez", "/org/bluez/hci0/dev_54_D1_7D_AD_0F_40/player0");
        }

        public void NextTrack()
        {
            Task.Run(() => _mediaController.NextAsync());
            Task.WaitAll();
        }
        
        public void PreviousTrack()
        {
            Task.Run(() => _mediaController.PreviousAsync());
            Task.WaitAll();
        }
        
        public void Play()
        {
            Task.Run(() => _mediaController.PlayAsync());
            Task.WaitAll();
        }
        
        public void Pause()
        {
            Task.Run(() => _mediaController.PauseAsync());
            Task.WaitAll();
        }

        public void GetTrackInfo()
        {
            var info = Task.Run(() => _mediaController.GetAllAsync());
            Task.WaitAll();
            Console.WriteLine(info);
        }
    }
}
