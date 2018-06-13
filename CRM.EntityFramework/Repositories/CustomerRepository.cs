using CRM.Domain.Entities;
using CRM.Domain.IRepositories;
using System.Linq;

namespace CRM.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CRMDbContext crmDbContext)
            : base(crmDbContext)
        {
        }

        public Customer CheckCustomer(string customerCode, string customerName)
        {
            return CRMDbContext.Set<Customer>().FirstOrDefault(customer => customer.CustomerCode == customerCode && customer.CustomerName == customerName);
        }
    }
}
