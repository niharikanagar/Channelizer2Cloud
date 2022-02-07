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
    public class Mvs_DealControllerk : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: Mvs_Deal
        public async Task<ActionResult> Index()
        {
            return View(await db.Mvs_Deal.ToListAsync());
        }

        // GET: Mvs_Deal/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvs_Deal mvs_Deal = await db.Mvs_Deal.FindAsync(id);
            if (mvs_Deal == null)
            {
                return HttpNotFound();
            }
            return View(mvs_Deal);
        }

        // GET: Mvs_Deal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mvs_Deal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Mvs_Deal_Id,VendorId,ProgramId,DealName,DealDescription,ExpectedRevenue,DealStatus,SubmittedOn,Mvs_VarId,CustomerId,CustomerContactId,SalesRepId,SubmitedBy,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Mvs_Deal mvs_Deal)
        {
            if (ModelState.IsValid)
            {
                db.Mvs_Deal.Add(mvs_Deal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mvs_Deal);
        }

        // GET: Mvs_Deal/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvs_Deal mvs_Deal = await db.Mvs_Deal.FindAsync(id);
            if (mvs_Deal == null)
            {
                return HttpNotFound();
            }
            return View(mvs_Deal);
        }

        // POST: Mvs_Deal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Mvs_Deal_Id,VendorId,ProgramId,DealName,DealDescription,ExpectedRevenue,DealStatus,SubmittedOn,Mvs_VarId,CustomerId,CustomerContactId,SalesRepId,SubmitedBy,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Mvs_Deal mvs_Deal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mvs_Deal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mvs_Deal);
        }

        // GET: Mvs_Deal/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvs_Deal mvs_Deal = await db.Mvs_Deal.FindAsync(id);
            if (mvs_Deal == null)
            {
                return HttpNotFound();
            }
            return View(mvs_Deal);
        }

        // POST: Mvs_Deal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mvs_Deal mvs_Deal = await db.Mvs_Deal.FindAsync(id);
            mvs_Deal.IsDeleted = true;
            //db.Mvs_Deal.Remove(mvs_Deal);
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
