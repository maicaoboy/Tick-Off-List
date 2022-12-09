using TickOffList.Models;

namespace TickOffList.Services;

// author: 李宏彬
public interface IHabitRecordStorage {
    public Task InitializeAsync();

    public Task AddAsync(HabitRecord habitRecord);

    public Task<IEnumerable<HabitRecord>> ListAsync();
}