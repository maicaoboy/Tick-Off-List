namespace TickOffList.Services; 

public interface IAlertService {
    void Alert(string title, string message, string button);
    Task<bool> Alert(string title, string message, string buttonConfirm, string buttonCancel);

}