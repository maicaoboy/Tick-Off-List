﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TickOffList.Models;
using TickOffList.Services;

namespace TickOffList.ViewModels;

// author: 朱怡达
public class DailySentenceViewModel : ObservableObject
{
    private readonly IDailySentenceService _dailySentenceService;

    public DailySentenceViewModel(IDailySentenceService dailySentenceService)
    {
        _dailySentenceService = dailySentenceService;
        _lazyLoadedCommand = new Lazy<AsyncRelayCommand>(() =>
            new AsyncRelayCommand(LoadedCommandFunction));
    }

    private readonly Lazy<AsyncRelayCommand> _lazyLoadedCommand;
    public AsyncRelayCommand LoadedCommand => _lazyLoadedCommand.Value;

    public async Task LoadedCommandFunction() {
        IsLoading = true;
        DailySentence = await _dailySentenceService.GetDailySentenceAsync();
        IsLoading = false;
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    private bool _isLoading;

    private DailySentence _dailySentence;

    public DailySentence DailySentence {
        get => _dailySentence;
        set => SetProperty(ref _dailySentence, value);
    }
}
