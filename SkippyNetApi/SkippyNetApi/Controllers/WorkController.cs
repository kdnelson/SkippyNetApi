using Microsoft.AspNetCore.Mvc;
using SkippyNetApi.Dto.Request.Work;
using SkippyNetApi.Dto.Response.Work;
using SkippyNetApi.Helpers.Common;
using SkippyNetApi.Interfaces.Work;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IWorkHelper _workHelper;

        public WorkController(IWorkHelper workHelper)
        {
            _workHelper = workHelper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ResponseDto> Create([FromBody] WorkCreateRequestDto request)
        {
            var checkRequestResponse = _workHelper.IsRequestValidAsync(request);
            if (!checkRequestResponse.Success)
            {
                return checkRequestResponse;
            }

            return await _workHelper.CreateAsync(request);
        }

        [HttpPost]
        [Route("get")]
        public async Task<ResponseDto<WorkResponseDto>> Get([FromBody] WorkGetRequestDto request)
        {
            var checkRequestResponse = _workHelper.IsRequestValidAsync(request);
            if (!checkRequestResponse.Success)
            {
                return checkRequestResponse.CastToNewResultType<WorkResponseDto>();
            }

            return await _workHelper.GetAsync(request.WorkId);
        }

        [HttpPost]
        [Route("search")]
        public async Task<ResponseDto<List<WorkResponseDto>>> Search([FromBody] WorkSearchRequestDto request)
        {
            var checkRequestResponse = _workHelper.IsRequestValidAsync(request);
            if (!checkRequestResponse.Success)
            {
                return checkRequestResponse.CastToNewResultType<List<WorkResponseDto>>();
            }

            return await _workHelper.SearchAsync(request);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ResponseDto> Update([FromBody] WorkUpdateRequestDto request)
        {
            var checkRequestResponse = _workHelper.IsRequestValidAsync(request);
            if (!checkRequestResponse.Success)
            {
                return checkRequestResponse;
            }

            return await _workHelper.UpdateAsync(request);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ResponseDto> Delete([FromBody] WorkDeleteRequestDto request)
        {
            var checkRequestResponse = _workHelper.IsRequestValidAsync(request);
            if (!checkRequestResponse.Success)
            {
                return checkRequestResponse;
            }

            return await _workHelper.DeleteAsync(request.WorkId);
        }
    }
}