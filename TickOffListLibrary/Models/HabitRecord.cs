using SQLite;

namespace TickOffList.Models;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-11
* @version 1.0
* ==============================================================================*/

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