using System.ComponentModel.DataAnnotations.Schema;
using Domain.Identity;

namespace Domain.Rights
{
    public class RolePrivilege
    {
        public int RolePrivilegeId { get; set; }
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public virtual RoleInt Role { get; set; }
        public int PrivilegeId { get; set; }
        public virtual Privilege Privilege { get; set; }
        public bool YesNo { get; set; }
    }
}
