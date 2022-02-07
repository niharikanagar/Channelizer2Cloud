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
using PagedList;

namespace Channelizer2Cloud.Controllers
{
    [Authorize]
    public class FieldTypesController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: FieldTypes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var fieldTypes = from s in db.FieldTypes
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                fieldTypes = fieldTypes.Where(s => s.FieldTypeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    fieldTypes = fieldTypes.OrderByDescending(s => s.FieldTypeName);
                    break;
                default:
                    fieldTypes = fieldTypes.OrderBy(s => s.FieldTypeName);
                    break;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(fieldTypes.ToPagedList(pageNumber,pageSize));
        }

        // GET: FieldTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldType fieldType = await db.FieldTypes.FindAsync(id);
            if (fieldType == null)
            {
                return HttpNotFound();
            }
            return View(fieldType);
        }

        // GET: FieldTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FieldTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FieldType_Id,FieldTypeName,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] FieldType fieldType)
        {
            if (ModelState.IsValid)
            {
                db.FieldTypes.Add(fieldType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fieldType);
        }

        // GET: FieldTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldType fieldType = await db.FieldTypes.FindAsync(id);
            if (fieldType == null)
            {
                return HttpNotFound();
            }
            return View(fieldType);
        }

        // POST: FieldTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FieldType_Id,FieldTypeName,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] FieldType fieldType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fieldType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fieldType);
        }

        // GET: FieldTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FieldType fieldType = await db.FieldTypes.FindAsync(id);
            if (fieldType == null)
            {
                return HttpNotFound();
            }
            return View(fieldType);
        }

        // POST: FieldTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FieldType fieldType = await db.FieldTypes.FindAsync(id);
            db.FieldTypes.Remove(fieldType);
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
