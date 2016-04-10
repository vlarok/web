using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Anumber { get; set; }

        [StringLength(128, MinimumLength = 0)]
        public string Bnumber { get; set; }

        [StringLength(128, MinimumLength = 0)]
        public string Dir { get; set; }

        [StringLength(128, MinimumLength = 0)]
        public string Duration { get; set; }
        public DateTime Created { get; set; }

        [StringLength(128, MinimumLength = 0)]
        public string AudioFileName { get; set; }
        public string UserId { get; set; }
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
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
