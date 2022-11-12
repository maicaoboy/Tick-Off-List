using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using TickOffList.Models;
using TickOffList.Services;

namespace TickOffList.ViewModels;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/
public class
    HabitViewModel : ObservableObject {
   
    // private Lazy<AsyncRelayCommand> _lazySelectCommand;
    //
    // public AsyncRelayCommand NavigatedToCommand =>
    //     _lazyNavigatedToCommand.Value;
    //
    // public async Task NavigatedToCommandFunction()
    // {
    //     await _poetryStorage.InitializeAsync();
    //
    //     Poetries.Clear();
    ////     await Poetries.LoadMoreAsync();
    // }

    public HabitViewModel(IHabitStorage habitStorage) {
        _habitStorage = habitStorage;
        string[] Day = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };

        DateTime today = DateTime.Now;
        DateToday1 = "今天";
        DateToday2 = Convert.ToString(today.AddDays(-1).Day);
        DateToday3 = Convert.ToString(today.AddDays(-2).Day);
        DateToday4 = Convert.ToString(today.AddDays(-3).Day);
        DateToday5 = Convert.ToString(today.AddDays(-4).Day);
        DateToday6 = Convert.ToString(today.AddDays(-5).Day);
        DateToday7 = Convert.ToString(today.AddDays(-6).Day);


        _dayOfWeek1 = Day[Convert.ToInt32(today.DayOfWeek.ToString("d"))].ToString();
        _dayOfWeek2 = Day[Convert.ToInt32(today.AddDays(-1).DayOfWeek.ToString("d"))].ToString();
        _dayOfWeek3 = Day[Convert.ToInt32(today.AddDays(-2).DayOfWeek.ToString("d"))].ToString();
        _dayOfWeek4 = Day[Convert.ToInt32(today.AddDays(-3).DayOfWeek.ToString("d"))].ToString();
        _dayOfWeek5 = Day[Convert.ToInt32(today.AddDays(-4).DayOfWeek.ToString("d"))].ToString();
        _dayOfWeek6 = Day[Convert.ToInt32(today.AddDays(-5).DayOfWeek.ToString("d"))].ToString();
        _dayOfWeek7 = Day[Convert.ToInt32(today.AddDays(-6).DayOfWeek.ToString("d"))].ToString();

        Init();
        // _habits = _habitStorage.ListAsync().Result;
        // _habits = null;
        // Habits = _habitStorage.ListAsync().Result.ToList();
        // Habits = new List<Habit>();
        // var element = new Habit();
        // element.title = "jid";
        // var element1 = new Habit();
        // element.title = "jidfe";
        // var element2 = new Habit();
        // element.title = "jidfefs";
        // Habits.Append(element);
        // Habits.Append(element1);
        // Habits.Append(element2);
    }

    public async void Init() {
        var listAsync = await _habitStorage.ListAsync();
        Habits = listAsync.ToList();
    }

    // public HabitViewModel() {
    //     string[] Day = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
    //     DateTime today = DateTime.Now;
    //     DateToday1 = "今天";
    //     DateToday2 = Convert.ToString(today.AddDays(-1).Day);
    //     DateToday3 = Convert.ToString(today.AddDays(-2).Day);
    //     DateToday4 = Convert.ToString(today.AddDays(-3).Day);
    //     DateToday5 = Convert.ToString(today.AddDays(-4).Day);
    //     DateToday6 = Convert.ToString(today.AddDays(-5).Day);
    //     DateToday7 = Convert.ToString(today.AddDays(-6).Day);
    //     _dayOfWeek1 = Day[Convert.ToInt32(today.DayOfWeek.ToString("d"))].ToString();
    //     _dayOfWeek2 = Day[Convert.ToInt32(today.AddDays(-1).DayOfWeek.ToString("d"))].ToString();
    //     _dayOfWeek3 = Day[Convert.ToInt32(today.AddDays(-2).DayOfWeek.ToString("d"))].ToString();
    //     _dayOfWeek4 = Day[Convert.ToInt32(today.AddDays(-3).DayOfWeek.ToString("d"))].ToString();
    //     _dayOfWeek5 = Day[Convert.ToInt32(today.AddDays(-4).DayOfWeek.ToString("d"))].ToString();
    //     _dayOfWeek6 = Day[Convert.ToInt32(today.AddDays(-5).DayOfWeek.ToString("d"))].ToString();
    //     _dayOfWeek7 = Day[Convert.ToInt32(today.AddDays(-6).DayOfWeek.ToString("d"))].ToString();
    // }

    // 日期显示
    private string _dateToday1;
    private string _dateToday2;
    private string _dateToday3;
    private string _dateToday4;
    private string _dateToday5;
    private string _dateToday6;
    private string _dateToday7;

    // 星期显示
    private string _dayOfWeek1;
    private string _dayOfWeek2;
    private string _dayOfWeek3;
    private string _dayOfWeek4;
    private string _dayOfWeek5;
    private string _dayOfWeek6;
    private string _dayOfWeek7;

    //习惯数据库
    private IHabitStorage _habitStorage;

    //ListView显示的Habit
    private List<Habit> _habits;



    public string DateToday1
    {
        get => _dateToday1;
        set => _dateToday1 = value;
    }

    public string DateToday2
    {
        get => _dateToday2;
        set => _dateToday2 = value;
    }

    public string DateToday3
    {
        get => _dateToday3;
        set => _dateToday3 = value;
    }

    public string DateToday4
    {
        get => _dateToday4;
        set => _dateToday4 = value;
    }

    public string DateToday5
    {
        get => _dateToday5;
        set => _dateToday5 = value;
    }

    public string DateToday6
    {
        get => _dateToday6;
        set => _dateToday6 = value;
    }

    public string DateToday7
    {
        get => _dateToday7;
        set => _dateToday7 = value;
    }

    public string DayOfWeek1 {
        get => _dayOfWeek1;
        set => _dayOfWeek1 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek2 {
        get => _dayOfWeek2;
        set => _dayOfWeek2 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek3 {
        get => _dayOfWeek3;
        set => _dayOfWeek3 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek4 {
        get => _dayOfWeek4;
        set => _dayOfWeek4 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek5 {
        get => _dayOfWeek5;
        set => _dayOfWeek5 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek6 {
        get => _dayOfWeek6;
        set => _dayOfWeek6 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek7 {
        get => _dayOfWeek7;
        set => _dayOfWeek7 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Habit> Habits {
        get => _habits;
        set => SetProperty(ref _habits, value);
    }
}