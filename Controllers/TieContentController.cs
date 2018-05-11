using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using student.Models;
using student.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace student.Controllers
{
    public class TieContentController : Controller
    {
        // GET: TieContent
        Models.MvctbEntities1 db = new Models.MvctbEntities1();

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                id = Convert.ToInt16(TempData["Tie_id"]);
            }
            student.DAL.Hf_DAL a = new Hf_DAL();
            ViewBag.a = a;
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
            student.Models.TieContent insert = new Models.TieContent();

            return View(insert);
        }

        [HttpPost]
        public ActionResult Add(student.Models.TieContent n)
        {
            n.createdate = DateTime.Now;
            n.Tie_id = Convert.ToInt16(TempData["Tie_id"]);
            db.TieContents.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddtoHf(int? id)
        {
            student.Models.hf insert = new Models.hf();
            if (id != null)
            {
                TempData["id"] = id;
            }

            return View(insert);
        }

        [HttpPost]
        public ActionResult AddtoHf(student.Models.hf n)
        {
            n.createdate = DateTime.Now;
            n.TieContent_id = Convert.ToInt16(TempData["id"]);
            db.hfs.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TestJson(int id)
        {
            Models.Tie tie1 = db.Ties.Where(t => t.id == id).FirstOrDefault();
            List<Models.TieContent> tieclist = db.TieContents.Where(t=>t.Tie_id==id).ToList();
            string str = "[";
            int j = 1;
            foreach (var item in tieclist)
            {
                List<Models.hf> hf = db.hfs.Where(h => h.TieContent_id == item.id).ToList();
                if (hf.Count == 0)
                {
                    str += "{\"tiecontent\":\"" + item.tie_content + "\"";
                }
                else
                {
                    str += "{\"tiecontent\":\"" + item.tie_content + "\",\"hf\":[";

                }
                int i = 1;
                foreach (var item1 in hf)
                {
                    if (i != hf.Count)
                    {
                        str += "{\"tiecontent\":\"" + item1.hf_content + "\"},";
                    }
                    else
                    {
                        str+= "{\"tiecontent\":\"" + item1.hf_content + "\"}]";
                    }

                    i++;
                    
                }

                if (j != tieclist.Count)
                {
                    str += "},";
                }
                else
                {
                    str += "}]";
                }

                j++;
            }
            student.DAL.JsonChange a = new JsonChange();
            var b = a.JsonToObject(str);
            ViewBag.j= b;
            return View();
        }
        /// <summary>
        /// { "Name": "Mark", "Age": "8", "Results": [ { "Subject": "语文", "Score": 100 }, { "Subject": "数学", "Score": 88 } ] }
        /// </summary>
        /// <returns></returns>
        public JObject GetResults()
        {
            var mark = new JObject { { "Name", "Mark" }, { "Age", "8" } };
            var results = new JArray
            {
                new JObject {{ "Subject", "语文"}, { "Score", 100}},
                new JObject {{ "Subject", "数学" }, { "Score", 88}}
            };
            mark.Add("Results", results);
            return mark;
        }


    }
}
