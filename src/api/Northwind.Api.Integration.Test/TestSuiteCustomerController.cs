using System.Collections;
using System;
using Xunit;
using System.Threading.Tasks;
using Alba;
using System.Collections.Generic;
using Northwind.Api.Models;
using FluentAssertions;

namespace Northwind.Api.Integration.Test
{
    public class TestSuiteCustomerController : IClassFixture<WebApiFixture>
    {
        private readonly SystemUnderTest _system;

        public TestSuiteCustomerController(WebApiFixture app)
        {   
            _system = app.systemUnderTest;
        }

        [Fact]
        public async Task Verify_GetAllCustomers_200ResponseCode_With_Data()
        {
        //Given
        
        //When
            var result = await _system.GetAsJson<IList<Customer>>("/api/customer");
        //Then
            result.Count.Should().Be(91);
        }

    }
}
