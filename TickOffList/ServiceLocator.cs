using TickOffList.Converters;
using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList; 

public class ServiceLocator {
    private IServiceProvider _serviceProvider;

    public CalendarViewModel CalendarViewModel =>
        _serviceProvider.GetService<CalendarViewModel>();


    public TickViewModelProxy TickViewModelProxy =>
        _serviceProvider.GetService<TickViewModelProxy>();
        

    public HabitViewModel HabitViewModel =>
        _serviceProvider.GetService<HabitViewModel>();

    public CreateHabitViewModel CreateHabitViewModel =>
        _serviceProvider.GetService<CreateHabitViewModel>();

    public IRouteService RouteService =>
        _serviceProvider.GetService<IRouteService>();

    public IInitializationNavigationService InitializationNavigationService =>
        _serviceProvider.GetService<IInitializationNavigationService>();

    public IHabitStorage HabitStorage =>
        _serviceProvider.GetService<IHabitStorage>();

    public InitializationPageViewModel InitializationPageViewModel =>
        _serviceProvider.GetService<InitializationPageViewModel>();

    public CountdownPageViewModel CountdownPageViewModel =>
        _serviceProvider.GetService<CountdownPageViewModel>();

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IPreferenceStorage, PreferenceStorage>();
        serviceCollection.AddSingleton<IHabitStorage, HabitStorage>();

        serviceCollection.AddSingleton<IRouteService, RouteService>();
        serviceCollection
            .AddSingleton<IContentNavigationService,
                ContentNavigationService>();
        serviceCollection
            .AddSingleton<IRootNavigationService, RootNavigationService>();

        serviceCollection.AddSingleton<HabitViewModel>();

        serviceCollection.AddSingleton<TickViewModelProxy>();

        serviceCollection.AddSingleton<CreateHabitViewModel>();

        serviceCollection.AddSingleton<CalendarViewModel>();

        serviceCollection.AddSingleton<InitializationPageViewModel>();

        serviceCollection.AddSingleton<IMeetingService, MeetingService>();

        serviceCollection.AddSingleton<IMeetingColorConverter, MeetingColorConverter>();

        serviceCollection.AddSingleton<IAlertService, AlertService>();

        serviceCollection
            .AddSingleton<IInitializationNavigationService,
                InitializationNavigationService>();

        serviceCollection.AddSingleton<CountdownPageViewModel>();
        serviceCollection.AddSingleton<ICountdownService, CountdownService>();
        serviceCollection.AddSingleton<IAudioPlayService, AudioPlayService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}