using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingFile
{
    public static class HelperClass
    {
        public static bool IsValidPath(string sPath)
        {
            return String.IsNullOrEmpty(sPath.Trim());
        }

        public static bool IsValidDirectory(string sPath)
        {
            return String.IsNullOrEmpty(Path.GetDirectoryName(sPath).Trim());
        }

        public static bool IsDirectoryExists(string sPath)
        {
            return Directory.Exists(Path.GetDirectoryName(sPath));
        }

        public static bool IsValidFileExtension(string sPath)
        {
            FileInfo fi = new FileInfo(sPath);
            return fi.Extension.Contains("csv");
        }
        public static bool IsFieExists(string sPath)
        {
            return File.Exists(sPath);
        }
        
    }
}
