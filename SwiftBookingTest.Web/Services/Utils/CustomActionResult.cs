using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Utils
{
    public class CustomActionResult : ActionResult
    {
        public CustomActionResult(object data, JsonRequestBehavior jsonRequestBehavior)
        {
            Data = data;
            JsonRequestBehavior = jsonRequestBehavior;
        }
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public object Data { get; set; }
        public JsonRequestBehavior JsonRequestBehavior { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            if (Data == null) return;
            response.Write(JsonConvert.SerializeObject(Data));
        }
    }
}