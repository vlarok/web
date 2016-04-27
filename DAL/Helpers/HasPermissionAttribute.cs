using System.Linq;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain.Identity;

public class HasPermissionAttribute : ActionFilterAttribute
{
    private string _permission;

    public HasPermissionAttribute(string permission)
    {
        this._permission = permission;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {/*
        IServiceRepository ne
        IUOW _uow =new UOW();
        int RolId = _uow.UserRolesInt.All.Where(x => x.UserId == User.Identity.GetUserId<int>()).Select(x => x.RoleId).FirstOrDefault();
        int PermissionId = _uow.Privileges.All.Where(x => x.PrivilegeName == "ListenAllCalls").Select(x => x.PrivilegeId).FirstOrDefault();
        bool midagi = _uow.RolePrivileges.All.Where(x => x.RoleId.Equals(RolId) && x.PrivilegeId.Equals(PermissionId)).Select(x => x.YesNo).FirstOrDefault();
*/
        /*  if (!CHECK_IF_USER_OR_ROLE_HAS_PERMISSION(_permission))
          {
              // If this user does not have the required permission then redirect to login page
              var url = new UrlHelper(filterContext.RequestContext);
              var loginUrl = url.Content("/Account/Login");
              filterContext.HttpContext.Response.Redirect(loginUrl, true);
          }*/
    }
}