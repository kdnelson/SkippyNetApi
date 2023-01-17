using System.Collections.Generic;
using SkippyNetApi.Helpers.Common;

namespace SkippyNetApi.Interfaces.Common
{
    public interface IResponseValidationDto
    {
        List<ResponseValidationDto.InValidField> InvalidFields { get; set; }
    }
}
