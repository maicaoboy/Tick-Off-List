namespace TickOffList.Services;

// author: 李宏彬
public interface IPreferenceStorage {
    void Set(string key, int value);

    int Get(string key, int defaultValue);
}