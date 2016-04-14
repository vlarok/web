using DAL.Interfaces;
using Domain.Rights;

namespace DAL.Repositories
{
 
    public class UserPrivilegesRepository : EFRepository<UserPrivilege>, IUserPrivilegesRepository
    {
        public UserPrivilegesRepository(IDbContext dbContext) : base(dbContext)
        {
        }


    }
}