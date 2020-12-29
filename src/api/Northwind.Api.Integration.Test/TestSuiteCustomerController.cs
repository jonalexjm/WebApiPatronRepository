using Xunit;
using System.Threading.Tasks;
using Alba;
using System.Collections.Generic;
using Northwind.Api.Models;
using FluentAssertions;
using Northwind.Api.Repository.Mysql;
using GenFu;

namespace Northwind.Api.Integration.Test
{
    public class TestSuiteCustomerController : IClassFixture<WebApiFixture>
    {
        private readonly SystemUnderTest _system;
        private readonly NorthwindDbContext _context;

        public TestSuiteCustomerController(WebApiFixture app)
        {   
            _system = app.systemUnderTest;
            _context = app.northwindDbContext;
        }

        [Fact]
        public async Task Verify_GetAllCustomers_200ResponseCode_With_Data()
        {
        //Given
            new CustomerBuilder(_context).With10Customers();
        //When
            var result = await _system.GetAsJson<IList<Customer>>("/api/customer");
        //Then
            result.Count.Should().Be(2);
        }

    }
}
