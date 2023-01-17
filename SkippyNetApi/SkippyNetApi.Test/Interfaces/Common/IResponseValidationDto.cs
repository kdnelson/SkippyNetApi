using SkippyNetApi.Test.Dtos.Classes.Common;
using System.Collections.Generic;

namespace SkippyNetApi.Test.Interfaces.Common
{
    public interface IResponseValidationDto
    {
        List<ResponseValidationDto.InValidField> InvalidFields { get; set; }
    }
}
