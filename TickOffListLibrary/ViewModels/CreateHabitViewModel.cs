using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TickOffList.Models;
using TickOffList.Services;

namespace TickOffList.ViewModels; 

public class CreateHabitViewModel : ObservableObject {
    private string _title;
    private string _description;
    private string _selectedIcon;
    private bool[] _isCheckedList;
    private string _tickCount;

    private IHabitStorage _habitStorage;
    private IContentNavigationService _contentNavigationService;

    private RelayCommand<string> _selecteIconRelayCommand;

    public RelayCommand<string> SelectIconCommand =>
        _selecteIconRelayCommand ??= new RelayCommand<string>(async iconStr => {
            SelectedIcon = iconStr;
        });

    private Lazy<AsyncRelayCommand> _lazySaveHabit;

    public AsyncRelayCommand SaveHabitCommand =>
        _lazySaveHabit.Value;

    public async Task SaveHabitCommandFunction()
    {
        if (_title == string.Empty) {
            return;
        }

        if (_description == String.Empty) {
            return;
        }
        bool flag  = false;
        foreach (var b in _isCheckedList) {
            if (b) {
                flag = true; break; 
            }
        }

        if (!flag) {
            return;
        }


        if (!_tickCount.All(char.IsDigit) && int.Parse(_tickCount) > 0) {
            return;
        }

        string days = "";
        for (var i = 0; i < IsCheckedList.Length; i++) {
            if (IsCheckedList[i]) {
                days += i;
            }
        }
        int tickCountNum = int.Parse(_tickCount);
        var habit = new Habit() {
            Title = this.Title,
            Describe = this.Description,
            IconName = this.SelectedIcon,
            Days = days,
            Quantity = tickCountNum
        };

        await _habitStorage.AddAsync(habit);

        // await _contentNavigationService.NavigateToAsync(
        //     RootNavigationConstant.HabitPage);
    }

    public CreateHabitViewModel(IHabitStorage habitStorage, IContentNavigationService contentNavigationService) {
        _habitStorage = habitStorage;
        _contentNavigationService = contentNavigationService;

        _selectedIcon = "paobu.png";
        _isCheckedList =
            new[] { true, true, true, true, true, true, true};

        _lazySaveHabit = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(SaveHabitCommandFunction));
    }

    public string Title {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Description {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string SelectedIcon {
        get => _selectedIcon;
        set => SetProperty(ref _selectedIcon, value);
    }

    public bool[] IsCheckedList {
        get => _isCheckedList;
        set => SetProperty(ref _isCheckedList, value);
    }

    public string TickCount {
        get => _tickCount;
        set => SetProperty(ref _tickCount, value);
    }
}