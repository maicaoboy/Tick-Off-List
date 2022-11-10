using TickOffList.Services;
using TickOffListLibrary.Services;
using TickOffListLibrary.ViewModels;

namespace TickOffList; 

public class ServiceLocator {
    private IServiceProvider _serviceProvider;

    public HabitViewModel HabitViewModel =>
        _serviceProvider.GetService<HabitViewModel>();

    public IRouteService RouteService =>
        _serviceProvider.GetService<IRouteService>();

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IHabitStorage, HabitStorage>();
        serviceCollection
            .AddSingleton<IHabitRecordStorage, HabitRecordStorage>();

        serviceCollection.AddSingleton<HabitViewModel>();

        serviceCollection.AddSingleton<IRouteService, RouteService>();
        serviceCollection
            .AddSingleton<IContentNavigationService,
                ContentNavigationService>();
        serviceCollection
            .AddSingleton<IRootNavigationService, RootNavigationService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}