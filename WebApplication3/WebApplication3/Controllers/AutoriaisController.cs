using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using MySql.Data.MySqlClient;

namespace WebApplication3.Controllers
{
    public class AutoriaisController : Controller
    {
        //private Project_DBEntities db = new Project_DBEntities();
        
        DataContext dbb = new DataContext();
        // GET: Autoriais
        public ActionResult Index()
        {
            //??? 
            var data = dbb.Autoriai.SqlQuery("select * from autoriai").ToList();
            return View(data);
        }

        //GET: Autoriais/Details/5
        public ActionResult Details(int? id)
        {
            var data = dbb.Autoriai.SqlQuery("select * from autoriai where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // GET: Autoriais/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutoriaiDouble collection)
        {
            try
            {
                List<object> lst = new List<object>();
                lst.Add(collection.Vardas1);
                lst.Add(collection.Pavarde1);
                lst.Add(collection.Vardas2);
                lst.Add(collection.Pavarde2);
                object[] allitems = lst.ToArray();
                int output;
                for (int i = 0; i < allitems.Length; i += 2)
                {
                    output = dbb.Database.ExecuteSqlCommand("insert into autoriai(vardas, pavarde) values(@p0,@p1)",
                        allitems[i], allitems[i + 1]);
                }
                    ViewBag.msg = "Nauji autoriai pridėtas";
                return View();
            }
            catch
            {
                return View();
            }
        }

        //GET: Autoriais/Edit/5
        public ActionResult Edit(int? id)
        {
            var data = dbb.Autoriai.SqlQuery("select * from autoriai where Id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Autoriais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Autoriai obj)
        {
            try
            {
                List<object> parameters = new List<object>();
                parameters.Add(obj.Vardas);
                parameters.Add(obj.Pavarde);
                parameters.Add(obj.Id);
                object[] objectarray = parameters.ToArray();

                int output = dbb.Database.ExecuteSqlCommand("update autoriai set vardas=@p0,pavarde=@p1 where Id=@p2", objectarray);
                if (output > 0)
                {
                    ViewBag.msg = "Redaguotas autorius ";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Autoriais/Delete/5
        public ActionResult Delete(int id)
        {
            var data = dbb.Autoriai.SqlQuery("select * from autoriai where Id=@p0", id).SingleOrDefault();
            return View(data);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Autoriai collection)
        {
            try
            {
                var list = dbb.Database.ExecuteSqlCommand("delete from autoriai where Id=@p0", id);

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



           