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
    public class ReferenceDataListItemsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: ReferenceDataListItems
        public async Task<ActionResult> Index()
        {
            return View(await db.ReferenceDataListItems.ToListAsync());
        }

        // GET: ReferenceDataListItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenceDataListItem referenceDataListItem = await db.ReferenceDataListItems.FindAsync(id);
            if (referenceDataListItem == null)
            {
                return HttpNotFound();
            }
            return View(referenceDataListItem);
        }

        // GET: ReferenceDataListItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReferenceDataListItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReferenceDataListItem_Id,ReferenceDataListId,ProgramId,DisplayValue,DataValue,Sequence,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] ReferenceDataListItem referenceDataListItem)
        {
            if (ModelState.IsValid)
            {
                db.ReferenceDataListItems.Add(referenceDataListItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(referenceDataListItem);
        }

        // GET: ReferenceDataListItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenceDataListItem referenceDataListItem = await db.ReferenceDataListItems.FindAsync(id);
            if (referenceDataListItem == null)
            {
                return HttpNotFound();
            }
            return View(referenceDataListItem);
        }

        // POST: ReferenceDataListItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReferenceDataListItem_Id,ReferenceDataListId,ProgramId,DisplayValue,DataValue,Sequence,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] ReferenceDataListItem referenceDataListItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referenceDataListItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(referenceDataListItem);
        }

        // GET: ReferenceDataListItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenceDataListItem referenceDataListItem = await db.ReferenceDataListItems.FindAsync(id);
            if (referenceDataListItem == null)
            {
                return HttpNotFound();
            }
            return View(referenceDataListItem);
        }

        // POST: ReferenceDataListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReferenceDataListItem referenceDataListItem = await db.ReferenceDataListItems.FindAsync(id);
            db.ReferenceDataListItems.Remove(referenceDataListItem);
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
