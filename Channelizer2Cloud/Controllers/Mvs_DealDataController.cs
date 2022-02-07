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
    public class Mvs_DealDataController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: Mvs_DealData
        public async Task<ActionResult> Index()
        {
            return View(await db.Mvs_DealData.ToListAsync());
        }

        // GET: Mvs_DealData/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvs_DealData mvs_DealData = await db.Mvs_DealData.FindAsync(id);
            if (mvs_DealData == null)
            {
                return HttpNotFound();
            }
            return View(mvs_DealData);
        }

        // GET: Mvs_DealData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mvs_DealData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Mvs_DealId,DataKey,DataValue,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Mvs_DealData mvs_DealData)
        {
            if (ModelState.IsValid)
            {
                db.Mvs_DealData.Add(mvs_DealData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mvs_DealData);
        }

        // GET: Mvs_DealData/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvs_DealData mvs_DealData = await db.Mvs_DealData.FindAsync(id);
            if (mvs_DealData == null)
            {
                return HttpNotFound();
            }
            return View(mvs_DealData);
        }

        // POST: Mvs_DealData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Mvs_DealId,DataKey,DataValue,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Mvs_DealData mvs_DealData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mvs_DealData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mvs_DealData);
        }

        // GET: Mvs_DealData/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvs_DealData mvs_DealData = await db.Mvs_DealData.FindAsync(id);
            if (mvs_DealData == null)
            {
                return HttpNotFound();
            }
            return View(mvs_DealData);
        }

        // POST: Mvs_DealData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mvs_DealData mvs_DealData = await db.Mvs_DealData.FindAsync(id);
            db.Mvs_DealData.Remove(mvs_DealData);
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
