using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_OTP
{
    internal class TimeBasedOnetimePassword
    {
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
                return "123456";
            }
        }
    }
}
