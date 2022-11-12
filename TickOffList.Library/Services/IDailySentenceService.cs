using TickOffList.Models;

namespace TickOffList.Services;

// author: 朱怡达
public interface IDailySentenceService {
    Task<DailySentence> GetDailySentenceAsync();
}