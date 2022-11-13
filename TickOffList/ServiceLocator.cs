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
        serviceCollection.AddSingleton<IAudioPlayService, AudioPlayService>();

        serviceCollection.AddSingleton<IHabitStorage, HabitStorage>();
        serviceCollection.AddSingleton<IHabitRecordStorage, HabitRecordStorage>();
        serviceCollection.AddSingleton<HabitViewModel>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}