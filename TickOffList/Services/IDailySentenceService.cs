using Refit;
using TickOffList.Models;

namespace TickOffList.Services;

public interface IDailySentenceService
{
    [Get("/?min_length=10")]
    Task<DailySentence> GetDailySentenceAsync();
}