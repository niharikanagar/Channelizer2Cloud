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
    public class StatesController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: States
        public async Task<ActionResult> Index()
        {
            var states = db.States.Include(s => s.country);
            return View(await states.ToListAsync());
        }

        // GET: States/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = await db.States.FindAsync(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // GET: States/Create
        public ActionResult Create()
        {
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name");
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "State_Id,Name,Abbreviation,ISOCode,Country_Id,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] State state)
        {
            if (ModelState.IsValid)
            {
                db.States.Add(state);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", state.Country_Id);
            return View(state);
        }

        // GET: States/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = await db.States.FindAsync(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", state.Country_Id);
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "State_Id,Name,Abbreviation,ISOCode,Country_Id,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Country_Id = new SelectList(db.Countries, "Country_Id", "Name", state.Country_Id);
            return View(state);
        }

        // GET: States/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = await db.States.FindAsync(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            State state = await db.States.FindAsync(id);
            db.States.Remove(state);
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
