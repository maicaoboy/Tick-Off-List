namespace TickOffList.Services; 

public class MeetingService : IMeetingService {
    private IHabitStorage _habitStorage;

    public MeetingService(IHabitStorage habitStorage) {
        _habitStorage = habitStorage;
    }

    public async void getMeetings(DateTime starTime, DateTime endTime) {
        var habits = await _habitStorage.ListAsync();
        
    }
}