using lab_task.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_task.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var db = new LabTaskEntities2();
            var data = db.Products.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Register(int customerId, int[] Products)
        {
            var db = new LabTaskEntities2();
            foreach (var p in Products)
            {
                var cs = new Order()
                {
                    Cid = customerId,
                    Pid = p,
                    Time= DateTime.Now,
                };
                db.Orders.Add(cs);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login(int Id)
        {
            var db = new LabTaskEntities2();
           // var data = db.Products.Find(id);
            var data = (from d in db.Customers
                    where d.Id == Id
                      select d).SingleOrDefault();
            return View(data);
        }

    }
}