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
        private IMediaControl1 _mediaController;
        public BluetoothService()
        {
            var systemConnection = Connection.System;
            _mediaController = systemConnection.CreateProxy<IMediaControl1>("org.bluez", "/org/bluez/hci0/dev_54_D1_7D_AD_0F_40/player0");
        }

        public void NextTrack()
        {
            var nextTrackTask = Task.Run(() => _mediaController.NextAsync());
            var details = Task.Run(() => _mediaController.GetAllAsync());
        }
    }
}
