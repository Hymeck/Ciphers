using System.IO;

namespace App.Tools
{
    public class FileReader
    {
        public static string[] ReadFile(string path) => File.ReadAllLines(path);
    }
}