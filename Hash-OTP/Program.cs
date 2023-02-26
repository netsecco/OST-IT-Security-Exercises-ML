namespace Hash_OTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("time based One Time Password");
            TimeBasedOnetimePassword tbotp = new TimeBasedOnetimePassword("this is a random key", 6);
            
            while (true)
            { 
                Console.WriteLine("One Time Password is {0} at {1}", tbotp.Otp, DateTime.Now.ToLocalTime().ToString());
                Thread.Sleep(10000);
            }

        }
    }
}