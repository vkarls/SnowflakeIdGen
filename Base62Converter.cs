using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnowflakeIdGen
{
    public class Base62Converter
    {
        private static readonly string Base62Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly int Base62Length = Base62Chars.Length;

        public static string ToBase62(long num)
        {
            StringBuilder base62 = new StringBuilder();

            while (num > 0)
            {
                base62.Insert(0, Base62Chars[(int)(num % Base62Length)]);
                num /= Base62Length;
            }

            return base62.ToString();
        }

        public static long FromBase62(string base62)
        {
            long num = 0;
            foreach (char c in base62)
            {
                num *= Base62Length;
                num += Base62Chars.IndexOf(c);
            }
            return num;
        }

        public static string ToBase62(byte[] byteArray)
        {
            StringBuilder base62 = new StringBuilder();

            foreach (byte b in byteArray)
            {
                base62.Append(ToBase62(b));
            }

            return base62.ToString();
        }

        public static byte[] FromBase62ToBytes(string base62)
        {
            List<byte> byteList = new List<byte>();

            for (int i = 0; i < base62.Length; i += 2)
            {
                string base62Sub = base62.Substring(i, Math.Min(base62.Length - i, 2));
                byte byteValue = (byte)FromBase62(base62Sub);
                byteList.Add(byteValue);
            }

            return byteList.ToArray();
        }
    }
}
