using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TickOffList.Models;
using TickOffList.Services;

namespace TickOffList.ViewModels;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-25
* @version 1.0
* ==============================================================================*/

public class TickViewModel : ObservableObject{
    private List<Object> _args;
    private Habit _tickHabit;
    private int _dateNum;
    private bool _enabled;
    private IHabitStorage _habitStorage;
    private IHabitRecordStorage _habitRecordStorage;

    public bool Enabled {
        get => _enabled;
        set => SetProperty(ref _enabled, value);
    }


    public List<Object> Args
    {
        get => _args;
        set => _args = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Habit TickHabit
    {
        get => _tickHabit;
        set => SetProperty(ref _tickHabit, value);
    }


    public int DateNum {
        get => _dateNum;
        set => _dateNum = value;
    }


    public TickViewModel(IHabitStorage habitStorage, IHabitRecordStorage habitRecordStorage) {
        _habitStorage = habitStorage;
        _habitRecordStorage = habitRecordStorage;

        _lazyNavigatedToCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(NavigatedToCommandFunction));

        _tickCommandLazy = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(TickCommandLazyFunction));
    }


    private Lazy<AsyncRelayCommand> _lazyNavigatedToCommand;

    public AsyncRelayCommand NavigatedToCommand =>
        _lazyNavigatedToCommand.Value;

    public async Task NavigatedToCommandFunction() {
        Habit tickHabitTemp = (Habit) _args[0];
        TickHabit = tickHabitTemp;
        DateNum = (int)_args[1];
        Enabled = !TickHabit.Finish && _dateNum == 0;
    }

    private Lazy<AsyncRelayCommand> _tickCommandLazy;

    public AsyncRelayCommand TickCommandLazy =>
        _tickCommandLazy.Value;

    public async Task TickCommandLazyFunction() {
        var habitRecord= new HabitRecord() {
            Hid = TickHabit.Id,
            RecordDate = DateTime.Now
        };
        await _habitRecordStorage.AddAsync(habitRecord);
        Enabled = false;
        var isFinish = await _habitStorage.isFinish(TickHabit.Id);
        if (isFinish) {
            TickHabit.RecordCount += 1;
            TickHabit.Finish = true;
            await _habitStorage.updateHabit(TickHabit);
        }
    }

}