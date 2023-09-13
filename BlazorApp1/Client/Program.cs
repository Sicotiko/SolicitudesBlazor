using BlazorApp1.Client.Components.Loading;
using BlazorApp1.Client.Services;
using BlazorApp1.Client.Services.ClienteWeb;
using BlazorApp1.Client.Services.Comunas;
using BlazorApp1.Client.Services.Dialogs;
using BlazorApp1.Client.Services.Login;
using BlazorApp1.Client.Services.Moviles;
using BlazorApp1.Client.Services.Notifications;
using BlazorApp1.Client.Services.OT;
using BlazorApp1.Client.Services.Retiros;
using BlazorApp1.Client.Utilities;
using BlazorApp1.Shared.Modelo.Moviles;
using BlazorApp1.Shared.User;
using BlazorApp1.Shared.ViewModel;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            builder.Services.AddScoped<LoadingScreen>();

            builder.Services.AddBlazoredSessionStorageAsSingleton();
            builder.Services.AddScoped<Usuario>();
            builder.Services.AddScoped<ListadoTipoMovil>();
            builder.Services.AddScoped<RetirosService>();
            builder.Services.AddScoped<OrdenesService>();
            builder.Services.AddScoped<MovilesService>();
            builder.Services.AddScoped<ComunaService>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthExtension>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<LoginService>();

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<IRetirosRepoService, RetirosRepoService>();
            builder.Services.AddScoped<IOrdenTrabajoRepoService, OrdenTrabajoRepoService>();
            //builder.Services.AddScoped<IUsuario, Usuario>();


            //DEBUG
            //builder.Services.AddScoped<PruebasServices>();

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            //builder.Services.AddScoped<LoadingDialog>();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddScoped<IDialogFrameService, DialogFrameService>();
            builder.Services.AddScoped<IClipboardService, ClipboardService>();


            await builder.Build().RunAsync();
        }
    }
}
