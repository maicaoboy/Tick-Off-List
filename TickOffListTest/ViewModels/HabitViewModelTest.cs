using Moq;
using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffListTest.ViewModels; 

public class HabitViewModelTest {
    private HabitStorage habitStorage;
    private TickViewModel _tickViewModel;

    public HabitViewModelTest()
    {
        habitStorage = new HabitStorage();
        var IRN = new Mock<IRootNavigationService>();
        _tickViewModel = new TickViewModel(new HabitStorage(), IRN.Object);
    }
}