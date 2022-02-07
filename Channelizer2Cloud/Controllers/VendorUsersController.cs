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
    public class VendorUsersController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: VendorUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.VendorUsers.ToListAsync());
        }

        // GET: VendorUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = await db.VendorUsers.FindAsync(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        // GET: VendorUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VendorUser_Id,UserId,VendorId,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] VendorUser vendorUser)
        {
            if (ModelState.IsValid)
            {
                db.VendorUsers.Add(vendorUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vendorUser);
        }

        // GET: VendorUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = await db.VendorUsers.FindAsync(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        // POST: VendorUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VendorUser_Id,UserId,VendorId,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] VendorUser vendorUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendorUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vendorUser);
        }

        // GET: VendorUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendorUser vendorUser = await db.VendorUsers.FindAsync(id);
            if (vendorUser == null)
            {
                return HttpNotFound();
            }
            return View(vendorUser);
        }

        // POST: VendorUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VendorUser vendorUser = await db.VendorUsers.FindAsync(id);
            db.VendorUsers.Remove(vendorUser);
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
