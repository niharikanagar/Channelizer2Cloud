using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Channelizer2Cloud.Data;
using Channelizer2Cloud.Models;

namespace Channelizer2Cloud.Controllers
{
    public class CustomerContactsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: CustomerContacts
        public async Task<ActionResult> Index()
        {
            var customerContacts = db.CustomerContacts.Include(c => c.customer);
            return View(await customerContacts.ToListAsync());
        }

        // GET: CustomerContacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerContact customerContact = await db.CustomerContacts.FindAsync(id);
            if (customerContact == null)
            {
                return HttpNotFound();
            }
            return View(customerContact);
        }

        // GET: CustomerContacts/Create
        public ActionResult Create()
        {
            ViewBag.Customer_Id = new SelectList(db.Customers, "Customer_Id", "Name");
            return View();
        }

        // POST: CustomerContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerContact_Id,Customer_Id,FirstName,LastName,Title,Email,Phone,Fax,Mobile,Website,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] CustomerContact customerContact)
        {
            if (ModelState.IsValid)
            {
                db.CustomerContacts.Add(customerContact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_Id = new SelectList(db.Customers, "Customer_Id", "Name", customerContact.Customer_Id);
            return View(customerContact);
        }

        // GET: CustomerContacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerContact customerContact = await db.CustomerContacts.FindAsync(id);
            if (customerContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_Id = new SelectList(db.Customers, "Customer_Id", "Name", customerContact.Customer_Id);
            return View(customerContact);
        }

        // POST: CustomerContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerContact_Id,Customer_Id,FirstName,LastName,Title,Email,Phone,Fax,Mobile,Website,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] CustomerContact customerContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerContact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_Id = new SelectList(db.Customers, "Customer_Id", "Name", customerContact.Customer_Id);
            return View(customerContact);
        }

        // GET: CustomerContacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerContact customerContact = await db.CustomerContacts.FindAsync(id);
            if (customerContact == null)
            {
                return HttpNotFound();
            }
            return View(customerContact);
        }

        // POST: CustomerContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomerContact customerContact = await db.CustomerContacts.FindAsync(id);
            db.CustomerContacts.Remove(customerContact);
            await db.SaveChangesAsync();
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
    }
}
