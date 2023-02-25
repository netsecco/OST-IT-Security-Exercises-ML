using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utils;

namespace Hash_Password
{
    internal static class PasswordManager
    {
        private static utils.DataStore s_DataStore = new DataStore(@"../../../passwd");
        public static void setPassword (string username, string password)
        {
            s_DataStore.Data[username] = password;  
        }

        public static bool checkPassword (string username, string password)
        {
            string l_password;

            if (s_DataStore.Data.TryGetValue(username, out l_password))
            {
                return l_password == password;
            }
            {
                return false;  // username not found
            }
        }

    }
}
