using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingDataTable.Models.Entities;

namespace UsingDataTable.Models.Repositories.Abstract
{
   public interface ICustomerRepository
    {
        IQueryable<CustomerTB> CustomerTB { get; }//Readonly Property
        bool InsertCustomer(CustomerTB customer);
        CustomerTB GetByID(int id);
        bool UpdateCustomer(CustomerTB customer);
        bool DeleteCustomer(int id);
    }
}
