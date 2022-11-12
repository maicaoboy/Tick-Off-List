using Plugin.Maui.Audio;

namespace TickOffList.Services;

// Author: 陶静龙
public class AudioPlayService : IAudioPlayService{
    private const string AudioName = "finish.wav";
    private static readonly string AudioPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder
            .LocalApplicationData), AudioName);

    private readonly IAudioManager _audioManager = new AudioManager();

    private FileStream auFileStream =
        new FileStream(AudioPath, FileMode.OpenOrCreate);

    public AudioPlayService() {
        InitializeAudio();
    }

    private void InitializeAudio() {
        using var auAssetStream =
            typeof(AudioPlayService).Assembly.GetManifestResourceStream(AudioName) ??
            throw new Exception($"找不到名为{AudioName}的资源");
        auAssetStream.CopyToAsync(auFileStream);
    }

    public async Task PlayAudio() {
        var player = _audioManager.CreatePlayer(auFileStream);
        player.Play();
        // FileStream.Close();
    }
}