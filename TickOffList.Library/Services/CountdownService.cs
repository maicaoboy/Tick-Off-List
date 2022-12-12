using Timer = System.Timers.Timer;

namespace TickOffList.Services;

// Author: 陶静龙
public class CountdownService : ICountdownService {
    private readonly IAudioPlayService _audioPlayService;
    private string _hour;
    private string _minute;
    private string _second;
    private decimal _percentRemain;
    private decimal _percentInterval;

    private decimal _tempNumHour;
    private decimal _tempNumMinute;
    private decimal _tempNumSecond;

    private Timer _timer;

    public CountdownService(IAudioPlayService audioPlayService) {
        _audioPlayService = audioPlayService;

        _hour = "00";
        _minute = "00";
        _second = "00";
        _percentRemain = 0;

        _timer = new Timer(1000);
    }

    public event EventHandler<TimerEventArgs>? Ticked;

    public void SetTime(string hour, string minute, string second) {
        _hour = hour;
        _minute = minute;
        _second = second;
        _percentRemain = 100;

        _tempNumHour = Convert.ToDecimal(_hour);
        _tempNumMinute = Convert.ToDecimal(_minute);
        _tempNumSecond = Convert.ToDecimal(_second);

        _percentInterval = 100 /
            (3600 * _tempNumHour + 60 * _tempNumMinute + _tempNumSecond);
    }

    public void StartOrStop(string command) {
        if (command == "start") {
            // 此句是为了让按钮图标立刻改变，而不是1s后再变
            Ticked?.Invoke(this,
                new TimerEventArgs(_hour, _minute, _second, _percentRemain, true, false));

            _timer.Start();
            _timer.Elapsed += (sender, args) => {
                if (_tempNumSecond > 0) {
                    _tempNumSecond--;
                    _second = _tempNumSecond > 9
                        ? $"{_tempNumSecond}"
                        : $"0{_tempNumSecond}";
                } else if (_tempNumSecond == 0) {
                    if (_tempNumMinute > 0) {
                        _tempNumMinute--;
                        _minute = _tempNumMinute > 9
                            ? $"{_tempNumMinute}"
                            : $"0{_tempNumMinute}";
                    } else if (_tempNumMinute == 0) {
                        if (_tempNumHour > 0) {
                            _tempNumHour--;
                            _hour = _tempNumHour > 9
                                ? $"{_tempNumHour}"
                                : $"0{_tempNumHour}";
                        } else if (_tempNumHour == 0) {
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
                _percentRemain -= _percentInterval;
                Ticked?.Invoke(this,
                    new TimerEventArgs(_hour, _minute, _second, _percentRemain, true, false));
            };
        } else if (command == "stop") {
            _timer.Stop();
            _timer.Close();
            _timer = new Timer(1000);
            Ticked?.Invoke(this,
                new TimerEventArgs(_hour, _minute, _second, _percentRemain, false, false));
        }
    }

    public void Reset() {
        _timer.Stop();
        _timer.Close();
        _timer = new Timer(1000);
        Ticked?.Invoke(this, new TimerEventArgs("00", "00", "00", 0, false, true));
    }
}