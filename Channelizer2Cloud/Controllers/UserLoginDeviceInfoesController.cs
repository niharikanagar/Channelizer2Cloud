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
    public class UserLoginDeviceInfoesController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: UserLoginDeviceInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.UserLoginDeviceInfoes.ToListAsync());
        }

        // GET: UserLoginDeviceInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoginDeviceInfo userLoginDeviceInfo = await db.UserLoginDeviceInfoes.FindAsync(id);
            if (userLoginDeviceInfo == null)
            {
                return HttpNotFound();
            }
            return View(userLoginDeviceInfo);
        }

        // GET: UserLoginDeviceInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLoginDeviceInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserLoginDeviceInfo_Id,ip,city,region,country,loc,org,postal,timezone,user_id,onetimepassword,login_time")] UserLoginDeviceInfo userLoginDeviceInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserLoginDeviceInfoes.Add(userLoginDeviceInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userLoginDeviceInfo);
        }

        // GET: UserLoginDeviceInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoginDeviceInfo userLoginDeviceInfo = await db.UserLoginDeviceInfoes.FindAsync(id);
            if (userLoginDeviceInfo == null)
            {
                return HttpNotFound();
            }
            return View(userLoginDeviceInfo);
        }

        // POST: UserLoginDeviceInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserLoginDeviceInfo_Id,ip,city,region,country,loc,org,postal,timezone,user_id,onetimepassword,login_time")] UserLoginDeviceInfo userLoginDeviceInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userLoginDeviceInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userLoginDeviceInfo);
        }

        // GET: UserLoginDeviceInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLoginDeviceInfo userLoginDeviceInfo = await db.UserLoginDeviceInfoes.FindAsync(id);
            if (userLoginDeviceInfo == null)
            {
                return HttpNotFound();
            }
            return View(userLoginDeviceInfo);
        }

        // POST: UserLoginDeviceInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserLoginDeviceInfo userLoginDeviceInfo = await db.UserLoginDeviceInfoes.FindAsync(id);
            db.UserLoginDeviceInfoes.Remove(userLoginDeviceInfo);
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
