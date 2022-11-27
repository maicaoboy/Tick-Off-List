using TickOffList.Models;

namespace TickOffList.Services;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-10
* @version 1.0
* ==============================================================================*/

public interface IHabitStorage {
    //初始化数据库
    public Task InitializeAsync();

    //添加一个Habit
    public Task AddAsync(Habit poetry);


    //获取今日所有习惯
    public Task<IEnumerable<Habit>> ListAsync();

    //获取一周内某天所有习惯
    public Task<List<Habit>> getHabitByWeekDay(string dayOfWeek);

    //根据Habit的Id查询今日是否已经打卡
    public Task<bool> isFinish(int hid);

    //根据Habit的Id查询datetime指定日期是否已经打卡
    public Task<bool> isFinish(int hid, DateTime dateTime);

    //更新Habit数据
    public Task updateHabit(Habit habit);

    //计算一个Habit的打卡时间
    public Task<int> TickCount(int hid, DateTime dateTime);


    //删除一个Habit及其打卡记录
    public Task DeleteHabit(int hid);

    //添加一个打卡记录
    public Task AddAsync(HabitRecord habitRecord);

}