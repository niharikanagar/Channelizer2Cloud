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
    public class Vendor_ProgramController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: Vendor_Program
        public async Task<ActionResult> Index()
        {
            var vendor_Program = db.Vendor_Program.Include(v => v.vendor);
            return View(await vendor_Program.ToListAsync());
        }

        // GET: Vendor_Program/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor_Program vendor_Program = await db.Vendor_Program.FindAsync(id);
            if (vendor_Program == null)
            {
                return HttpNotFound();
            }
            return View(vendor_Program);
        }

        // GET: Vendor_Program/Create
        public ActionResult Create()
        {
            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "VendorName");
            return View();
        }

        // POST: Vendor_Program/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Vendor_Program_Id,Vendor_Id,ProgramName,Description,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Vendor_Program vendor_Program)
        {
            if (ModelState.IsValid)
            {
                db.Vendor_Program.Add(vendor_Program);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "VendorName", vendor_Program.Vendor_Id);
            return View(vendor_Program);
        }

        // GET: Vendor_Program/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor_Program vendor_Program = await db.Vendor_Program.FindAsync(id);
            if (vendor_Program == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "VendorName", vendor_Program.Vendor_Id);
            return View(vendor_Program);
        }

        // POST: Vendor_Program/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Vendor_Program_Id,Vendor_Id,ProgramName,Description,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Vendor_Program vendor_Program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor_Program).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Vendor_Id = new SelectList(db.Vendors, "Vendor_Id", "VendorName", vendor_Program.Vendor_Id);
            return View(vendor_Program);
        }

        // GET: Vendor_Program/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor_Program vendor_Program = await db.Vendor_Program.FindAsync(id);
            if (vendor_Program == null)
            {
                return HttpNotFound();
            }
            return View(vendor_Program);
        }

        // POST: Vendor_Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vendor_Program vendor_Program = await db.Vendor_Program.FindAsync(id);
            db.Vendor_Program.Remove(vendor_Program);
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
