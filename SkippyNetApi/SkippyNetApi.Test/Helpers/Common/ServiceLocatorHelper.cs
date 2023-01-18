using DryIoc;
using SkippyNetApi.Test.Controllers;
using SkippyNetApi.Test.Helpers.Work;
using SkippyNetApi.Test.Interfaces.Common;
using SkippyNetApi.Test.Interfaces.Work;
using SkippyNetApi.Test.Tests.Work;

namespace SkippyNetApi.Test.Helpers.Common
{
    public class ServiceLocatorHelper
    {
        private static Container _container { get; set; }

        public static Container Initialize()
        {
            BuildUnityContainer();
            return _container;
        }

        private static void BuildUnityContainer()
        {
            _container = new Container();

            // Common
            _container.Register<ITestController, TestController>();
            _container.Register<IRequestHelper, RequestHelper>();
            _container.Register<IUrlHelper, UrlHelper>();

            // Work
            _container.Register<IWorkTestController, WorkTestController>();
            _container.Register<IWorkRequestHelper, WorkRequestHelper>();
            _container.Register<IWorkCreateFixture, WorkCreateFixture>();
            _container.Register<IWorkDeleteFixture, WorkDeleteFixture>();
            _container.Register<IWorkGetFixture, WorkGetFixture>();
            _container.Register<IWorkSearchFixture, WorkSearchFixture>();
            _container.Register<IWorkUpdateFixture, WorkUpdateFixture>();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
