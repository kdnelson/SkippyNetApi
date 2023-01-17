using SkippyNetApi.Dto.Request.Work;
using SkippyNetApi.Dto.Response.Work;
using SkippyNetApi.Helpers.Common;
using SkippyNetApi.Interfaces.Work;
using System;
using System.Collections.Generic;

namespace SkippyNetApi.Helpers.Work
{
    public class WorkMappingHelper : IWorkMappingHelper
    {
        private const string ClassName = nameof(WorkMappingHelper);

        public ResponseDto<DataAccess.Models.Work> MapCreateToEntity(WorkCreateRequestDto request)
        {
            const string methodName = ClassName + "." + nameof(MapCreateToEntity);
            var response = new ResponseDto<DataAccess.Models.Work>();

            try
            {
                response.Result = new DataAccess.Models.Work
                {
                    WorkId = request.WorkId,
                    WorkName = request.WorkName,
                    IsCompleted = request.IsCompleted,
                    IsActive = request.IsActive
                };
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName);
            }

            return response;
        }

        public ResponseDto<DataAccess.Models.Work> MapDeleteToEntity(WorkDeleteRequestDto request)
        {
            const string methodName = ClassName + "." + nameof(MapDeleteToEntity);
            var response = new ResponseDto<DataAccess.Models.Work>();

            try
            {
                response.Result = new DataAccess.Models.Work
                {
                    WorkId = request.WorkId
                };
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName);
            }

            return response;
        }

        public ResponseDto<WorkResponseDto> MapToResponseDto(DataAccess.Models.Work request)
        {
            const string methodName = ClassName + "." + nameof(MapToResponseDto);
            var response = new ResponseDto<WorkResponseDto>();

            try
            {
                response.Result = new WorkResponseDto
                {
                    WorkId = request.WorkId,
                    WorkName = request.WorkName,
                    IsCompleted = request.IsCompleted,
                    IsActive = request.IsActive
                };
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName);
            }

            return response;
        }

        public ResponseDto<List<WorkResponseDto>> MapToResponseListDto(List<DataAccess.Models.Work> list)
        {
            const string methodName = ClassName + "." + nameof(MapToResponseListDto);
            var response = new ResponseDto<List<WorkResponseDto>>
            {
                Result = new List<WorkResponseDto>()
            };

            try
            {
                foreach (var item in list)
                {
                    response.Result.Add(new WorkResponseDto
                    {
                        WorkId = item.WorkId,
                        WorkName = item.WorkName,
                        IsCompleted = item.IsCompleted,
                        IsActive = item.IsActive
                    });
                }
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName);
            }

            return response;
        }

        public ResponseDto<DataAccess.Models.Work> MapUpdateToEntity(WorkUpdateRequestDto request)
        {
            const string methodName = ClassName + "." + nameof(MapUpdateToEntity);
            var response = new ResponseDto<DataAccess.Models.Work>();

            try
            {
                response.Result = new DataAccess.Models.Work
                {
                    WorkId = request.WorkId,
                    WorkName = request.WorkName,
                    IsCompleted = request.IsCompleted,
                    IsActive = request.IsActive
                };
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName);
            }

            return response;
        }
    }
}
