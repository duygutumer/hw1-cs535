using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace WinFormsApp1
{
    internal class Encryptor
    {
        public (byte[] IV, byte[] cipherText) Encrypt(byte[] key, string plainText)
        {
            return Encrypt(key, Encoding.ASCII.GetBytes(plainText));
        }

        public (byte[] IV, byte[] cipherText) Encrypt(byte[] key, byte[] plainText)
        {
            byte[] IV = new byte[16];
            Random rnd = new Random();

            rnd.NextBytes(IV);

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

              
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return (IV, encrypted);
        }

        public string Decrypt(byte[] ivCtextPair, byte[] key)
        {
            byte[] IV = ivCtextPair.Take(16).ToArray();
            byte[] cText = ivCtextPair.Skip(16).ToArray();

            return Decrypt(IV, key, cText);
        }


        public string Decrypt(byte[] IV, byte[] key, byte[] cText)
        {
            // Check arguments.
            if (cText == null || cText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string plaintext = null;


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;
                
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
