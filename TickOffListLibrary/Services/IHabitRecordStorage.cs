using TickOffList.Models;

namespace TickOffList.Services;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/

public interface IHabitRecordStorage
{
    public Task InitializeAsync();

    public Task AddAsync(HabitRecord habitRecord);

    public Task<IEnumerable<HabitRecord>> ListAsync();

}