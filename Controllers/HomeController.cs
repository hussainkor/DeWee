using DeWee.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeWee.Controllers
{
    [Authorize]
    [SessionCheck]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDashboadLegend(int CId, int SId, int DId, int BId, int TypeOfEnterpriseId, int TypeofIndicator)
        {
            DataSet ds = SPManager.USP_GetDashboardLegend(CId, SId,DId,BId,TypeOfEnterpriseId,TypeofIndicator);
            try
            {
                if (ds.Tables.Count > 0)
                {
                    //ViewBag.Markers = JsonConvert.SerializeObject(ds);
                    var dsdata = JsonConvert.SerializeObject(ds);
                    return Json(new { IsSuccess = true, Data = dsdata }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { IsSuccess = false, Data = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Data = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult ImageLoad()
        {
            return View();
        }
    }
}