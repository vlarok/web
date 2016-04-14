using DAL.Interfaces;
using DAL.Repositories;
using Domain.Rights;

namespace DAL.Helpers
{
   

    public class GroupPrivilegeRepository : EFRepository<GroupPrivilege>, IGroupPrivilegeRepository
    {
        public GroupPrivilegeRepository(IDbContext dbContext) : base(dbContext)
        {
        }


    }
}