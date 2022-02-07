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
    public class RolesAppPermissionsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: RolesAppPermissions
        public async Task<ActionResult> Index()
        {
            return View(await db.RolesAppPermissions.ToListAsync());
        }

        // GET: RolesAppPermissions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesAppPermission rolesAppPermission = await db.RolesAppPermissions.FindAsync(id);
            if (rolesAppPermission == null)
            {
                return HttpNotFound();
            }
            return View(rolesAppPermission);
        }

        // GET: RolesAppPermissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesAppPermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RolesAppPermission_Id,Role_Id,Controller,Action,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] RolesAppPermission rolesAppPermission)
        {
            if (ModelState.IsValid)
            {
                db.RolesAppPermissions.Add(rolesAppPermission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rolesAppPermission);
        }

        // GET: RolesAppPermissions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesAppPermission rolesAppPermission = await db.RolesAppPermissions.FindAsync(id);
            if (rolesAppPermission == null)
            {
                return HttpNotFound();
            }
            return View(rolesAppPermission);
        }

        // POST: RolesAppPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RolesAppPermission_Id,Role_Id,Controller,Action,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] RolesAppPermission rolesAppPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolesAppPermission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rolesAppPermission);
        }

        // GET: RolesAppPermissions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesAppPermission rolesAppPermission = await db.RolesAppPermissions.FindAsync(id);
            if (rolesAppPermission == null)
            {
                return HttpNotFound();
            }
            return View(rolesAppPermission);
        }

        // POST: RolesAppPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RolesAppPermission rolesAppPermission = await db.RolesAppPermissions.FindAsync(id);
            db.RolesAppPermissions.Remove(rolesAppPermission);
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
