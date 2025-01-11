using System.IO;

namespace vroomApp.Podaci;

public static class Constants
{
    public const string DatabaseFilename = "VroomAppSQLite.db3";

    public static string DatabasePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
}

