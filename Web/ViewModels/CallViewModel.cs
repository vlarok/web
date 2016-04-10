using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.ViewModels
{
    public class CallViewModel
    {
        public Service Service { get; set; }
        public Call Call { get; set; }
        public IEnumerable<Call> Calls { get;  set; }
        public DateTime SearchStartDate { get; set; }
        public DateTime SearchEndDate { get; set; }
        public SelectList ServiceSelectList { get; set; }
    }
}