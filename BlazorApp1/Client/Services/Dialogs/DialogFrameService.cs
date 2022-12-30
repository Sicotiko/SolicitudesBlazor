using BlazorApp1.Client.Components.Retiros;
using BlazorApp1.Shared.Modelo.Retiros;
using Radzen;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Dialogs
{
    public class DialogFrameService : IDialogFrameService
    {
        private readonly DialogService dialogService;
        public DialogFrameService(DialogService dialogService)
        {
            this.dialogService = dialogService;
        }


        public async Task<bool> OpenAlertDialogAsync(string Message, string Title)
        {
            return (bool)await dialogService.Alert(Message, Title, new AlertOptions
            {
                OkButtonText = "OK",
                CloseDialogOnEsc = false,
                CloseDialogOnOverlayClick = false,
                ShowClose = false
            }) ;
        }

        public async Task<bool> OpenConfirmDialogAsync(string Message, string Title)
        {
            return (bool)await dialogService.Confirm(Message, Title, new ConfirmOptions()
            {
                OkButtonText = "Confirmar",
                CancelButtonText = "No",
                CloseDialogOnEsc = false,
                CloseDialogOnOverlayClick = false,
                ShowClose = false
            });
        }

        public async Task<dynamic> OpenRetiroDetailAsync(Retiro retiro)
        {
            return await dialogService.OpenAsync<RetiroDetalle>($"N° Retiro: {retiro.CodigoRetiro}",
                                               new Dictionary<string, object>(){
                                                  {
                                                      "RetiroObject",
                                                      retiro
                                                  }
                                                                                   },
                                               new DialogOptions()
                                               {
                                                   Width = "700px",
                                                   Height = "512px",
                                                   Resizable = true,
                                                   Draggable = true
                                               });
        }
    }
}
