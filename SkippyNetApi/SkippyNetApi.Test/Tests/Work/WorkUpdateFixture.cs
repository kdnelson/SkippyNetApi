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
    public class WorkUpdateFixture : IWorkUpdateFixture
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IWorkRequestHelper _workRequestHelper;

        public WorkUpdateFixture(IUrlHelper urlHelper,
            IWorkRequestHelper workRequestHelper)
        {
            _urlHelper = urlHelper;
            _workRequestHelper = workRequestHelper;
        }

        public async Task<List<TestLogDto>> RunUpdateAsync(TestType testType)
        {
            var testLogList = new List<TestLogDto>
            {
                await UpdateFixtureAsync("UpdateFixtureAsync", testType)
            };

            return testLogList;
        }

        private async Task<TestLogDto> UpdateFixtureAsync(string testId, TestType testType)
        {
            const string methodName = nameof(UpdateFixtureAsync);
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
                var workUpdateUrl = _urlHelper.GetApiUrl(ApiRequestType.WorkUpdateUrl);

                var workUpdateRequest = BuildWorkUpdateRequestDto();

                var workUpdateResponse = await _workRequestHelper.UpdateAsync(workUpdateUrl, workUpdateRequest);
                if (workUpdateResponse != null)
                {
                    if (workUpdateResponse.Success == true)
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

        private WorkUpdateRequestDto BuildWorkUpdateRequestDto()
        {
            return new WorkUpdateRequestDto()
            {
                WorkId = 1,
                WorkName = "TestWorkLoad",
                IsCompleted = true,
                IsActive = true
            };
        }
    }
}
