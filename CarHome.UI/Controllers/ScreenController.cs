using System;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely.Core.Network;
using CarHome.Services;

namespace CarHome.UI.Controllers
{
    /// <summary>
    /// Controller for all Screen Functions.
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
            RegisterRequest("screen/launchapp", LaunchApp);

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
            var path = request.Parameters["command"];

            if (path != null)
            {
                var screen = _screenService.Navigate(path);
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

            response.Status = 200;
            response.Data = _serializerUtil.ObjectToJson(screen);

            return response;
        }

        private IChromelyResponse LaunchApp(IChromelyRequest request)
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
            var command = request.Parameters["command"];

            if (command != null)
            {
                var app = System.Diagnostics.Process.Start(command);
                var screen = _screenService.GetScreenStatus();

                response.Data = _serializerUtil.ObjectToJson(screen);
                response.Status = 200;

                return response;
            }

            response.Status = 400;
            return response;
        }
    }
}
