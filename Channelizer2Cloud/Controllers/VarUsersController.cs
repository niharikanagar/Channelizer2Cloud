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
    public class VarUsersController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: VarUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.VarUsers.ToListAsync());
        }

        // GET: VarUsers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarUser varUser = await db.VarUsers.FindAsync(id);
            if (varUser == null)
            {
                return HttpNotFound();
            }
            return View(varUser);
        }

        // GET: VarUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VarUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VarUser_Id,UserId,Mvs_VarId,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] VarUser varUser)
        {
            if (ModelState.IsValid)
            {
                db.VarUsers.Add(varUser);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(varUser);
        }

        // GET: VarUsers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarUser varUser = await db.VarUsers.FindAsync(id);
            if (varUser == null)
            {
                return HttpNotFound();
            }
            return View(varUser);
        }

        // POST: VarUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VarUser_Id,UserId,Mvs_VarId,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] VarUser varUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(varUser).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(varUser);
        }

        // GET: VarUsers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VarUser varUser = await db.VarUsers.FindAsync(id);
            if (varUser == null)
            {
                return HttpNotFound();
            }
            return View(varUser);
        }

        // POST: VarUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VarUser varUser = await db.VarUsers.FindAsync(id);
            db.VarUsers.Remove(varUser);
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
