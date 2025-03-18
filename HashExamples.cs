using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnowflakeIdGen
{
    public class HashExamples
    {
        // MurmurHash (32-bit version) from a string input
        public static uint MurmurHash(string input)
        {
            // Using a simple implementation for MurmurHash (32-bit)
            uint seed = 0x1234ABCD;
            uint hash = seed;

            foreach (char c in input)
            {
                hash ^= (uint)c;
                hash *= 0x5bd1e995;
                hash ^= hash >> 15;
            }

            return hash;
        }

        // MD5 Hash
        public static byte[] Md5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }

        //public static void Main()
        //{
        //    string input = "Hello, World!";

        //    // MurmurHash
        //    uint murmurHashValue = MurmurHash(input);
        //    string murmurHashBase62 = Base62Converter.ToBase62(murmurHashValue);
        //    Console.WriteLine($"MurmurHash (32-bit) Original: {murmurHashValue}");
        //    Console.WriteLine($"MurmurHash (32-bit) Base62: {murmurHashBase62}");

        //    // MD5 Hash
        //    byte[] md5HashValue = Md5Hash(input);
        //    string md5HashBase62 = Base62Converter.ToBase62(md5HashValue);
        //    Console.WriteLine($"MD5 Original: {BitConverter.ToString(md5HashValue).Replace("-", "")}");
        //    Console.WriteLine($"MD5 Base62: {md5HashBase62}");
        //}
    }
}
