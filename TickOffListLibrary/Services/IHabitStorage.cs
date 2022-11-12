using TickOffList.Models;

namespace TickOffList.Services; 

public interface IHabitStorage {
    public Task InitializeAsync();

    public Task AddAsync(Habit poetry);

    public Task<IEnumerable<Habit>> ListAsync();

    public Task<List<Habit>> getHabitByWeekDay(string dayOfWeek);

    public Task<bool> isFinish(int hid);

    public Task<bool> isFinish(int hid, DateTime dateTime);
}