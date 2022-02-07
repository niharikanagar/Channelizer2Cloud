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
    public class AuditlogsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: Auditlogs
        public async Task<ActionResult> Index()
        {
            return View(await db.Auditlogs.ToListAsync());
        }

        // GET: Auditlogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditlog auditlog = await db.Auditlogs.FindAsync(id);
            if (auditlog == null)
            {
                return HttpNotFound();
            }
            return View(auditlog);
        }

        // GET: Auditlogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auditlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Auditlog_Id,EventLevel,EventType,VendorId,Message,EventRaiser,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Auditlog auditlog)
        {
            if (ModelState.IsValid)
            {
                db.Auditlogs.Add(auditlog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(auditlog);
        }

        // GET: Auditlogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditlog auditlog = await db.Auditlogs.FindAsync(id);
            if (auditlog == null)
            {
                return HttpNotFound();
            }
            return View(auditlog);
        }

        // POST: Auditlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Auditlog_Id,EventLevel,EventType,VendorId,Message,EventRaiser,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Auditlog auditlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditlog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(auditlog);
        }

        // GET: Auditlogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditlog auditlog = await db.Auditlogs.FindAsync(id);
            if (auditlog == null)
            {
                return HttpNotFound();
            }
            return View(auditlog);
        }

        // POST: Auditlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Auditlog auditlog = await db.Auditlogs.FindAsync(id);
            db.Auditlogs.Remove(auditlog);
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
