namespace TickOffList.Services;

// Author: 陶静龙
public interface ICountdownService
{
    public event EventHandler<TimerEventArgs> Ticked;

    void SetTime(string hour, string minute, string second);
    void StartOrStop(string command);
    void Reset();
}

public class TimerEventArgs : EventArgs
{
    public string Hour { get; set; }

    public string Minute { get; set; }

    public string Second { get; set; }

    public bool IsRunning { get; set; }

    public bool IsEnabled { get; set; }

    public TimerEventArgs(string hour, string minute, string second, bool isRunning, bool isEnabled)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        IsRunning = isRunning;
        IsEnabled = isEnabled;
    }
}