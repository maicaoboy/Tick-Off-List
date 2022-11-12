using TickOffList.Services;

namespace TickOffList.UnitTest.Services;

// author: 朱怡达
public class DailySentenceServiceTest {
    [Fact]
    public async Task GetDailySentenceAsync_Default() {
        var dailySentenceService = new DailySentenceService(null);
        var result = await dailySentenceService.GetDailySentenceAsync();
        Assert.NotNull(result);
    }
}