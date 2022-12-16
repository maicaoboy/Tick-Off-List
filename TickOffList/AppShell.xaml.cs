using TickOffList.Pages;
using TickOffList.Services;

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

        Routing.RegisterRoute(
            routeService.GetRoute(ContentNavigationConstant.TickPage),
            typeof(TickPage));

        Routing.RegisterRoute(
            routeService.GetRoute(ContentNavigationConstant.CreateHabitPage),
            typeof(CreateHabitPage));

        Items.Add(new FlyoutItem
        {
            Title = nameof(CountdownPage),
            Route = routeService.GetRoute(RootNavigationConstant.CountdownPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(CountdownPage))
                }
            }
        });

        Items.Add(new FlyoutItem
        {
            Title = nameof(CalendarPage),
            Route = routeService.GetRoute(RootNavigationConstant.CalendarPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(CalendarPage))
                }
            }
        });



        Items.Add(new FlyoutItem
        {
            Title = nameof(DailyPage),
            Route = routeService.GetRoute(RootNavigationConstant.DailyPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(DailyPage))
                }
            }
        });

    }
}
