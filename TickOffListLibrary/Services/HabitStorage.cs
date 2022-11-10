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
}