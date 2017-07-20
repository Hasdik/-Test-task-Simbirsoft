using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using LastTestProject.Models;

namespace LastTestProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getData()
        {
            //Параметр Datatable
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //Параметр пагинации
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //параметр сортировки
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //параметр фильтрации
            var IDF = Request.Form.GetValues("columns[0][search][value]").GetValue(0);
            var CountryF = Request.Form.GetValues("columns[1][search][value]").GetValue(0);
            var CityF = Request.Form.GetValues("columns[2][search][value]").GetValue(0);
            var StreetF = Request.Form.GetValues("columns[3][search][value]").GetValue(0);
            var HouseF = Request.Form.GetValues("columns[4][search][value]").GetValue(0);
            var IndexF = Request.Form.GetValues("columns[5][search][value]").GetValue(0);
            var DateF = Request.Form.GetValues("columns[6][search][value]").GetValue(0);

            List<Mail> allCustomer = new List<Mail>();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (DBEntities dc = new DBEntities())
            {
                //фильтрация
                var v = (from a in dc.Mail select a);
                v = v.Where(a =>
                    a.Id.ToString().Contains(IDF.ToString()) &&
                    a.Country.Contains(CountryF.ToString()) &&
                    a.City.Contains(CityF.ToString()) &&
                    a.Street.Contains(StreetF.ToString()) &&
                    a.House.ToString().Contains(HouseF.ToString()) &&
                    a.Index.ToString().Contains(IndexF.ToString()) &&
                    a.Date.ToString().Contains(DateF.ToString())
                    );

                //сортировка
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    v = v.OrderBy(sortColumn + " " + sortColumnDir);
                }

                recordsTotal = v.Count();
                allCustomer = v.Skip(skip).Take(pageSize).ToList();
            }

            return Json(new { recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = allCustomer });
        }
        public ActionResult getDataEN()
        {
            //Параметр Datatable
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            //Параметр пагинации
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //параметр сортировки
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            //параметр фильтрации
            var IDF = Request.Form.GetValues("columns[0][search][value]").GetValue(0);
            var CountryF = Request.Form.GetValues("columns[1][search][value]").GetValue(0);
            var CityF = Request.Form.GetValues("columns[2][search][value]").GetValue(0);
            var StreetF = Request.Form.GetValues("columns[3][search][value]").GetValue(0);
            var HouseF = Request.Form.GetValues("columns[4][search][value]").GetValue(0);
            var IndexF = Request.Form.GetValues("columns[5][search][value]").GetValue(0);
            var DateF = Request.Form.GetValues("columns[6][search][value]").GetValue(0);

            List<MailEN> allCustomer = new List<MailEN>();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (DBEntities dc = new DBEntities())
            {
                var v = (from a in dc.MailEN select a);
                v = v.Where(a =>
                    a.Id.ToString().Contains(IDF.ToString()) &&
                    a.Country.Contains(CountryF.ToString()) &&
                    a.City.Contains(CityF.ToString()) &&
                    a.Street.Contains(StreetF.ToString()) &&
                    a.House.ToString().Contains(HouseF.ToString()) &&
                    a.Index.ToString().Contains(IndexF.ToString()) &&
                    a.Date.ToString().Contains(DateF.ToString())
                    );

                //сортировка
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    v = v.OrderBy(sortColumn + " " + sortColumnDir);
                }

                recordsTotal = v.Count();
                allCustomer = v.Skip(skip).Take(pageSize).ToList();
            }

            return Json(new { recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = allCustomer });
        }
    }
}