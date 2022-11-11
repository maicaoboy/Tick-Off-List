using TickOffList.Pages;

namespace TickOffList;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		// MainPage = new AppShell();
        MainPage = new NavigationPage(new HabitPage()) {
            BarTextColor = Color.FromRgb(255, 255, 255)
        }; ;
    }
}
