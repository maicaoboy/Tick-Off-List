using SQLite;

namespace TickOffList.Models;

[SQLite.Table("habit_record")]
public class HabitRecord
{
    [Column("id"), AutoIncrement, PrimaryKey]
    public int Id { set; get; }

    [SQLite.Column("hid")]
    public int Hid { set; get; }

    [SQLite.Column("record_date")]
    public DateTime RecordDate { set; get; } = DateTime.MinValue;
}