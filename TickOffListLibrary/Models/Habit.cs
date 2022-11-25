using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace TickOffList.Models;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-11
* @version 1.0
* ==============================================================================*/


[SQLite.Table("habit")]
public class Habit : ObservableObject{
    [Column("id"), PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [SQLite.Column("title")]
    public string Title { get; set; } = string.Empty;

    [SQLite.Column("describe")]
    public string Describe { get; set; } = string.Empty;

    [SQLite.Column("iconName")]
    public string IconName { get; set; } = string.Empty;

    [SQLite.Column("days")]
    public string Days { get; set; } = string.Empty;

    [SQLite.Column("quantity")]
    public int Quantity { get; set; }

    [SQLite.Column("recordCount")]
    public int RecordCount { get; set; } = 0;

    private bool _finish;

    [SQLite.Ignore]
    public bool Finish {
        get => _finish;
        set => SetProperty(ref _finish, value);
    }
}