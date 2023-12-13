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
    public class DeclarationsController : Controller
    {
        private RQVEntities1 db = new RQVEntities1();

        // GET: Declarations
        public ActionResult Index()
        {
            var declaration = db.Declaration.Include(d => d.ObjectCategory).Include(d => d.Users);
            return View(declaration.ToList());
        }

        // GET: Declarations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Declaration declaration = db.Declaration.Find(id);
            if (declaration == null)
            {
                return HttpNotFound();
            }
            return View(declaration);
        }

        // GET: Declarations/Create
        public ActionResult Create()
        {
            ViewBag.objectCat_id = new SelectList(db.ObjectCategory, "id", "name");
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name");
            return View();
        }

        // POST: Declarations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "declaration_id,user_id,objectCat_id,object_name,obj_description,vol_date,place,decl_date,user_role,statut")] Declaration declaration)
        {
            if (ModelState.IsValid)
            {
                db.Declaration.Add(declaration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.objectCat_id = new SelectList(db.ObjectCategory, "id", "name", declaration.objectCat_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name", declaration.user_id);
            return View(declaration);
        }

        // GET: Declarations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Declaration declaration = db.Declaration.Find(id);
            if (declaration == null)
            {
                return HttpNotFound();
            }
            ViewBag.objectCat_id = new SelectList(db.ObjectCategory, "id", "name", declaration.objectCat_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name", declaration.user_id);
            return View(declaration);
        }

        // POST: Declarations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "declaration_id,user_id,objectCat_id,object_name,obj_description,vol_date,place,decl_date,user_role,statut")] Declaration declaration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(declaration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.objectCat_id = new SelectList(db.ObjectCategory, "id", "name", declaration.objectCat_id);
            ViewBag.user_id = new SelectList(db.Users, "id", "first_name", declaration.user_id);
            return View(declaration);
        }

        // GET: Declarations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Declaration declaration = db.Declaration.Find(id);
            if (declaration == null)
            {
                return HttpNotFound();
            }
            return View(declaration);
        }

        // POST: Declarations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Declaration declaration = db.Declaration.Find(id);
            db.Declaration.Remove(declaration);
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
