using System;
using Alba;
using Northwind.Api.Repository.Mysql;

namespace Northwind.Api.Integration.Test
{
    public class WebApiFixture : IDisposable
    {
        public readonly SystemUnderTest systemUnderTest;
        public readonly NorthwindDbContext northwindDbContext;
        public WebApiFixture()
        {
            systemUnderTest = SystemUnderTest.ForStartup<Test.Startup>();
            northwindDbContext = (NorthwindDbContext)systemUnderTest.Services.GetService(typeof(NorthwindDbContext));
        }

        public void Dispose()
        {
            systemUnderTest?.Dispose();
        }

    }
}
