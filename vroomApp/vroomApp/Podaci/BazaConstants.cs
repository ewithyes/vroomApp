using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Maui.Storage;

namespace vroomApp.Podaci
{
    public static class BazaConstants
    {
        public const string DatabaseFilename = "VroomSQLite.db3";

 

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
        
           
    }
}
