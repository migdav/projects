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
    public class ZanraisController : Controller
    {
        //private Project_DBEntities db = new Project_DBEntities();

        DataContext dbb = new DataContext();
        // GET: Zanrais
        public ActionResult Index()
        {
            var data = dbb.Zanrai.SqlQuery("select * from zanrai").ToList();
            return View(data);
        }

        // GET: Zanrais/Details/5
        public ActionResult Details(int? id)
        {
            var data = dbb.Zanrai.SqlQuery("select * from zanrai where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: Zanrais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zanrais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Zanrai collection)
        {
            try
            {
                List<object> lst = new List<object>();
                lst.Add(collection.Pav);
                object[] allitems = lst.ToArray();
                int output = dbb.Database.ExecuteSqlCommand("insert into zanrai(pav) values(@p0)", allitems);
                if (output > 0)
                {
                    ViewBag.msg = "Naujas žanras pridėtas";
                }
                return View();

                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Zanrais/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = dbb.Zanrai.SqlQuery("select * from zanrai where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Zanrais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Zanrai obj)
        {
            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(obj.Pav);
                parameters.Add(obj.Id);
                object[] objectarray = parameters.ToArray();

                int output = dbb.Database.ExecuteSqlCommand("update zanrai set pav=@p0 where Id=@p1", objectarray);
                if (output > 0)
                {
                    ViewBag.msg = "Redaguotas žanras ";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Zanrais/Delete/5
        public ActionResult Delete(int id)
        {
            var data = dbb.Zanrai.SqlQuery("select * from zanrai where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Zanrais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Autoriai collection)
        {
            try
            {
                var list = dbb.Database.ExecuteSqlCommand("delete from zanrai where Id=@p0", id);

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
