using BlazorApp1.Client.Services.OT;
using BlazorApp1.Client.Services.Retiros;
using BlazorApp1.Shared.User;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IRetirosRepoService,RetirosRepoService>();
            builder.Services.AddScoped<IOrdenTrabajoRepoService, OrdenTrabajoRepoService>();
            //builder.Services.AddScoped<IUsuario, Usuario>();
            builder.Services.AddScoped<Usuario>();

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();


            await builder.Build().RunAsync();
        }
    }
}
