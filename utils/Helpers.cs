using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace utils
{
    public static class Helpers
    {
        public static string ByteArrayToHexString(byte[] ba, int start)
        {
            string hex = BitConverter.ToString(ba, start);
            return hex.Replace("-", "");
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            return ByteArrayToHexString(ba, 0);
        }

        public static byte[] Sha256(byte[] array)
        {
            var hashstring = new SHA256Managed();
            return hashstring.ComputeHash(array);
        }

        public static string Sha256(string text)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
            byte[] hash = Sha256(data);
            return ByteArrayToHexString(hash);
        }

    }
}
