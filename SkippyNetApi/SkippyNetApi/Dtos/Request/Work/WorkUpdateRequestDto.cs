using SkippyNetApi.Interfaces.Common;

namespace SkippyNetApi.Dto.Request.Work
{
    public class WorkUpdateRequestDto : IRequest
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
    }
}