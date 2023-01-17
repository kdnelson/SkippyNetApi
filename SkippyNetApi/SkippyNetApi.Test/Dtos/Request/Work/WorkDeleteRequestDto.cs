using SkippyNetApi.Test.Interfaces.Common;

namespace SkippyNetApi.Test.Dto.Request.Work
{
    public class WorkDeleteRequestDto : IRequest
    {
        public int WorkId { get; set; }
    }
}
