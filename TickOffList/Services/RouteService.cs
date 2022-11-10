using TickOffListLibrary.Services;

namespace TickOffList.Services;

public class RouteService : IRouteService
{
    // pageKey -> route
    private readonly Dictionary<string, string> _routeDictionary = new()
    {
        [RootNavigationConstant.HabitPage] = RootNavigationConstant.HabitPage,
        // pageKey "TodayPage" -> route "TodayPage"
        // [ContentNavigationConstant.TodayDetailPage] =
        //     $"{RootNavigationConstant.TodayPage}/{ContentNavigationConstant.TodayDetailPage}",
        // pageKey "TodayDetailPage" -> "TodayPage/TodayDetailPage"
        // TODO 待修改
        // [ContentNavigationConstant.ResultPage] =
        //     ContentNavigationConstant.ResultPage,
        // TODO
    };

    public string GetRoute(string pageKey) => _routeDictionary[pageKey];
}