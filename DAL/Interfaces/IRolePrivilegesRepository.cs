using Domain.Rights;

namespace DAL.Interfaces
{
    public interface IRolePrivilegesRepository : IEFRepository<RolePrivilege>
    {
        bool Contains(int id, int privilegeId);
    }
}