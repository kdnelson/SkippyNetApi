using SkippyNetApi.Test.Dto.Request.Work;
using SkippyNetApi.Test.Dto.Response.Work;
using SkippyNetApi.Test.Dtos.Classes.Common;
using SkippyNetApi.Test.Enums;
using SkippyNetApi.Test.Interfaces.Common;
using SkippyNetApi.Test.Interfaces.Work;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Test.Tests.Work
{
    public class WorkGetFixture : IWorkGetFixture
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IWorkRequestHelper _workRequestHelper;

        public WorkGetFixture(IUrlHelper urlHelper,
            IWorkRequestHelper workRequestHelper)
        {
            _urlHelper = urlHelper;
            _workRequestHelper = workRequestHelper;
        }

        public async Task<List<TestLogDto>> RunGetAsync(TestType testType)
        {
            var testLogList = new List<TestLogDto>
            {
                await GetFixtureAsync("GetFixtureAsync", testType)
            };

            return testLogList;
        }

        private async Task<TestLogDto> GetFixtureAsync(string testId, TestType testType)
        {
            const string methodName = nameof(GetFixtureAsync);
            var logList = new TestLogDto
            {
                Passed = false,
                TestId = testId,
                TestType = testType.ToString(),
                ErrorDateUtc = DateTime.Now,
                MethodName = methodName
            };

            try
            {
                var workGetUrl = _urlHelper.GetApiUrl(ApiRequestType.WorkGetUrl);

                var workGetRequest = new WorkGetRequestDto() { WorkId = 1 };

                var workGetResponse = await _workRequestHelper.GetAsync(workGetUrl, workGetRequest);
                if (workGetResponse?.Result != null)
                {
                    if (workGetResponse.Success == true &&
                        workGetResponse.Result.GetType() == typeof(WorkResponseDto))
                    {
                        logList.Passed = true;
                    }
                }
                else
                {
                    logList.ErrorMessage = ErrorMessage.NullResponse;
                }
            }
            catch (Exception ex)
            {
                logList.ErrorMessage = ex.Message;
            }

            return logList;
        }
    }
}
