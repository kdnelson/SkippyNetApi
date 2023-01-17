using SkippyNetApi.Test.Dtos.Classes.Common;
using SkippyNetApi.Test.Enums;
using SkippyNetApi.Test.Interfaces.Common;
using SkippyNetApi.Test.Interfaces.Work;
using System;
using System.Collections.Generic;

namespace SkippyNetApi.Test.Controllers
{
    public class TestController : ITestController
    {
        private const string ClassName = nameof(TestController);
        private readonly IWorkTestController _workTestController;

        public TestController(IWorkTestController workTestController) 
        {
            _workTestController = workTestController;
        }

        public async void Run(TestType testType)
        {
            const string methodName = ClassName + "." + nameof(Run);

            try
            {
                var testLogList = new List<TestLogDto>();

                if (testType == TestType.All)
                {
                    var workTests = await _workTestController.RunAsync(TestType.Work);
                    if (workTests != null)
                    {
                        testLogList.AddRange(workTests);
                    }
                }

                if (testType == TestType.Work)
                {
                    var workTests = await _workTestController.RunAsync(TestType.Work);
                    if (workTests != null)
                    {
                        testLogList.AddRange(workTests);
                    }
                }

                DisplayTestLogList(testLogList);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(methodName + " " + ex);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        private void DisplayTestLogList(List<TestLogDto> testLogList)
        {
            if (testLogList != null)
            {
                foreach (var test in testLogList)
                {
                    if (test.Passed)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(test.TestType + " - " + test.TestId);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(test.TestType + " - " + test.TestId + " " + test.ErrorMessage);
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
            }
        }
    }
}
