using CRM.Domain.Entities;

namespace CRM.Domain.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer CheckCustomer(string customerCode, string customerName);
    }
}
