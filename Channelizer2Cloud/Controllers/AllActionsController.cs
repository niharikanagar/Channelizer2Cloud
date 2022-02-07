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
    public class AllActionsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: AllActions
        public async Task<ActionResult> Index()
        {
            var allActions = db.AllActions.Include(a => a.ControllerId);
            return View(await allActions.ToListAsync());
        }

        // GET: AllActions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllActions allActions = await db.AllActions.FindAsync(id);
            if (allActions == null)
            {
                return HttpNotFound();
            }
            return View(allActions);
        }

        // GET: AllActions/Create
        public ActionResult Create()
        {
            ViewBag.Controller_Id = new SelectList(db.AllControllers, "Controller_Id", "ControllerName");
            return View();
        }

        // POST: AllActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Action_Id,ActionName,Controller_Id,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] AllActions allActions)
        {
            if (ModelState.IsValid)
            {
                db.AllActions.Add(allActions);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Controller_Id = new SelectList(db.AllControllers, "Controller_Id", "ControllerName", allActions.Controller_Id);
            return View(allActions);
        }

        // GET: AllActions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllActions allActions = await db.AllActions.FindAsync(id);
            if (allActions == null)
            {
                return HttpNotFound();
            }
            ViewBag.Controller_Id = new SelectList(db.AllControllers, "Controller_Id", "ControllerName", allActions.Controller_Id);
            return View(allActions);
        }

        // POST: AllActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Action_Id,ActionName,Controller_Id,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] AllActions allActions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allActions).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Controller_Id = new SelectList(db.AllControllers, "Controller_Id", "ControllerName", allActions.Controller_Id);
            return View(allActions);
        }

        // GET: AllActions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllActions allActions = await db.AllActions.FindAsync(id);
            if (allActions == null)
            {
                return HttpNotFound();
            }
            return View(allActions);
        }

        // POST: AllActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AllActions allActions = await db.AllActions.FindAsync(id);
            db.AllActions.Remove(allActions);
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
