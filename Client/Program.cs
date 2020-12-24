using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Skclusive.Core.Component;
using Skclusive.Material.AppBar;
using Skclusive.Material.Button;
using Skclusive.Material.Component;
using Skclusive.Material.Core;
using Skclusive.Material.Divider;
using Skclusive.Material.Layout;
using Skclusive.Material.Progress;
using Skclusive.Material.Table;
using Skclusive.Material.Toolbar;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RepoLiveSharpUpdateFailsWithMatBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var name = typeof(Microsoft.AspNetCore.SignalR.Client.HubConnection);
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Logging.SetMinimumLevel(LogLevel.Trace);




            builder.Services.TryAddMaterialViewServices(
                new LayoutConfigBuilder()
                .WithIsServer(false)
                .WithIsPreRendering(false)
                .WithResponsive(false)
                .Build());

            builder.Services.TryAddMaterialServices(
                new MaterialConfigBuilder()
                .WithTheme(Theme.Dark)
                .Build());


            builder.Services.AddHttpClient(
                    "assetmanager",
                    client => client.BaseAddress = new Uri("https://localhost:44311"));


            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AssetManager.Web.UI.Blazor.ServerAPI"));

            await builder.Build().RunAsync();
        }
    }
    public static class MaterialViewExtension
    {
        public static void TryAddMaterialViewServices(this IServiceCollection services, ILayoutConfig config)
        {
            services.TryAddLayoutServices(config);

            services.TryAddButtonServices(config);
            services.TryAddProgressServices(config);
            services.TryAddDividerServices(config);
            services.TryAddTableServices(config);
            services.TryAddAppBarServices(config);
            services.TryAddToolbarServices(config);

            //services.AddBlazorStyled();

            //services.TryAddStyleTypeProvider<MaterialStyleProvider>();
        }
    }
    //public class MaterialStyleProvider : StyleTypeProvider
    //{
    //    public MaterialStyleProvider() : base
    //    (
    //        typeof(SiteStyle),
    //        typeof(FullLayoutStyle),
    //        typeof(AssetManagerMainLayoutStyle)
    //    )
    //    {
    //    }
    //}
}
