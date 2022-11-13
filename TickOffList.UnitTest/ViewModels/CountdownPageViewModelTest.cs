using TickOffList.Services;
using TickOffList.ViewModels;

namespace TickOffList.UnitTest.ViewModels;

// Author: 陶静龙
public class CountdownPageViewModelTest
{
    [Fact]
    public async Task StartTest()
    {
        IAudioPlayService audioPlayService = new AudioPlayService();
        var countdownPageViewModel = new CountdownPageViewModel(audioPlayService);
        countdownPageViewModel.Hour = "00";
        countdownPageViewModel.Minute = "00";
        countdownPageViewModel.Second = "01";
        await countdownPageViewModel.CountdownTime();
        await Task.Delay(1500);
        Assert.Equal("00", countdownPageViewModel.Second);
    }

    [Fact]
    public async Task StopTest()
    {
        IAudioPlayService audioPlayService = new AudioPlayService();
        var countdownPageViewModel = new CountdownPageViewModel(audioPlayService);
        countdownPageViewModel.Hour = "00";
        countdownPageViewModel.Minute = "00";
        countdownPageViewModel.Second = "05";
        countdownPageViewModel.IsRunning = true;
        await countdownPageViewModel.CountdownTime();
        Assert.False(countdownPageViewModel.IsRunning);
        Assert.Equal("05", countdownPageViewModel.Second);
    }

    [Fact]
    public async Task ResetTest()
    {
        IAudioPlayService audioPlayService = new AudioPlayService();
        var countdownPageViewModel = new CountdownPageViewModel(audioPlayService);
        countdownPageViewModel.Hour = "00";
        countdownPageViewModel.Minute = "00";
        countdownPageViewModel.Second = "05";
        countdownPageViewModel.IsRunning = true;
        await countdownPageViewModel.ResetCommandFunction();
        Assert.False(countdownPageViewModel.IsRunning);
        Assert.True(countdownPageViewModel.IsEnabled);
        Assert.Equal("00", countdownPageViewModel.Hour);
        Assert.Equal("00", countdownPageViewModel.Minute);
        Assert.Equal("00", countdownPageViewModel.Second);
    }
}