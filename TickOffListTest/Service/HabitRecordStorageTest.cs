using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using TickOffListLibrary.Models;
using TickOffListLibrary.Services; 
using Xunit;
using Xunit.Abstractions;

namespace TickOffListTest.Service; 

public class HabitRecordStorageTest {
    private readonly ITestOutputHelper output;

    public HabitRecordStorageTest(ITestOutputHelper output)
    {
        this.output = output;
        this.output.WriteLine("Execute constructor     !");
    }

    [Fact]
    public void StorageAndReadTest()
    {
        var habitRecordStorage = new HabitRecordStorage();
        var habitRecord = new HabitRecord
        {
            Hid = 1,
            RecordDate = DateTime.Now
        };
        habitRecordStorage.InitializeAsync();
        habitRecordStorage.AddAsync(habitRecord);
        // habitRecord.RecordDate.AddDays(-1);
        // habitRecordStorage.AddAsync(habitRecord);
        // habitRecordStorage.AddAsync(habitRecord);
        // habitRecordStorage.AddAsync(habitRecord);
        // habitRecord.RecordDate.AddDays(-1);
        // habitRecordStorage.AddAsync(habitRecord);
        // habitRecord.RecordDate.AddDays(-1);
        // habitRecordStorage.AddAsync(habitRecord);
        var listAsync = habitRecordStorage.ListAsync();
        var iter = listAsync.Result.GetEnumerator();
        iter.MoveNext();
        var habitRecordGet = iter.Current;
        // Assert.Equal(DateTime.Now.Day, habitRecordGet.RecordDate.Day + 1);
        this.output.WriteLine("fefeffes{0}",habitRecord.RecordDate.ToShortDateString());
        var temp = "my class!";
        this.output.WriteLine("This is output from {0}", temp);
    }

    [Fact]
    public void GetRecordByDay() {
        long begin = DateTime.Now.Date.Ticks;
        long end = DateTime.Now.Date.AddMilliseconds(86400000).Ticks;
        Assert.True(begin < DateTime.Now.Ticks && DateTime.Now.Ticks < end);
    }

    
}