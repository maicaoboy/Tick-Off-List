using TickOffList.Services;

namespace TickOffList.Services;

public class RouteService : IRouteService
{
    // pageKey -> route
    private readonly Dictionary<string, string> _routeDictionary = new()
    {
        [RootNavigationConstant.MainPage] = RootNavigationConstant.MainPage,
        [RootNavigationConstant.HabitPage] = RootNavigationConstant.HabitPage,
        [ContentNavigationConstant.TickPage] = 
            $"{RootNavigationConstant.HabitPage}/{ContentNavigationConstant.TickPage}",
    };

    public string GetRoute(string pageKey) => _routeDictionary[pageKey];
}