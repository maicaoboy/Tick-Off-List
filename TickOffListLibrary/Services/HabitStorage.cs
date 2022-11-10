﻿using Microsoft.VisualBasic.CompilerServices;
using SQLite;
using TickOffListLibrary.Constant;
using TickOffListLibrary.Models;

namespace TickOffListLibrary.Services; 

public class HabitStorage : IHabitStorage{
    private static SQLiteAsyncConnection Database;

    private SQLiteAsyncConnection? _connection;

    private SQLiteAsyncConnection Connection =>
        _connection ??= new SQLiteAsyncConnection(Constants.DatabasePath);

    public HabitStorage()
    {
        Database =
            new SQLiteAsyncConnection(Constants.DatabasePath,
                Constants.Flags);
        InitializeAsync();
    }

    public async Task InitializeAsync()
    {
        await Connection.CreateTableAsync<Habit>();
    }

    public async Task AddAsync(Habit poetry)
    {
        await Connection.InsertAsync(poetry);
    }

    public async Task<IEnumerable<Habit>> ListAsync()
    {
        return await Connection.Table<Habit>().ToListAsync();
    }

    public async Task<List<Habit>> getHabitByWeekDay(string dayOfWeek) {
        return await Connection.Table<Habit>().Where(h => h.days.Contains(dayOfWeek)).ToListAsync();
    }

    public async Task<bool> isFinish(int hid) {
        var todayBegin = DateTime.Now.Date;
        var todayEnd = todayBegin.AddMilliseconds(86400000);
        var countAsync = await Connection.Table<HabitRecord>().Where(hr => hr.Hid == hid && todayBegin <= hr.RecordDate && hr.RecordDate < todayEnd).CountAsync();
        var result = await Connection.Table<Habit>()
            .Where(h => h.Id == hid && h.quantity == countAsync).CountAsync();
        bool flag = result != 0;
        return flag;
    }

    public async Task<bool> isFinish(int hid, DateTime dateTime) {
        // Connection.ta
        var todayBegin = dateTime.Date;
        var todayEnd = todayBegin.AddMilliseconds(86400000);
        var countAsync = await Connection.Table<HabitRecord>().Where(hr => hr.Hid == hid && todayBegin <= hr.RecordDate && hr.RecordDate < todayEnd).CountAsync();
        var result = await Connection.Table<Habit>()
            .Where(h => h.Id == hid && h.quantity == countAsync).CountAsync();
        bool flag = result != 0;
        return flag;
    }
}