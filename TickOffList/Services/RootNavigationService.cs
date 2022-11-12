using TickOffList.Services;

namespace TickOffList.Services;

public class RootNavigationService : IRootNavigationService
{
    private IRouteService _routeService;

    public RootNavigationService(IRouteService routeService)
    {
        _routeService = routeService;
    }

    public async Task NavigateToAsync(string pageKey) =>
        await Shell.Current.GoToAsync($"//{_routeService.GetRoute(pageKey)}");


    public async Task NavigateToAsync(string pageKey, object parameter)
    {
        throw new NotImplementedException();
    }
}