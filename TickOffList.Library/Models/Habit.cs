using SQLite;

namespace TickOffList.Models;

// author: 李宏彬
[Table("habit")]
public class Habit {
    [Column("id")]
    [PrimaryKey]
    [AutoIncrement]
    public int Id { get; set; }

    [Column("title")]
    public string title { get; set; } = string.Empty;

    [Column("describe")]
    public string describe { get; set; } = string.Empty;

    [Column("iconName")]
    public string iconName { get; set; } = string.Empty;

    [Column("days")]
    public string days { get; set; } = string.Empty;

    [Column("quantity")]
    public int quantity { get; set; }
}