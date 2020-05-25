using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Views
{
    public class UzsakymaisController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        // GET: Uzsakymais
        public ActionResult Index()
        {
            //var uzsakymais = db.Uzsakymais.Include(u => u.Biblioteko).Include(u => u.Skaitytojai);
            //return View(uzsakymais.ToList());
            return View(db.function_simple(2, 5).ToList());
        }

        // GET: Uzsakymais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymai uzsakymai = db.Uzsakymais.Find(id);
            if (uzsakymai == null)
            {
                return HttpNotFound();
            }
            return View(uzsakymai);
        }

        // GET: Uzsakymais/Create
        public ActionResult Create()
        {
            ViewBag.BibliotekaId = new SelectList(db.Bibliotekos, "Id", "Pav");
            ViewBag.SkaitytojasId = new SelectList(db.Skaitytojais, "Id", "Vardas");
            return View();
        }

        // POST: Uzsakymais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Uzsakymo_Data,Grazinimo_Data,SkaitytojasId,BibliotekaId")] Uzsakymai uzsakymai)
        {
            if (ModelState.IsValid)
            {
                db.Uzsakymais.Add(uzsakymai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BibliotekaId = new SelectList(db.Bibliotekos, "Id", "Pav", uzsakymai.BibliotekaId);
            ViewBag.SkaitytojasId = new SelectList(db.Skaitytojais, "Id", "Vardas", uzsakymai.SkaitytojasId);
            return View(uzsakymai);
        }

        // GET: Uzsakymais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymai uzsakymai = db.Uzsakymais.Find(id);
            if (uzsakymai == null)
            {
                return HttpNotFound();
            }
            ViewBag.BibliotekaId = new SelectList(db.Bibliotekos, "Id", "Pav", uzsakymai.BibliotekaId);
            ViewBag.SkaitytojasId = new SelectList(db.Skaitytojais, "Id", "Vardas", uzsakymai.SkaitytojasId);
            return View(uzsakymai);
        }

        // POST: Uzsakymais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Uzsakymo_Data,Grazinimo_Data,SkaitytojasId,BibliotekaId")] Uzsakymai uzsakymai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzsakymai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BibliotekaId = new SelectList(db.Bibliotekos, "Id", "Pav", uzsakymai.BibliotekaId);
            ViewBag.SkaitytojasId = new SelectList(db.Skaitytojais, "Id", "Vardas", uzsakymai.SkaitytojasId);
            return View(uzsakymai);
        }

        // GET: Uzsakymais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymai uzsakymai = db.Uzsakymais.Find(id);
            if (uzsakymai == null)
            {
                return HttpNotFound();
            }
            return View(uzsakymai);
        }

        // POST: Uzsakymais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzsakymai uzsakymai = db.Uzsakymais.Find(id);
            db.Uzsakymais.Remove(uzsakymai);
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
