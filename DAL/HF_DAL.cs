using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace student.DAL
{
    public class Hf_DAL
    {
        Models.MvctbEntities1 db = new Models.MvctbEntities1();

        public List<Models.hf> List(int id)
        {
            List<Models.hf> list = db.hfs.Where(tc=>tc.TieContent_id==id).ToList();
            return list;
        }
    }
}