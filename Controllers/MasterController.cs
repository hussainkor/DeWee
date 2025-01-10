using DeWee.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeWee.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        #region Master List
        public ActionResult GetStateList(int SelectAll)
        {
            try
            {
                var items = CommonModel.GetALLStateM(SelectAll);
                if (items != null)
                {
                    if (items.Count > 0)
                    {
                        var data = JsonConvert.SerializeObject(items);
                        return Json(new { IsSuccess = true, res = data }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { IsSuccess = false, res = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { IsSuccess = false, res = "There was a communication error." }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDistrictList(int SelectAll, int SId)
        {
            try
            {
                var items = CommonModel.GetALLDistrictM(SelectAll, SId);
                if (items != null)
                {
                    if (items.Count > 0)
                    {
                        var data = JsonConvert.SerializeObject(items);
                        return Json(new { IsSuccess = true, res = data }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetBlockList(int SelectAll, int SId, int DId)
        {
            try
            {
                var items = CommonModel.GetALLBlockM(SelectAll, SId, DId);
                if (items != null)
                {
                    if (items.Count > 0)
                    {
                        var data = JsonConvert.SerializeObject(items);
                        return Json(new { IsSuccess = true, res = data }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCLFList(int SelectAll, int SId, int DId, int BId)
        {
            try
            {
                var items = CommonModel.GetALLCLFM(SelectAll, SId, DId, BId);
                if (items != null)
                {
                    if (items.Count > 0)
                    {
                        var data = JsonConvert.SerializeObject(items);
                        return Json(new { IsSuccess = true, res = data }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPanchayatList(int SelectAll, int SId, int DId, int BId)
        {
            try
            {
                var items = CommonModel.GetALLPanchayatM(SelectAll, SId, DId, BId);
                if (items != null)
                {
                    if (items.Count > 0)
                    {
                        var data = JsonConvert.SerializeObject(items);
                        return Json(new { IsSuccess = true, res = data }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetVillageList(int SelectAll, int SId, int DId, int BId, int PId)
        {
            try
            {
                var items = CommonModel.GetALLVillM(SelectAll, SId, DId, BId, PId);
                if (items != null)
                {
                    if (items.Count > 0)
                    {
                        var data = JsonConvert.SerializeObject(items);
                        return Json(new { IsSuccess = true, res = data }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetVOList(int SelectAll, int SId, int DId, int BId, int PId, int CId, int VId)
        {
            try
            {
                var items = CommonModel.GetALLVO(SelectAll, SId, DId, BId, PId, CId,VId);
                if (items != null)
                {
                    if (items.Count > 0)
                    {
                        var data = JsonConvert.SerializeObject(items);
                        return Json(new { IsSuccess = true, res = data }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { IsSuccess = false, res = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

    }
}