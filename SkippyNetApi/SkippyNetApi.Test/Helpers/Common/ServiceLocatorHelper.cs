using SkippyNetApi.Test.Controllers;
using SkippyNetApi.Test.Helpers.Work;
using SkippyNetApi.Test.Interfaces.Common;
using SkippyNetApi.Test.Interfaces.Work;
using SkippyNetApi.Test.Tests.Work;
using Unity;  // TODO switch to DryIoc

namespace SkippyNetApi.Test.Helpers.Common
{
    public class ServiceLocatorHelper
    {
        private static IUnityContainer _container;

        public static IUnityContainer Initialize()
        {
            BuildUnityContainer();
            return _container;
        }

        private static void BuildUnityContainer()
        {
            _container = new UnityContainer();

            // Common
            _container.RegisterType<ITestController, TestController>();
            _container.RegisterType<IRequestHelper, RequestHelper>();
            _container.RegisterType<IUrlHelper, UrlHelper>();

            // Work
            _container.RegisterType<IWorkTestController, WorkTestController>();
            _container.RegisterType<IWorkRequestHelper, WorkRequestHelper>();
            _container.RegisterType<IWorkCreateFixture, WorkCreateFixture>();
            _container.RegisterType<IWorkDeleteFixture, WorkDeleteFixture>();
            _container.RegisterType<IWorkGetFixture, WorkGetFixture>();
            _container.RegisterType<IWorkSearchFixture, WorkSearchFixture>();
            _container.RegisterType<IWorkUpdateFixture, WorkUpdateFixture>();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
