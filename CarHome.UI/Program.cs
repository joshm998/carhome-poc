using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CarHome.Services;
using Chromely;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely.Core.Network;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarHome.UI
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var config = DefaultConfiguration.CreateForRuntimePlatform();
            config.StartUrl = "http://localhost:3000";
            //config.StartUrl = "local://dist/index.html";
            config.UrlSchemes.Add(new UrlScheme("default-custom-http", "http", "backend", string.Empty, UrlSchemeType.LocalRequest, false));
            //Enable Kiosk Mode
            config.WindowOptions.KioskMode = false;

            AppBuilder
            .Create()
            .UseConfig<DefaultConfiguration>(config)
            .UseApp<UIApp>()
            .Build()
            .Run(args);
        }
    }

    public class UIApp : ChromelyBasicApp
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddLogging(configure => configure.AddConsole());
            services.AddLogging(configure => configure.AddFile("Logs/serilog-{Date}.txt"));
            services.AddScoped<IScreenService, ScreenService>();
            /*
            // Optional - adding custom handler
            services.AddSingleton<CefDragHandler, CustomDragHandler>();
            */

            /*
            // Optional- using config section to register IChromelyConfiguration
            // This just shows how it can be used, developers can use custom classes to override this approach
            //
            var builder = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var config = DefaultConfiguration.CreateFromConfigSection(configuration);
            services.AddSingleton<IChromelyConfiguration>(config);
            */

           var options = new JsonSerializerOptions();
            options.ReadCommentHandling = JsonCommentHandling.Skip;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.AllowTrailingCommas = true;
            options.Converters.Add(new JsonStringEnumConverter());
            services.AddSingleton<JsonSerializerOptions>(options);


            RegisterControllerAssembly(services, typeof(UIApp).Assembly);
        }
    }
}