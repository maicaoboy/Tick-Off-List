using SQLite;
using TickOffListLibrary.Constant;
using TickOffListLibrary.Models;

namespace TickOffListLibrary.Services;

public class HabitRecordStorage : IHabitRecordStorage {
    private static SQLiteAsyncConnection Database;

    private SQLiteAsyncConnection? _connection;

    private SQLiteAsyncConnection Connection =>
        _connection ??= new SQLiteAsyncConnection(Constants.DatabasePath);

    public HabitRecordStorage()
    {
        Database =
            new SQLiteAsyncConnection(Constants.DatabasePath,
                Constants.Flags);
    }
    public async Task InitializeAsync() {
        await Connection.CreateTableAsync<HabitRecord>();
    }
    public async Task AddAsync(HabitRecord habitRecord) {
        await Connection.InsertAsync(habitRecord);
    }

    public async Task<IEnumerable<HabitRecord>> ListAsync()
    {
        return await Connection.Table<HabitRecord>().ToListAsync();
    }



}