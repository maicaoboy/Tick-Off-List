using System.Text.Json;
using TickOffList.Models;

namespace TickOffList.Services; 

public class DailySentenceService : IDailySentenceService {
    public async Task<DailySentence> GetDailySentenceAsync() {
        using var httpClient = new HttpClient();

        HttpResponseMessage response = new HttpResponseMessage();

        try {
            response = await httpClient.GetAsync("https://v1.hitokoto.cn/");
            response.EnsureSuccessStatusCode();
        } catch (Exception e) {
            _alertService.Alert("出错了", e.Message, "好的");
        }

        var json = await response.Content.ReadAsStringAsync();

        HitokotoSentence hitokotosentence = new HitokotoSentence();

        try {
            hitokotosentence = JsonSerializer.Deserialize<HitokotoSentence>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? throw new JsonException();
        } catch (Exception e) {
            _alertService.Alert("出错了", e.Message, "好的");
        }

        try {
            return new DailySentence {
                Snippet = 
                    hitokotosentence.Data?.Hitokoto ??
                    throw new JsonException(),
                From = hitokotosentence.Data?.From ?? throw new JsonException(),
                Creator = hitokotosentence.Data?.Creator ??
                    throw new JsonException()
            };
        } catch (Exception e) {
            _alertService.Alert("出错了", e.Message, "好的");
            throw;
        }
    }

    private readonly IAlertService _alertService;

    public DailySentenceService(IAlertService alertService) {
        _alertService = alertService;
    }
}

public class HitokotoData {
    public string? Hitokoto { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;
    public string? Creator { get; set; } = string.Empty;
}
public class HitokotoSentence {
    public HitokotoData? Data { get; set; } = new();
}