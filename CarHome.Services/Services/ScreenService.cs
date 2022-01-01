using CarHome.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHome.Services
{
    public class ScreenService: IScreenService
    {
        private string _currentPath;
        private readonly FileBrowserService _fileBrowserService;
        public MusicPlayerService MusicPlayer { get; set; }
        public BluetoothService BluetoothService { get; set; }
        public ScreenService()
        {
            _currentPath = "home";
            _fileBrowserService = new FileBrowserService();
            MusicPlayer = new MusicPlayerService();
            BluetoothService = new BluetoothService();
        }
        
        public ScreenModel GetScreenStatus()
        {
            switch (_currentPath)
            {
                case "media":
                    if (MusicPlayer.MusicList.Count == 0)
                        return new ScreenModel("Select Drive", _fileBrowserService.GetDrives(), ScreenType.ListView);
                    else
                        goto default;

                default:
                    using (var r = new StreamReader($"data/{_currentPath}.json"))
                    {
                        var json = r.ReadToEnd();
                        var model = JsonConvert.DeserializeObject<ScreenModel>(json);
                        return model;
                    }

            }
            
        }

        public ScreenModel Navigate(string path)
        {
            _currentPath = path;
            return GetScreenStatus();
        }
    }
}
