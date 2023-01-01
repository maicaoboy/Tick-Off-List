using System.Text.Json;
using TickOffList.Models;

namespace TickOffList.Services;

// author: 朱怡达
public class DailySentenceService : IDailySentenceService {
    public async Task<DailySentence> GetDailySentenceAsync() {
        using var httpClient = new HttpClient();

        HttpResponseMessage response;
        response = await httpClient.GetAsync("https://v1.hitokoto.cn/");
        response.EnsureSuccessStatusCode();


        var json = await response.Content.ReadAsStringAsync();

        var hitokotoSentence = JsonSerializer.Deserialize<HitokotoSentence>(json);

        return new DailySentence {
            Hitokoto = hitokotoSentence.hitokoto,
            From = hitokotoSentence.from,
            FromWho = hitokotoSentence.from_who
        };
    }

    private readonly IAlertService _alertService;

    public DailySentenceService(IAlertService alertService) {
        _alertService = alertService;
    }
}

public class HitokotoSentence {
    // 一言正文。编码方式 unicode，使用 utf-8。
    public string hitokoto { get; set; }
    // 一言的出处
    public string from { get; set; }
    // 一言的作者
    public string from_who { get; set; }
}