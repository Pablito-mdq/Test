using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ServiceTestingFramework.Dextap.Utilities
{
    public class Encryption
    {
        private static readonly byte[] IV = new byte[] { 51, 12, 170, 249, 226, 186, 11, 89 };
        private static readonly byte[] key = new byte[] { 111, 113, 120, 113, 113, 107, 110, 53 };

        /// <summary>
        /// Decrypts encrypted data
        /// </summary>
        /// <param name="stringToDecrypt">The data to decrypt</param>
        /// <returns>The decrypted data</returns>
        public static string DecryptFromBase64String(string stringToDecrypt)
        {
            var desProvider = new DESCryptoServiceProvider();
            var inputByteArray = Convert.FromBase64String(stringToDecrypt);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, desProvider.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();
            var decryptedString = Encoding.UTF8.GetString(memoryStream.ToArray());
            return decryptedString;
        }

        /// <summary>
        /// Encrypts data
        /// </summary>
        /// <param name="stringToEncrypt">The data to encrypt</param>
        /// <returns>The encrypted data</returns>
        public static string EncryptToBase64String(string stringToEncrypt)
        {
            var desProvider = new DESCryptoServiceProvider();
            var inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream(memoryStream, desProvider.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();
            var encryptedString = Convert.ToBase64String(memoryStream.ToArray());
            return encryptedString;
        }
    }

}
