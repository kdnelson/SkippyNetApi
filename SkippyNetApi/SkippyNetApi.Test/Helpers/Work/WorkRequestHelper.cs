using SkippyNetApi.Test.Dto.Request.Work;
using SkippyNetApi.Test.Dto.Response.Work;
using SkippyNetApi.Test.Dtos.Classes.Common;
using SkippyNetApi.Test.Interfaces.Common;
using SkippyNetApi.Test.Interfaces.Work;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Test.Helpers.Work
{
    public class WorkRequestHelper : IWorkRequestHelper
    {
        private readonly IRequestHelper _requestHelper;

        public WorkRequestHelper(IRequestHelper requestHelper)
        {
            _requestHelper = requestHelper;
        }

        public async Task<ResponseDto<long>> CreateAsync(string url, WorkCreateRequestDto request)
        {
            return await _requestHelper.CallServiceAsync<long>(url, request);
        }

        public async Task<ResponseDto> DeleteAsync(string url, WorkDeleteRequestDto request)
        {
            return await _requestHelper.CallServiceAsync(url, request);
        }

        public async Task<ResponseDto<WorkResponseDto>> GetAsync(string url, WorkGetRequestDto request)
        {
            return await _requestHelper.CallServiceAsync<WorkResponseDto>(url, request);
        }

        public async Task<ResponseDto<List<WorkResponseDto>>> SearchAsync(string url, WorkSearchRequestDto request)
        {
            return await _requestHelper.CallServiceAsync<List<WorkResponseDto>>(url, request);
        }

        public async Task<ResponseDto<long>> UpdateAsync(string url, WorkUpdateRequestDto request)
        {
            return await _requestHelper.CallServiceAsync<long>(url, request);
        }
    }
}
