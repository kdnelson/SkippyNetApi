namespace SkippyNetApi.Dto.Response.Work
{
    public class WorkResponseDto
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
    }
}