﻿namespace TickOffList.Services;

// Author: 陶静龙、李宏彬
public class ContentNavigationService : IContentNavigationService {
    private readonly IRouteService _routeService;

    public ContentNavigationService(IRouteService routeService) {
        _routeService = routeService;
    }

    public async Task NavigateToAsync(string pageKey) {
        await Shell.Current.GoToAsync(_routeService.GetRoute(pageKey));
    }

    public async Task NavigateToAsync(string pageKey, object parameter) {
        await Shell.Current.GoToAsync($"{_routeService.GetRoute(pageKey)}",
            new Dictionary<string, object> {["parameter"] = parameter});
    }
}