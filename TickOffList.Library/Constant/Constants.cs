using SQLite;

namespace TickOffList.Constant;

// author: 李宏彬
public static class Constants {
    public const string DatabaseFilename = "TickOffListDB.db3";

    public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

    public static string DatabasePath {
        get {
            var basePath =
                Environment.GetFolderPath(Environment.SpecialFolder
                    .LocalApplicationData);
            return Path.Combine(basePath, DatabaseFilename);
        }
    }
}