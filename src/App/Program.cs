using System;
using System.Text;
using Library;
using static System.Console;

namespace App
{
    class Program
    {
        private const string RussianAlphabet =
            "Аа Бб Вв Гг Дд Ее Ёё Жж Зз Ии Йй Кк Лл Мм Нн Оо Пп Рр Сс Тт Уу Фф Хх Цц Чч Шш Щщ Ъъ Ыы Ьь Ээ Юю Яя";
        static void Main(string[] args)
        {
            InputEncoding = Encoding.UTF8;
            OutputEncoding = Encoding.UTF8;
            
            var input = args.Length == 0 ? RussianAlphabet : string.Join(' ', args);
            var key = 3;
            var encodedInput = Caesar.encipher(input, key);
            var decodedInput = Caesar.decipher(encodedInput, key);
            
            WriteLine($"Входная строка: {input}");
            WriteLine($"Закодированная  строка по основанию {key}: {encodedInput}");
            WriteLine($"Раскодированная строка по основанию {key}: {decodedInput}");
            
        }
    }
}
