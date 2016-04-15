using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Identity;
using Domain.Rights;
using MvcCheckBoxList.Model;

namespace Web.Areas.Admin.ViewModels
{
    public class RoleViewModel
    {
        public RoleInt Role { get; set; }
        public IEnumerable<SelectListItem> Privileges { get; set; }
        public int[] PrivilegeId { get; set; }

        //public PostedPrivileges PostedPrivileges { get; set; }
        //  public HtmlListInfo htmlListInfo { get; set; }

        //   public SelectList PrivilegeSources { get; set; }
        //   public IEnumerable<string> SelectedSources { get; set; }
    }

    public class PostedPrivileges
    {
        public string[] PrivilegeIds { get; set; }
    }
}