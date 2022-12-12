using System.Dynamic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TickOffList.Services;

namespace TickOffList.ViewModels;

// Author: 陶静龙
public class CountdownPageViewModel : ObservableObject {

    private readonly ICountdownService _countdownService;

    private bool _isEnabled;

    private bool _isRunning;

    private string _resetButtonImage;

    private readonly Lazy<AsyncRelayCommand> _resetCommand;

    private string _selectedHour;

    private readonly Lazy<AsyncRelayCommand> _selectedIndexChangedCommand;

    private string _selectedMinute;

    private string _selectedSecond;

    private List<string> _hourItemSource = new ();

    private List<string> _minuteItemSource = new ();

    private List<string> _secondItemSource = new();

    private string _startStopButtonImage;

    private readonly Lazy<AsyncRelayCommand> _startStopCommand;

    private string _time;

    private decimal _percentRemain;

    public CountdownPageViewModel(ICountdownService countdownService) {
        _countdownService = countdownService;

        Time = "00 : 00 : 00";
        PercentRemain = 0;
        IsRunning = false;
        IsEnabled = true;
        StartStopButtonImage = CountdownPageSource.StartButtonImage;
        ResetButtonImage = CountdownPageSource.ResetButtonImage;

        for (var i = 0; i <= 99; i++)
            if (i <= 9)
            {
                _hourItemSource.Add($"0{i}");
                _minuteItemSource.Add($"0{i}");
                _secondItemSource.Add($"0{i}");
            }
            else if (i <= 59)
            {
                _minuteItemSource.Add($"{i}");
                _secondItemSource.Add($"{i}");
            }
            else
            {
                _hourItemSource.Add($"{i}");
            }
        ClearSelections();

        _startStopCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(StartStopCommandFunction));

        _resetCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(ResetCommandFunction));

        _selectedIndexChangedCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(SelectedIndexChangedCommandFunction));

        // 订阅事件
        _countdownService.Ticked += (sender, args) => {
            Time = $"{args.Hour} : {args.Minute} : {args.Second}";
            PercentRemain = args.PercentRemain;
            IsRunning = args.IsRunning;
            IsEnabled = args.IsEnabled;
            StartStopButtonImage = IsRunning
                ? CountdownPageSource.StopButtonImage
                : CountdownPageSource.StartButtonImage;
            if (IsEnabled)
                ClearSelections();
        };
    }

    public List<string> HourItemSource => _hourItemSource;

    public List<string> MinuteItemSource => _minuteItemSource;

    public List<string> SecondItemSource => _secondItemSource;

    public string SelectedHour {
        get => _selectedHour;
        set => SetProperty(ref _selectedHour, value);
    }

    public string SelectedMinute {
        get => _selectedMinute;
        set => SetProperty(ref _selectedMinute, value);
    }

    public string SelectedSecond {
        get => _selectedSecond;
        set => SetProperty(ref _selectedSecond, value);
    }

    public string Time {
        get => _time;
        set => SetProperty(ref _time, value);
    }

    public decimal PercentRemain {
        get => _percentRemain;
        set => SetProperty(ref _percentRemain, value);
    }

    public bool IsRunning {
        get => _isRunning;
        set => SetProperty(ref _isRunning, value);
    }

    public bool IsEnabled {
        get => _isEnabled;
        set => SetProperty(ref _isEnabled, value);
    }

    public string StartStopButtonImage {
        get => _startStopButtonImage;
        set => SetProperty(ref _startStopButtonImage, value);
    }

    public string ResetButtonImage {
        get => _resetButtonImage;
        set => SetProperty(ref _resetButtonImage, value);
    }

    public AsyncRelayCommand StartStopCommand => _startStopCommand.Value;

    public AsyncRelayCommand ResetCommand => _resetCommand.Value;

    public AsyncRelayCommand SelectedIndexChangedCommand =>
        _selectedIndexChangedCommand.Value;

    public async Task StartStopCommandFunction() {
        if (!(SelectedHour == "00" && SelectedMinute == "00" &&
                SelectedSecond == "00")) {
            if (IsEnabled)
                _countdownService.SetTime(SelectedHour, SelectedMinute,
                    SelectedSecond);
            var command = IsRunning ? "stop" : "start";
            _countdownService.StartOrStop(command);
        }
    }

    public async Task ResetCommandFunction() {
        if (!(SelectedHour == "00" && SelectedMinute == "00" &&
                SelectedSecond == "00")) {
            _countdownService.Reset();
        }
    }

    public async Task SelectedIndexChangedCommandFunction() {
        Time = $"{SelectedHour} : {SelectedMinute} : {SelectedSecond}";
    }

    private void ClearSelections() {
        SelectedHour = "00";
        SelectedMinute = "00";
        SelectedSecond = "00";
    }
}

public static class CountdownPageSource {
    public const string StartButtonImage = "start.png";
    public const string StopButtonImage = "stop.png";
    public const string ResetButtonImage = "reset.png";
}