using TickOffList.Pages;

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

        Items.Add(new FlyoutItem
        {
            Title = nameof(DailyPage),
            Route = nameof(DailyPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(DailyPage))
                }
            }
        });
    }
}
