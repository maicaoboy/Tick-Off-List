namespace TickOffList.Services; 

public interface IMeetingService {
    //查询一段时间内的打卡记录
    public void getMeetings(DateTime starTime, DateTime endTime);
}