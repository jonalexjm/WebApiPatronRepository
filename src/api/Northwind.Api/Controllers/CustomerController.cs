using System.Collections;
using System;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Repository;
using System.Collections.Generic;
using Northwind.Api.Models;

namespace Northwind.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomer()
        {
            return Ok(_repository.ReadAll());
        }
        
    }
}
