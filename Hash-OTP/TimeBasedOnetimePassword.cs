using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Hash_OTP
{
    internal class TimeBasedOnetimePassword
    {
        private const long INTERVAL = 30;
        public TimeBasedOnetimePassword(string key, int lenght)
        {
            Key = key;
            Lenght = lenght;
        }

        public string Key { set; get; }

        public int Lenght { get; set; }

        public string Otp
        {
            get
            {
                // Get the offset from current time in UTC time
                DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
                // Get the unix timestamp in seconds
                long unixTime = dto.ToUnixTimeSeconds();
                Debug.WriteLine("unix time: {0}", unixTime);
                // timePart changes every INTERVAL seconds
                long timePart = unixTime / INTERVAL;
                Debug.WriteLine("timePart: {0}", timePart);
                // concat timePart and Key
                string codeBase = timePart.ToString() + Key;
                Debug.WriteLine("codeBase: {0}", codeBase);
                // convert string to bayte array
                byte[] codeBaseByteArray = System.Text.Encoding.UTF8.GetBytes(codeBase);
                // create SHA256 hash from codeBaseByteArray
                byte[] hash = SHA256.Create().ComputeHash(codeBaseByteArray);
                Debug.WriteLine("hash lenght: {0}; hash: {1}", hash.Length, utils.Helpers.ByteArrayToHexString(hash));
                // convert the first 4 bytes of the hash to UInt32
                UInt32 codeUInt32 = BitConverter.ToUInt32(hash, 0);
                Debug.WriteLine("codeUInt32: {0}", codeUInt32);
                // we need Lenght digits code
                UInt32 code = codeUInt32 % (UInt32)Math.Pow(10, Lenght);
                Debug.WriteLine("code: {0}", code);

                return code.ToString("D" + Lenght.ToString());
            }
        }
    }
}
