namespace TickOffList.Models; 

// 承载service返回的结果，服务器返回的一言
public class DailySentence {
    public string Snippet { get; set; } = string.Empty;

    public string Hitokoto { get; set; } = string.Empty;

    public string From { get; set; } = string.Empty;

    public string Creator { get; set; } = string.Empty;
}