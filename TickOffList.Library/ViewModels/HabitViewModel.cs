using CommunityToolkit.Mvvm.ComponentModel;
using TickOffList.Models;
using TickOffList.Services;

namespace TickOffList.ViewModels;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/
public class HabitViewModel : ObservableObject {
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

    // 星期显示
    private string _dayOfWeek1;
    private string _dayOfWeek2;
    private string _dayOfWeek3;
    private string _dayOfWeek4;
    private string _dayOfWeek5;
    private string _dayOfWeek6;
    private string _dayOfWeek7;

    //ListView显示的Habit
    private List<Habit> _habits;

    //习惯数据库
    private readonly IHabitStorage _habitStorage;

    public HabitViewModel(IHabitStorage habitStorage) {
        _habitStorage = habitStorage;
        string[] Day = {"周日", "周一", "周二", "周三", "周四", "周五", "周六"};

        var today = DateTime.Now;
        DateToday1 = "今天";
        DateToday2 = Convert.ToString(today.AddDays(-1).Day);
        DateToday3 = Convert.ToString(today.AddDays(-2).Day);
        DateToday4 = Convert.ToString(today.AddDays(-3).Day);
        DateToday5 = Convert.ToString(today.AddDays(-4).Day);
        DateToday6 = Convert.ToString(today.AddDays(-5).Day);
        DateToday7 = Convert.ToString(today.AddDays(-6).Day);

        _dayOfWeek1 = Day[Convert.ToInt32(today.DayOfWeek.ToString("d"))];
        _dayOfWeek2 =
            Day[Convert.ToInt32(today.AddDays(-1).DayOfWeek.ToString("d"))];
        _dayOfWeek3 =
            Day[Convert.ToInt32(today.AddDays(-2).DayOfWeek.ToString("d"))];
        _dayOfWeek4 =
            Day[Convert.ToInt32(today.AddDays(-3).DayOfWeek.ToString("d"))];
        _dayOfWeek5 =
            Day[Convert.ToInt32(today.AddDays(-4).DayOfWeek.ToString("d"))];
        _dayOfWeek6 =
            Day[Convert.ToInt32(today.AddDays(-5).DayOfWeek.ToString("d"))];
        _dayOfWeek7 =
            Day[Convert.ToInt32(today.AddDays(-6).DayOfWeek.ToString("d"))];

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

    public string DateToday1 { get; set; }

    public string DateToday2 { get; set; }

    public string DateToday3 { get; set; }

    public string DateToday4 { get; set; }

    public string DateToday5 { get; set; }

    public string DateToday6 { get; set; }

    public string DateToday7 { get; set; }

    public string DayOfWeek1 {
        get => _dayOfWeek1;
        set =>
            _dayOfWeek1 =
                value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek2 {
        get => _dayOfWeek2;
        set =>
            _dayOfWeek2 =
                value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek3 {
        get => _dayOfWeek3;
        set =>
            _dayOfWeek3 =
                value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek4 {
        get => _dayOfWeek4;
        set =>
            _dayOfWeek4 =
                value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek5 {
        get => _dayOfWeek5;
        set =>
            _dayOfWeek5 =
                value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek6 {
        get => _dayOfWeek6;
        set =>
            _dayOfWeek6 =
                value ?? throw new ArgumentNullException(nameof(value));
    }

    public string DayOfWeek7 {
        get => _dayOfWeek7;
        set =>
            _dayOfWeek7 =
                value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Habit> Habits {
        get => _habits;
        set => SetProperty(ref _habits, value);
    }

    public async void Init() {
        var listAsync = await _habitStorage.ListAsync();
        Habits = listAsync.ToList();
    }
}