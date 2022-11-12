using System.Data.SqlTypes;
using SQLite;

namespace TickOffList.Models;

[SQLite.Table("habit")]
public class Habit {
    [Column("id"), PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [SQLite.Column("title")]
    public string title { get; set; } = string.Empty;

    [SQLite.Column("describe")]
    public string describe { get; set; } = string.Empty;

    [SQLite.Column("iconName")]
    public string iconName { get; set; } = string.Empty;

    [SQLite.Column("days")]
    public string days { get; set; } = string.Empty;

    [SQLite.Column("quantity")]
    public int quantity { get; set; }
}