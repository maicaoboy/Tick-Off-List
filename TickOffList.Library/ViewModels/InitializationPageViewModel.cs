using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TickOffList.Services;

namespace TickOffList.ViewModels;

public class InitializationPageViewModel : ObservableObject
{
    private IHabitStorage _habitStorage;

    private IInitializationNavigationService _initializationNavigationService;

    public InitializationPageViewModel(IHabitStorage habitStorage,
        IInitializationNavigationService initializationNavigationService) {
        _habitStorage = habitStorage;
        _initializationNavigationService = initializationNavigationService;
        _lazyLoadedCommand =
            new Lazy<AsyncRelayCommand>(
                new AsyncRelayCommand(LoadedCommandFunction));
    }

    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    private string _status = string.Empty;

    public AsyncRelayCommand LoadedCommand => _lazyLoadedCommand.Value;

    private Lazy<AsyncRelayCommand> _lazyLoadedCommand;

    public async Task LoadedCommandFunction()
    {
        if (!_habitStorage.IsInitialized)
        {
            Status = "正在初始化习惯数据库";
            await _habitStorage.InitializeAsync();
        }


        Status = "所有初始化已完成";
        await Task.Delay(1000);

        _initializationNavigationService.NavigateToAppShell();
    }
}