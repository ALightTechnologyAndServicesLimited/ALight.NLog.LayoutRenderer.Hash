using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ALight.NLog.LayoutRenderer.Hash.Benchmarks
{
    [MemoryDiagnoser]
    public class BenchmarkHash
    {
        private int dataLength = 32;
        Random rand = new Random();
        private string value;

        [GlobalSetup]
        public void Setup()
        {
            var data = new byte[dataLength];
            rand.NextBytes(data);
            value = Convert.ToBase64String(data).Substring(0, dataLength);
        }

        [Benchmark]
        public void HashSHA256()
        {
            HashHelper.HashSHA256(value);
        }

        [Benchmark]
        public void HashMurmur()
        {
            HashHelper.HashMurmur(value);
        }
    }
}
