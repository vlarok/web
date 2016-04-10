using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;
using Web.ViewModels;

namespace Web.Controllers
{
    public class CallsController : BaseController
    {

        private readonly IUOW _uow;

        public CallsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: Calls
        public ActionResult Index()
        {
            var vm = new CallViewModel()
            {
                SearchStartDate = DateTime.Today,
                SearchEndDate = DateTime.Now,
                Calls = _uow.Calls.All,
                ServiceSelectList = new SelectList(_uow.Services.All.Select(t => new { t.ServiceId, t.ServiceName }).ToList(), nameof(Service.ServiceId), nameof(Service.ServiceName))
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CallViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //DoSomeStuff
                if (vm.ServiceIdNullable == null)
                {
                }
                else
                {
                }
                return RedirectToAction("Index", "Home", new { ServiceIdNullable = vm.ServiceIdNullable== null ? "null" : vm.ServiceIdNullable.ToString() });
            }

            //initialize lists again
            vm.Calls = _uow.Calls.All;
            //initialize list and set back selected value
            vm.ServiceSelectList = new SelectList(_uow.Services.All.Select(t => new { t.ServiceId, t.ServiceName }).ToList(), nameof(Service.ServiceId), nameof(Service.ServiceName), vm.Service.ServiceId);

            return View(vm);
        }

        // GET: Calls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = _uow.Calls.GetById(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        // GET: Calls/Create
        public ActionResult Create()
        {
            ViewBag.ServiceId = new SelectList(_uow.Services.All, "ServiceId", "ServiceName");
            return View();
        }

        // POST: Calls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CallId,Anumber,Bnumber,Dir,Duration,Created,AudioFileName,UserId,AudioDir,Custom1,Custom2,Custom3,Custom4,ServiceId")] Call call)
        {
            if (ModelState.IsValid)
            {
                _uow.Calls.Add(call);
                _uow.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceId = new SelectList(_uow.Services.All, "ServiceId", "ServiceName", call.ServiceId);
            return View(call);
        }

        // GET: Calls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = _uow.Calls.GetById(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = new SelectList(_uow.Services.All, "ServiceId", "ServiceName", call.ServiceId);
            return View(call);
        }

        // POST: Calls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CallId,Anumber,Bnumber,Dir,Duration,Created,AudioFileName,UserId,AudioDir,Custom1,Custom2,Custom3,Custom4,ServiceId")] Call call)
        {
            if (ModelState.IsValid)
            {
                _uow.Calls.Update(call);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceId = new SelectList(_uow.Services.All, "ServiceId", "ServiceName", call.ServiceId);
            return View(call);
        }

        // GET: Calls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = _uow.Calls.GetById(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            return View(call);
        }

        // POST: Calls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Calls.Delete(id);
            _uow.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
