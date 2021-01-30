using System;
using System.Collections.Generic;
using static System.Console;

namespace App.Tools
{
    public abstract class Provider
    {
        protected readonly string[] _lines;
        public readonly string Path;

        public Provider(string path)
        {
            Path = path;
            try
            {
                _lines = FileReader.ReadFile(path);
            }
            catch (Exception)
            {
                _lines = new[] {path};
            }
        }

        protected static void PrintLines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
                WriteLine(line);
        }
        
        public abstract void Output();
    }
}