using System;

namespace Lab0x03
{
    class Program
    {
        static void Main(string[] args)
        {
            var sandbox = new ThreeSumSandbox();

            //if (sandbox.VerificationTests())
            //{
             //   Console.WriteLine("Tests passed!");
                sandbox.RunTimeTests();
           // }
            //else
           // {
            //    Console.WriteLine("Something went wrong in the verification tests... :(");
           // }
            
        }
    }
}
