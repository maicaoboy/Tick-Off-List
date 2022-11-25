using TickOffList.Services;

namespace TickOffList.ViewModels;

[QueryProperty(nameof(Args), "parameter")]
public class TickViewModelProxy : TickViewModel{
    public TickViewModelProxy(IHabitStorage habitStorage, IHabitRecordStorage habitRecordStorage) : base(habitStorage, habitRecordStorage) { }
}