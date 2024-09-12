using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace CorkMaster;

public class DB
{
    private static string DBName = "wine.db";
    public static SQLiteConnection conn;
    public static void OpenConnection()
    {
        string libFolder = FileSystem.AppDataDirectory;
        string fname = System.IO.Path.Combine(libFolder, DBName);
        conn = new SQLiteConnection(fname);
    }
}
