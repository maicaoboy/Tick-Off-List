using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList; 

public class ServiceLocator {
    private IServiceProvider _serviceProvider;

    public TickViewModelProxy TickViewModelProxy =>
        _serviceProvider.GetService<TickViewModelProxy>();
        

    public HabitViewModel HabitViewModel =>
        _serviceProvider.GetService<HabitViewModel>();

    public CreateHabitViewModel CreateHabitViewModel =>
        _serviceProvider.GetService<CreateHabitViewModel>();

    public IRouteService RouteService =>
        _serviceProvider.GetService<IRouteService>();

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

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

        serviceCollection.AddSingleton<IDialogService, DialogService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}