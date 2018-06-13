using CRM.Domain;

namespace CRM.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRMDbContext _crmDbContext;

        public UnitOfWork(CRMDbContext crmDbContext)
        {
            _crmDbContext = crmDbContext;
        }

        public bool Commit()
        {
            return _crmDbContext.SaveChanges() > 0;
        }
    }
}
