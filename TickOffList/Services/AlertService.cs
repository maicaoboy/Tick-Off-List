namespace TickOffList.Services;

public class AlertService : IAlertService

{
    public void Alert(string title, string message, string button) =>
        MainThread.BeginInvokeOnMainThread(async () =>
            await Shell.Current.DisplayAlert(title, message, button));

    public Task<bool> Alert(string title, string message, string buttonConfirm, string buttonCancel) {
        var tcs = new TaskCompletionSource<bool>();
        MainThread.BeginInvokeOnMainThread(async () => {
            try
            {
                var result = await Shell.Current.DisplayAlert(title, message, buttonConfirm, buttonCancel);
                tcs.TrySetResult(result);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        });
        return tcs.Task;
    }
}