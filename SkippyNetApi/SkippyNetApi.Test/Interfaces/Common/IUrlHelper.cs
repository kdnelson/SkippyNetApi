using SkippyNetApi.Test.Enums;

namespace SkippyNetApi.Test.Interfaces.Common
{
    public interface IUrlHelper
    {
        string GetApiUrl(ApiRequestType urlRequest);
    }
}
