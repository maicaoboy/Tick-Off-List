using TickOffListLibrary.Models;
using TickOffListLibrary.Services;
using Xunit;

namespace TickOffListTest.Service; 

public class HabitStorageTest {
    [Fact]
    public void StorageAndReadTest()
    {
        var habitStorage = new HabitStorage();
        habitStorage.InitializeAsync();
        var habit = new Habit();
        habit.title = "haha";
        habitStorage.AddAsync(habit);
        var listAsync = habitStorage.ListAsync();
        var iter = listAsync.Result.GetEnumerator();
        iter.MoveNext();
        var habitGet = iter.Current;
        Assert.Equal("haha", habitGet.title);
    }
}