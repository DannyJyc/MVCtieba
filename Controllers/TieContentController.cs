using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tb.Controllers
{
    public class TieContentController : Controller
    {
        // GET: TieContent
        Models.MvctbEntities db = new Models.MvctbEntities();

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                id = Convert.ToInt16(TempData["Tie_id"]);
            }
            var tielist = db.Ties.Where(t => t.id == id).FirstOrDefault();
            ViewData["tie_title"] = tielist.tie_title;
            ViewData["tie_content"] = tielist.tie_content;
            ViewData["createdate"] = tielist.createdate;
            TempData["Tie_id"] = id;
            List<Models.TieContent> tieclist = db.TieContents.Where(tc => tc.Tie_id == id).ToList();
            return View(tieclist);
        }

        [HttpGet]
        public ActionResult Add()
        {
            tb.Models.TieContent insert = new Models.TieContent();
            return View(insert);
        }

        [HttpPost]
        public ActionResult Add(tb.Models.TieContent n)
        {
            n.createdate = DateTime.Now;
            n.Tie_id = Convert.ToInt16(TempData["Tie_id"]);
            db.TieContents.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}