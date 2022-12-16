namespace TickOffList.Services;

public class RouteService : IRouteService
{
    // pageKey -> route
    private readonly Dictionary<string, string> _routeDictionary = new()
    {
        [RootNavigationConstant.DailyPage] = RootNavigationConstant.DailyPage,
        [RootNavigationConstant.MainPage] = RootNavigationConstant.MainPage,
        [RootNavigationConstant.HabitPage] = RootNavigationConstant.HabitPage,
        [RootNavigationConstant.CalendarPage] = RootNavigationConstant.CalendarPage,
        [RootNavigationConstant.CountdownPage] = RootNavigationConstant.CountdownPage,
        [ContentNavigationConstant.TickPage] = 
            $"{RootNavigationConstant.HabitPage}/{ContentNavigationConstant.TickPage}",
        [ContentNavigationConstant.CreateHabitPage] =
            $"{RootNavigationConstant.HabitPage}/{ContentNavigationConstant.CreateHabitPage}",
    };

    public string GetRoute(string pageKey) => _routeDictionary[pageKey];
}