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
using PagedList;
using PagedList.Mvc;
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
        //[ValidateInput(false)]
        public ActionResult Index(CallViewModel vm)
        {

            IQueryable<Call> calls;
            vm.CreatedSort = String.IsNullOrEmpty(vm.Sort) ? "created" : string.Empty;
            if (vm.SearchStartDate.Equals(vm.SearchEndDate))
            {

                vm.SearchStartDate = DateTime.Today;
                vm.SearchEndDate = DateTime.Today.AddDays(1).AddTicks(-1);
            }

            if (vm.ServiceIdNullable == null)
            {
                calls = _uow.Calls.GetAllCalls(vm.SearchStartDate, vm.SearchEndDate);

            }
            else
            {
              
                    calls = _uow.Calls.GetAllCalls(vm.SearchStartDate, vm.SearchEndDate).Where(
                        c => c.ServiceId == vm.ServiceIdNullable);
            }

            //+------------------------------------------------------------------+
            //|serach direction                                         |
            //+------------------------------------------------------------------+
            if (!String.IsNullOrEmpty(vm.Direction))
            {
                calls = calls.Where(s => s.Dir.Equals(vm.Direction));
            }

            //+------------------------------------------------------------------+
            //|Serach by number                                         |
            //+------------------------------------------------------------------+


            if (!String.IsNullOrEmpty(vm.Search))
            {
                calls = calls.Where(c => c.Anumber.StartsWith(vm.Search) || c.Bnumber.StartsWith(vm.Search));
            }

            switch (vm.Sort)
            {

                case "created":
                    calls = calls.OrderBy(c => c.Created);

                    break;

                default:
                    calls = calls.OrderByDescending(c => c.Created);

                    break;
            }

            vm.ServiceSelectList =
                new SelectList(_uow.Services.All.Select(t => new { t.ServiceId, t.ServiceName }).ToList(),
                    nameof(Service.ServiceId), nameof(Service.ServiceName));

            //Dir
            List<SelectListItem> items = new List<SelectListItem>();



            items.Add(new SelectListItem { Text = "in",Value = Resources.Front.InBound  });
            items.Add(new SelectListItem { Text = "out",Value = Resources.Front.OutBound });
            vm.DirectionSelectList = new SelectList(items, "Text","Value");

            vm.PagedCalls= calls.ToPagedList(vm.Page ?? 1, 20);
            return View(vm);
        }


        public void Generate()
        {
            //:TODO meil on vaja kontroll teha kui custom väljad on nullid
            for (int i = 0; i < 30; i++)
            {
                for (int j = 1; j < 1000; j++)
                {
                    _uow.Calls.AddCall(new Call()
                    {
                        AudioDir = @"2015\04\27\22\",
                        AudioFileName = "20150427225942_001_50336869",
                        Anumber = "16684" + i.ToString(),
                        Bnumber = i.ToString() + "98991",
                        Dir = "in",
                        Duration = "1" + i.ToString(),
                        UserId = 1,
                        ServiceId = 1,
                        Created = DateTime.Now.AddMinutes(-j),
                        Custom1 = "1"

                    });
                    _uow.Commit();
                }
              
            }
           
        }
        public ActionResult Selective()
        {
            return View();
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CallViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //DoSomeStuff
                if (vm.ServiceIdNullable == null)
                {
                    vm.Calls =
                        _uow.Calls.All.Where(
                            c => c.Created >= vm.SearchStartDate && c.Created <= vm.SearchEndDate)
                            .OrderBy(x => x.Created).ToPagedList(vm.Page??1,3);
                    
                }
                else
                {
                    vm.Calls =
                       _uow.Calls.All.Where(
                           c => c.Created >= vm.SearchStartDate && c.Created <= vm.SearchEndDate && c.ServiceId== vm.ServiceIdNullable)
                           .OrderBy(x => x.Created).ToPagedList(vm.Page ?? 1, 3);
                }
               // return RedirectToAction("Index", "Home", new { ServiceIdNullable = vm.ServiceIdNullable== null ? "null" : vm.ServiceIdNullable.ToString() });
            }

            //initialize lists again
           // vm.Calls = _uow.Calls.All;
            //initialize list and set back selected value
            vm.ServiceSelectList = new SelectList(_uow.Services.All.Select(t => new { t.ServiceId, t.ServiceName }).ToList(), nameof(Service.ServiceId), nameof(Service.ServiceName));

            return View(vm);
        }
        */
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
                _uow.Calls.AddCall(call);
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
