using System.Collections.Generic;
using System.Threading.Tasks;
using SkippyNetApi.Dto.Request.Work;
using SkippyNetApi.Dto.Response.Work;
using SkippyNetApi.Helpers.Common;

namespace SkippyNetApi.Interfaces.Work
{
    public interface IWorkHelper
    {
        Task<ResponseDto> CreateAsync(WorkCreateRequestDto request);
        Task<ResponseDto> DeleteAsync(int id);
        Task<ResponseDto<WorkResponseDto>> GetAsync(int id);
        Task<ResponseDto<List<WorkResponseDto>>> SearchAsync(WorkSearchRequestDto request);
        Task<ResponseDto> UpdateAsync(WorkUpdateRequestDto request);
        ResponseDto IsRequestValidAsync(object request);
    }
}
