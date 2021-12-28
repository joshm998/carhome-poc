using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHome.Services.Models
{
    internal class MediaModel
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public MediaStatus MediaStatus { get; set; }
        public int Duration { get; set; }
        public int Position { get; set; }
    }

    public enum MediaStatus
    {
        Playing,
        Paused,
    }
}
