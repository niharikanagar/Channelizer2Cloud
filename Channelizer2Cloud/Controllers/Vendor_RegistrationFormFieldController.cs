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
    public class Vendor_RegistrationFormFieldController : Controller
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        // GET: Vendor_RegistrationFormField
        public async Task<ActionResult> Index()
        {
            return View(await db.Vendor_RegistrationFormField.ToListAsync());
        }

        // GET: Vendor_RegistrationFormField/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor_RegistrationFormField vendor_RegistrationFormField = await db.Vendor_RegistrationFormField.FindAsync(id);
            if (vendor_RegistrationFormField == null)
            {
                return HttpNotFound();
            }
            return View(vendor_RegistrationFormField);
        }

        // GET: Vendor_RegistrationFormField/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendor_RegistrationFormField/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Vendor_RegistrationFormField_Id,VendorId,VendorProgramId,FieldName,FieldLabel,FieldTypeId,FieldDescription,Placeholder,ReferenceDataListId,Sequence,IsRequired,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Vendor_RegistrationFormField vendor_RegistrationFormField)
        {
            if (ModelState.IsValid)
            {
                db.Vendor_RegistrationFormField.Add(vendor_RegistrationFormField);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vendor_RegistrationFormField);
        }

        // GET: Vendor_RegistrationFormField/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor_RegistrationFormField vendor_RegistrationFormField = await db.Vendor_RegistrationFormField.FindAsync(id);
            if (vendor_RegistrationFormField == null)
            {
                return HttpNotFound();
            }
            return View(vendor_RegistrationFormField);
        }

        // POST: Vendor_RegistrationFormField/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Vendor_RegistrationFormField_Id,VendorId,VendorProgramId,FieldName,FieldLabel,FieldTypeId,FieldDescription,Placeholder,ReferenceDataListId,Sequence,IsRequired,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Vendor_RegistrationFormField vendor_RegistrationFormField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor_RegistrationFormField).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vendor_RegistrationFormField);
        }

        // GET: Vendor_RegistrationFormField/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor_RegistrationFormField vendor_RegistrationFormField = await db.Vendor_RegistrationFormField.FindAsync(id);
            if (vendor_RegistrationFormField == null)
            {
                return HttpNotFound();
            }
            return View(vendor_RegistrationFormField);
        }

        // POST: Vendor_RegistrationFormField/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vendor_RegistrationFormField vendor_RegistrationFormField = await db.Vendor_RegistrationFormField.FindAsync(id);
            db.Vendor_RegistrationFormField.Remove(vendor_RegistrationFormField);
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
