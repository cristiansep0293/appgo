using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace goapp.webApi.Utils
{
    public class Encryption
    {
        private static byte[] GetValidKey(string key, int length)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            if (keyBytes.Length > length)
                return keyBytes.Take(length).ToArray(); // Truncar

            if (keyBytes.Length < length)
            {
                Array.Resize(ref keyBytes, length); // Rellenar con ceros
            }

            return keyBytes;
        }

        public static string Encrypt(string texto, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetValidKey(key, 32); // AES-256 requiere clave de 32 bytes
                aes.IV = GetValidKey(iv, 16);

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(texto);
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public static string Decrypt(string textoCifrado, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = GetValidKey(key, 32); // AES-256 requiere clave de 32 bytes
                aes.IV = GetValidKey(iv, 16);

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(Convert.FromBase64String(textoCifrado)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
