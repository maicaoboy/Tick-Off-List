using System.Text.Json;
using TickOffList.Models;

namespace TickOffList.Services; 

public class DailySentenceService : IDailySentenceService {
    public async Task<DailySentence> GetDailySentenceAsync() {
        using var httpClient = new HttpClient();

        HttpResponseMessage response;

        try {
            response =
                await httpClient.GetAsync("https://v1.hitokoto.cn/");
            response.EnsureSuccessStatusCode();
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

        var json = await response.Content.ReadAsStringAsync();

        HitokotoSentence hitokotosentence;

        try {
            hitokotosentence = JsonSerializer.Deserialize<HitokotoSentence>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? throw new JsonException();
        } catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
}

public class HitokotoData {
    public string? Hitokoto { get; set; } = string.Empty;
    public string? Type { get; set; } = string.Empty;
    public string? From { get; set; } = string.Empty;
    public string? Creator { get; set; } = string.Empty;
    public string? CreatedAt { get; set; } = string.Empty;
}
public class HitokotoSentence {
    public HitokotoData? Data { get; set; } = new();
}