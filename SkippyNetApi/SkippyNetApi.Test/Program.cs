using SkippyNetApi.Test.Enums;
using SkippyNetApi.Test.Helpers.Common;
using SkippyNetApi.Test.Interfaces.Common;
using System;

namespace SkippyNetApi.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SkippyNet - Api Tests";
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press 'm' for menu or 'q' to quit.");
            Console.WriteLine();

            ServiceLocatorHelper.Initialize();
            var testController = ServiceLocatorHelper.Resolve<ITestController>();

            while (true)
            {
                var line = Console.ReadLine();
                if (line == null) continue;

                if (line.ToLower().Equals("m"))
                {
                    Console.WriteLine("Press '0' to run All Api tests.");
                    Console.WriteLine("Press '1' to run Work Api tests.");
                    Console.WriteLine();
                }

                if (line.ToLower().Equals("0"))
                {
                    Console.WriteLine("Running All Api Tests...");
                    Console.WriteLine();
                    testController.Run(TestType.All);
                }

                if (line.ToLower().Equals("1"))
                {
                    Console.WriteLine("Running Work Api Tests...");
                    Console.WriteLine();
                    testController.Run(TestType.Work);
                }

                if (line.ToLower().Equals("q")) break;
            }
        }
    }
}
