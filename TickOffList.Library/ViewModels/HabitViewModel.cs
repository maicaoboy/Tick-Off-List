using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics;
using TickOffList.Models;
using TickOffList.Services;
using Color = Microsoft.Maui.Graphics.Color;

namespace TickOffList.ViewModels;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/
public class HabitViewModel : ObservableObject
{


    private string[] _dayOfWeekArray;
    private string[] _dayOfMonthArray;
    private Color[] _dayColorsArray;
    private Color[] _dayTextColorsArray;
    private int _dateNum;

    private readonly IContentNavigationService _contentNavigationService;


    private RelayCommand<string> _changeDateCommand;

    public RelayCommand<string> ChangeDateCommand =>
        _changeDateCommand ??= new RelayCommand<string>(async dateStr => {
            int dateNum = int.Parse(dateStr);
            _dateNum = dateNum;
            var dateTime = DateTime.Now.AddDays(-dateNum);

            var habitByWeekDay = await _habitStorage.getHabitByWeekDay(Convert
                .ToInt32(dateTime.DayOfWeek.ToString("d")).ToString());
            Habits.Clear();
            foreach (var habit in habitByWeekDay)
            {
                habit.Finish = await _habitStorage.isFinish(habit.Id, DateTime.Now.AddDays(-dateNum));
                habit.QuantityToday = await _habitStorage.TickCount(habit.Id, DateTime.Now.AddDays(-dateNum));
                Habits.Add(habit);
            }

            Color[] colors = new Color[] {
                Colors.White,
                Colors.White,
                Colors.White,
                Colors.White,
                Colors.White,
                Colors.White,
                Colors.White
            };
            colors[dateNum] = Color.FromRgb(81, 42, 212);
            DayColorsArray = colors;

            Color[] textColors = new Color[] {
                Colors.Black,
                Colors.Black,
                Colors.Black,
                Colors.Black,
                Colors.Black,
                Colors.Black,
                Colors.Black
            };
            textColors[dateNum] = Colors.White;
            DayTextColorsArray = textColors;
        });

    private Lazy<AsyncRelayCommand> _lazyNavigatedToCommand;

    public AsyncRelayCommand NavigatedToCommand =>
        _lazyNavigatedToCommand.Value;

    public async Task NavigatedToCommandFunction()
    {
        var dateTime = DateTime.Now.AddDays(-_dateNum);

        var habitByWeekDay = await _habitStorage.getHabitByWeekDay(Convert
            .ToInt32(dateTime.DayOfWeek.ToString("d")).ToString());
        Habits.Clear();
        foreach (var habit in habitByWeekDay)
        {
            habit.Finish = await _habitStorage.isFinish(habit.Id, DateTime.Now.AddDays(-_dateNum));
            habit.QuantityToday = await _habitStorage.TickCount(habit.Id,
                DateTime.Now.AddDays(-_dateNum));
            Habits.Add(habit);
        }
    }



    private RelayCommand<Habit> _tickCommand;

    public RelayCommand<Habit> TickCommand =>
        _tickCommand ??= new RelayCommand<Habit>(async habit => {
            List<Object> args = new List<Object>() { habit, (Object)_dateNum };
            await _contentNavigationService.NavigateToAsync(
                ContentNavigationConstant.TickPage, args);
        });

    private RelayCommand<Habit> _createCommand;

    public RelayCommand<Habit> CreateCommand =>
        _createCommand ??= new RelayCommand<Habit>(async habit => {
            await _contentNavigationService.NavigateToAsync(
                ContentNavigationConstant.CreateHabitPage);
        });

    public HabitViewModel(IHabitStorage habitStorage, IContentNavigationService contentNavigationService)
    {
        _habitStorage = habitStorage;
        _dateNum = 0;
        _contentNavigationService = contentNavigationService;
        string[] Day = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };

        DateTime today = DateTime.Now;
        _dayOfWeekArray = new string[] {
            Day[Convert.ToInt32(today.DayOfWeek.ToString("d"))].ToString(),
            Day[Convert.ToInt32(today.AddDays(-1).DayOfWeek.ToString("d"))].ToString(),
            Day[Convert.ToInt32(today.AddDays(-2).DayOfWeek.ToString("d"))].ToString(),
            Day[Convert.ToInt32(today.AddDays(-3).DayOfWeek.ToString("d"))].ToString(),
            Day[Convert.ToInt32(today.AddDays(-4).DayOfWeek.ToString("d"))].ToString(),
            Day[Convert.ToInt32(today.AddDays(-5).DayOfWeek.ToString("d"))].ToString(),
            Day[Convert.ToInt32(today.AddDays(-6).DayOfWeek.ToString("d"))].ToString()
        };

        _dayOfMonthArray = new string[] {
            "今天",
            Convert.ToString(today.AddDays(-1).Day),
            Convert.ToString(today.AddDays(-2).Day),
            Convert.ToString(today.AddDays(-3).Day),
            Convert.ToString(today.AddDays(-4).Day),
            Convert.ToString(today.AddDays(-5).Day),
            Convert.ToString(today.AddDays(-6).Day)
        };

        _dayColorsArray = new Color[] {
            Color.FromRgb(81,42,212),
            Colors.White,
            Colors.White,
            Colors.White,
            Colors.White,
            Colors.White,
            Colors.White
        };

        _dayTextColorsArray = new Color[] {
            Colors.White,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black,
            Colors.Black
        };

        Init();

        _lazyNavigatedToCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(NavigatedToCommandFunction));
    }

    public async void Init()
    {
        var listAsync = await _habitStorage.ListAsync();
        foreach (var habit in listAsync)
        {
            habit.Finish = await _habitStorage.isFinish(habit.Id, DateTime.Now.AddDays(-_dateNum));
            habit.QuantityToday = await _habitStorage.TickCount(habit.Id, DateTime.Now.AddDays(-_dateNum));
        }
        Habits = new ObservableCollection<Habit>(listAsync);
    }


    //习惯数据库
    private IHabitStorage _habitStorage;



    //ListView显示的Habit
    private ObservableCollection<Habit> _habits;


    public ObservableCollection<Habit> Habits
    {
        get => _habits;
        set => SetProperty(ref _habits, value);
    }

    public string[] DayOfWeekArray
    {
        get => _dayOfWeekArray;
        set => _dayOfWeekArray = value ?? throw new ArgumentNullException(nameof(value));
    }


    public string[] DayOfMonthArray
    {
        get => _dayOfMonthArray;
        set => _dayOfMonthArray = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Color[] DayColorsArray
    {
        get => _dayColorsArray;
        set => SetProperty(ref _dayColorsArray, value);
    }

    public Color[] DayTextColorsArray
    {
        get => _dayTextColorsArray;
        set => SetProperty(ref _dayTextColorsArray, value);
    }

    public int DateNum
    {
        get => _dateNum;
        set => _dateNum = value;
    }
}