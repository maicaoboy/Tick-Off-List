﻿namespace TickOffList.Services;

// Author: 陶静龙、李宏彬
public class RouteService : IRouteService {
    private readonly Dictionary<string, string> _routeDictionary = new() {
        // pageKey "CountdownPage" -> route "CountdownPage"
        [RootNavigationConstant.CountdownPage] =
            RootNavigationConstant.CountdownPage,
        [RootNavigationConstant.HabitPage] = RootNavigationConstant.HabitPage
    };

    public string GetRoute(string pageKey) {
        return _routeDictionary[pageKey];
    }
}