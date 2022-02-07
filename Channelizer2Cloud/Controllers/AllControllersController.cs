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
    public class AllControllersController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: AllControllers
        public async Task<ActionResult> Index()
        {
            return View(await db.AllControllers.ToListAsync());
        }

        // GET: AllControllers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllController allController = await db.AllControllers.FindAsync(id);
            if (allController == null)
            {
                return HttpNotFound();
            }
            return View(allController);
        }

        // GET: AllControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllControllers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Controller_Id,ControllerName,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] AllController allController)
        {
            if (ModelState.IsValid)
            {
                db.AllControllers.Add(allController);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(allController);
        }

        // GET: AllControllers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllController allController = await db.AllControllers.FindAsync(id);
            if (allController == null)
            {
                return HttpNotFound();
            }
            return View(allController);
        }

        // POST: AllControllers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Controller_Id,ControllerName,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] AllController allController)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allController).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(allController);
        }

        // GET: AllControllers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllController allController = await db.AllControllers.FindAsync(id);
            if (allController == null)
            {
                return HttpNotFound();
            }
            return View(allController);
        }

        // POST: AllControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AllController allController = await db.AllControllers.FindAsync(id);
            db.AllControllers.Remove(allController);
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
