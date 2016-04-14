using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rights
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public virtual List<GroupPrivilege> GroupPrivileges { get; set; }
        public virtual List<UserGroup> UserGroups { get; set; }

    }
}
