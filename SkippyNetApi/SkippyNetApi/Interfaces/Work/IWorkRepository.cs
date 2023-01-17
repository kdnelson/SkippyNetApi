using System.Collections.Generic;
using System.Threading.Tasks;
using SkippyNetApi.Dto.Request.Work;
using SkippyNetApi.Helpers.Common;

namespace SkippyNetApi.Interfaces.Work
{
    public interface IWorkRepository
    {
        Task<ResponseDto> CreateAsync(DataAccess.Models.Work model);
        Task<ResponseDto> DeleteAsync(int id);
        Task<ResponseDto<DataAccess.Models.Work>> GetAsync(int id);
        Task<ResponseDto<List<DataAccess.Models.Work>>> SearchAsync(WorkSearchRequestDto request);
        Task<ResponseDto> UpdateAsync(DataAccess.Models.Work model);
    }
}
