using SkippyNetApi.Test.Dto.Request.Work;
using SkippyNetApi.Test.Dtos.Classes.Common;
using SkippyNetApi.Test.Enums;
using SkippyNetApi.Test.Interfaces.Common;
using SkippyNetApi.Test.Interfaces.Work;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Test.Tests.Work
{
    public class WorkDeleteFixture : IWorkDeleteFixture
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IWorkRequestHelper _workRequestHelper;

        public WorkDeleteFixture(IUrlHelper urlHelper,
            IWorkRequestHelper workRequestHelper)
        {
            _urlHelper = urlHelper;
            _workRequestHelper = workRequestHelper;
        }

        public async Task<List<TestLogDto>> RunDeleteAsync(TestType testType)
        {
            var testLogList = new List<TestLogDto>
            {
                await DeleteFixtureAsync("DeleteFixtureAsync", testType)
            };

            return testLogList;
        }

        private async Task<TestLogDto> DeleteFixtureAsync(string testId, TestType testType)
        {
            const string methodName = nameof(DeleteFixtureAsync);
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
                var workCreateUrl = _urlHelper.GetApiUrl(ApiRequestType.WorkDeleteUrl);

                var workDeleteRequest = new WorkDeleteRequestDto() { WorkId = 1 };

                var workCreateResponse = await _workRequestHelper.DeleteAsync(workCreateUrl, workDeleteRequest);
                if (workCreateResponse != null)
                {
                    if (workCreateResponse.Success == true)
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
