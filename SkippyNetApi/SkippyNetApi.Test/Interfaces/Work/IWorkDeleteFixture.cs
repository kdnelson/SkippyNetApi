﻿using SkippyNetApi.Test.Dtos.Classes.Common;
using SkippyNetApi.Test.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkippyNetApi.Test.Interfaces.Work
{
    public interface IWorkDeleteFixture
    {
        Task<List<TestLogDto>> RunDeleteAsync(TestType testType);
    }
}
