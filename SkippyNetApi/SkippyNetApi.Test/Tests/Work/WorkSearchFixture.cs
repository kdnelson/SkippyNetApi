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
    public class WorkSearchFixture : IWorkSearchFixture
    {
        private readonly IUrlHelper _urlHelper;
        private readonly IWorkRequestHelper _workRequestHelper;

        public WorkSearchFixture(IUrlHelper urlHelper,
            IWorkRequestHelper workRequestHelper)
        {
            _urlHelper = urlHelper;
            _workRequestHelper = workRequestHelper;
        }

        public async Task<List<TestLogDto>> RunSearchAsync(TestType testType)
        {
            var testLogList = new List<TestLogDto>
            {
                await SearchAllFixtureAsync("SearchAllFixtureAsync", testType),
                await SearchFilterFixtureAsync("SearchFilterFixtureAsync", testType)
            };

            return testLogList;
        }

        private async Task<TestLogDto> SearchAllFixtureAsync(string testId, TestType testType)
        {
            const string methodName = nameof(SearchAllFixtureAsync);
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
                var workSearchUrl = _urlHelper.GetApiUrl(ApiRequestType.WorkSearchUrl);

                var workSearchRequest = new WorkSearchRequestDto();

                var workSearchResponse = await _workRequestHelper.SearchAsync(workSearchUrl, workSearchRequest);
                if (workSearchResponse?.Result != null)
                {
                    if (workSearchResponse.Success == true)
                    {
                        if (workSearchResponse.Result.Count > 0)
                        {
                            if (workSearchResponse.Result[0].GetType() == typeof(WorkResponseDto))
                            {
                                logList.Passed = true;
                            }
                        }
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

        private async Task<TestLogDto> SearchFilterFixtureAsync(string testId, TestType testType)
        {
            const string methodName = nameof(SearchFilterFixtureAsync);
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
                var workSearchUrl = _urlHelper.GetApiUrl(ApiRequestType.WorkSearchUrl);

                var workSearchRequest = new WorkSearchRequestDto() { ItemCollection = { "TestWorkLoad" } };

                var workSearchResponse = await _workRequestHelper.SearchAsync(workSearchUrl, workSearchRequest);
                if (workSearchResponse?.Result != null)
                {
                    if (workSearchResponse.Success == true)
                    {
                        if (workSearchResponse.Result.Count > 0)
                        {
                            if (workSearchResponse.Result[0].GetType() == typeof(WorkResponseDto))
                            {
                                logList.Passed = true;
                            }
                        }
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
