// Copyright © 2017-2020 Chromely Projects. All rights reserved.
// Use of this source code is governed by MIT license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Chromely;
using ManagedBass;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely.Core.Network;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace ChromelyReact.Controllers
{
    /// <summary>
    /// The demo controller.
    /// </summary>
    [ControllerProperty(Name = "MusicController")]
    public class MusicController : ChromelyController
    {
        private readonly IChromelyConfiguration _config;
        private readonly IChromelySerializerUtil _serializerUtil;
        private readonly MediaPlayer _player;
        private List<string> _musicList;
        private int _currentSong;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicController"/> class.
        /// </summary>
        public MusicController(IChromelyConfiguration config, IChromelySerializerUtil serializerUtil)
        {
            _config = config;
            _serializerUtil = serializerUtil;
            _player = new MediaPlayer();
            _currentSong = 0;
            _musicList = new List<string>();
            RegisterRequest("/music/load", LoadMusic);
            RegisterRequest("/music/pause", PauseMusic);
            RegisterRequest("/music/play", PlayMusic);
            RegisterRequest("drives/list", GetDrives);

            _player.MediaEnded += (s, e) =>
            {
                _player.Stop();
                if (_currentSong < _musicList.Count - 1)
                {
                    _currentSong += 1;
                    var loadMusicTask = Task.Run(() =>
                    {
                        return LoadMusic(_musicList[_currentSong]);
                    });

                    loadMusicTask.Wait();

                    _player.Play();
                }

            };
        }

    private IChromelyResponse LoadMusic(IChromelyRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Parameters == null)
            {
                throw new Exception("Parameters are null or invalid.");
            }

            var response = new ChromelyResponse(request.Id);
            var path = request.Parameters["path"];

            if (path != null)
            {
                _musicList = Directory
                    .EnumerateFiles(path)
                    .Where(file => file.ToLower().EndsWith("mp3") || file.ToLower().EndsWith("flac"))
                    .ToList();

                if (_musicList.Count > 0)
                {
                    _currentSong = 0;

                    var loadMusicTask = Task.Run(() =>
                    {
                        return LoadMusic(_musicList[0]);
                    });

                    loadMusicTask.Wait();

                    _player.Play();
                }
            }

            var options = new JsonSerializerOptions();
            options.ReadCommentHandling = JsonCommentHandling.Skip;
            options.AllowTrailingCommas = true;
            response.Data = _serializerUtil.ObjectToJson(_player);
            response.Status = 200;

            return response;
        }

        private IChromelyResponse PauseMusic(IChromelyRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = new ChromelyResponse(request.Id);

            _player.Pause();

            var options = new JsonSerializerOptions();
            options.ReadCommentHandling = JsonCommentHandling.Skip;
            options.AllowTrailingCommas = true;
            response.Data = _serializerUtil.ObjectToJson(_player);

            return response;
        }

        private IChromelyResponse PlayMusic(IChromelyRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = new ChromelyResponse(request.Id);

            _player.Play();

            var options = new JsonSerializerOptions();
            options.ReadCommentHandling = JsonCommentHandling.Skip;
            options.AllowTrailingCommas = true;
            response.Data = _serializerUtil.ObjectToJson(_player);

            return response;
        }

        private IChromelyResponse GetDrives(IChromelyRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = new ChromelyResponse(request.Id);

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            var removableDrives = allDrives.Where(e => e.DriveType == DriveType.Removable);

            var options = new JsonSerializerOptions();
            options.ReadCommentHandling = JsonCommentHandling.Skip;
            options.AllowTrailingCommas = true;
            response.Data = _serializerUtil.ObjectToJson(removableDrives);

            return response;
        }

        private async Task LoadMusic(string path)
        {
            await _player.LoadAsync(path);
        }
    }
}
