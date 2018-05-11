using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace student.DAL
{
    public class JsonChange
    {
        public dynamic StrJsonResult(string n)
        {
            var a = Json.Decode(n);
            return a;
        }

        public object JsonToObject(string jsonString)
        {
            return JsonConvert.DeserializeObject(jsonString);
        }

    }
}