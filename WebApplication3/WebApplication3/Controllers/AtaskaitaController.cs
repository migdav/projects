using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using System.Data.SqlClient;

namespace WebApplication3.Controllers
{
    public class AtaskaitaController : Controller
    {
        private Project_DBEntities db = new Project_DBEntities();
        
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ataskaita obj)
        {
            int a = obj.NUO;
            int b = obj.IKI;
            int v = obj.viso;
            Session["nuo"] = a;
            Session["iki"] = b;
            Session["viso"] = v;

            return RedirectToAction("List");
        }

        public ActionResult List()
        {

            int sk1 = (int)Session["nuo"];
            int sk2 = (int)Session["iki"];
            int viso = (int)Session["viso"];
            ViewBag.msg = sk1 + sk2;

            var data = db.Ataskaitas.SqlQuery("select * from Ataskaita " +
                "where uzsakymoId >= @p0 AND uzsakymoId <= @p1 AND leidiniai <= @p2 " +
                "order by pavarde, vardas", sk1, sk2, viso).ToList();
            
            return View(data);
        }

    }
}