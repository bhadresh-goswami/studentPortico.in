using StudentPortico.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentPortico.Areas.Administrator.Controllers
{
    public class CountryManageController : Controller
    {
        private dbStudentEntities db = new dbStudentEntities();
        // GET: Administrator/CountryManage
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getCountry()
        {
            return Json(db.CountryMasters.Select(a => new { a.CountryId, a.CountryName, a.IsCountryEnabled }).ToList(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public string addCountryDetails(string CountryName, bool CountryIsEnabled)
        {
            try
            {

                CountryMaster countryMaster = new CountryMaster()
                {
                    CountryName = CountryName,
                    IsCountryEnabled = CountryIsEnabled
                };

                db.CountryMasters.Add(countryMaster);
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "Country Details Add Successfuly!";
        }

        [HttpPost]
        public string updateCountryDetails(string CountryName, bool CountryIsEnabled, int countryId)
        {
            try
            {

                CountryMaster countryMaster = db.CountryMasters.SingleOrDefault(a => a.CountryId == countryId);
                if(countryMaster!=null)
                {

                    countryMaster.CountryName = CountryName;
                    countryMaster.IsCountryEnabled = CountryIsEnabled;
                }
                else
                {
                    return "Country Not Found!";
                }

                
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "Country Details Updated Successfuly!";
        }

        [HttpDelete]
        public string deleteCountryDetails(int id)
        {
            try
            {

                CountryMaster countryMaster = db.CountryMasters.SingleOrDefault(a => a.CountryId == id);
                if (countryMaster != null)
                {
                    db.CountryMasters.Remove(countryMaster);
                }
                else
                {
                    return "Country Not Found!";
                }


                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return "Error:" + ex.Message;
            }
            return "Country Details Deleted Successfuly!";
        }

    }
}