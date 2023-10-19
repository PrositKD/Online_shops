using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab_task.EF;

namespace lab_task.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new LabTaskEntities2();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new LabTaskEntities2();
            var data = db.Products.Find(id);
            //var data = (from d in db.Departments
            //            where d.Id == id
            //            select d).SingleOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Product d)
        {
            var db = new LabTaskEntities2();
            var ex = db.Products.Find(d.Id);
            ex.pName = d.pName;
             ex.price = d.price;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var db = new LabTaskEntities2();
            var ex = db.Products.Find(id);
            db.Products.Remove(ex);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product d)
        {
            var db = new LabTaskEntities2();
            db.Products.Add(d);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}