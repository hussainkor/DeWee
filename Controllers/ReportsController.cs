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
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult DeWeeReports()
		{
			return View();
		}

		public JsonResult GetReportLegend(int CId, int SId, int DId, int BId, int TypeOfEnterpriseId, int TypeofIndicator)
		{
			DataSet ds = SPManager.USP_GetReportLegend(CId, SId, DId, BId, TypeOfEnterpriseId, TypeofIndicator);
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

        public JsonResult GetSummaryBoxCount()
        {
            DataSet ds = SPManager.Usp_GetSummaryBoxCount();
            try
            {
                if (ds.Tables.Count > 0)
                {
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

        public JsonResult GetWeeklyReffreal()
		{
			DataTable dt = SPManager.SP_GetWeeklyReffreal();
			try
			{
				if (dt.Rows.Count > 0)
				{
					//ViewBag.Markers = JsonConvert.SerializeObject(ds);
					var dsdata = JsonConvert.SerializeObject(dt);
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

		public JsonResult GetWeeklyLeads()
		{
			DataTable dt = SPManager.SP_GetWeeklyLeads();
			try
			{
				if (dt.Rows.Count > 0)
				{
					//ViewBag.Markers = JsonConvert.SerializeObject(ds);
					var dsdata = JsonConvert.SerializeObject(dt);
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

		public JsonResult GetLeadsCategoriesAcross()
		{
			DataTable dt = SPManager.SP_GetLeadsCategoriesAcross();
			try
			{
				if (dt.Rows.Count > 0)
				{
					//ViewBag.Markers = JsonConvert.SerializeObject(ds);
					var dsdata = JsonConvert.SerializeObject(dt);
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

		public JsonResult GetTATReport()
		{
			DataTable dt = SPManager.SP_GetTATReport();
			try
			{
				if (dt.Rows.Count > 0)
				{
					var dsdata = JsonConvert.SerializeObject(dt);
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

		public ActionResult TATList()
		{
			return View();
		}
		public JsonResult GetTATList(string districtIds, string blockIds)
		{
			DataTable dt = SPManager.SP_GetTATList(districtIds, blockIds);
			try
			{
				if (dt.Rows.Count > 0)
				{
					var dsdata = JsonConvert.SerializeObject(dt);
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

		public JsonResult GetEnterprisesSolarized()
		{
			DataTable dt = SPManager.SP_GetEnterprisesSolarized();
			try
			{
				if (dt.Rows.Count > 0)
				{
					//ViewBag.Markers = JsonConvert.SerializeObject(ds);
					var dsdata = JsonConvert.SerializeObject(dt);
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

		public JsonResult GetPerformingDistricts()
		{
			DataTable dt = SPManager.SP_GetPerformingDistricts();
			try
			{
				if (dt.Rows.Count > 0)
				{
					//ViewBag.Markers = JsonConvert.SerializeObject(ds);
					var dsdata = JsonConvert.SerializeObject(dt);
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

		public JsonResult GetSolarShopsMapped()
		{
			DataTable dt = SPManager.SP_GetDistrictsWith_SolarShopsMapped();
			try
			{
				if (dt.Rows.Count > 0)
				{
					//ViewBag.Markers = JsonConvert.SerializeObject(ds);
					var dsdata = JsonConvert.SerializeObject(dt);
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
	}
}