using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            await builder.Build().RunAsync();
        }
    }
}
