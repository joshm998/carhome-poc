using System;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely.Core.Network;
using System.Threading.Tasks;
using CarHome.Services;

namespace CarHome.UI.Controllers
{
    /// <summary>
    /// Controller for all Bluetooth Functions.
    /// </summary>
    [ControllerProperty(Name = "BluetoothController")]
    public class BluetoothController : ChromelyController
    {
        private readonly IChromelyConfiguration _config;
        private readonly IChromelySerializerUtil _serializerUtil;
        private readonly IScreenService _screenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BluetoothController"/> class.
        /// </summary>
        public BluetoothController(IChromelyConfiguration config, IChromelySerializerUtil serializerUtil, IScreenService screenService)
        {
            _config = config;
            _serializerUtil = serializerUtil;
            _screenService = screenService;
            RegisterRequest("/bt", MusicControl);
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
            var commandType = request.Parameters["commandType"];
            var command = request.Parameters["command"];

            if (commandType != null)
            {
                switch(commandType)
                {
                    case "Next":
                        _screenService.BluetoothService.NextTrack();
                        goto default;
                    case "Previous":
                        _screenService.BluetoothService.PreviousTrack();
                        goto default;
                    case "Play":
                        _screenService.BluetoothService.Play();
                        goto default;
                    case "Pause":
                        _screenService.BluetoothService.Pause();
                        goto default;    
                    default:
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
