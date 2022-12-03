namespace TickOffList.Services;

public interface IRootNavigationService
{
    Task NavigateToAsync(string pageKey);

    Task NavigateToAsync(string pageKey, object parameter);
}

public static class RootNavigationConstant {
    public const string MainPage = nameof(MainPage);
    public const string HabitPage = nameof(HabitPage);
    public const string CalendarPage = nameof(CalendarPage);
}