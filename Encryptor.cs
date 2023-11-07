using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace Client
{
    internal class Encryptor
    {
        private static ulong nonce_right = 1;
        private static ulong nonce_left = 0;

        public static void IncreaseNonce()
        {
            nonce_right++;

            if (nonce_right == 0)
            {
                nonce_left++;
            }
        }

        public byte[] Encrypt(byte[] key, string plainText)
        {
            byte[] IV = BitConverter.GetBytes(nonce_left)
                .Concat(BitConverter.GetBytes(nonce_right))
                .ToArray();

            IncreaseNonce();

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
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }


            }

            return IV.Concat(encrypted).ToArray();
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

            string plaintext = "null";


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
