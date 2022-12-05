using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList; 

public class ServiceLocator {
    private IServiceProvider _serviceProvider;

    public DailySentenceViewModel DailySentenceViewModel =>
        _serviceProvider.GetService<DailySentenceViewModel>();

    public CountdownPageViewModel CountdownPageViewModel =>
        _serviceProvider.GetService<CountdownPageViewModel>();

    public HabitViewModel HabitViewModel =>
        _serviceProvider.GetService<HabitViewModel>();

    public TickViewModelProxy TickViewModelProxy =>
        _serviceProvider.GetService<TickViewModelProxy>();

    public CreateHabitViewModel CreateHabitViewModel =>
        _serviceProvider.GetService<CreateHabitViewModel>();

    public IRouteService RouteService =>
        _serviceProvider.GetService<IRouteService>();

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IRouteService, RouteService>();
        serviceCollection.AddSingleton<IContentNavigationService, ContentNavigationService>();
        serviceCollection.AddSingleton<IRootNavigationService, RootNavigationService>();

        serviceCollection.AddTransient<IDailySentenceService, DailySentenceService>();
        serviceCollection.AddSingleton<DailySentenceViewModel>();
        serviceCollection.AddSingleton<IAlertService, AlertService>();

        serviceCollection.AddSingleton<CountdownPageViewModel>();
        serviceCollection.AddSingleton<ICountdownService, CountdownService>();
        serviceCollection.AddSingleton<IAudioPlayService, AudioPlayService>();

        serviceCollection.AddSingleton<IHabitStorage, HabitStorage>();
        serviceCollection.AddSingleton<HabitViewModel>();

        serviceCollection.AddSingleton<TickViewModelProxy>();
        serviceCollection.AddSingleton<CreateHabitViewModel>();
        serviceCollection.AddSingleton<IDialogService, DialogService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}