namespace TickOffList.Services;

// Author: 陶静龙、李宏彬
public interface IRootNavigationService {
    Task NavigateToAsync(string pageKey);

    Task NavigateToAsync(string pageKey, object parameter);
}

public static class RootNavigationConstant {
    public const string CountdownPage = nameof(CountdownPage);

    public const string HabitPage = nameof(HabitPage);
}