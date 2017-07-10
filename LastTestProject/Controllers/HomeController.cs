using LastTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace LastTestProject.Controllers
{
    public class HomeController : Controller
    {
        JsonResult json;
        JsonResult jsonen;
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllMailAdress()
        {
            try
            {
                MailContext db = new MailContext();
                List<Mailserver> list = db.mailservers.ToList();
                json = Json(list, JsonRequestBehavior.AllowGet);
                json.MaxJsonLength = int.MaxValue;
            }
            catch (Exception ex)
            {
                StreamWriter writer = new StreamWriter("C:\\Log.txt", true);
                writer.WriteLine(ex.Message);
                writer.Close();
            }
            return json;
        }
        public JsonResult GetAllMailAdressEN()
        {
            try
            {
                MailContextEN db = new MailContextEN();
                List<MailserverEN> list = db.mailserverEN.ToList();
                jsonen = Json(list, JsonRequestBehavior.AllowGet);
                jsonen.MaxJsonLength = int.MaxValue;
            }
            catch (Exception ex)
            {
                using (FileStream fstream = new FileStream(@"C:\Logerror.txt", FileMode.OpenOrCreate))
                {
                    byte[] input = Encoding.Default.GetBytes(ex.Message);
                    fstream.Write(input, 0, input.Length);
                    fstream.Flush();
                    fstream.Close();
                }
            }
            return jsonen;
        }
    }
}