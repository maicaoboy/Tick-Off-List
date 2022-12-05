using Moq;
using TickOffList.Models;
using TickOffList.Services;
using TickOffList.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace TickOffList.UnitTest.ViewModels;

public class TickViewModelTest
{
    private HabitStorage habitStorage;
    private TickViewModel _tickViewModel;

    public TickViewModelTest()
    {
        habitStorage = new HabitStorage();
        var IRN = new Mock<IRootNavigationService>();
        _tickViewModel = new TickViewModel(new HabitStorage(), IRN.Object);
    }

    [Fact]
    public async void TickCommandLazyFunctionTest()
    {
        var habitRecord = new HabitRecord() { Hid = 999, RecordDate = DateTime.Now };
        habitStorage.AddAsync(habitRecord);
        _tickViewModel.TickHabit = new Habit() { Id = 1, Quantity = 1 };
        var isFinish = await habitStorage.isFinish(1, DateTime.Now);
        Assert.False(isFinish);
        _tickViewModel.TickCommandLazyFunction();
        var isFinish1 = await habitStorage.isFinish(1, DateTime.Now);
        Assert.True(isFinish1);
    }
}