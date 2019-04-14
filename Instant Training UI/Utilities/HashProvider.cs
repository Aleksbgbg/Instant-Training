namespace Instant.Training.UI.Utilities
{
    using System;
    using System.Security.Cryptography;

    public class HashProvider : IHashProvider
    {
        public string Hash(byte[] contents)
        {
            using (MD5 md5Hasher = MD5.Create())
            {
                byte[] hashBytes = md5Hasher.ComputeHash(contents);
                return BitConverter.ToString(hashBytes);
            }
        }
    }
}