using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utils;

namespace Hash_Password
{
    internal static class PasswordManager
    {
        private const string SALT = "HGT65Gj998Jugr";
        private const int NO_ITERATIONS = 100000;

        private static utils.DataStore s_DataStore = new DataStore(@"../../../passwd");
        public static void setPassword (string username, string password)
        {
            // salt password
            password += SALT; // append salt to password
            Debug.WriteLine("setPassword - salted password: {0}", password);
            string passwordHashAsHex = utils.Helpers.Sha256(password);
            for (int i = 0; i < NO_ITERATIONS; i++)
            {
                passwordHashAsHex = utils.Helpers.Sha256(passwordHashAsHex);
            }
            Debug.WriteLine("setPassword - hash of password: {0} for user {1}", passwordHashAsHex, username);
            s_DataStore.Data[username] = passwordHashAsHex;
        }

        public static bool checkPassword (string username, string password)
        {
            string l_passwordHash;

            // salt password
            password += SALT; // append salt to password
            Debug.WriteLine("checkPassword - salted password: {0}", password);
            string passwordHashAsHex = utils.Helpers.Sha256(password);
            for (int i = 0; i < NO_ITERATIONS; i++)
            {
                passwordHashAsHex = utils.Helpers.Sha256(passwordHashAsHex);
            }
            Debug.WriteLine("checkPassword - hash of password: {0} for user {1}", passwordHashAsHex, username);

            if (s_DataStore.Data.TryGetValue(username, out l_passwordHash))
            {
                return l_passwordHash == passwordHashAsHex;
            }
            {
                return false;  // username not found
            }
        }

    }
}
