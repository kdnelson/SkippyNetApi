using SkippyNetApi.Dto.Request.Work;
using SkippyNetApi.Dto.Response.Work;
using SkippyNetApi.Enums;
using SkippyNetApi.Helpers.Common;
using SkippyNetApi.Interfaces.Work;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Helpers.Work
{
    public class WorkHelper : IWorkHelper
    {
        private const string ClassName = nameof(WorkHelper);
        private readonly IWorkRepository _workRepository;
        private readonly IWorkMappingHelper _workMappingHelper;
        private readonly IWorkValidationHelper _workValidationHelper;

        public WorkHelper(IWorkRepository workRepository,
            IWorkMappingHelper workMappingHelper,
            IWorkValidationHelper workValidationHelper)
        {
            _workRepository = workRepository;
            _workMappingHelper = workMappingHelper;
            _workValidationHelper = workValidationHelper;
        }

        public async Task<ResponseDto> CreateAsync(WorkCreateRequestDto request)
        {
            const string methodName = ClassName + "." + nameof(CreateAsync);
            var response = new ResponseDto();

            var mappingResponse = _workMappingHelper.MapCreateToEntity(request);
            if (mappingResponse.Success)
            {
                var createResponse = await _workRepository.CreateAsync(mappingResponse.Result);
                if (createResponse.Success)
                {
                    response.SetSuccess();
                }
                else
                {
                    response.SetError(createResponse.ErrorId, createResponse.Message, methodName, createResponse.ResponseType);
                }
            }
            else
            {
                response.SetError(mappingResponse.ErrorId, mappingResponse.Message, methodName, mappingResponse.ResponseType);
            }

            return response;
        }

        public async Task<ResponseDto> DeleteAsync(int id)
        {
            const string methodName = ClassName + "." + nameof(DeleteAsync);
            var response = new ResponseDto();

            var getResponse = await _workRepository.GetAsync(id);
            if (getResponse.Success)
            {
                if (getResponse.Result != null)
                {
                    var mappingResponse = _workMappingHelper.MapDeleteToEntity(new WorkDeleteRequestDto()
                    {
                        WorkId = id
                    });

                    if (mappingResponse.Success)
                    {
                        var deleteResponse = await _workRepository.DeleteAsync(mappingResponse.Result.WorkId);
                        if (deleteResponse.Success)
                        {
                            response.SetSuccess();
                        }
                        else
                        {
                            response.SetError(deleteResponse.ErrorId, deleteResponse.Message, methodName,
                                deleteResponse.ResponseType);
                        }
                    }
                    else
                    {
                        response.SetError(mappingResponse.ErrorId, mappingResponse.Message, methodName,
                            mappingResponse.ResponseType);
                    }
                }
                else
                {
                    response.SetError(getResponse.ErrorId, ErrorMessage.RecordNotFound, methodName, getResponse.ResponseType);
                }
            }
            else
            {
                response.SetError(getResponse.ErrorId, getResponse.Message, methodName, getResponse.ResponseType);
            }

            return response;
        }

        public async Task<ResponseDto<WorkResponseDto>> GetAsync(int id)
        {
            const string methodName = ClassName + "." + nameof(GetAsync);
            var response = new ResponseDto<WorkResponseDto>();

            var getResponse = await _workRepository.GetAsync(id);
            if (getResponse.Success)
            {
                var mappingResponse = _workMappingHelper.MapToResponseDto(getResponse.Result);
                if (mappingResponse.Success)
                {
                    response.Result = mappingResponse.Result;
                    response.SetSuccess();
                }
                else
                {
                    response.SetError(mappingResponse.ErrorId, mappingResponse.Message, methodName, mappingResponse.ResponseType);
                }
            }
            else
            {
                response.SetError(getResponse.ErrorId, getResponse.Message, methodName, getResponse.ResponseType);
            }

            return response;
        }

        public async Task<ResponseDto<List<WorkResponseDto>>> SearchAsync(WorkSearchRequestDto request)
        {
            const string methodName = ClassName + "." + nameof(SearchAsync);
            var response = new ResponseDto<List<WorkResponseDto>>();

            var searchResponse = await _workRepository.SearchAsync(request);
            if (searchResponse.Success)
            {
                var mappingResponse = _workMappingHelper.MapToResponseListDto(searchResponse.Result);
                if (mappingResponse.Success)
                {
                    response.Result = mappingResponse.Result;
                    response.SetSuccess();
                }
                else
                {
                    response.SetError(mappingResponse.ErrorId, mappingResponse.Message, methodName, mappingResponse.ResponseType);
                }
            }
            else
            {
                response.SetError(searchResponse.ErrorId, searchResponse.Message, methodName, searchResponse.ResponseType);
            }

            return response;
        }

        public async Task<ResponseDto> UpdateAsync(WorkUpdateRequestDto request)
        {
            const string methodName = ClassName + "." + nameof(UpdateAsync);
            var response = new ResponseDto();

            var getResponse = await _workRepository.GetAsync(request.WorkId);
            if (getResponse.Success)
            {
                var mappingResponse = _workMappingHelper.MapUpdateToEntity(request);
                if (mappingResponse.Success)
                {
                    var insertResponse = await _workRepository.UpdateAsync(mappingResponse.Result);
                    if (insertResponse.Success)
                    {
                        response.SetSuccess();
                    }
                    else
                    {
                        response.SetError(insertResponse.ErrorId, insertResponse.Message, methodName,
                            insertResponse.ResponseType);
                    }
                }
                else
                {
                    response.SetError(mappingResponse.ErrorId, mappingResponse.Message, methodName,
                        mappingResponse.ResponseType);
                }
            }
            else
            {
                response.SetError(getResponse.ErrorId, getResponse.Message, methodName, getResponse.ResponseType);
            }

            return response;
        }

        public ResponseDto IsRequestValidAsync(object request)
        {
            return _workValidationHelper.ValidateAsync(request);
        }
    }
}
