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
    public class KalboesController : Controller
    {
        //private Project_DBEntities db = new Project_DBEntities();

        DataContext dbb = new DataContext();
        // GET: Kalboes
        public ActionResult Index()
        {
            var data = dbb.Kalbos.SqlQuery("select * from kalbos").ToList();
            return View(data);
        }

        // GET: Kalboes/Details/5
        public ActionResult Details(int? id)
        {
            var data = dbb.Kalbos.SqlQuery("select * from kalbos where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: Kalboes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kalboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kalbo collection)
        {
            try
            {
                List<object> lst = new List<object>();
                lst.Add(collection.Pav);
                object[] allitems = lst.ToArray();
                int output = dbb.Database.ExecuteSqlCommand("insert into kalbos(pav) values(@p0)", allitems);
                if (output > 0)
                {
                    ViewBag.msg = "Nauja kalba pridėta";
                }
                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kalboes/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = dbb.Kalbos.SqlQuery("select * from kalbos where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Kalboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kalbo obj)
        {
            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(obj.Pav);
                parameters.Add(obj.Id);
                object[] objectarray = parameters.ToArray();

                int output = dbb.Database.ExecuteSqlCommand("update kalbos set pav=@p0 where Id=@p1", objectarray);
                if (output > 0)
                {
                    ViewBag.msg = "Redaguota kalba ";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Kalboes/Delete/5
        public ActionResult Delete(int id)
        {
            var data = dbb.Kalbos.SqlQuery("select * from kalbos where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Kalboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Autoriai collection)
        {
            try
            {
                var list = dbb.Database.ExecuteSqlCommand("delete from kalbos where Id=@p0", id);

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
