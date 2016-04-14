using DAL.Interfaces;
using Domain.Rights;

namespace DAL.Repositories
{
   

    public class UserGroupRepository : EFRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(IDbContext dbContext) : base(dbContext)
        {
        }


    }
}