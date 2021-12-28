using CarHome.Services.Models;

namespace CarHome.Services
{
    public interface IScreenService
    {
        public MusicPlayerService MusicPlayer { get; set; }
        public ScreenModel Navigate(string path);
        public ScreenModel GetScreenStatus();
        public BluetoothService BluetoothService { get; set; }
    }
}
