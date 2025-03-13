using DeWee.Manager;
using DeWee.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace DeWee.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        private DeWee_DBEntities db = new DeWee_DBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddPanchayat()
        {
            return View();
        }
        //[HttpPost]
        //public JsonResult AddPanchayat(PanchayatModel model)
        //{
        //    try
        //    {
        //        if (model == null)
        //            return Json(new { success = false, message = "Model is null." });

        //        if (!ModelState.IsValid)
        //        {
        //            var errors = string.Join("; ", ModelState.Values
        //                .SelectMany(v => v.Errors)
        //                .Select(e => e.ErrorMessage));

        //            return Json(new { success = false, message = "Validation failed: " + errors });
        //        }

        //        var tbl = new mst_GP
        //        {
        //            DistrictId_fk = model.DistrictId_fk,
        //            BlockId_fk = model.BlockId_fk,
        //            GPName = model.GPName.Trim(),
        //            //GPCode = model.GPCode,
        //            IsActive = model.IsActive,
        //            //CreatedBy = MvcApplication.CUser.UserId,
        //            //CreatedOn = DateTime.Now
        //        };

        //        db.mst_GP.Add(tbl);
        //        db.SaveChanges();

        //        return Json(new { success = true, message = Enums.GetEnumDescription(Enums.eReturnReg.Insert) });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = $"Error: {ex.Message}" });
        //    }
        //}

        [HttpPost]
        public JsonResult AddPanchayat(PanchayatModel model)
        {
            try
            {
                bool isExist = db.mst_GP.Any(x => x.GPName == model.GPName.Trim() && x.DistrictId_fk == model.DistrictId_fk && x.BlockId_fk == model.BlockId_fk && x.GPId_pk != model.GPId_pk);

                if (isExist)
                {
                    return Json(new { success = false, message = Enums.GetEnumDescription(Enums.eReturnReg.Already) });
                }
                //int maxOrderBy = db.mst_GP.Select(j => (int?)j.OrderBy).DefaultIfEmpty(0).Max() ?? 0;
                var tbl = new mst_GP
                {
                    DistrictId_fk = model.DistrictId_fk,
                    BlockId_fk = model.BlockId_fk,
                    GPName = model.GPName.Trim(),
                    IsActive = true,
                    CreatedBy = MvcApplication.CUser.UserId, 
                    CreatedOn = DateTime.Now,
                    //OrderBy = maxOrderBy + 1
                };

                db.mst_GP.Add(tbl);
                db.SaveChanges();

                return Json(new { success = true, message = Enums.GetEnumDescription(Enums.eReturnReg.Insert) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) });
            }
        }


        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
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
        public ActionResult GetDistrictList(int SelectAll, int SId = 1)
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
                var items = CommonModel.GetALLVO(SelectAll, SId, DId, BId, PId, CId, VId);
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