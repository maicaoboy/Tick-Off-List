﻿namespace TickOffList.Services;

// author: 李宏彬
public class PreferenceStorage : IPreferenceStorage {
    public void Set(string key, int value) {
        Preferences.Set(key, value);
    }

    public int Get(string key, int defaultValue) {
        return Preferences.Get(key, defaultValue);
    }
}