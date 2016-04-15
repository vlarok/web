using System.Linq;
using DAL.Interfaces;
using Domain.Rights;

namespace DAL.Repositories
{
 
    public class RolePrivilegesRepository : EFRepository<RolePrivilege>, IRolePrivilegesRepository
    {
        public RolePrivilegesRepository(IDbContext dbContext) : base(dbContext)
        {
        }


        public bool Contains(int id, int privilegeId)
        {
          return  DbSet.Any(x => x.RoleId == id && x.PrivilegeId == privilegeId);
          
        }
    }
}