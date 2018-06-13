using System;
using System.Collections.Generic;
using System.Text;
using CRM.Domain.Entities;

namespace CRM.Application.CustomerApplication
{
    public interface ICustomerService
    {
        bool IsExist(string customerCode, string customerName);

        List<Customer> GetAll();
    }
}
