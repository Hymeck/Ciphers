using System.Linq;
using Library;
using static System.Console;

namespace App.Tools
{
    public sealed class CaesarProvider : Provider
    {
        public CaesarProvider(string path) : base(path)
        {
        }
        
        public override void Output()
        {
            var key = ParseKey();
            var lines = _lines.Length == 1 ? _lines : _lines.Skip(1);
            var encryptedLines = lines.Select(x => Caesar.encrypt(x, key));
            var decryptedLines = encryptedLines.Select(x => Caesar.decrypt(x, key));
            
            WriteLine("Шифрование Цезаря.\n");
            WriteLine("Содержимое файла:");
            PrintLines(lines);
            
            WriteLine($"\nЗашифрованное содержимое файла по основанию {key}:");
            PrintLines(encryptedLines);
            
            WriteLine($"\nРасшифрованное содержимое файла по основанию {key}:");
            PrintLines(decryptedLines);
        }

        private int ParseKey()
        {
            if (_lines.Length == 1)
                return 3;
            
            var line = _lines[0];
            var number = line.Split('=').Last();
            return int.Parse(number);
        }
    }
}