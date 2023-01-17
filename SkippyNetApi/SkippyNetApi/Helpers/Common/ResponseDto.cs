using System.Collections.Generic;
using SkippyNetApi.Enums;
using SkippyNetApi.Interfaces.Common;

namespace SkippyNetApi.Helpers.Common
{
    public class ResponseDto<TResult> : IResponseDto<TResult>
    {
        public ResponseDto()
        {
            Success = false;
            ResponseType = ResponseType.Error;
            Validation = new ResponseValidationDto();
            Message = string.Empty;
            MethodName = string.Empty;
        }

        public bool Success { get; set; }
        public ResponseType ResponseType { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public long ErrorId { get; set; }
        public IResponseValidationDto Validation { get; set; }
        public TResult Result { get; set; }
        public int TotalRecordCount { get; set; }

        public void SetSuccess(ResponseType responseType = ResponseType.Ok)
        {
            Success = true;
            ResponseType = responseType;
        }

        public void SetError(ResponseDto responseDto)
        {
            Success = false;
            ErrorId = responseDto.ErrorId;
            ResponseType = responseDto.ResponseType;
            Message = responseDto.Message;
            MethodName = responseDto.MethodName;
            Validation = responseDto.Validation;
        }

        public void SetError(int v, long errorId, string message, string methodName)
        {
            Success = false;
            ErrorId = errorId;
            ResponseType = ResponseType.Error;
            Message = message;
            MethodName = methodName;
        }

        public void SetError(long errorId, string message, string methodName, ResponseType responseType)
        {
            Success = false;
            ErrorId = errorId;
            ResponseType = responseType;
            Message = message;
            MethodName = methodName;
        }

        public void SetError(long errorId, string message, string methodName, ResponseType responseType, ResponseValidationDto responseValidationDto)
        {
            Success = false;
            ErrorId = errorId;
            ResponseType = responseType;
            Message = message;
            MethodName = methodName;
            Validation = responseValidationDto;
        }

        public ResponseDto<T> CastToNewResultType<T>()
        {
            var response = new ResponseDto<T>
            {
                Success = this.Success,
                ErrorId = this.ErrorId,
                Message = this.Message,
                MethodName = this.MethodName,
                ResponseType = this.ResponseType,
                Validation = this.Validation
            };

            return response;
        }

        public ResponseDto CastToNewResponseDto()
        {
            var response = new ResponseDto
            {
                Success = this.Success,
                ErrorId = this.ErrorId,
                Message = this.Message,
                MethodName = this.MethodName,
                ResponseType = this.ResponseType,
                Validation = this.Validation
            };

            return response;
        }

        public void SetError(long errorId, string message, string methodName)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ResponseDto : IResponseDto
    {
        public ResponseDto()
        {
            Success = false;
            ResponseType = ResponseType.Error;
            Validation = new ResponseValidationDto();
        }

        public bool Success { get; set; }
        public ResponseType ResponseType { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }

        public long ErrorId { get; set; }
        public IResponseValidationDto Validation { get; set; }

        public void SetSuccess(ResponseType responseType = ResponseType.Ok)
        {
            Success = true;
            ResponseType = responseType;
        }

        public void SetError(ResponseDto responseDto)
        {
            Success = false;
            ErrorId = responseDto.ErrorId;
            ResponseType = responseDto.ResponseType;
            Message = responseDto.Message;
            MethodName = responseDto.MethodName;
            Validation = responseDto.Validation;
        }

        public void SetError(long errorId, string message, string methodName)
        {
            Success = false;
            ErrorId = errorId;
            ResponseType = ResponseType.Error;
            Message = message;
            MethodName = methodName;
        }

        public void SetError(long errorId, string message, string methodName, ResponseType responseType)
        {
            Success = false;
            ErrorId = errorId;
            ResponseType = responseType;
            Message = message;
            MethodName = methodName;
        }

        public void SetError(long errorId, string message, string methodName, ResponseType responseType, ResponseValidationDto responseValidationDto)
        {
            Success = false;
            ErrorId = errorId;
            ResponseType = responseType;
            Message = message;
            MethodName = methodName;
            Validation = responseValidationDto;
        }

        public ResponseDto<T> CastToNewResultType<T>()
        {
            var response = new ResponseDto<T>
            {
                Success = this.Success,
                ErrorId = this.ErrorId,
                Message = this.Message,
                MethodName = this.MethodName,
                ResponseType = this.ResponseType,
                Validation = this.Validation
            };

            return response;
        }

    }

    public class ResponseValidationDto : IResponseValidationDto
    {
        public List<InValidField> InvalidFields { get; set; }

        public ResponseValidationDto()
        {
            InvalidFields = new List<InValidField>();
        }

        public class InValidField
        {
            public string FieldName { get; set; }
            public string Message { get; set; }
        }
    }
}