using CommunityToolkit.Mvvm.ComponentModel;
using TickOffList.Models;

namespace TickOffList.ViewModels; 

public class TickViewModel : ObservableObject{
    private Habit _habit;

    public Habit Habit
    {
        get => _habit;
        set => SetProperty(ref _habit, value);
    }
}