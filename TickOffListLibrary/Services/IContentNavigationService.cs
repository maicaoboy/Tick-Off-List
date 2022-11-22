namespace TickOffList.Services;

public interface IContentNavigationService
{
    Task NavigateToAsync(string pageKey);

    Task NavigateToAsync(string pageKey, object parameter);
}

public static class ContentNavigationConstant {

    public const string HabitPage = nameof(HabitPage);

    public const string TickPage = nameof(TickPage);
}