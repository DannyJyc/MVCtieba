using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace student.Controllers
{
    public class BaController : Controller
    {
        // GET: Ba
        Models.MvctbEntities1 db = new Models.MvctbEntities1();
        public ActionResult Index()
        {
            List<Models.Ba> list = db.Bas.OrderByDescending(b => b.createdate).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            student.Models.Ba insert = new Models.Ba();
            return View(insert);
        }

        [HttpPost]
        public ActionResult Add(student.Models.Ba n)
        {
            n.createdate = DateTime.Now;
            db.Bas.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}