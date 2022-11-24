namespace TickOffList.Services;

using Timer = System.Timers.Timer;

// Author: 陶静龙
public class CountdownService : ICountdownService
{
    private string _hour;
    private string _minute;
    private string _second;

    private decimal _tempNumHour;
    private decimal _tempNumMinute;
    private decimal _tempNumSecond;

    private Timer _timer;

    private IAudioPlayService _audioPlayService;

    public event EventHandler<TimerEventArgs>? Ticked;

    public CountdownService(IAudioPlayService audioPlayService)
    {
        _audioPlayService = audioPlayService;

        _hour = "00";
        _minute = "00";
        _second = "00";

        _timer = new Timer(1000);
    }

    public void SetTime(string hour, string minute, string second)
    {
        _hour = hour;
        _minute = minute;
        _second = second;

        _tempNumHour = Convert.ToDecimal(_hour);
        _tempNumMinute = Convert.ToDecimal(_minute);
        _tempNumSecond = Convert.ToDecimal(_second);
    }

    public void StartOrStop(string command)
    {
        if (command == "start")
        {
            // 此句是为了让按钮图标立刻改变，而不是1s后再变
            Ticked?.Invoke(this, new TimerEventArgs(_hour, _minute, _second, true, false));

            _timer.Start();
            _timer.Elapsed += (sender, args) =>
            {
                if (_tempNumSecond > 0)
                {
                    _tempNumSecond--;
                    _second = _tempNumSecond > 9 ? $"{_tempNumSecond}" : $"0{_tempNumSecond}";
                }
                else if (_tempNumSecond == 0)
                {
                    if (_tempNumMinute > 0)
                    {
                        _tempNumMinute--;
                        _minute = _tempNumMinute > 9 ? $"{_tempNumMinute}" : $"0{_tempNumMinute}";
                    }
                    else if (_tempNumMinute == 0)
                    {
                        if (_tempNumHour > 0)
                        {
                            _tempNumHour--;
                            _hour = _tempNumHour > 9 ? $"{_tempNumHour}" : $"0{_tempNumHour}";
                        }
                        else if (_tempNumHour == 0)
                        {
                            _audioPlayService.PlayAudio();
                            Reset();
                            return;
                        }

                        _tempNumMinute = 59;
                        _minute = $"{_tempNumMinute}";
                    }

                    _tempNumSecond = 59;
                    _second = $"{_tempNumSecond}";
                }

                Ticked?.Invoke(this, new TimerEventArgs(_hour, _minute, _second, true, false));
            };
        }
        else if (command == "stop")
        {
            _timer.Stop();
            Ticked?.Invoke(this, new TimerEventArgs(_hour, _minute, _second, false, false));
        }
    }

    public void Reset()
    {
        _timer.Stop();
        _timer.Close();
        _timer = new Timer(1000);
        Ticked?.Invoke(this, new TimerEventArgs("00", "00", "00", false, true));
    }
}