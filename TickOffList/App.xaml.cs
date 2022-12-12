using TickOffList.Pages;

namespace TickOffList;

public partial class App : Application
{
	public App()
	{
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

        InitializeComponent();

		MainPage = new NavigationPage(new ContentPage());

        var serviceLocatorName = nameof(ServiceLocator);
        var serviceLocator =
            (ServiceLocator)Application.Current.Resources.MergedDictionaries
                .First(p => p.ContainsKey(serviceLocatorName))[
                    serviceLocatorName];

        var habitStorage = serviceLocator.HabitStorage;
        var initializationNavigationService = serviceLocator.InitializationNavigationService;

        if (!habitStorage.IsInitialized )
        {
            initializationNavigationService.NavigateToInitializationPage();
        }
        else
        {
            initializationNavigationService.NavigateToAppShell();
        }
    }
}
