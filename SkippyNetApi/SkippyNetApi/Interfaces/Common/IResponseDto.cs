using SkippyNetApi.Enums;
using SkippyNetApi.Helpers.Common;

namespace SkippyNetApi.Interfaces.Common
{
    public interface IResponseDto<TResult>
    {
        bool Success { get; set; }
        ResponseType ResponseType { get; set; }
        string Message { get; set; }
        string MethodName { get; set; }
        long ErrorId { get; set; }
        IResponseValidationDto Validation { get; set; }
        TResult Result { get; set; }
        int TotalRecordCount { get; set; }
        void SetSuccess(ResponseType responseType = ResponseType.Ok);
        void SetError(ResponseDto responseDto);
        void SetError(long errorId, string message, string methodName);
        void SetError(long errorId, string message, string methodName, ResponseType responseType);
        void SetError(long errorId, string message, string methodName, ResponseType responseType, ResponseValidationDto responseValidationDto); ResponseDto<T> CastToNewResultType<T>();
        ResponseDto CastToNewResponseDto();
    }

    public interface IResponseDto
    {
        bool Success { get; set; }
        ResponseType ResponseType { get; set; }
        string Message { get; set; }
        string MethodName { get; set; }
        long ErrorId { get; set; }
        IResponseValidationDto Validation { get; set; }
        void SetSuccess(ResponseType responseType = ResponseType.Ok);
        void SetError(ResponseDto responseDto);
        void SetError(long errorId, string message, string methodName);
        void SetError(long errorId, string message, string methodName, ResponseType responseType);
        void SetError(long errorId, string message, string methodName, ResponseType responseType, ResponseValidationDto responseValidationDto);
        ResponseDto<T> CastToNewResultType<T>();
    }
}
