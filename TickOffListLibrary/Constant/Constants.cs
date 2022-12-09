namespace TickOffList.Constant;

/* ==============================================================================
* 创建人：李宏彬
* 创建时间：2022-11-11
* @version 1.0
* ==============================================================================*/
public static class Constants
{
    public const string DatabaseFilename = "TickOffListDB.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath
    {
        get
        {
            var basePath =
                Environment.GetFolderPath(Environment.SpecialFolder
                    .LocalApplicationData);
            return Path.Combine(basePath, DatabaseFilename);
        }
    }
}