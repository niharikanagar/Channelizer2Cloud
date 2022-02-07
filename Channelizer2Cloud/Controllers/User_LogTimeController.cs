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
    public class User_LogTimeController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: User_LogTime
        public async Task<ActionResult> Index()
        {
            return View(await db.User_LogTime.ToListAsync());
        }

        // GET: User_LogTime/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_LogTime user_LogTime = await db.User_LogTime.FindAsync(id);
            if (user_LogTime == null)
            {
                return HttpNotFound();
            }
            return View(user_LogTime);
        }

        // GET: User_LogTime/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_LogTime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "User_LogTime_Id,UserId,SessionId,LogInTime,LogOutTime,Offline")] User_LogTime user_LogTime)
        {
            if (ModelState.IsValid)
            {
                db.User_LogTime.Add(user_LogTime);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user_LogTime);
        }

        // GET: User_LogTime/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_LogTime user_LogTime = await db.User_LogTime.FindAsync(id);
            if (user_LogTime == null)
            {
                return HttpNotFound();
            }
            return View(user_LogTime);
        }

        // POST: User_LogTime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User_LogTime_Id,UserId,SessionId,LogInTime,LogOutTime,Offline")] User_LogTime user_LogTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_LogTime).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user_LogTime);
        }

        // GET: User_LogTime/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_LogTime user_LogTime = await db.User_LogTime.FindAsync(id);
            if (user_LogTime == null)
            {
                return HttpNotFound();
            }
            return View(user_LogTime);
        }

        // POST: User_LogTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User_LogTime user_LogTime = await db.User_LogTime.FindAsync(id);
            db.User_LogTime.Remove(user_LogTime);
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
