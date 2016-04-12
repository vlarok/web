using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identity;

namespace Domain
{
    public class Call
    {
        public int CallId { get; set; }
        [StringLength(128, MinimumLength = 0)]
        [Display(Name = nameof(Resources.Domain.Anumber), ResourceType = typeof(Resources.Domain))]

        public string Anumber { get; set; }

        [StringLength(128, MinimumLength = 0)]
        [Display(Name = nameof(Resources.Domain.Bnumber), ResourceType = typeof(Resources.Domain))]

        public string Bnumber { get; set; }

        [StringLength(128, MinimumLength = 0)]
        [Display(Name = nameof(Resources.Domain.Dir), ResourceType = typeof(Resources.Domain))]

        public string Dir { get; set; }

        [StringLength(128, MinimumLength = 0)]

        [Display(Name = nameof(Resources.Domain.Duration), ResourceType = typeof(Resources.Domain))]

        public string Duration { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = nameof(Resources.Domain.Created), ResourceType = typeof(Resources.Domain))]

        public DateTime Created { get; set; }

        [StringLength(128, MinimumLength = 0)]
        public string AudioFileName { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual UserInt User { get; set; }

        [StringLength(512, MinimumLength = 0)]
        public string AudioDir { get; set; }

        [StringLength(128, MinimumLength = 0)]
        public string Custom1 { get; set; }
        [StringLength(128, MinimumLength = 0)]
        public string Custom2 { get; set; }
        [StringLength(128, MinimumLength = 0)]
        public string Custom3 { get; set; }

        [StringLength(128, MinimumLength = 0)]
        public string Custom4 { get; set; }
        public int? ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
