using System.Collections.Generic;
using SkippyNetApi.Dto.Request.Work;
using SkippyNetApi.Dto.Response.Work;
using SkippyNetApi.Helpers.Common;

namespace SkippyNetApi.Interfaces.Work
{
    public interface IWorkMappingHelper
    {
        ResponseDto<DataAccess.Models.Work> MapCreateToEntity(WorkCreateRequestDto request);
        ResponseDto<DataAccess.Models.Work> MapDeleteToEntity(WorkDeleteRequestDto request);
        ResponseDto<DataAccess.Models.Work> MapUpdateToEntity(WorkUpdateRequestDto request);
        ResponseDto<WorkResponseDto> MapToResponseDto(DataAccess.Models.Work request);
        ResponseDto<List<WorkResponseDto>> MapToResponseListDto(List<DataAccess.Models.Work> list);
    }
}
