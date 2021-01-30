using System.Linq;
using Vigenere;
using static System.Console;

namespace App.Tools
{
    public sealed class VigenereProvider : Provider
    {
        public VigenereProvider(string path) : base(path)
        {
        }

        public override void Output()
        {
            var key = _lines.Length == 1 ? "ключ" : _lines[0];
            var lines = _lines.Length == 1 ? _lines : _lines.Skip(1);

            var vigenere = new VigenereEncrypter();
            var encryptedLines = lines.Select(x => vigenere.Encrypt(x, key));
            var decryptedLines = encryptedLines.Select(x => vigenere.Decrypt(x, key));
            
            WriteLine("Шифрование Виженера.\n");
            WriteLine($"Ключ: {key}\n");
            WriteLine("Содержимое файла:");
            PrintLines(lines);
            
            WriteLine($"\nЗашифрованное содержимое файла:");
            PrintLines(encryptedLines);
            
            WriteLine($"\nРасшифрованное содержимое файла:");
            PrintLines(decryptedLines);
        }
    }
}