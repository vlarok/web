using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain.Rights
{
    public class UserGroup
    {
        public int UserGroupId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
