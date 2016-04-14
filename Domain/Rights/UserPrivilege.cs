using System.ComponentModel.DataAnnotations.Schema;
using Domain.Identity;

namespace Domain.Rights
{
    public class UserPrivilege
    {
        public int UserPrivilegeId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }
        public bool YesNo { get; set; }
    }
}
