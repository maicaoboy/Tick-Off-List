namespace TickOffList.Services;

// Author: 陶静龙
public interface ICountdownService {
    public event EventHandler<TimerEventArgs> Ticked;

    void SetTime(string hour, string minute, string second);
    void StartOrStop(string command);
    void Reset();
}

public class TimerEventArgs : EventArgs {

    public string Hour { get; }

    public string Minute { get; }

    public string Second { get; }

    public decimal PercentRemain { get;  }

    public bool IsRunning { get; }

    public bool IsEnabled { get; }

    public TimerEventArgs(string hour, string minute, string second, decimal percentRemain,
        bool isRunning, bool isEnabled)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        PercentRemain = percentRemain;
        IsRunning = isRunning;
        IsEnabled = isEnabled;
    }
}