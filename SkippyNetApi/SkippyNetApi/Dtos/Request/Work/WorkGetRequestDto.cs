using SkippyNetApi.Interfaces.Common;

namespace SkippyNetApi.Dto.Request.Work
{
    public class WorkGetRequestDto : IRequest
    {
        public int WorkId { get; set; }
    }
}
