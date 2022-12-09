namespace TickOffList.Services;

// Author: 陶静龙、李宏彬
public class ContentNavigationService : IContentNavigationService {
    private readonly IRouteService _routeService;

    public ContentNavigationService(IRouteService routeService) {
        _routeService = routeService;
    }

        await Shell.Current.GoToAsync(_routeService.GetRoute(pageKey));
    }

        await Shell.Current.GoToAsync($"{_routeService.GetRoute(pageKey)}",
            new Dictionary<string, object> {["parameter"] = parameter});
}
}