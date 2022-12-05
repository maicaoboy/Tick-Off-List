using Moq;
using TickOffList.Services;
using TickOffList.ViewModels;
using Xunit;

namespace TickOffList.UnitTest.ViewModels;

public class CreateHabitViewModelTest
{
    private HabitStorage habitStorage;
    private CreateHabitViewModel _createHabitViewModel;

    public CreateHabitViewModelTest()
    {
        habitStorage = new HabitStorage();
        var mock = new Mock<IHabitStorage>();
        var mock1 = new Mock<IRootNavigationService>();
        var mock2 = new Mock<IDialogService>();
        _createHabitViewModel = new CreateHabitViewModel(mock.Object, mock1.Object, mock2.Object);
    }

    [Fact]
    public void SaveHabitCommandFunctionTest()
    {

    }
}