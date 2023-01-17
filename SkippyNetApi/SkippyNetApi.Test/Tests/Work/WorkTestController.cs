using SkippyNetApi.Test.Dtos.Classes.Common;
using SkippyNetApi.Test.Enums;
using SkippyNetApi.Test.Interfaces.Work;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Test.Tests.Work
{
    public class WorkTestController : IWorkTestController
    {
        private readonly IWorkCreateFixture _workCreateFixture;
        private readonly IWorkDeleteFixture _workDeleteFixture;
        private readonly IWorkGetFixture _workGetFixture;
        private readonly IWorkUpdateFixture _workUpdateFixture;
        private readonly IWorkSearchFixture _workSearchFixture;

        public WorkTestController(
            IWorkCreateFixture workCreateFixture,
            IWorkDeleteFixture workDeleteFixture,
            IWorkGetFixture workGetFixture,
            IWorkUpdateFixture workUpdateFixture,
            IWorkSearchFixture workSearchFixture)
        {
            _workCreateFixture = workCreateFixture;
            _workDeleteFixture = workDeleteFixture;
            _workGetFixture = workGetFixture;
            _workUpdateFixture = workUpdateFixture;
            _workSearchFixture = workSearchFixture;
        }

        public async Task<List<TestLogDto>> RunAsync(TestType testType)
        {
            var testLogList = new List<TestLogDto>();

            var createFixture = await _workCreateFixture.RunCreateAsync(testType);
            if (createFixture != null)
            {
                testLogList.AddRange(createFixture);
            }

            var getFixture = await _workGetFixture.RunGetAsync(testType);
            if (getFixture != null)
            {
                testLogList.AddRange(getFixture);
            }

            var searchFixture = await _workSearchFixture.RunSearchAsync(testType);
            if (searchFixture != null)
            {
                testLogList.AddRange(searchFixture);
            }

            var updateFixture = await _workUpdateFixture.RunUpdateAsync(testType);
            if (updateFixture != null)
            {
                testLogList.AddRange(updateFixture);
            }

            var deleteFixture = await _workDeleteFixture.RunDeleteAsync(testType);
            if (deleteFixture != null)
            {
                testLogList.AddRange(deleteFixture);
            }

            return testLogList;
        }
    }
}
