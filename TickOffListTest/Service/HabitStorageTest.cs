using TickOffList.Models;
using TickOffList.Services;
using Xunit;
using Xunit.Abstractions;

namespace TickOffListTest.Service;
/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/
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
    public async void TestUpdate()
    {
        var listAsync = await habitStorage.ListAsync();
        var enumerator = listAsync.GetEnumerator();
        enumerator.MoveNext();
        var habit = enumerator.Current;
        // Assert.Equal(habit.Id, 1);
        Assert.Equal(habit.Quantity, 1);


        habit.Quantity = 2;
        habitStorage.updateHabit(habit);

        var listAsync1 = await habitStorage.ListAsync();
        var enumerator1 = listAsync1.GetEnumerator();
        enumerator1.MoveNext();
        var habit1 = enumerator1.Current;
        Assert.Equal(habit1.Quantity, 2);

    }

    // [Fact]
    // public void StorageAndReadTest()
    // {
    //     var habitStorage = new HabitStorage();
    //     // habitStorage.InitializeAsync();
    //     var habit = new Habit();
    //     habit.Title = "haha";
    //     habitStorage.AddAsync(habit);
    //     var listAsync = habitStorage.ListAsync();
    //     var iter = listAsync.Result.GetEnumerator();
    //     iter.MoveNext();
    //     var habitGet = iter.Current;
    //     Assert.Equal("背单词", habitGet.Title);
    // }
    //
    // [Fact]
    // public async void testList()
    // {
    //     var storage = new HabitStorage();
    //     var listAsync = await habitStorage.ListAsync();
    //     var habits = listAsync.ToList();
    //     for (var i = 0; i < habits.Count; i++) {
    //         output.WriteLine(habits[i].Title);
    //     }
    // }
    //
    // [Fact]
    // public void GetHabitByDayOfWeekTest() {
    //     var habitByWeekDay = habitStorage.getHabitByWeekDay("6").Result;
    //     output.WriteLine("{0}-{1}", habitByWeekDay[0].Title, habitByWeekDay[1].Title);
    // }
    //
    // [Fact]
    // public void TetsHabitFinish() {
    //     // var isFinish = habitStorage.isFinish(1);
    //     // Assert.Equal(true, isFinish);
    //     var isFinish2 = habitStorage.isFinish(2);
    //     Assert.Equal(true, isFinish2.Result);
    // }
    //
    // [Fact]
    // public void TetsHabitFinishPara()
    // {
    //     // var isFinish = habitStorage.isFinish(1);
    //     // Assert.Equal(true, isFinish);
    //     var isFinish2 = habitStorage.isFinish(2, DateTime.Now);
    //     Assert.Equal(true, isFinish2.Result);
    // }



}