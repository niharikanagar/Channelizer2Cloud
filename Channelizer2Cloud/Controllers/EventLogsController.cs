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
    public class EventLogsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: EventLogs
        public async Task<ActionResult> Index()
        {
            return View(await db.EventLogs.ToListAsync());
        }

        // GET: EventLogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = await db.EventLogs.FindAsync(id);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        // GET: EventLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EventLog_Id,EventLevel,EventType,UserId,VendorId,Message,ExceptionMessage,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] EventLog eventLog)
        {
            if (ModelState.IsValid)
            {
                db.EventLogs.Add(eventLog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eventLog);
        }

        // GET: EventLogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = await db.EventLogs.FindAsync(id);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        // POST: EventLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EventLog_Id,EventLevel,EventType,UserId,VendorId,Message,ExceptionMessage,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] EventLog eventLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventLog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eventLog);
        }

        // GET: EventLogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventLog eventLog = await db.EventLogs.FindAsync(id);
            if (eventLog == null)
            {
                return HttpNotFound();
            }
            return View(eventLog);
        }

        // POST: EventLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EventLog eventLog = await db.EventLogs.FindAsync(id);
            db.EventLogs.Remove(eventLog);
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
