using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rot13App;
using System;

namespace Rot13App.Tests
{
    [TestClass]
    public class Rot13CipherTests
    {
        [TestMethod]
        public void EncryptDecrypt_SelfInverse_Lowercase()
        {
            string original = "hello";
            string encrypted = Rot13Cipher.Encrypt(original);
            string decrypted = Rot13Cipher.Decrypt(encrypted);
            Assert.AreEqual(original, decrypted);
        }

        [TestMethod]
        public void EncryptDecrypt_SelfInverse_Uppercase()
        {
            string original = "HELLO";
            string encrypted = Rot13Cipher.Encrypt(original);
            string decrypted = Rot13Cipher.Decrypt(encrypted);
            Assert.AreEqual(original, decrypted);
        }

        [TestMethod]
        public void Encrypt_MixedCaseWithSpaces_ReturnsCorrect()
        {
            string original = "Hello World";
            string expected = "Uryyb Jbeyq";
            string actual = Rot13Cipher.Encrypt(original);
            Assert.AreEqual(expected, actual);

            string back = Rot13Cipher.Decrypt(actual);
            Assert.AreEqual(original, back);
        }

        [TestMethod]
        public void Encrypt_IgnoreDigits()
        {
            string original = "Test123";
            string expected = "Grfg123";
            string actual = Rot13Cipher.Encrypt(original);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Encrypt_IgnorePunctuation()
        {
            string original = "Hi!";
            string expected = "Uv!";
            string actual = Rot13Cipher.Encrypt(original);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Encrypt_EmptyString_ReturnsEmpty()
        {
            string original = "";
            string actual = Rot13Cipher.Encrypt(original);
            Assert.AreEqual("", actual);
        }

        [TestMethod]
        public void Encrypt_FullAlphabet()
        {
            string original = "abcdefghijklmnopqrstuvwxyz";
            string expected = "nopqrstuvwxyzabcdefghijklm";
            string actual = Rot13Cipher.Encrypt(original);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Encrypt_Null_ThrowsArgumentNullException()
        {
            Rot13Cipher.Encrypt(null);
        }

        [TestMethod]
        public void Encrypt_NonLatinCyrillic_Unchanged()
        {
            string original = "Привет";
            string actual = Rot13Cipher.Encrypt(original);
            Assert.AreEqual(original, actual);
        }
    }
}