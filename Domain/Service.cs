using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Service
    {
        public int ServiceId { get; set; }

        [Required]
        [MaxLength(128, ErrorMessageResourceName = "FirstnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [MinLength(1, ErrorMessageResourceName = "FirstnameLengthError", ErrorMessageResourceType = typeof(Resources.Domain))]
        [Display(Name = nameof(Resources.Domain.ServiceName), ResourceType = typeof(Resources.Domain))]
        public string ServiceName { get; set; }
        public virtual List<Call> Calls { get; set; }
        public bool Deteted { get; set; }
    }
}
