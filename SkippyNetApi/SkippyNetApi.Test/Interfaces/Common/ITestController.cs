using SkippyNetApi.Test.Enums;

namespace SkippyNetApi.Test.Interfaces.Common
{
    public interface ITestController
    {
        void Run(TestType testType);
    }
}
