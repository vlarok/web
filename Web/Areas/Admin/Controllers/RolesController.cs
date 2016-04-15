using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DAL.Interfaces;
using Domain.Identity;
using Domain.Rights;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MvcCheckBoxList.Model;
using NLog;
using Web.Areas.Admin.ViewModels;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : BaseController
    {
        private readonly NLog.ILogger _logger;
        private readonly string _instanceId = Guid.NewGuid().ToString();

        private readonly IUOW _uow;
        private readonly ApplicationRoleManager _roleManager;
        private readonly ApplicationSignInManager _signInManager;
        private readonly ApplicationUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public RolesController(IUOW uow, ApplicationRoleManager roleManager, ApplicationUserManager userManager,
            ApplicationSignInManager signInManager, IAuthenticationManager authenticationManager, ILogger logger)
        {
            _uow = uow;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationManager = authenticationManager;
            _logger = logger;

            _logger.Debug("InstanceId: " + _instanceId);
        }

        // GET: Roles
        public ActionResult Index()
        {
            // our rolemanager does not implement IQueryableRoleStore by choice
            // so lets drop down to ef 
            //return View(_roleManager.RolesInt.ToList());

            return View(_uow.RolesInt.All.OrderBy(a => a.Name).ToList());
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = _roleManager.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] RoleInt role)
        {
            if (ModelState.IsValid)
            {
                _roleManager.Create(role);
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleInt role = _roleManager.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            /*
            var selected= _uow.RolePrivileges.All.Where(x => x.RoleId.Equals(id)).ToList();

            var sel =
                _uow.Privileges.All.Where(
                    x =>
                        x.PrivilegeId ==
                        _uow.RolePrivileges.All.Where(z => z.RoleId.Equals(id))
                            .Select(i => i.PrivilegeId)
                            .FirstOrDefault());
            */
           
            var vm = new RoleViewModel()
            {
                Role = role,
                Privileges = _uow.Privileges.All.Select(x => new SelectListItem()
                {
                     Selected = _uow.RolePrivileges.Contains(id,x.PrivilegeId),
                  //  Selected = true,
                    Text = x.PrivilegeName,
                    Value = x.PrivilegeId.ToString()
                })

                // PrivilegeSources=new SelectList(_uow.Privileges.All)
                // SelectedSources=_uow.
            };
          
            /*
               ViewBag.ApplicationUserList = db.ApplicationUsers.ToList().Select(x => new SelectListItem()
            {
                Selected = ApplicationUser.Contains(x.Id),
                Text = x.UserName,
                Value = x.Id
            });*/
            return View(vm);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( RoleViewModel vm)
        {
            if (ModelState.IsValid)
            {

                _roleManager.Update(vm.Role);
                

                _uow.RolePrivileges.UpdateById(vm.Role.Id,vm.PrivilegeId);
              _uow.Commit();
              
                
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == default(int))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = _roleManager.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var role = _roleManager.FindById(id);
            _roleManager.Delete(role);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _logger.Debug("InstanceId: " + _instanceId + " Disposing:" + disposing);
            base.Dispose(disposing);
        }
    }
}