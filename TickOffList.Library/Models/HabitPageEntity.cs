using SQLite;

namespace TickOffList.Models;

// author: 李宏彬
public class HabitPageEntity
{
    public int Id { get; set; }

    public string title { get; set; } = string.Empty;

    public string describe { get; set; } = string.Empty;

    public string iconName { get; set; } = string.Empty;

    public string days { get; set; } = string.Empty;

    public int quantity { get; set; }

    public int dayA { get; set; }

    public int quantityA { get; set; }
}