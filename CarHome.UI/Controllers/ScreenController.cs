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
    [ControllerProperty(Name = "ScreenController")]
    public class ScreenController : ChromelyController
    {
        private readonly IChromelyConfiguration _config;
        private readonly IChromelySerializerUtil _serializerUtil;
        private readonly IScreenService _screenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScreenController"/> class.
        /// </summary>
        public ScreenController(IChromelyConfiguration config, IChromelySerializerUtil serializerUtil, IScreenService screenService)
        {
            _config = config;
            _serializerUtil = serializerUtil;
            _screenService = screenService;
            RegisterRequest("screen/get", GetScreen);
            RegisterRequest("screen/navigate", Navigate);

        }

        private IChromelyResponse Navigate(IChromelyRequest request)
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
                var screen = _screenService.Navigate(path);
                var options = new JsonSerializerOptions();
                options.ReadCommentHandling = JsonCommentHandling.Skip;
                options.AllowTrailingCommas = true;
                response.Data = _serializerUtil.ObjectToJson(screen);
                response.Status = 200;

                return response;
            }

            response.Status = 400;
            return response;
        }

        private IChromelyResponse GetScreen(IChromelyRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = new ChromelyResponse(request.Id);

            var screen = _screenService.GetScreenStatus();

            var options = new JsonSerializerOptions();
            options.ReadCommentHandling = JsonCommentHandling.Skip;
            options.AllowTrailingCommas = true;
            response.Data = _serializerUtil.ObjectToJson(screen);

            return response;
        }

    }
}
