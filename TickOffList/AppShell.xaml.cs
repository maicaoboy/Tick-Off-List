using TickOffList.Pages;

namespace TickOffList;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Items.Add(new FlyoutItem
        {
            Title = nameof(HabitPage),
            Route = nameof(HabitPage),
            Items = {
                new ShellContent {
                    ContentTemplate = new DataTemplate(typeof(HabitPage))
                }
            }
        });
    }
}
