using SkippyNetApi.Interfaces.Common;

namespace SkippyNetApi.Dto.Request.Work
{
    public class WorkDeleteRequestDto : IRequest
    {
        public int WorkId { get; set; }
    }
}
