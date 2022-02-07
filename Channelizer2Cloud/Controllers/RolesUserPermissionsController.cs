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
    public class RolesUserPermissionsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: RolesUserPermissions
        public async Task<ActionResult> Index()
        {
            return View(await db.RolesUserPermissions.ToListAsync());
        }

        // GET: RolesUserPermissions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesUserPermission rolesUserPermission = await db.RolesUserPermissions.FindAsync(id);
            if (rolesUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(rolesUserPermission);
        }

        // GET: RolesUserPermissions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesUserPermissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RolesUserPermission_Id,User_Id,Role_Id,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] RolesUserPermission rolesUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.RolesUserPermissions.Add(rolesUserPermission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rolesUserPermission);
        }

        // GET: RolesUserPermissions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesUserPermission rolesUserPermission = await db.RolesUserPermissions.FindAsync(id);
            if (rolesUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(rolesUserPermission);
        }

        // POST: RolesUserPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RolesUserPermission_Id,User_Id,Role_Id,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] RolesUserPermission rolesUserPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolesUserPermission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rolesUserPermission);
        }

        // GET: RolesUserPermissions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolesUserPermission rolesUserPermission = await db.RolesUserPermissions.FindAsync(id);
            if (rolesUserPermission == null)
            {
                return HttpNotFound();
            }
            return View(rolesUserPermission);
        }

        // POST: RolesUserPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RolesUserPermission rolesUserPermission = await db.RolesUserPermissions.FindAsync(id);
            db.RolesUserPermissions.Remove(rolesUserPermission);
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
