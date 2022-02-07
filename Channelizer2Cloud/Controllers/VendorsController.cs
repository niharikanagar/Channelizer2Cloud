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
using PagedList;
using System.IO;

namespace Channelizer2Cloud.Controllers
{
    public class VendorsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: Vendors
        public async Task<ActionResult> Index()
        {
            return View(await db.Vendors.ToListAsync());
        }

        // GET: Vendors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = await db.Vendors.FindAsync(id);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Vendor_Id,VendorName,VendorLogo,VendorPrimaryColor,VendorSecondaryColor,VendorFont,TwitterLink,LinkedinLink,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = await db.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Vendor_Id,VendorName,VendorLogo,VendorPrimaryColor,VendorSecondaryColor,VendorFont,TwitterLink,LinkedinLink,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Vendor vendor, HttpPostedFileBase LogoImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                string path = Server.MapPath("~/Content/img/vendor/");
                vendor.VendorLogo = LogoImage.FileName;
                LogoImage.SaveAs(path + Path.GetFileName(LogoImage.FileName));
                db.Entry(vendor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = await db.Vendors.FindAsync(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vendor vendor = await db.Vendors.FindAsync(id);
            db.Vendors.Remove(vendor);
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
