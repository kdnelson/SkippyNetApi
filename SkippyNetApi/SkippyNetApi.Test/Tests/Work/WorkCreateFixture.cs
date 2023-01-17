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
    public class WorkCreateFixture : IWorkCreateFixture
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IWorkRequestHelper _workRequestHelper;

        public WorkCreateFixture(IUrlHelper urlHelper,
            IWorkRequestHelper workRequestHelper)
        {
            _urlHelper = urlHelper;
            _workRequestHelper = workRequestHelper;
        }

        public async Task<List<TestLogDto>> RunCreateAsync(TestType testType)
        {
            var testLogList = new List<TestLogDto>
            {
                await CreateFixtureAsync("CreateFixtureAsync", testType)
            };

            return testLogList;
        }

        private async Task<TestLogDto> CreateFixtureAsync(string testId, TestType testType)
        {
            const string methodName = nameof(CreateFixtureAsync);
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
                var workCreateUrl = _urlHelper.GetApiUrl(ApiRequestType.WorkCreateUrl);

                var workCreateRequest = BuildWorkCreateRequestDto();

                var workCreateResponse = await _workRequestHelper.CreateAsync(workCreateUrl, workCreateRequest);
                if (workCreateResponse?.Result != null)
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

        private WorkCreateRequestDto BuildWorkCreateRequestDto() 
        {
            return new WorkCreateRequestDto()
            {
                WorkId = 1,
                WorkName = "TestWorkLoad",
                IsCompleted = false,
                IsActive = true
            };
        }
    }
}
