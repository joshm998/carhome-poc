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
using CarHome.Services;

namespace CarHome.UI.Controllers
{
    /// <summary>
    /// Controller for all Music Functions.
    /// </summary>
    [ControllerProperty(Name = "MusicController")]
    public class MusicController : ChromelyController
    {
        private readonly IChromelyConfiguration _config;
        private readonly IChromelySerializerUtil _serializerUtil;
        private readonly IScreenService _screenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicController"/> class.
        /// </summary>
        public MusicController(IChromelyConfiguration config, IChromelySerializerUtil serializerUtil, IScreenService screenService)
        {
            _config = config;
            _serializerUtil = serializerUtil;
            _screenService = screenService;
            RegisterRequest("/music", MusicControl);
        }

        private IChromelyResponse MusicControl(IChromelyRequest request)
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
            var commandType = request.Parameters["CommandType"];
            var command = request.Parameters["Command"];

            if (commandType != null)
            {
                switch(commandType)
                {
                    case "LoadMusic":
                        var loadMusicTask = Task.Run(() =>
                        {
                            return _screenService.MusicPlayer.LoadMusic(command);
                        });
                        loadMusicTask.Wait();
                        goto default;

                    case "Play":
                        _screenService.MusicPlayer.Play();
                        goto default;

                    case "Pause":
                        _screenService.MusicPlayer.Pause();
                        goto default;

                    case "Previous":
                        _screenService.MusicPlayer.PreviousTrack();
                        goto default;

                    case "Next":
                        _screenService.MusicPlayer.NextTrack();
                        goto default;

                    default:
                        var options = new JsonSerializerOptions();
                        options.ReadCommentHandling = JsonCommentHandling.Skip;
                        options.AllowTrailingCommas = true;
                        response.Data = _serializerUtil.ObjectToJson(_screenService.GetScreenStatus());
                        response.Status = 200;
                        return response;

                }
            }
            response.Status = 400;
            return response;
        }
    }
}
