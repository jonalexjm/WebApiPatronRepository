using System.Threading;
using System;
using Northwind.Api.Models;
using System.Linq;

namespace Northwind.Api.Repository.Mysql
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly NorthwindDbContext _context;
        public CustomerRepository(NorthwindDbContext context):base(context)
        {
            _context = context;
        }

        public bool Exist(int id)
        {
           return _context.Customers.FirstOrDefault(c => c.Id == id) != null;
           
           
        }
    }
}
