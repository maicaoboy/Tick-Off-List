using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList;

public class ServiceLocator {
    private readonly IServiceProvider _serviceProvider;


    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IRouteService, RouteService>();
        serviceCollection
            .AddSingleton<IContentNavigationService,
                ContentNavigationService>();
        serviceCollection
            .AddSingleton<IRootNavigationService, RootNavigationService>();

        serviceCollection
            .AddTransient<IDailySentenceService, DailySentenceService>();
        serviceCollection.AddSingleton<DailySentenceViewModel>();
        serviceCollection.AddSingleton<IAlertService, AlertService>();

        serviceCollection.AddSingleton<CountdownPageViewModel>();
        serviceCollection.AddSingleton<ICountdownService, CountdownService>();
        serviceCollection.AddSingleton<IAudioPlayService, AudioPlayService>();

        serviceCollection.AddSingleton<IHabitStorage, HabitStorage>();
        serviceCollection
            .AddSingleton<IHabitRecordStorage, HabitRecordStorage>();
        serviceCollection.AddSingleton<HabitViewModel>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    public DailySentenceViewModel DailySentenceViewModel =>
        _serviceProvider.GetService<DailySentenceViewModel>();

    public CountdownPageViewModel CountdownPageViewModel =>
        _serviceProvider.GetService<CountdownPageViewModel>();

    public HabitViewModel HabitViewModel =>
        _serviceProvider.GetService<HabitViewModel>();

    public IRouteService RouteService =>
        _serviceProvider.GetService<IRouteService>();
}