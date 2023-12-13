using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeclarationDeVol.Models;

namespace DeclarationDeVol.Controllers
{
    public class ObjectCategoriesController : Controller
    {
        private RQVEntities1 db = new RQVEntities1();

        // GET: ObjectCategories
        public ActionResult Index()
        {
            return View(db.ObjectCategory.ToList());
        }

        // GET: ObjectCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectCategory objectCategory = db.ObjectCategory.Find(id);
            if (objectCategory == null)
            {
                return HttpNotFound();
            }
            return View(objectCategory);
        }

        // GET: ObjectCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ObjectCategories/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] ObjectCategory objectCategory)
        {
            if (ModelState.IsValid)
            {
                db.ObjectCategory.Add(objectCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objectCategory);
        }

        // GET: ObjectCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectCategory objectCategory = db.ObjectCategory.Find(id);
            if (objectCategory == null)
            {
                return HttpNotFound();
            }
            return View(objectCategory);
        }

        // POST: ObjectCategories/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] ObjectCategory objectCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objectCategory);
        }

        // GET: ObjectCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectCategory objectCategory = db.ObjectCategory.Find(id);
            if (objectCategory == null)
            {
                return HttpNotFound();
            }
            return View(objectCategory);
        }

        // POST: ObjectCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjectCategory objectCategory = db.ObjectCategory.Find(id);
            db.ObjectCategory.Remove(objectCategory);
            db.SaveChanges();
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
