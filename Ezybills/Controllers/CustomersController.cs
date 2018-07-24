using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using EzyBills.Models;
using Ezybills.Models;
using System;
using System.Collections.Generic;

namespace Ezybills.Controllers
{
    public class CustomersController : Controller
    {
        private EzybillsContext db = new EzybillsContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Customers/Login
        public ActionResult Login()
        {
            return View();
        }
        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create([System.Web.Http.FromBody] Customer customer)
        {

            db.Customers.Add(customer);
            db.SaveChanges();
            return View("Index");

        }

        [HttpPost]
        public ActionResult GetId([System.Web.Http.FromBody]Customer customer)
        {
            var cu = db.Customers.FirstOrDefault(x => x.CustomerEmail == customer.CustomerEmail);
            return Json(new { customerId = cu.CustomerID });
        }

        // POST: Customers/Login
        [HttpPost]

        public ActionResult Login([System.Web.Http.FromBody] Customer customer)
        {

            if (db.Customers.FirstOrDefault(x => (x.CustomerEmail == customer.CustomerEmail && x.SetCustomerPassword == customer.SetCustomerPassword)) != null)
            {
                return Json(new { ok = true, newurl = Url.Action("Profile"), email = customer.CustomerEmail });

            }

            return RedirectToAction("Error");

        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerUsername,SetPassword,CustomerEmail,CustomerPhone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult ShowSummary(int customerid, DateTime startdate, DateTime enddate)
        {
            // first step get all billids
            List<int> billid = (from bill in db.Bills
                                where bill.BillCustomerID == customerid && bill.dateOfPurchase >= startdate
                                && bill.dateOfPurchase <= enddate
                                select bill.BillID).ToList();
            // step 2 show all bills having 
            List<ItemSummary> summary = new List<ItemSummary>();
            List<Item> itemList = new List<Item>();
            foreach (int Bill in billid)
            {
                IEnumerable<Item> items = from item in db.Items
                                          where item.ItemBillID == Bill
                                          select item;
                foreach(Item item in items)
                {
                    itemList.Add(item);
                }

            }
            foreach (Item item in itemList)
            {
                ItemSummary itemSummary = new ItemSummary()
                {
                    Itemname = item.ItemName,
                    Quantity = item.QuantityPurchased,
                    Cost = item.QuantityCost
                };
                summary.Add(itemSummary);
            }
            return Json(new { Summary = summary });
        }
    }
}
