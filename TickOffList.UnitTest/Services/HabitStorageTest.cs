using TickOffList.Models;
using TickOffList.Services;
using Xunit;
using Xunit.Abstractions;

namespace TickOffList.UnitTest.Services;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/
public class HabitStorageTest
{
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
        Assert.Equal("背单词", habitGet.title);
    }

    [Fact]
    public async void testList()
    {
        var storage = new HabitStorage();
        var listAsync = await habitStorage.ListAsync();
        var habits = listAsync.ToList();
        for (var i = 0; i < habits.Count; i++)
        {
            output.WriteLine(habits[i].title);
        }
    }

    [Fact]
    public void GetHabitByDayOfWeekTest()
    {
        var habitByWeekDay = habitStorage.getHabitByWeekDay("6").Result;
        output.WriteLine("{0}-{1}", habitByWeekDay[0].title, habitByWeekDay[1].title);
    }

    [Fact]
    public void TetsHabitFinish()
    {
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
}