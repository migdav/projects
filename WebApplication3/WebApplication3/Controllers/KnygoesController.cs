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
    public class KnygoesController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();

        DataContext dbb = new DataContext();

        // GET: Knygoes
        public ActionResult Index()
        {
            var data = dbb.Knygos.SqlQuery("select * from knygos").ToList();
            return View(data);
        }

        // GET: Knygoes/Details/5
        public ActionResult Details(int? id)
        {
            var data = dbb.Knygos.SqlQuery("select * from knygos where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: Knygoes/Create
        public ActionResult CreateDouble()
        {
            ViewBag.KalbaId1 = new SelectList(dbb.Kalbos, "Id", "Pav");
            ViewBag.ZanrasId1 = new SelectList(dbb.Zanrai, "Id", "Pav");
            ViewBag.KalbaId2 = new SelectList(dbb.Kalbos, "Id", "Pav");
            ViewBag.ZanrasId2 = new SelectList(dbb.Zanrai, "Id", "Pav");
            return View("CreateDouble");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDouble(KnygoesDouble collection)
        {
           
            try
            {
         
                //// reikes viewbagu

                ViewBag.KalbaId1 = new SelectList(dbb.Kalbos, "Id", "Pav", collection.KalbaId1);
                ViewBag.kalbaId2 = new SelectList(dbb.Kalbos, "Id", "Pav", collection.KalbaId2);

                ViewBag.ZanrasId1 = new SelectList(dbb.Zanrai, "Id", "Pav", collection.ZanrasId1);
                ViewBag.ZanrasId2 = new SelectList(dbb.Zanrai, "Id", "Pav", collection.ZanrasId2);

                string command = String.Format("CreateAutoriaiIrKnygos @vardas='{0}' , @pavarde = '{1}' ," +
                    "@pav1 = '{2}',@Leidykla1 = '{3}', @Metai1 = {4}, @KalbaId1 = {5}, @ZanrasId1 = {6},"+
                    "@pav2 = '{7}',@Leidykla2 = '{8}', @Metai2 = {9}, @KalbaId2 = {10}, @ZanrasId2 = {11}", 
                    collection.Vardas,
                    collection.Pavarde,
                    collection.Pav1,
                    collection.Leidykla1,
                    collection.Metai1,
                    collection.KalbaId1,
                    collection.ZanrasId1,
                    collection.Pav2,
                    collection.Leidykla2,
                    collection.Metai2,
                    collection.KalbaId2,
                    collection.ZanrasId2
                    );

                dbb.Database.ExecuteSqlCommand(command);

                
                ViewBag.msg = "Naujos knygos pridėtos";

                return View("CreateDouble");

            }
            catch (Exception e)
            {
                return View("CreateDouble");
            }

        }

            // GET: Knygoes/Create
        public ActionResult Create()
        {
            ViewBag.AutoriusId = new SelectList((from s in dbb.Autoriai.ToList()
                                                 select new
                                                 {
                                                     AutoriusId = s.Id,
                                                     FullName = s.Vardas + " " + s.Pavarde
                                                 }), "AutoriusId", "FullName", null);
            ViewBag.KalbaId = new SelectList(dbb.Kalbos, "Id", "Pav");
            ViewBag.ZanrasId = new SelectList(dbb.Zanrai, "Id", "Pav");
            return View();
        }

        // POST: Knygoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Knygo collection)
        {
            try
            {
                List<object> lst = new List<object>();
                lst.Add(collection.Pav);
                lst.Add(collection.Leidykla);
                lst.Add(collection.Metai);

                lst.Add(collection.AutoriusId);
                lst.Add(collection.KalbaId);
                lst.Add(collection.ZanrasId);
                object[] allitems = lst.ToArray();
                int output = dbb.Database.ExecuteSqlCommand
                    ("insert into knygos(pav, leidykla, metai, autoriusId, kalbaId, zanrasId) " +
                    "values(@p0,@p1,@p2,@p3,@p4,@p5)", allitems);


                ViewBag.AutoriusId = new SelectList((from s in dbb.Autoriai.ToList()
                                                     select new
                                                     {
                                                         AutoriusId = s.Id,
                                                         FullName = s.Vardas + " " + s.Pavarde
                                                     }), "AutoriusId", "FullName", collection.AutoriusId);
                ViewBag.KalbaId = new SelectList(dbb.Kalbos, "Id", "Pav", collection.KalbaId);
                ViewBag.ZanrasId = new SelectList(dbb.Zanrai, "Id", "Pav", collection.ZanrasId);

                if (output > 0)
                {
                    ViewBag.msg = "Nauja knyga pridėta";
                }
                return View();
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Knygoes/Edit/5
        public ActionResult Edit(int id)
        {
            var data = dbb.Knygos.SqlQuery("select * from knygos where Id=@p0", id).SingleOrDefault();
            ViewBag.AutoriusId = new SelectList((from s in dbb.Autoriai.ToList()
                                                 select new
                                                 {
                                                     AutoriusId = s.Id,
                                                     FullName = s.Vardas + " " + s.Pavarde
                                                 }), "AutoriusId", "FullName", data.Autoriai.Id);
            ViewBag.KalbaId = new SelectList(dbb.Kalbos, "Id", "Pav", data.Kalbo.Id);
            ViewBag.ZanrasId = new SelectList(dbb.Zanrai, "Id", "Pav", data.Zanrai.Id);
            return View(data);
        }

        // POST: Knygoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Knygo collection)
        {
            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(collection.Pav);
                parameters.Add(collection.Leidykla);
                parameters.Add(collection.Metai);
                ViewBag.AutoriusId = new SelectList((from s in dbb.Autoriai.ToList()
                                                     select new
                                                     {
                                                         AutoriusId = s.Id,
                                                         FullName = s.Vardas + " " + s.Pavarde
                                                     }), "AutoriusId", "FullName", collection.AutoriusId);
                ViewBag.KalbaId = new SelectList(dbb.Kalbos, "Id", "Pav", collection.KalbaId);
                ViewBag.ZanrasId = new SelectList(dbb.Zanrai, "Id", "Pav", collection.ZanrasId);
                parameters.Add(collection.AutoriusId);
                parameters.Add(collection.KalbaId);
                parameters.Add(collection.ZanrasId);
                parameters.Add(collection.Id);
                object[] objectarray = parameters.ToArray();

                int output = dbb.Database.ExecuteSqlCommand("update knygos set pav=@p0,leidykla=@p1,metai=@p2,autoriusId=@p3,kalbaId=@p4,zanrasId=@p5 where Id=@p6", objectarray);
                if (output > 0)
                {
                    ViewBag.msg = "Redaguota knyga ";
                }
                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Knygoes/Delete/5
        public ActionResult Delete(int? id)
        {
            var data = dbb.Knygos.SqlQuery("select * from knygos where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Knygoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var list = dbb.Database.ExecuteSqlCommand("delete from knygos where Id=@p0", id);

                if (list != 0)
                {
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
