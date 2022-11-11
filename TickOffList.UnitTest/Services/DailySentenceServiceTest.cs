using TickOffList.Services;

namespace TickOffList.UnitTest.Services; 

public class DailySentenceServiceTest {
    [Fact]
    public async Task GetDailySentenceAsync_Default() {
        var dailySentenceService = new DailySentenceService(null);
        var result = await dailySentenceService.GetDailySentenceAsync();
        Assert.NotNull(result);
    }
}