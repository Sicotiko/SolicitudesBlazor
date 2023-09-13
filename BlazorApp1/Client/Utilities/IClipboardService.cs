using System.Threading.Tasks;

namespace BlazorApp1.Client.Utilities
{
    public interface IClipboardService
    {
        Task CopyToClipboard(string text);
    }
}
