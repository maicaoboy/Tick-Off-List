namespace TickOffListLibrary.Models;

[SQLite.Table("habit_record")]
public class HabitRecord
{
    [SQLite.Column("id")]
    public int Id { set; get; }

    [SQLite.Column("hid")]
    public int Hid { set; get; }

    [SQLite.Column("record_date")]
    public DateTime RecordDate { set; get; } = DateTime.MinValue;
}