using static System.Net.Mime.MediaTypeNames;
using System.Resources;
using System.Threading.Tasks;

namespace TickOffList.Services;

// Author: 李宏彬
public interface IDialogService
{
    public Task<bool> ShowConfirmationAsync(string title, string message);

    public Task ShowAlertAsync(string title, string message, string accept, string cancel);

    public Task ShowAlertAsync(string title, string message, string accept);
}