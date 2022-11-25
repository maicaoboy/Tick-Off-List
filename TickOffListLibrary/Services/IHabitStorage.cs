using TickOffList.Models;

namespace TickOffList.Services;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/

public interface IHabitStorage {
    public Task InitializeAsync();

    public Task AddAsync(Habit poetry);

    public Task<IEnumerable<Habit>> ListAsync();

    public Task<List<Habit>> getHabitByWeekDay(string dayOfWeek);

    public Task<bool> isFinish(int hid);

    public Task<bool> isFinish(int hid, DateTime dateTime);

    public Task updateHabit(Habit habit);
}