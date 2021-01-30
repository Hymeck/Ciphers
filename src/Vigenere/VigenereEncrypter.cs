using System;
using System.Collections.Generic;
using System.Linq;
using Library;

namespace Vigenere
{
    public class VigenereEncrypter
    {
        private readonly string _letters;
        
        public VigenereEncrypter(string alphabet)
        {
            if (string.IsNullOrEmpty(alphabet))
                throw new NotImplementedException(nameof(alphabet));
            
            _letters = alphabet;
        }

        public VigenereEncrypter() : this(Shared.russianLowerLetters)
        {
        }

        private IEnumerable<char> YieldChar(IEnumerable<(char, char)> inputWithKey, int step)
        {
            var letterCount = _letters.Length;
            foreach (var (inputCharacter, keyCharacter) in inputWithKey)
            {
                var charIndex = _letters.IndexOf(inputCharacter);
                var keyIndex = _letters.IndexOf(keyCharacter);

                if (charIndex < 0)
                    yield return inputCharacter;
                else
                {
                    var cipheredIndex = (letterCount + charIndex + step * keyIndex) % letterCount;
                    yield return _letters[cipheredIndex];
                }
            }
        }
        
        private string VigenereCaller(string input, string key, bool isEncrypting)
        {
            var step = isEncrypting ? 1 : -1;
            var fullKey = Library.Vigenere.fullKey(key, input.Length);
            var inputWithKey = input.Zip(fullKey);

            return string.Concat(YieldChar(inputWithKey, step));
        }
        
        public string Encrypt(string input, string key) => VigenereCaller(input, key, true);
        
        public string Decrypt(string input, string key) => VigenereCaller(input, key, false);
    }
}