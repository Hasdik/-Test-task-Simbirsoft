using LastTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastTestProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllMailAdress()
        {
            MailContext db = new MailContext();
            List<Mailserver> list = db.mailservers.ToList();
            JsonResult json = Json(list, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
        public JsonResult GetAllMailAdressEN()
        {

            MailContextEN db = new MailContextEN();
            List<MailserverEN> list = db.mailserverEN.ToList();
            JsonResult json = Json(list, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }
    }
}