using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;

using System.Web.Mvc;
using EzyBills.Models;
using Ezybills.Models;
using System.Data.Entity.Validation;

namespace Ezybills.Controllers
{
    public class VendorsController : Controller
    {
        private EzybillsContext db = new EzybillsContext();

        // GET: Vendors
        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }
        [HttpPost]
        public ActionResult StoreNames()
        {
            var store = db.Vendors.Select(x => x.StoreName);
            return Json(new { stores = store });
        }

        [HttpPost]
        public ActionResult Location([System.Web.Http.FromBody] Vendor vendor)
        {
            var location = db.Vendors.Where(x => x.StoreName == vendor.StoreName).Select(x => x.Location);
            return Json(new { locations = location });
        }

        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create([System.Web.Http.FromBody] Vendor vendor)
        {
            try
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return RedirectToAction("Index");

            }

        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorID,VendorUsername,SetVendorPassword,VendorEmail,VendorPhone,Location,StoreName")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Vendors/Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Testing_Login()
        {
            return View("Testing_Login");
        }
        // POST: Vendors/Login
        [HttpPost]

        public ActionResult Login([System.Web.Http.FromBody] Vendor vendor)
        {
            Session["VendorEmail"] = vendor.VendorEmail;
            if (db.Vendors.FirstOrDefault(x => (x.VendorEmail == vendor.VendorEmail && x.SetVendorPassword == vendor.SetVendorPassword)) != null)
            {
                return Json(new { ok = true, email = vendor.VendorEmail });


            }

            return Json(new { ok = false, message = "login failed" });

        }

        [HttpPost]
        public ActionResult GetId([System.Web.Http.FromBody]Vendor vendor)
        {
            var ve = db.Vendors.FirstOrDefault(x => x.VendorEmail == Session["VendorEmail"].ToString());
            return Json(new { vendorId = ve.VendorID });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
