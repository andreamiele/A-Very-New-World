 using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class EncryptionDecryption // Class used to encrypt/decrypt a text with a key using a Symmetric-key algorithms. (cf: https://en.wikipedia.org/wiki/Symmetric-key_algorithm )
{
    public static string EncryptString(string key, string plainText) // Encrypt a text with a key using a Symmetric-key algorithms.
    {
        byte[] iv = new byte[16];
        byte[] array;

        using (Aes x = Aes.Create())
        {
            x.Key = Encoding.UTF8.GetBytes(key);
            x.IV = iv;

            ICryptoTransform encryptor = x.CreateEncryptor(x.Key, x.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }

                    array = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(array);
    }// end EncryptString

    public static string DecryptString(string key, string cipherText) // Decrypt a text with a key using a Symmetric-key algorithms.
    {
        byte[] iv = new byte[16];
        byte[] buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = iv;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }// end DecryptString


}// end Class



