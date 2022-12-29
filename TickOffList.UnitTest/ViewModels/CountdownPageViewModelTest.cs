using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList.UnitTest.ViewModels;

// Author: 陶静龙
public class CountdownPageViewModelTest {

    [Fact]
    public async Task StartCommandTest() {
        IAudioPlayService audioPlayService = new AudioPlayService();
        ICountdownService countdownService = new CountdownService(audioPlayService);
        var countdownPageViewModel =
            new CountdownPageViewModel(countdownService);
        countdownPageViewModel.IsEnabled = true;
        countdownPageViewModel.IsRunning = false;
        countdownPageViewModel.SelectedHour = "00";
        countdownPageViewModel.SelectedMinute = "00";
        countdownPageViewModel.SelectedSecond = "01";
        await countdownPageViewModel.StartStopCommandFunction();
        await Task.Delay(2000);
        Assert.Equal("00 : 00 : 00", countdownPageViewModel.Time);
        Assert.True(countdownPageViewModel.IsEnabled);
        Assert.False(countdownPageViewModel.IsRunning);
    }

    [Fact]
    public async Task StopCommandTest() {
        IAudioPlayService audioPlayService = new AudioPlayService();
        ICountdownService countdownService = new CountdownService(audioPlayService);
        var countdownPageViewModel =
            new CountdownPageViewModel(countdownService);
        countdownPageViewModel.IsEnabled = true;
        countdownPageViewModel.IsRunning = true;
        countdownPageViewModel.SelectedHour = "00";
        countdownPageViewModel.SelectedMinute = "00";
        countdownPageViewModel.SelectedSecond = "05";
        await countdownPageViewModel.StartStopCommandFunction();
        Assert.Equal("00 : 00 : 05", countdownPageViewModel.Time);
        Assert.False(countdownPageViewModel.IsEnabled);
        Assert.False(countdownPageViewModel.IsRunning);
    }

    [Fact]
    public async Task ResetCommandTest() {
        IAudioPlayService audioPlayService = new AudioPlayService();
        ICountdownService countdownService = new CountdownService(audioPlayService);
        var countdownPageViewModel =
            new CountdownPageViewModel(countdownService);
        countdownPageViewModel.IsEnabled = true;
        countdownPageViewModel.IsRunning = true;
        countdownPageViewModel.SelectedHour = "00";
        countdownPageViewModel.SelectedMinute = "00";
        countdownPageViewModel.SelectedSecond = "05";
        await countdownPageViewModel.StartStopCommandFunction();
        await countdownPageViewModel.ResetCommandFunction();
        Assert.Equal("00 : 00 : 00", countdownPageViewModel.Time);
        Assert.True(countdownPageViewModel.IsEnabled);
        Assert.False(countdownPageViewModel.IsRunning);
    }
}