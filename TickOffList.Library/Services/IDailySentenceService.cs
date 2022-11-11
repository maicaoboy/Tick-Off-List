using TickOffList.Models;

namespace TickOffList.Services; 

public interface IDailySentenceService {
    Task<DailySentence> GetDailySentenceAsync();
}