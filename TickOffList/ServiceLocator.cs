using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList; 

public class ServiceLocator {
    private IServiceProvider _serviceProvider;

    public CountdownPageViewModel CountdownPageViewModel =>
        _serviceProvider.GetService<CountdownPageViewModel>();

    public IRouteService RouteService =>
        _serviceProvider.GetService<IRouteService>();


    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<CountdownPageViewModel>();

        serviceCollection.AddSingleton<IRouteService, RouteService>();

        serviceCollection.AddSingleton<IAudioPlayService, AudioPlayService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}