namespace Hash_OTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("time based One Time Password");
            TimeBasedOnetimePassword tbotp = new TimeBasedOnetimePassword("this is a random key", 6);

            Console.WriteLine("One Time Password is {0}", tbotp.Otp);
        }
    }
}