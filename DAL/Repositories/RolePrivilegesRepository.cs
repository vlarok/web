using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Domain.Identity;
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

        public void UpdateById(int id, int[] privilegeId)
        {
            List<RolePrivilege> rp = DbSet.Where(x => x.RoleId.Equals(id)).ToList();
            DbSet.RemoveRange(rp);
          
            foreach (var pid in privilegeId)
            {
                DbSet.Add(new RolePrivilege() {RoleId = id,PrivilegeId = pid});
            }
         
        }

        public object GetAllUserPrivileges(int v)
        {
            throw new System.NotImplementedException();
        }
    }
}