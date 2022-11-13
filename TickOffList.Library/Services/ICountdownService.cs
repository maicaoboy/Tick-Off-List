namespace TickOffList.Services;

// Author: 陶静龙
public interface ICountdownService
{
    void Start(ref string hour, ref string minute, ref string second, ref bool isRunning);
    void Stop(ref bool isRunning);
    void Reset(ref string hour, ref string minute, ref string second, ref bool isRunning);
}