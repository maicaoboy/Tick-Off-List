using TickOffList.Models;
using TickOffList.Services;
using Xunit;
using Xunit.Abstractions;

namespace TickOffListTest.Service; 

public class HabitStorageTest {
    private HabitStorage habitStorage;
    private readonly ITestOutputHelper output;

    public HabitStorageTest(ITestOutputHelper output)
    {
        this.output = output;
        habitStorage = new HabitStorage();
        this.output.WriteLine("Execute constructor!");
    }

    [Fact]
    public void StorageAndReadTest()
    {
        var habitStorage = new HabitStorage();
        // habitStorage.InitializeAsync();
        var habit = new Habit();
        habit.title = "haha";
        habitStorage.AddAsync(habit);
        var listAsync = habitStorage.ListAsync();
        var iter = listAsync.Result.GetEnumerator();
        iter.MoveNext();
        var habitGet = iter.Current;
        Assert.Equal("haha", habitGet.title);
    }

    [Fact]
    public void GetHabitByDayOfWeekTest() {
        var habitByWeekDay = habitStorage.getHabitByWeekDay("6").Result;
        output.WriteLine("{0}-{1}", habitByWeekDay[0].title, habitByWeekDay[1].title);
    }

    [Fact]
    public void TetsHabitFinish() {
        // var isFinish = habitStorage.isFinish(1);
        // Assert.Equal(true, isFinish);
        var isFinish2 = habitStorage.isFinish(2);
        Assert.Equal(true, isFinish2.Result);
    }

    [Fact]
    public void TetsHabitFinishPara()
    {
        // var isFinish = habitStorage.isFinish(1);
        // Assert.Equal(true, isFinish);
        var isFinish2 = habitStorage.isFinish(2, DateTime.Now);
        Assert.Equal(true, isFinish2.Result);
    }

    [Fact]
    public void testList() {
        var storage = new HabitStorage();
        var listAsync = storage.ListAsync();
        listAsync.Result.GetEnumerator().MoveNext();
        output.WriteLine(listAsync.Result.GetEnumerator().Current.ToString());
    }
}