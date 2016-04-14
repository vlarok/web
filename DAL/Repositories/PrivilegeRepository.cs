using DAL.Interfaces;
using DAL.Repositories;
using Domain.Rights;

namespace DAL.Repositories
{

    public class PrivilegeRepository : EFRepository<Privilege>, IPrivilegeRepository
    {
        public PrivilegeRepository(IDbContext dbContext) : base(dbContext)
        {
        }


    }
}