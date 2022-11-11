using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList; 

public class ServiceLocator {
    private IServiceProvider _serviceProvider;

    public DailySentenceViewModel DailySentenceViewModel =>
        _serviceProvider.GetService<DailySentenceViewModel>();

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IDailySentenceService, DailySentenceService>();
        serviceCollection.AddSingleton<DailySentenceViewModel>();
        serviceCollection.AddSingleton<IAlertService, AlertService>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}