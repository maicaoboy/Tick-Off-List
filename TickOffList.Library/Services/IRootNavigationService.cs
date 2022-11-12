namespace TickOffList.Services;

// Author: 陶静龙
public interface IRootNavigationService
{
    Task NavigateToAsync(string pageKey);

    Task NavigateToAsync(string pageKey, object parameter);
}

public static class RootNavigationConstant
{
    public const string CountdownPage = nameof(CountdownPage);
}