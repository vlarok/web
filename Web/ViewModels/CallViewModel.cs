using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using PagedList;

namespace Web.ViewModels
{
    public class CallViewModel
    {
        public Service Service { get; set; }
        public Call Call { get; set; }
        public int? ServiceIdNullable { get; set; }
        public IPagedList<Call> PagedCalls { get;  set; }

        public IEnumerable<Call> Calls { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime SearchStartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SearchEndDate { get; set;  }
        public SelectList ServiceSelectList { get; set; }
        public string CreatedSort { get; set; }

        public int? Page { get; set; }
        public string CurrentSearch { get; set; }
        public string CurrentSort { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }
    }
}