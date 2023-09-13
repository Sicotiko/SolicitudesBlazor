using BlazorApp1.Client.Components.Retiros;
using BlazorApp1.Shared.ControllerModel;
using BlazorApp1.Shared.Excepciones;
using BlazorApp1.Shared.Modelo.Retiros;
using BlazorApp1.Shared.User;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Retiros
{
    internal class RetirosRepoService : IRetirosRepoService
    {
        private readonly HttpClient _httpClient;
        private readonly Usuario _usuario;
        private readonly DialogService _dialogService;
        private JsonSerializerOptions _options;

        public RetirosRepoService(HttpClient httpClient, Usuario usuario, DialogService dialogService)
        {
            this._httpClient = httpClient;
            this._usuario = usuario;
            this._dialogService = dialogService;
            this._options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
        }

        public async Task<IEnumerable<Retiro>> GetRetirosPendientes(string TipoRetiro, string CodigoComuna, DateTime Desde, DateTime Hasta)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();

            _usuario.GetCredentials();


            var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetiros/{TipoRetiro}/{CodigoComuna}/PEND/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;

        }
        public async Task<IEnumerable<Retiro>> GetRetirosTodosLosEstados(string TipoRetiro, string CodigoComuna, DateTime Desde, DateTime Hasta)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();

            _usuario.GetCredentials();

            var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetiros/{TipoRetiro}/{CodigoComuna}/TODOS/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;

        }

        public async Task<IEnumerable<Retiro>> GetRetirosFallidos(string CodigoComuna, DateTime Desde, DateTime Hasta, string CodCliente)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();

            _usuario.GetCredentials();

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"Retiros/GetFallidos/TODOS/{CodigoComuna}/NOEF/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}/{CodCliente}", _usuario);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());



            return resultado;

        }

        //Reporte Sucursales
        public async Task<IEnumerable<Retiro>> GetReporteSucursalesAsync(DateTime FechaReporte)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();

            var response = await _httpClient.PostAsJsonAsync($"Retiros/ReporteSucursal/{FechaReporte.Day:00}/{FechaReporte.Month:00}/{FechaReporte.Year}", _usuario);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;

        }

        public async Task<IEnumerable<Retiro>> GetRetirosAsignados(string TipoRetiro, string Movil, DateTime Desde, DateTime Hasta)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();

            var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetirosByMovil/{TipoRetiro}/{Movil}/ASIG/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", _usuario);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;

        }

        public async Task AsignarAsync(Retiro retiro)
        {

            if (retiro != null)
            {
                RetiroToAssign retiroToAssign = new RetiroToAssign(retiro, _usuario);

                var response = await _httpClient.PostAsJsonAsync("Retiros/Asignar", retiroToAssign);
                if (!response.IsSuccessStatusCode)
                    throw new ExceptionResponse(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task<IEnumerable<Retiro>> GetRetirosHistorialCliente(string CodigoCliente, DateTime Desde, DateTime Hasta)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();


            RetiroToHistorial retiroToHistorial = new RetiroToHistorial(CodigoCliente, _usuario);

            var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetirosByCliente/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", retiroToHistorial);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;
        }

        public async Task<IEnumerable<Retiro>> GetRetirosHistorialCliente(string CodigoCliente, string CodigoComuna, DateTime Desde, DateTime Hasta)
        {
            IEnumerable<Retiro> resultado = new List<Retiro>();


            RetiroToHistorial retiroToHistorial = new RetiroToHistorial(CodigoCliente, _usuario, CodigoComuna);

            var response = await _httpClient.PostAsJsonAsync($"Retiros/GetRetirosByCliente/{Desde.Day:00}/{Desde.Month:00}/{Desde.Year}/{Hasta.Day:00}/{Hasta.Month:00}/{Hasta.Year}", retiroToHistorial);
            if (response.IsSuccessStatusCode)
                resultado = await response.Content.ReadFromJsonAsync<IEnumerable<Retiro>>();
            else
                throw new ExceptionResponse(await response.Content.ReadAsStringAsync());

            return resultado;
        }

        public async Task HistorialClienteInDialog(Retiro retiro)
        {
            IEnumerable<Retiro> RetirosHistorial = await GetRetirosHistorialCliente(retiro.CodigoCliente, retiro.CodigoPostal.ToString(), DateTime.Today.AddDays(-7), DateTime.Today);
            await _dialogService.OpenAsync<HistorialCliente>($"{retiro.Nombre} - Historial Semanal", new Dictionary<string, object>()
                                                                                                    {
                                                                                                        {
                                                                                                            "RetirosHistorial",RetirosHistorial
                                                                                                        }
                                                                                                    }, new DialogOptions()
                                                                                                    {
                                                                                                        Style = "min-height:auto;min-width:auto;width:auto",
                                                                                                        CloseDialogOnEsc = true,
                                                                                                        CloseDialogOnOverlayClick = true
                                                                                                    }
                                                                                                        );
        }


    }
}
