using CommunityToolkit.Mvvm.ComponentModel;

namespace TickOffListLibrary.ViewModels; 

public class 
    HabitViewModel : ObservableObject {
    private int _dateToday1;
    private int _dateToday2;
    private int _dateToday3;
    private int _dateToday4;
    private int _dateToday5;
    private int _dateToday6;
    private int _dateToday7;

    public HabitViewModel() {
        DateTime today = DateTime.Now;
        DateToday1 = today.Day;
        DateToday2 = today.Day - 1;
        DateToday3 = today.Day - 2;
        DateToday4 = today.Day - 3;
        DateToday5 = today.Day - 4;
        DateToday6 = today.Day - 5;
        DateToday7 = today.Day - 6;
    }
    



















    public int DateToday1 {
        get => _dateToday1;
        set => _dateToday1 = value;
    }

    public int DateToday2 {
        get => _dateToday2;
        set => _dateToday2 = value;
    }

    public int DateToday3 {
        get => _dateToday3;
        set => _dateToday3 = value;
    }

    public int DateToday4 {
        get => _dateToday4;
        set => _dateToday4 = value;
    }

    public int DateToday5 {
        get => _dateToday5;
        set => _dateToday5 = value;
    }

    public int DateToday6 {
        get => _dateToday6;
        set => _dateToday6 = value;
    }

    public int DateToday7 {
        get => _dateToday7;
        set => _dateToday7 = value;
    }
}