using Radzen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Components.Loading
{
    public class LoadingScreen
    {
        private readonly DialogService dialogService;
        public LoadingScreen(DialogService dialogService)
        {
            this.dialogService = dialogService;
        }
        public void Show(string Message)
        {
            dialogService.Open<LoadingPage>("", new Dictionary<string, object>() { { "LoadingMessage", Message } }, new DialogOptions() { ShowTitle = false, Style = "min-height:auto;min-width:auto;width:auto", CloseDialogOnEsc = false });
        }
        public void Close()
        {
            dialogService.Close();
        }
        public async Task ShowAsync(string Message)
        {
            await dialogService.OpenAsync<LoadingPage>("", new Dictionary<string, object>() { { "LoadingMessage", Message } }, new DialogOptions() { ShowTitle = false, Style = "min-height:auto;min-width:auto;width:auto", CloseDialogOnEsc = false });
        }
    }
}
