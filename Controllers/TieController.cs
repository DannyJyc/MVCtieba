using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tb.Controllers
{
    public class TieController : Controller
    {
        // GET: Ti
        Models.MvctbEntities db = new Models.MvctbEntities();
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                id = Convert.ToInt16(TempData["ba_id"]);
            }
            List<Models.Tie> list = db.Ties.Where(b => b.Ba_id == id).OrderByDescending(b => b.createdate).ToList();
            TempData["ba_id"] = id;
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            tb.Models.Tie insert = new Models.Tie();
            return View(insert);
        }

        [HttpPost]
        public ActionResult Add(tb.Models.Tie n)
        {
            n.createdate = DateTime.Now;
            n.Ba_id = Convert.ToInt16(TempData["ba_id"]);
            db.Ties.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Del(int id)
        {
            db.Ties.Remove(db.Ties.Where(t => t.id == id).FirstOrDefault());
            db.hfs.RemoveRange(db.hfs.Where(h => h.TieContent_id == id).ToList());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}