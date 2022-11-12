namespace TickOffList.Services;

public interface IRootNavigationService
{
    Task NavigateToAsync(string pageKey);

    Task NavigateToAsync(string pageKey, object parameter);
}

public static class RootNavigationConstant
{
    public const string CountdownPage = nameof(CountdownPage);
}