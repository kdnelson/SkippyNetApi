using System.ComponentModel.DataAnnotations;

namespace SkippyNetApi.DataAccess.Models
{
    public class Work
    {
        [Key]
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsActive { get; set; }
    }
}
