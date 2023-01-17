using SkippyNetApi.Helpers.Common;

namespace SkippyNetApi.Interfaces.Work
{
    public interface IWorkValidationHelper
    {
        ResponseDto ValidateAsync(object request);
    }
}
