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
using Channelizer2Cloud.Services;


namespace Channelizer2Cloud.Controllers
{
    public class UserInformationsController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();
        private Service _service = new Service();

        // GET: UserInformations
        public async Task<ActionResult> Index()
        {
            return View(await db.UserInformations.ToListAsync());
        }

        // GET: UserInformations/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // GET: UserInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserInformation_Id,UserTypeId,FirstName,LastName,UserName,Email,Phone,Password,SuccessfulLoginCount,ForcePasswordChangeNextLogin,IsActive,IsLockedOut,LastLogindate,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                userInformation.UserInformation_Id = Guid.NewGuid();
                userInformation.Password = _service.Base64Encode(userInformation.Password);
                db.UserInformations.Add(userInformation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userInformation);
        }

        // GET: UserInformations/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // POST: UserInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserInformation_Id,UserTypeId,FirstName,LastName,UserName,Email,Phone,Password,SuccessfulLoginCount,ForcePasswordChangeNextLogin,IsActive,IsLockedOut,LastLogindate,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
               userInformation.Password = _service.Base64Encode(userInformation.Password);
                db.Entry(userInformation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userInformation);
        }

        // GET: UserInformations/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // POST: UserInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            UserInformation userInformation = await db.UserInformations.FindAsync(id);
            db.UserInformations.Remove(userInformation);
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
