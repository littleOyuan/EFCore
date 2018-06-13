using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Domain
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
