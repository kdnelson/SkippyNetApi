using SkippyNetApi.Test.Dto.Request.Work;
using SkippyNetApi.Test.Dto.Response.Work;
using SkippyNetApi.Test.Dtos.Classes.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Test.Interfaces.Work
{
    public interface IWorkRequestHelper
    {
        Task<ResponseDto<long>> CreateAsync(string url, WorkCreateRequestDto request);
        Task<ResponseDto> DeleteAsync(string url, WorkDeleteRequestDto request);
        Task<ResponseDto<WorkResponseDto>> GetAsync(string url, WorkGetRequestDto request);
        Task<ResponseDto<List<WorkResponseDto>>> SearchAsync(string url, WorkSearchRequestDto request);
        Task<ResponseDto<long>> UpdateAsync(string url, WorkUpdateRequestDto request);
    }
}