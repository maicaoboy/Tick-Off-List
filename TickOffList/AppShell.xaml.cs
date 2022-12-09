using TickOffList.Pages;
using TickOffList.Services;

namespace TickOffList;

public partial class AppShell : Shell {
    public AppShell() {
        InitializeComponent();

        var serviceLocatorName = nameof(ServiceLocator);
        var serviceLocator =
            (ServiceLocator) Application.Current.Resources.MergedDictionaries
                .First(p => p.ContainsKey(serviceLocatorName))[
                    serviceLocatorName];

        Items.Add(new FlyoutItem {
            Title = nameof(DailyPage),
            Route = nameof(DailyPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(DailyPage))
                }
            }
        });

        var routeService = serviceLocator.RouteService;

        Items.Add(new FlyoutItem {
            Title = nameof(CountdownPage),
            Route = routeService.GetRoute(RootNavigationConstant.CountdownPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(CountdownPage))
                }
            }
        });

        Items.Add(new FlyoutItem {
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