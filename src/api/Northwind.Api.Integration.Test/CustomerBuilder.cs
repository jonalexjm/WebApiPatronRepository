using System.Collections.Generic;
using System;
using Northwind.Api.Repository.Mysql;
using Northwind.Api.Models;

namespace Northwind.Api.Integration.Test
{
    public class CustomerBuilder
    {
        public readonly NorthwindDbContext _context;  

        public CustomerBuilder(NorthwindDbContext context)
        {
            _context = context;
        } 

        public CustomerBuilder With10Customers()
        {
            AdCustomersToDbContext(CreateCustomer(10));

            return this;
        }

        public NorthwindDbContext Build()
        {
            return _context;

        }

        public void AdCustomersToDbContext(IEnumerable<Customer> customers)
        {
            _context.AddRange(customers);
            _context.SaveChanges();


        }

        private IEnumerable<Customer> CreateCustomer(int quantity)
        {
            int id = 1;
            GenFu.GenFu.Configure<Customer>()
                    .Fill(c => c.Id, () => {return id++;});
            return A.ListOf<Customer>(quantity);

        }
       
    }
}
