using SQLite;
using TickOffList.Constant;
using TickOffList.Models;

namespace TickOffList.Services;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/
public class HabitStorage : IHabitStorage
{
    private static SQLiteAsyncConnection Database;

    private SQLiteAsyncConnection? _connection;

    private SQLiteAsyncConnection Connection =>
        _connection ??= new SQLiteAsyncConnection(Constants.DatabasePath,Constants.Flags);

    public HabitStorage()
    {

        Database = new SQLiteAsyncConnection(Constants.DatabasePath);
        InitializeAsync();
    }

    //初始化数据库
    public async Task InitializeAsync()
    {
        if (!File.Exists(Constants.DatabasePath)) {
            await Connection.CreateTableAsync<Habit>();
            await Connection.CreateTableAsync<HabitRecord>();
            var habit = new Habit {
                Title = "开始你的第一个习惯吧",
                Describe = "第一个习惯",
                IconName = "paobu.png",
                Days = "12345",
                Quantity = 1,
                RecordCount = 0
            };
            await AddAsync(habit);
        }
    }

    public async Task AddAsync(Habit poetry)
    {
        await Connection.InsertAsync(poetry);
    }

    public async Task<IEnumerable<Habit>> ListAsync() =>
        await Connection.Table<Habit>().ToListAsync();

    public async Task<IEnumerable<HabitRecord>> ListRecordAsync(DateTime starTime, DateTime endTime) =>
        await Connection.Table<HabitRecord>().Where(p => p.RecordDate < endTime && p.RecordDate > starTime).ToListAsync();

    public async Task<List<Habit>> getHabitByWeekDay(string dayOfWeek) {
        return await Connection.Table<Habit>().Where(h => h.Days.Contains(dayOfWeek)).ToListAsync();
    }

    public async Task<bool> isFinish(int hid) {
        var todayBegin = DateTime.Now.Date;
        var todayEnd = todayBegin.AddMilliseconds(86400000);
        var countAsync = await Connection.Table<HabitRecord>().Where(hr => hr.Hid == hid && todayBegin <= hr.RecordDate && hr.RecordDate < todayEnd).CountAsync();
        var result = await Connection.Table<Habit>()
            .Where(h => h.Id == hid && h.Quantity == countAsync).CountAsync();
        bool flag = result != 0;
        return flag;
    }

    public async Task<bool> isFinish(int hid, DateTime dateTime) {
        // Connection.ta
        var todayBegin = dateTime.Date;
        var todayEnd = todayBegin.AddMilliseconds(86400000);
        var countAsync = await Connection.Table<HabitRecord>().
            Where(hr => hr.Hid == hid && todayBegin <= hr.RecordDate && hr.RecordDate < todayEnd).CountAsync();
        var result = await Connection.Table<Habit>()
            .Where(h => h.Id == hid && h.Quantity == countAsync).CountAsync();
        bool flag = result != 0;
        return flag;
    }

    public async Task updateHabit(Habit habit) {
        await Connection.UpdateAsync(habit);
    }

    public async Task<int> TickCount(int hid, DateTime dateTime) {
        var todayBegin = dateTime.Date;
        var todayEnd = todayBegin.AddMilliseconds(86400000);
        var countAsync = await Connection.Table<HabitRecord>().Where(hr => hr.Hid == hid && todayBegin <= hr.RecordDate && hr.RecordDate < todayEnd).CountAsync();
        return countAsync;
    }

    public async Task DeleteHabit(int hid) {
        await Connection.Table<Habit>().DeleteAsync(h => h.Id == hid);
        await Connection.Table<HabitRecord>().DeleteAsync(hr => hr.Id == hid);
    }

    public async Task AddAsync(HabitRecord habitRecord)
    {
        await Connection.InsertAsync(habitRecord);
    }

}