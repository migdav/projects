using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class SkaitytojaisController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        DataContext dbb = new DataContext();
        
        // GET: Skaitytojais
        public ActionResult Index()
        {
            var data = dbb.Skaitytojai.SqlQuery("select * from skaitytojai").ToList();
            return View(data);
        }


        // GET: Skaitytojais/Create
        public ActionResult Create()
        {
            ViewBag.BibliotekaId1 = new SelectList(db.Bibliotekos, "Id", "Pav");
            ViewBag.TipasId1 = new SelectList(db.Tipais, "Id", "Pav");
            ViewBag.BibliotekaId2 = new SelectList(db.Bibliotekos, "Id", "Pav");
            ViewBag.TipasId2 = new SelectList(db.Tipais, "Id", "Pav");
            return View();
        }

        // POST: Skaitytojais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SkaitytojaiDouble collection)
        {

            try
            {
                List<object> lstA = new List<object>();
                List<object> lstB = new List<object>();
                lstA.Add(collection.kodas1);
                lstB.Add(collection.kodas2);

                lstA.Add(collection.Vardas1);
                lstB.Add(collection.Vardas2);

                lstA.Add(collection.Pavarde1);
                lstB.Add(collection.Pavarde2);

                lstA.Add(collection.Gimimo_metai1);
                lstB.Add(collection.Gimimo_metai2);

                lstA.Add(collection.TelefonoNr1);
                lstB.Add(collection.TelefonoNr2);

                lstA.Add(collection.Email1);
                lstB.Add(collection.Email2);

                // reikes viewbagu

                ViewBag.TipasId1 = new SelectList(db.Tipais, "Id", "Pav", collection.TipasId1);
                ViewBag.TipasId2 = new SelectList(db.Tipais, "Id", "Pav", collection.TipasId2);
                lstA.Add(collection.TipasId1);
                lstB.Add(collection.TipasId2);

                ViewBag.BibliotekaId1 = new SelectList(db.Bibliotekos, "Id", "Pav", collection.BibliotekaId1);
                ViewBag.BibliotekaId2 = new SelectList(db.Bibliotekos, "Id", "Pav", collection.BibliotekaId2);
                lstA.Add(collection.BibliotekaId1);
                lstB.Add(collection.BibliotekaId2);


                object[] allitemsA = lstA.ToArray();
                object[] allitemsB = lstB.ToArray();
                int output = dbb.Database.ExecuteSqlCommand("insert into skaitytojai(kodas,vardas,pavarde,gimimo_metai," +
                    "telefonoNr,email,bibliotekaId,tipasId) values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)",allitemsA);
                int outputt = dbb.Database.ExecuteSqlCommand("insert into skaitytojai(kodas,vardas,pavarde,gimimo_metai," +
                    "telefonoNr,email,bibliotekaId,tipasId) values(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)", allitemsB);

                ViewBag.msg = "Nauji skaitytojai pridėti";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Skaitytojais/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = dbb.Skaitytojai.SqlQuery("select * from skaitytojai where Id=@p0", id).SingleOrDefault();
            ViewBag.BibliotekaId = new SelectList(db.Bibliotekos, "Id", "Pav", data.Biblioteko.Id);
            ViewBag.TipasId = new SelectList(db.Tipais, "Id", "Pav", data.Tipai.Id);
            return View(data);
        }

        // POST: Skaitytojais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Skaitytojai collection)
        {

            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(collection.kodas);
                parameters.Add(collection.Vardas);
                parameters.Add(collection.Pavarde);
                parameters.Add(collection.Gimimo_metai);
                parameters.Add(collection.TelefonoNr);
                parameters.Add(collection.Email);

                ViewBag.BibliotekaId = new SelectList(dbb.Kalbos, "Id", "Pav", collection.BibliotekaId);
                ViewBag.TipasId = new SelectList(dbb.Zanrai, "Id", "Pav", collection.TipasId);
                parameters.Add(collection.BibliotekaId);
                parameters.Add(collection.TipasId);
                parameters.Add(collection.Id);
                object[] objectarray = parameters.ToArray();

                int output = dbb.Database.ExecuteSqlCommand("update skaitytojai set kodas=@p0,vardas=@p1," +
                    "pavarde=@p2,gimimo_metai=@p3,telefonoNr=@p4,email=@p5,bibliotekaId=@p6,tipasId=@p7 " +
                    "where Id=@p8",objectarray);
                if (output > 0)
                {
                    ViewBag.msg = "Redaguotas skaitytojas ";
                }
                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skaitytojais/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = dbb.Skaitytojai.SqlQuery("select * from skaitytojai where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Skaitytojais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var list = dbb.Database.ExecuteSqlCommand("delete from skaitytojai where Id=@p0", id);

                if (list != 0)
                {
                    //We will go back to action ProductDelete to show updated records
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
