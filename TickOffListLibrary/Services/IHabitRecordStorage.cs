using TickOffListLibrary.Models;

namespace TickOffListLibrary.Services;

public interface IHabitRecordStorage
{
    public Task InitializeAsync();

    public Task AddAsync(HabitRecord habitRecord);

    public Task<IEnumerable<HabitRecord>> ListAsync();

}