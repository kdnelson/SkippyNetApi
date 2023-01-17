using SkippyNetApi.Dto.Request.Work;
using SkippyNetApi.Enums;
using SkippyNetApi.Helpers.Common;
using SkippyNetApi.Interfaces.Work;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.DataAccess.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private const string ClassName = nameof(WorkRepository);

        public async Task<ResponseDto> CreateAsync(Models.Work model)
        {
            const string methodName = ClassName + "." + nameof(CreateAsync);

            var response = new ResponseDto();

            try
            {
                // TODO Make entity action here
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName, ResponseType.Error);
            }

            return response;
        }

        public async Task<ResponseDto> DeleteAsync(int id)
        {
            const string methodName = ClassName + "." + nameof(DeleteAsync);

            var response = new ResponseDto();

            try
            {
                // TODO Make entity action here
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName, ResponseType.Error);
            }

            return response;
        }

        public async Task<ResponseDto<Models.Work>> GetAsync(int id)
        {
            const string methodName = ClassName + "." + nameof(GetAsync);

            var response = new ResponseDto<Models.Work>();

            try
            {
                // TODO Make entity action here
                response.Result = new Models.Work()
                {
                    WorkId = 1,
                    WorkName = "TestWorkLoad",
                    IsCompleted = true,
                    IsActive = true,
                };
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName, ResponseType.Error);
            }

            return response;
        }

        public async Task<ResponseDto<List<Models.Work>>> SearchAsync(WorkSearchRequestDto request)
        {
            const string methodName = ClassName + "." + nameof(SearchAsync);

            var response = new ResponseDto<List<Models.Work>>()
            {
                Result = new List<Models.Work>()
            };

            try
            {
                // TODO Make entity action here
                var testResult = new Models.Work()
                {
                    WorkId = 1,
                    WorkName = "TestWorkLoad",
                    IsCompleted = true,
                    IsActive = true,
                };
                response.Result.Add(testResult);
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName, ResponseType.Error);
            }

            return response;
        }

        public async Task<ResponseDto> UpdateAsync(Models.Work model)
        {
            const string methodName = ClassName + "." + nameof(UpdateAsync);

            var response = new ResponseDto();

            try
            {
                // TODO Make entity action here
                response.SetSuccess();
            }
            catch (Exception ex)
            {
                response.SetError(0, ex.Message, methodName, ResponseType.Error);
            }

            return response;
        }
    }
}
