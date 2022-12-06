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
        // habitStorage = new HabitStorage();
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
        int i = habit.RecordCount;


        habit.RecordCount = i + 1;
        habitStorage.updateHabit(habit);

        var listAsync1 = await habitStorage.ListAsync();
        var enumerator1 = listAsync1.GetEnumerator();
        enumerator1.MoveNext();
        var habit1 = enumerator1.Current;
        Assert.Equal(habit1.RecordCount, i + 1);

    }

    
    
    [Fact]
    public void GetHabitByDayOfWeekTest() {
        var habitByWeekDay = habitStorage.getHabitByWeekDay("5").Result;
        Assert.Equal(habitByWeekDay[0].IconName, "paobu.png");
        var habitByWeekDay1 = habitStorage.getHabitByWeekDay("6").Result;
        Assert.Equal(0, habitByWeekDay1.Count);
    }

    [Fact]
    public async void TetsHabitFinish() {
        var finish1 = await habitStorage.isFinish(1);
        if (!finish1) {
            var habitRecord = new HabitRecord() {Hid = 1, RecordDate = DateTime.Now};
            habitStorage.AddAsync(habitRecord);
        }
        var isFinish2 = habitStorage.isFinish(1);
        Assert.Equal(true, isFinish2.Result);
    }
    
    [Fact]
    public async void TestHabitFinishPara()
    {
        var finish1 = await habitStorage.isFinish(1, DateTime.Now);
        if (!finish1)
        {
            var habitRecord = new HabitRecord() { Hid = 1, RecordDate = DateTime.Now };
            habitStorage.AddAsync(habitRecord);
        }
        var isFinish2 = habitStorage.isFinish(1, DateTime.Now);
        Assert.Equal(true, isFinish2.Result);
    }

    [Fact]
    public async void TestTickCount() {
        var tickCount = await habitStorage.TickCount(1, DateTime.Now);
        Assert.Equal(1, tickCount);
    }

}