using System;
using Alba;

namespace Northwind.Api.Integration.Test
{
    public class WebApiFixture : IDisposable
    {
        public readonly SystemUnderTest systemUnderTest;
        public WebApiFixture()
        {
            systemUnderTest = SystemUnderTest.ForStartup<Api.Startup>();
        }

        public void Dispose()
        {
            systemUnderTest?.Dispose();
        }

    }
}
