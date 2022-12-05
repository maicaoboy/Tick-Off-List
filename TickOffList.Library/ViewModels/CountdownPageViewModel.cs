using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TickOffList.Services;
using Timer = System.Timers.Timer;

namespace TickOffList.ViewModels;

// Author: 陶静龙
public class CountdownPageViewModel : ObservableObject
{
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

    private string _time;

    public string Time
    {
        get => _time;
        set => SetProperty(ref _time, value);
    }

    private bool _isRunning;

    public bool IsRunning
    {
        get => _isRunning;
        set => SetProperty(ref _isRunning, value);
    }

    private bool _isEnabled;

    public bool IsEnabled
    {
        get => _isEnabled;
        set => SetProperty(ref _isEnabled, value);
    }

    private string _startStopButtonImage;

    public string StartStopButtonImage
    {
        get => _startStopButtonImage;
        set => SetProperty(ref _startStopButtonImage, value);
    }

    private string _resetButtonImage;

    public string ResetButtonImage
    {
        get => _resetButtonImage;
        set => SetProperty(ref _resetButtonImage, value);
    }

    private ICountdownService _countdownService;

    private IAudioPlayService _audioPlayService;


    public CountdownPageViewModel(ICountdownService countdownService)
    {
        _countdownService = countdownService;

        Time = "00 : 00 : 00";
        IsRunning = false;
        IsEnabled = true;
        StartStopButtonImage = CountdownPageSource.StartButtonImage;
        ResetButtonImage = CountdownPageSource.ResetButtonImage;

        _startStopCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(StartStopCommandFunction));

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

    public async Task StartStopCommandFunction()
    {
        // 注册委托
        _countdownService.Ticked += (sender, args) =>
        {
            Time = $"{args.Hour} : {args.Minute} : {args.Second}";
            IsRunning = args.IsRunning;
            IsEnabled = args.IsEnabled;
            StartStopButtonImage =
                IsRunning ? CountdownPageSource.StopButtonImage : CountdownPageSource.StartButtonImage;

            if (IsEnabled == true)
            {
                ClearSelections();
            }
        };

        string command = IsRunning ? "stop" : "start";
        _countdownService.StartOrStop(command);
    }

    public async Task ResetCommandFunction()
    {
        _countdownService.Reset();
        ClearSelections();
    }

    public async Task SelectedIndexChangedCommandFunction()
    {
        Time = $"{SelectedHour} : {SelectedMinute} : {SelectedSecond}";
        _countdownService.SetTime(SelectedHour, SelectedMinute, SelectedSecond);
    }

    private void ClearSelections()
    {
        SelectedHour = "00";
        SelectedMinute = "00";
        SelectedSecond = "00";
    }
}

public static class CountdownPageSource
{
    public const string StartButtonImage = "start.png";
    public const string StopButtonImage = "stop.png";
    public const string ResetButtonImage = "reset.png";
}