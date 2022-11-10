using TickOffListLibrary.Services;
using TickOffListLibrary.ViewModels;

namespace TickOffList; 

public class ServiceLocator {
    private IServiceProvider _serviceProvider;

    public HabitViewModel HabitViewModel =>
        _serviceProvider.GetService<HabitViewModel>();

    public ServiceLocator() {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IHabitStorage, HabitStorage>();
        serviceCollection
            .AddSingleton<IHabitRecordStorage, HabitRecordStorage>();

        serviceCollection.AddSingleton<HabitViewModel>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}