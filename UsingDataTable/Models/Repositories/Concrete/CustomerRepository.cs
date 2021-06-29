using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingDataTable.Models.Context;
using UsingDataTable.Models.Entities;
using UsingDataTable.Models.Repositories.Abstract;

namespace UsingDataTable.Models.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private ProjectContext _context;
        public CustomerRepository(ProjectContext context)
        {
            _context = context;
        }
        public IQueryable<CustomerTB> CustomerTB => _context.CustomerTB;

        public bool DeleteCustomer(int id)
        {
            _context.CustomerTB.Remove(GetByID(id));
            return _context.SaveChanges() > 0;
        }

        public CustomerTB GetByID(int id) => _context.CustomerTB.Find(id);
       

        public bool InsertCustomer(CustomerTB customer)
        {
            _context.CustomerTB.Add(customer);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCustomer(CustomerTB customer)
        {
            _context.CustomerTB.Update(customer);
            return _context.SaveChanges() > 0;
        }
    }
}
