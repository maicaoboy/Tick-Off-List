namespace TickOffList.Constant;

// author: 李宏彬
public static class Constants
{
    public const string DatabaseFilename = "TickOffLisDB.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath
    {
        get
        {
            var basePath =
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, DatabaseFilename);
            // 如果程序无法获取到目标路径，请将上面三行注释掉，使用下面的方法：
            //return Path.Combine("C:\\Users\\用户名\\AppData\\Local", DatabaseFilename);
        }
    }
}