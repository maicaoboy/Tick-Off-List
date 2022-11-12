﻿namespace TickOffList.Services; 

public class RouteService : IRouteService {
    private readonly Dictionary<string, string> _routeDictionary = new()
    {
        // pageKey "CountdownPage" -> route "CountdownPage"
        [RootNavigationConstant.CountdownPage] = RootNavigationConstant.CountdownPage,

    };

    public string GetRoute(string pageKey) => _routeDictionary[pageKey];
}