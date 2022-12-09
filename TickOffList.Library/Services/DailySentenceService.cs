using System.Text.Json;
using TickOffList.Models;

namespace TickOffList.Services;

// author: 朱怡达
public class DailySentenceService : IDailySentenceService {
    private readonly IAlertService _alertService;

    public DailySentenceService(IAlertService alertService) {
        _alertService = alertService;
    }

    public async Task<DailySentence> GetDailySentenceAsync() {
        using var httpClient = new HttpClient();

        HttpResponseMessage response;
        response = await httpClient.GetAsync("https://v1.hitokoto.cn/");
        response.EnsureSuccessStatusCode();


        var json = await response.Content.ReadAsStringAsync();

        var hitokotoSentence =
            JsonSerializer.Deserialize<HitokotoSentence>(json);

        return new DailySentence {
            Hitokoto = hitokotoSentence.hitokoto,
            From = hitokotoSentence.from,
            FromWho = hitokotoSentence.from_who
        };
    }
}

public class HitokotoSentence {
    public string hitokoto { get; set; }
    public string from { get; set; }
    public string from_who { get; set; }
}