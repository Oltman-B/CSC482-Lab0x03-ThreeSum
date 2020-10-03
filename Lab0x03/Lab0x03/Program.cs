using System;

namespace Lab0x03
{
    class Program
    {
        static void Main(string[] args)
        {
            var sandbox = new ThreeSumSandbox();

            Console.WriteLine($"Tests passed? {sandbox.VerificationTests()}");
        }
    }
}
