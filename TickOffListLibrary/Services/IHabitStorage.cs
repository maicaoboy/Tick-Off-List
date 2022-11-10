using TickOffListLibrary.Models;

namespace TickOffListLibrary.Services; 

public interface IHabitStorage {
    public Task InitializeAsync();

    public Task AddAsync(Habit poetry);

    public Task<IEnumerable<Habit>> ListAsync();
}