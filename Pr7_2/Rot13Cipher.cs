using System;

namespace Rot13App
{
    /// <summary>
    /// Предоставляет методы для шифрования и дешифрования текста по алгоритму ROT13.
    /// </summary>
    public static class Rot13Cipher
    {
        /// <summary>
        /// Шифрует текст методом ROT13. Обрабатывает только латинские буквы, остальные символы не изменяются.
        /// </summary>
        /// <param name="text">Исходный текст.</param>
        /// <returns>Зашифрованная строка.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="text"/> равен null.</exception>
        public static string Encrypt(string text)
        {
            return Transform(text);
        }

        /// <summary>
        /// Дешифрует текст методом ROT13 (самодвойственная операция).
        /// </summary>
        /// <param name="text">Зашифрованный текст.</param>
        /// <returns>Расшифрованная строка.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="text"/> равен null.</exception>
        public static string Decrypt(string text)
        {
            return Transform(text);
        }

        /// <summary>
        /// Выполняет преобразование ROT13 над строкой.
        /// </summary>
        private static string Transform(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char c = buffer[i];
                if (c >= 'a' && c <= 'z')
                    buffer[i] = (char)(((c - 'a' + 13) % 26) + 'a');
                else if (c >= 'A' && c <= 'Z')
                    buffer[i] = (char)(((c - 'A' + 13) % 26) + 'A');
            }
            return new string(buffer);
        }
    }
}