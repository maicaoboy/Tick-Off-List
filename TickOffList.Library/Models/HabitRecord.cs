using SQLite;

namespace TickOffList.Models;

// author: 李宏彬
[Table("habit_record")]
public class HabitRecord {
    [Column("id")]
    [AutoIncrement]
    [PrimaryKey]
    public int Id { set; get; }

    [Column("hid")]
    public int Hid { set; get; }

    [Column("record_date")]
    public DateTime RecordDate { set; get; } = DateTime.MinValue;
}