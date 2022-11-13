using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TickOffList.Services;
using Timer = System.Timers.Timer;

namespace TickOffList.ViewModels;

// Author: 陶静龙
public class CountdownPageViewModel : ObservableObject
{
    // private ICountdownService _countdownService;

    private Timer _timer;

    private bool _isRunning = false;

    public bool IsRunning
    {
        get => _isRunning;
        set => SetProperty(ref _isRunning, value);
    }

    private string _startStopButtonImage = CountdownPageSource.StartButtonImage;

    private bool _isEnabled = true;

    public bool IsEnabled
    {
        get => _isEnabled;
        set => SetProperty(ref _isEnabled, value);
    }

    public string StartStopButtonImage
    {
        get => _startStopButtonImage;
        set => SetProperty(ref _startStopButtonImage, value);
    }

    private string _resetButtonImage = CountdownPageSource.ResetButtonImage;

    private string _hour;

    public string Hour
    {
        get => _hour;
        set => SetProperty(ref _hour, value);
    }

    private string _minute;

    public string Minute
    {
        get => _minute;
        set => SetProperty(ref _minute, value);
    }

    private string _second;

    public string Second
    {
        get => _second;
        set => SetProperty(ref _second, value);
    }

    private string _lastTime;

    public string LastTime
    {
        get => _lastTime;
        set => SetProperty(ref _lastTime, value);
    }

    private string _selectedHour;

    public string SelectedHour
    {
        get => _selectedHour;
        set => SetProperty(ref _selectedHour, value);
    }

    private string _selectedMinute;

    public string SelectedMinute
    {
        get => _selectedMinute;
        set => SetProperty(ref _selectedMinute, value);
    }

    private string _selectedSecond;

    public string SelectedSecond
    {
        get => _selectedSecond;
        set => SetProperty(ref _selectedSecond, value);
    }

    private IAudioPlayService _audioPlayService;

    public CountdownPageViewModel(IAudioPlayService audioPlayService)
    {
        _audioPlayService = audioPlayService;

        _timer = new Timer(1000);
        Hour = "00";
        Minute = "00";
        Second = "00";
        LastTime = Hour + " : " + Minute + " : " + Second;
        SelectedHour = "00";
        SelectedMinute = "00";
        SelectedSecond = "00";

        _startStopCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(CountdownTime));

        _resetCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(ResetCommandFunction));

        _selectedIndexChangedCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(SelectedIndexChangedCommandFunction));
    }

    private Lazy<AsyncRelayCommand> _startStopCommand;

    public AsyncRelayCommand StartStopCommand => _startStopCommand.Value;

    private Lazy<AsyncRelayCommand> _resetCommand;

    public AsyncRelayCommand ResetCommand => _resetCommand.Value;

    private Lazy<AsyncRelayCommand> _selectedIndexChangedCommand;

    public AsyncRelayCommand SelectedIndexChangedCommand => _selectedIndexChangedCommand.Value;

    public async Task CountdownTime()
    {
        IsEnabled = false;

        if (Hour == "00" && Minute == "00" && Second == "00")
        {
            return;
        }

        _isRunning = !_isRunning;
        StartStopButtonImage = _isRunning
            ? CountdownPageSource.StopButtonImage
            : CountdownPageSource.StartButtonImage;

        if (_isRunning == true)
        {
            decimal tempNumHour = Convert.ToDecimal(Hour);
            decimal tempNumMinute = Convert.ToDecimal(Minute);
            decimal tempNumSecond = Convert.ToDecimal(Second);

            _timer.Start();
            _timer.Elapsed += async (sender, args) => {
                if (tempNumSecond > 0)
                {
                    tempNumSecond--;

                    if (tempNumSecond > 9)
                    {
                        Second = Convert.ToString(tempNumSecond);
                    }
                    else
                    {
                        Second = "0" + Convert.ToString(tempNumSecond);
                    }
                    LastTime = Hour + " : " + Minute + " : " + Second;

                }
                else if (tempNumSecond == 0)
                {
                    if (tempNumMinute == 0)
                    {
                        if (tempNumHour == 0)
                        {
                            _timer.Stop();
                            _timer.Close();
                            _timer = new Timer(1000);
                            _isRunning = false;
                            StartStopButtonImage = _isRunning
                                ? CountdownPageSource.StopButtonImage
                                : CountdownPageSource.StartButtonImage;
                            SelectedHour = "00";
                            SelectedMinute = "00";
                            SelectedSecond = "00";
                            IsEnabled = true;
                            await _audioPlayService.PlayAudio();
                            return;
                        }
                        else if (tempNumHour > 0)
                        {
                            tempNumHour--;

                            if (tempNumHour > 9)
                            {
                                Hour = Convert.ToString(tempNumHour);
                            }
                            else
                            {
                                Hour = "0" + Convert.ToString(tempNumHour);
                            }
                            LastTime = Hour + " : " + Minute + " : " + Second;
                        }
                        tempNumMinute = 59;
                        Minute = Convert.ToString(tempNumMinute);
                        LastTime = Hour + " : " + Minute + " : " + Second;
                    }
                    else if (tempNumMinute > 0)
                    {
                        tempNumMinute--;

                        if (tempNumMinute > 9)
                        {
                            Minute = Convert.ToString(tempNumMinute);
                        }
                        else
                        {
                            Minute = "0" + Convert.ToString(tempNumMinute);
                        }
                        LastTime = Hour + " : " + Minute + " : " + Second;
                    }
                    tempNumSecond = 59;
                    Second = Convert.ToString(tempNumSecond);
                    LastTime = Hour + " : " + Minute + " : " + Second;
                }
            };
        }
        else
        {
            _timer.Stop();
        }
    }

    public async Task ResetCommandFunction()
    {
        _timer.Stop();
        _timer.Close();
        _timer = new Timer(1000);
        _isRunning = false;
        StartStopButtonImage = _isRunning
            ? CountdownPageSource.StopButtonImage
            : CountdownPageSource.StartButtonImage;
        Hour = "00";
        Minute = "00";
        Second = "00";
        LastTime = Hour + " : " + Minute + " : " + Second;
        SelectedHour = "00";
        SelectedMinute = "00";
        SelectedSecond = "00";
        IsEnabled = true;
    }

    public async Task SelectedIndexChangedCommandFunction()
    {
        Hour = SelectedHour;
        Minute = SelectedMinute;
        Second = SelectedSecond;
        LastTime = Hour + " : " + Minute + " : " + Second;
    }
}

public static class CountdownPageSource
{
    public const string StartButtonImage = "start.png";
    public const string StopButtonImage = "stop.png";
    public const string ResetButtonImage = "reset.png";
}