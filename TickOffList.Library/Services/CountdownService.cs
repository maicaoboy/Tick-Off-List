namespace TickOffList.Services;
using Timer = System.Timers.Timer;

public class CountdownService : ICountdownService{

    public void Start(ref string hour, ref string minute, ref string second,
        ref bool isRunning) {
        throw new NotImplementedException();
    }

    public void Stop(ref bool isRunning) {
        throw new NotImplementedException();
    }

    public void Reset(ref string hour, ref string minute, ref string second,
        ref bool isRunning) {
        throw new NotImplementedException();
    }
}