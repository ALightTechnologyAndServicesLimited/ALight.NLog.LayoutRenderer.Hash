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
        private static ConcurrentQueue<SHA256> sha256s = new ConcurrentQueue<SHA256>();

        public static string HashSHA256(string value, bool objectPool = true)
        {
            if (String.IsNullOrEmpty(value)) return String.Empty;

            SHA256 sha256Hash = GetSHA256(objectPool);
            byte[] bytes = sha256Hash.ComputeHash(GetBytes(value));
            var retVal = Convert.ToBase64String(bytes);

            if (objectPool)
                ReturnSHA256(sha256Hash);

            return retVal;
        }

        public static string HashMurmur(string value, bool objectPool = false)
        {
            if (String.IsNullOrEmpty(value)) return String.Empty;

            var murmur = GetMurmur(objectPool);
            var bytes = murmur.ComputeHash(GetBytes(value));
            var hash = Convert.ToBase64String(bytes);

            if (objectPool)
                ReturnMurmur(murmur);

            return hash;
        }

        internal static void DisposeSHA256()
        {
            foreach (var sha256 in sha256s)
            {
                sha256.Dispose();
            }
        }

        private static byte[] GetBytes(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        private static void ReturnMurmur(MurmurHash3 murmur)
        {
            murmurs.Enqueue(murmur);
        }

        private static SHA256 GetSHA256(bool objectPool)
        {
            SHA256 sha256 = null;

            if (objectPool)
            {
                if (sha256s.TryDequeue(out sha256))
                {
                    return sha256;
                }
            }

            return SHA256.Create();
        }

        private static void ReturnSHA256(SHA256 sha256Hash)
        {
            sha256s.Enqueue(sha256Hash);
        }


        private static MurmurHash3 GetMurmur(bool objectPool)
        {
            if (objectPool)
            {
                MurmurHash3 murmur = null;
                if (murmurs.TryDequeue(out murmur))
                {
                    return murmur;
                }
            }

            return new MurmurHash3();
        }
    }
}
