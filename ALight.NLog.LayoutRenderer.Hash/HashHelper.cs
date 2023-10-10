using Grassfed.MurmurHash3;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ALight.NLog.LayoutRenderer.Hash
{
    public static class HashHelper
    {
        private static ConcurrentQueue<MurmurHash3> murmurs = new ConcurrentQueue<MurmurHash3>();

        public static string HashSHA256(string value)
        {
            if (String.IsNullOrEmpty(value)) return String.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(GetBytes(value));
                return Convert.ToBase64String(bytes);
            }
        }

        public static string HashMurmur(string value)
        {
            if (String.IsNullOrEmpty(value)) return String.Empty;

            var murmur = new MurmurHash3();
            var bytes = murmur.ComputeHash(GetBytes(value));
            var hash = Convert.ToBase64String(bytes);

            return hash;
        }

        private static byte[] GetBytes(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }
    }
}
