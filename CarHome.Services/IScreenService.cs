using CarHome.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHome.Services
{
    public interface IScreenService
    {
        public MusicPlayerService MusicPlayer { get; set; }
        public ScreenModel Navigate(string path);
        public ScreenModel GetScreenStatus();
    }
}
