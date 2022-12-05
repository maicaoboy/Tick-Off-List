namespace TickOffList.Services;

// Author: 陶静龙、李宏彬
public class RouteService : IRouteService
{
    private readonly Dictionary<string, string> _routeDictionary = new()
    {
        [RootNavigationConstant.CountdownPage] = RootNavigationConstant.CountdownPage,
        [RootNavigationConstant.HabitPage] = RootNavigationConstant.HabitPage,
        [ContentNavigationConstant.TickPage] =
            $"{RootNavigationConstant.HabitPage}/{ContentNavigationConstant.TickPage}",
        [ContentNavigationConstant.CreateHabitPage] =
            $"{RootNavigationConstant.HabitPage}/{ContentNavigationConstant.CreateHabitPage}",
    };

    public string GetRoute(string pageKey) => _routeDictionary[pageKey];
}