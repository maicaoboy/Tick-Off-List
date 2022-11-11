using TickOffList.Pages;
using TickOffListLibrary.Services;

namespace TickOffList;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();


        var serviceLocatorName = nameof(ServiceLocator);
        var serviceLocator =
            (ServiceLocator)Application.Current.Resources.MergedDictionaries
                .First(p => p.ContainsKey(serviceLocatorName))[
                    serviceLocatorName];
        var routeService = serviceLocator.RouteService;

        Items.Add(new FlyoutItem
        {
            Title = nameof(HabitPage),
            Route = routeService.GetRoute(RootNavigationConstant.HabitPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(HabitPage))
                }
            }
        });



    }
}
