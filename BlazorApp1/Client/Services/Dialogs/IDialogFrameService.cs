using BlazorApp1.Shared.Modelo.Retiros;
using System.Threading.Tasks;

namespace BlazorApp1.Client.Services.Dialogs
{
    public interface IDialogFrameService
    {
        public Task<dynamic> OpenRetiroDetailAsync(Retiro retiro);
        public Task<bool> OpenConfirmDialogAsync(string Message, string Title);
        public Task<bool> OpenAlertDialogAsync(string Message, string Title);
    }
}
