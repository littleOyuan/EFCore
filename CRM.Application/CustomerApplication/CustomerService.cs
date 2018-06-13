using System.Collections.Generic;
using CRM.Domain.Entities;
using CRM.Domain.IRepositories;
using CRM.EntityFrameworkCore.Repositories;

namespace CRM.Application.CustomerApplication
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool IsExist(string customerCode, string customerName)
        {
            return _customerRepository.CheckCustomer(customerCode, customerName) != null;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
    }
}
