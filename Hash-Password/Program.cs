using utils;

namespace Hash_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Password Manager");

            PasswordManager.setPassword("testuser", "testpassword");

            bool result = PasswordManager.checkPassword("testuser", "testpassword");

            Console.WriteLine("password matches: {0}", result);

            result = PasswordManager.checkPassword("testuser", "wrong password");

            Console.WriteLine("password matches: {0}", result);

            Console.ReadKey();  


        }
    }
}