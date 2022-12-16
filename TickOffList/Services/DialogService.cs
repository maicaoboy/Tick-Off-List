using System.Resources;
using System.Threading.Tasks;

namespace TickOffList.Services;

// Author: 李宏彬
public class DialogService : IDialogService
{
    public Task<bool> ShowConfirmationAsync(string title, string message)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, "ok", "no");
    }

    public Task ShowAlertAsync(string title, string message, string accept, string cancel)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
    }

    public async Task ShowAlertAsync(string title, string message, string accept)
    {
        await Application.Current.MainPage.DisplayAlert("Alert", "You have been alerted", "OK");
    }
}