using ManagedBass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarHome.Services
{
    public class MusicPlayerService : MediaPlayer
    {
        public bool Shuffle { get; set; }
        private MediaPlayer _player;
        public List<string> MusicList { get; set; }
        private int _currentSong;
        public MusicPlayerService()
        {
            _player = new MediaPlayer();
            MusicList = new List<string>();

            _player.MediaEnded += (s, e) =>
            {
                _player.Stop();
                if (_currentSong < MusicList.Count - 1)
                {
                    _currentSong += 1;
                    var loadMusicTask = Task.Run(() =>
                    {
                        return _player.LoadAsync(MusicList[_currentSong]);
                    });

                    loadMusicTask.Wait();

                    _player.Play();
                }
            };
        }

        public async Task LoadMusic(string path)
        {
            MusicList = Directory
                   .EnumerateFiles(path)
                   .Where(file => file.ToLower().EndsWith("mp3") || file.ToLower().EndsWith("flac"))
                   .ToList();

            if (MusicList.Count > 0)
            {
                _currentSong = 0;

                await _player.LoadAsync(MusicList[0]);

                _player.Play();
            }
        }

        public void NextTrack()
        {
            _currentSong += 1;
            var loadMusicTask = Task.Run(() =>
            {
                return _player.LoadAsync(MusicList[_currentSong]);
            });

            loadMusicTask.Wait();

            _player.Play();
        }

        public void PreviousTrack()
        {
            _currentSong -= 1;
            var loadMusicTask = Task.Run(() =>
            {
                return _player.LoadAsync(MusicList[_currentSong]);
            });

            loadMusicTask.Wait();

            _player.Play();
        }



    }
}
