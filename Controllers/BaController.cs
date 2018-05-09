using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tb.Controllers
{
    public class BaController : Controller
    {
        // GET: Ba
        Models.MvctbEntities db = new Models.MvctbEntities();
        public ActionResult Index()
        {
            List<Models.Ba> list = db.Bas.OrderByDescending(b => b.createdate).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            tb.Models.Ba insert = new Models.Ba();
            return View(insert);
        }

        [HttpPost]
        public ActionResult Add(tb.Models.Ba n)
        {
            n.createdate = DateTime.Now;
            db.Bas.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}