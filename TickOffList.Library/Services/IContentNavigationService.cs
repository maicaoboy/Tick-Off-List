namespace TickOffList.Services;

public interface IContentNavigationService
{
    Task NavigateToAsync(string pageKey);

    Task NavigateToAsync(string pageKey, object parameter);
}

public static class ContentNavigationConstant
{
    
}