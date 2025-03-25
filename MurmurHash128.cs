using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowflakeIdGen
{
    using System;
	using System.Numerics;

    public static class MurmurHash128
    {
        // MurmurHash3 128-bit implementation
        public static (ulong, ulong) MurmurHash3_x64_128(byte[] data, uint seed = 0)
        {
            const ulong c1 = 0x87c37b91114253d5;
            const ulong c2 = 0x4cf5ad432745937f;

            ulong h1 = 0;
            ulong h2 = 0;

            int length = data.Length;
            int index = 0;

            // Process the body in chunks of 8 bytes (64 bits)
            while (length >= 8)
            {
                ulong k1 = BitConverter.ToUInt64(data, index);
                index += 8;
                length -= 8;

                k1 *= c1;
                k1 = RotateLeft(k1, 31);
                k1 *= c2;

                h1 ^= k1;
                h1 = RotateLeft(h1, 27);
                h1 += h2;
                h1 = h1 * 5 + 0x52dce729;

                ulong k2 = BitConverter.ToUInt64(data, index);
                index += 8;
                length -= 8;

                k2 *= c2;
                k2 = RotateLeft(k2, 33);
                k2 *= c1;

                h2 ^= k2;
                h2 = RotateLeft(h2, 31);
                h2 += h1;
                h2 = h2 * 5 + 0x38495ab5;
            }

            // Process any remaining bytes (less than 8)
            if (length > 0)
            {
                ulong k1 = 0;
                for (int i = length - 1; i >= 0; i--)
                {
                    k1 |= (ulong)data[index + i] << (i * 8);
                }

                k1 *= c1;
                k1 = RotateLeft(k1, 31);
                k1 *= c2;

                h1 ^= k1;
            }

            // Finalization
            h1 ^= (ulong)data.Length;
            h2 ^= (ulong)data.Length;

            h1 += h2;
            h2 += h1;

            h1 = FMix(h1);
            h2 = FMix(h2);

            h1 += h2;

            return (h1, h2);
        }

        // Rotates bits to the left (for MurmurHash internals)
        private static ulong RotateLeft(ulong x, int r)
        {
            return (x << r) | (x >> (64 - r));
        }

        // Finalization mix (for MurmurHash internals)
        private static ulong FMix(ulong h)
        {
            h ^= h >> 33;
            h *= 0xff51afd7ed558ccd;
            h ^= h >> 33;
            h *= 0xc4ceb9fe1a85ec53;
            h ^= h >> 33;

            return h;
        }

		static string base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		public static string ToBase62(ulong high, ulong low)
		{
			// Combine high and low into a single BigInteger (128-bit)
			BigInteger bigInt = ((BigInteger)high << 64) | low;

			// Encode to Base62
			StringBuilder sb = new StringBuilder();
			while (bigInt > 0)
			{
				bigInt = BigInteger.DivRem(bigInt, 62, out var remainder);
				sb.Insert(0, base62Chars[(int)remainder]);
			}

			return sb.Length > 0 ? sb.ToString() : "0";
		}


        // Example of usage
        //public static void Main(string[] args)
        //{
        //    string input = "Hello, World!";
        //    byte[] data = System.Text.Encoding.UTF8.GetBytes(input);

        //    // Generate 128-bit hash
        //    var (high, low) = MurmurHash3_x64_128(data);

        //    // Convert to Base62
        //    string base62Hash = ToBase62(high, low);

        //    Console.WriteLine($"Original Input: {input}");
        //    Console.WriteLine($"MurmurHash 128-bit (Base62): {base62Hash}");
        //}
    }

}
