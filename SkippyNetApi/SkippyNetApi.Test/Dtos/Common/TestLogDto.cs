using System;

namespace SkippyNetApi.Test.Dtos.Classes.Common
{
    public class TestLogDto
    {
        public string TestId { get; set; }
        public bool Passed { get; set; }
        public string TestType { get; set; }

        public DateTime ErrorDateUtc { get; set; }
        public string MethodName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorMethodName { get; set; }
    }
}
