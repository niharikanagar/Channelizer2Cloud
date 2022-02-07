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
    public class MvsSalesRepresentativesController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: MvsSalesRepresentatives
        public async Task<ActionResult> Index()
        {
            return View(await db.MvsSalesRepresentatives.ToListAsync());
        }

        // GET: MvsSalesRepresentatives/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvsSalesRepresentative mvsSalesRepresentative = await db.MvsSalesRepresentatives.FindAsync(id);
            if (mvsSalesRepresentative == null)
            {
                return HttpNotFound();
            }
            return View(mvsSalesRepresentative);
        }

        // GET: MvsSalesRepresentatives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MvsSalesRepresentatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MvsSalesRepresentative_Id,UserId,FirstName,LastName,Email,Phone,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] MvsSalesRepresentative mvsSalesRepresentative)
        {
            if (ModelState.IsValid)
            {
                db.MvsSalesRepresentatives.Add(mvsSalesRepresentative);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mvsSalesRepresentative);
        }

        // GET: MvsSalesRepresentatives/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvsSalesRepresentative mvsSalesRepresentative = await db.MvsSalesRepresentatives.FindAsync(id);
            if (mvsSalesRepresentative == null)
            {
                return HttpNotFound();
            }
            return View(mvsSalesRepresentative);
        }

        // POST: MvsSalesRepresentatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MvsSalesRepresentative_Id,UserId,FirstName,LastName,Email,Phone,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] MvsSalesRepresentative mvsSalesRepresentative)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mvsSalesRepresentative).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mvsSalesRepresentative);
        }

        // GET: MvsSalesRepresentatives/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvsSalesRepresentative mvsSalesRepresentative = await db.MvsSalesRepresentatives.FindAsync(id);
            if (mvsSalesRepresentative == null)
            {
                return HttpNotFound();
            }
            return View(mvsSalesRepresentative);
        }

        // POST: MvsSalesRepresentatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MvsSalesRepresentative mvsSalesRepresentative = await db.MvsSalesRepresentatives.FindAsync(id);
            db.MvsSalesRepresentatives.Remove(mvsSalesRepresentative);
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
