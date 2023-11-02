
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WinFormsApp1
{
    internal class PasswordData
    {
        private readonly List<byte[]> _passwordChain1 = new List<byte[]>(); // Backwards Secrecy
        private readonly List<byte[]> _passwordChain2 = new List<byte[]>(); // Forward Secrecy

        public void GeneratePasswordChains(string str1, string str2, int count)
        {
            using (SHA256 hasher = SHA256.Create())
            {
                var firstHash = hasher.ComputeHash(Encoding.ASCII.GetBytes(str1));
                _passwordChain1.Add(firstHash);

                firstHash =  hasher.ComputeHash(Encoding.ASCII.GetBytes(str2));
                _passwordChain2.Add(firstHash);

                for (int i = 1; i < count; i++)
                {
                    byte[] prevHash = _passwordChain1[^1];
                    _passwordChain1.Add(hasher.ComputeHash(prevHash));

                    prevHash = _passwordChain2[^1];
                    _passwordChain2.Add(hasher.ComputeHash(prevHash));
                }
            }
        }

        public (byte[], byte[]) GetSessionHashes(int sessionNo)
        {
            return (_passwordChain1[sessionNo - 1], _passwordChain2[^sessionNo]);
        }
    }

    internal class TamperProofProcessor
    {
        private readonly PasswordData _passwordData;
        private int _sessionNo;

        private const int HashSize = 256 / 8;
        private const int KeySize = 128 / 8;

        public TamperProofProcessor(int sessionCount = 10, string password1 = "Duygu", string password2 = "Batuhan")
        {
            if (sessionCount < 1)
            {
                throw new ArgumentException("Session count can not be lower than 1!");
            }

            _passwordData = new PasswordData();
            _passwordData.GeneratePasswordChains(password1, password2, sessionCount);

            _sessionNo = 1;
        }

        public static byte[] Xor(byte[] hash1, byte[] hash2)
        {
            byte[] result = new byte[HashSize];
            
            for (int i = 0; i < HashSize; i++)
                result[i] = (byte)(hash1[i] ^ hash2[i]);

            return result;
        }

        public byte[] GetNewSessionKey()
        {
            (byte[] hash1, byte[] hash2) = _passwordData.GetSessionHashes(_sessionNo);
            _sessionNo++;

            byte[] xorHash = Xor(hash1, hash2);

            return xorHash.Take(KeySize).ToArray();
        }
    }
}
