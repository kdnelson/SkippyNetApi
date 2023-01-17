using Newtonsoft.Json;
using SkippyNetApi.Test.Dtos.Classes.Common;
using SkippyNetApi.Test.Enums;
using SkippyNetApi.Test.Interfaces.Common;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SkippyNetApi.Test.Helpers.Common
{
    public class RequestHelper : IRequestHelper
    {
        public async Task<ResponseDto> CallServiceAsync(string url, IRequest request)
        {
            const string methodName = nameof(CallServiceAsync);
            var response = new ResponseDto();

            try
            {
                var httpClient = new HttpClient();

                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonObject = JsonConvert.SerializeObject(request);

                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                var uri = new Uri(url);

                var serviceResponse = await httpClient.PostAsync(uri, content);

                var result = await serviceResponse.Content.ReadAsStringAsync();

                var serviceResponseDto = JsonConvert.DeserializeObject<ResponseDto>(result);

                response = serviceResponseDto;

            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName, ResponseType.Error);
            }

            return response;
        }
        public async Task<ResponseDto<T>> CallServiceAsync<T>(string url, IRequest request)
        {
            const string methodName = nameof(CallServiceAsync);
            var response = new ResponseDto<T>();

            try
            {
                var httpClient = new HttpClient();

                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var jsonObject = JsonConvert.SerializeObject(request);

                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                var uri = new Uri(url);

                var serviceResponse = await httpClient.PostAsync(uri, content);

                var result = await serviceResponse.Content.ReadAsStringAsync();

                var serviceResponseDto = JsonConvert.DeserializeObject<ResponseDto<T>>(result);

                response = serviceResponseDto;
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName, ResponseType.Error);
            }

            return response;

        }
    }
}