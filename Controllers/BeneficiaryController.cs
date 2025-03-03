using DeWee.Manager;
using DeWee.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using OfficeOpenXml;
using static DeWee.Manager.Enums;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;

namespace DeWee.Controllers
{

    [Authorize]
    [SessionCheck]
    public class BeneficiaryController : Controller
    {
        DeWee_DBEntities db = new DeWee_DBEntities();
        private const string GoogleApiKey = "AIzaSyAw2rgDsJqTKA8ern_oI6heqv-xgSLuu1U";
        int results = 0;
        // GET: Beneficiary
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult AddBeneficiary(Guid? BeneficiaryId)
        {
            BeneficiaryModel model = new BeneficiaryModel();
            if (BeneficiaryId != Guid.Empty && BeneficiaryId != null)
            {
                var tbl = db.tbl_IndtSolarization.Find(BeneficiaryId);
                if (tbl != null)
                {
                    //model.Indt_Id = tbl.Indt_Id;
                    //model.NameofSHGmember = tbl.NameofSHGMember;
                    //model.YearOfSHG = Convert.ToInt32(tbl.YearOfSHG);
                    //model.PhoneNumber = tbl.PhoneNumber;
                    //model.NameofEnterpriseOwner = tbl.NameofEnterpriseOwner;
                    //model.Age = tbl.Age.Value;
                    //model.EducationQlf_Id = tbl.EducationQlf_Id.Value;
                    //model.Caste_Id = Convert.ToInt32(tbl.Caste_Id);
                    //model.TypeofEnterpriseBusin_Id = Convert.ToInt32(tbl.TypeofEnterpriseBusin_Id);
                    //model.BusinessOwnedType_Id = Convert.ToInt32(tbl.BusinessOwnedType_Id);
                    //model.EstablishedEnterpriseType_Id = Convert.ToInt32(tbl.EstablishedEnterpriseType_Id);
                    //model.TypeOfInvestBusin_Id = Convert.ToInt32(tbl.TypeOfInvestBusin_Id);
                    //model.TookSourceOfLoan_Id = Convert.ToInt32(tbl.TookSourceOfLoan_Id);
                    //model.TookLoanAmt = Convert.ToInt32(tbl.TookLoanAmt);
                    //model.StartBusinessInvestAmt = Convert.ToInt32(tbl.StartBusinessInvestAmt);
                    //model.StartYourBusinessTakeAmt = Convert.ToInt32(tbl.StartYourBusinessTakeAmt);
                    //model.MonthlyProfitBusiness = Convert.ToInt32(tbl.MonthlyProfitBusiness);
                    //model.WorkInEnterprises_FamilyMembers = Convert.ToInt32(tbl.WorkInEnterprises_FamilyMembers);
                    //model.WorkInEnterprises_SHGMembers = Convert.ToInt32(tbl.WorkInEnterprises_SHGMembers);
                    //model.WorkInEnterprises_AssitantStaff = Convert.ToInt32(tbl.WorkInEnterprises_AssitantStaffs);
                    //model.TypeOfMachineEnterprise_Id = Convert.ToInt32(tbl.TypeOfMachineEnterprise_Id);
                    //model.MotorBasedOnMachinesInActualUsed = Convert.ToInt32(tbl.TypeOfMachineEnterprise_Id);
                    //model.MachineryPowerkilowatt_Id = Convert.ToInt32(tbl.MachineryPowerkilowatt_Id);
                    //model.ElectricityConnection_Id = Convert.ToInt32(tbl.ElectricityConnection_Id);
                    //model.ConnectionPhaseofPower_Id = Convert.ToInt32(tbl.ConnectionPhaseofPower_Id);
                    //model.MonthlyElectricityConsumption_Id = Convert.ToInt32(tbl.MonthlyElectricityConsumption_Id);
                    //model.MachineSourceofEnergy_Id = Convert.ToInt32(tbl.MachineSourceofEnergy_Id);
                    //model.MachineSourceofEnergy_Others = tbl.MachineSourceofEnergy_Others;
                    //model.Solar_InKilowatt_Id = Convert.ToInt32(tbl.Solar_InKilowatt_Id);
                    //model.Solar_EnergyPanelYesNo_Id = Convert.ToInt32(tbl.Solar_EnergyPanelYesNo_Id);
                    //model.Solar_ExpenditureIncurredAmt = Convert.ToInt32(tbl.Solar_ExpenditureIncurredAmt);
                    //model.SubsidySolarReceive_Id = Convert.ToInt32(tbl.SubsidySolarReceive_Id);
                    //model.LoanSolarPanelsYesNo_Id = Convert.ToInt32(tbl.LoanSolarPanelsYesNo_Id);
                    //model.MonthAvgAmtSavedDescription_Id = Convert.ToInt32(tbl.MonthAvgAmtSavedDescription_Id);
                    //model.ElectricityUsedHours_Id = Convert.ToInt32(tbl.ElectricityUsedHours_Id);
                    //model.MonthlyExpenseInElectricityBill_Id = Convert.ToInt32(tbl.MonthlyExpenseInElectricityBill_Id);
                    //model.GeneratorElectricityUsedHours_Id = Convert.ToInt32(tbl.GeneratorElectricityUsedHours_Id);
                    //model.MonthlyExpenseFuelSource_Id = Convert.ToInt32(tbl.MonthlyExpenseFuelSource_Id);
                    //model.MonthlyRepairCost_Id = Convert.ToInt32(tbl.MonthlyRepairCost_Id);
                    //model.HeardAboutSolarEYesNo_Id = Convert.ToInt32(tbl.HeardAboutSolarEYesNo_Id);
                    //model.HeardAboutSolarEYes_IfYeswhere = tbl.HeardAboutSolarEYes_IfYeswhere;
                    //model.InforknowledgeGovtSubsidyOfSEYesNo_Id = Convert.ToInt32(tbl.InforknowledgeGovtSubsidyOfSEYesNo_Id);
                    //model.InforknowledgeIfYesAmtGovPaid = Convert.ToInt32(tbl.InforknowledgeIfYesAmtGovPaid);
                    //model.LoanProcedureInSEYesNo_Id = Convert.ToInt32(tbl.LoanProcedureInSEYesNo_Id);
                    //model.AdoptSolarizationYesNo_Id = Convert.ToInt32(tbl.AdoptSolarizationYesNo_Id);
                    //model.CapitalArrangedForSEYesNo_Id = Convert.ToInt32(tbl.CapitalArrangedForSEYesNo_Id);
                    //model.IfYesCapitalArrangedForSEAmt = Convert.ToInt32(tbl.IfYesCapitalArrangedForSEAmt);
                    //model.OtherIndustriesEnterprisesYesNo_Id = Convert.ToInt32(tbl.OtherIndustriesEnterprisesYesNo_Id);
                    //model.IfYesFillForm_OtherIndustriesEnterprises = tbl.IfYesFillForm_OtherIndustriesEnterprises;
                }
            }
            return View(model);
        }
        [HttpPost]
        [SessionCheck]
        public ActionResult AddBeneficiary(BeneficiaryModel model)
        {
            JsonResponseData response = new JsonResponseData();
            try
            {
                var tbl = model.BeneficiaryId_pk != Guid.Empty ? db.tbl_Beneficiary.Find(model.BeneficiaryId_pk) : new tbl_Beneficiary();
                if (ModelState.IsValid)
                {
                    if (tbl != null)
                    {
                        if (model.BeneficiaryId_pk == Guid.Empty)
                        {
                            tbl.BeneficiaryId_pk = Guid.NewGuid();
                        }
                        tbl.StateId = model.StateId;
                        tbl.DistrictId = model.DistrictId;
                        tbl.BlockId = model.BlockId;
                        tbl.GPId = model.GPId;
                        tbl.Village = model.Village;
                        tbl.CLF = model.CLF;
                        tbl.VO = model.VO;
                        tbl.NameofSHG = model.NameofSHG;
                        tbl.YearOfSHG = model.YearOfSHG;
                        tbl.NameofEnterprise = model.NameofEnterprise;
                        tbl.TypeofEnterpriseBusinId = model.TypeofEnterpriseBusinId;
                        tbl.EnterpriseBusinId_other = model.EnterpriseBusinId_other;
                        tbl.NameofSHGMember = model.NameofSHGMember;
                        tbl.NameofEnterpriseOwner = model.NameofEnterpriseOwner;
                        tbl.EnterpriseOwner_Gender = model.EnterpriseOwner_Gender;
                        tbl.DOB = model.DOB;
                        tbl.TypeofRelative = model.TypeofRelative;
                        tbl.NameofGuardian = model.NameofGuardian;
                        tbl.Guardian_Gender = model.Guardian_Gender;
                        tbl.PrimaryMobileNo = model.PrimaryMobileNo;
                        tbl.AlternateMobileNo = model.AlternateMobileNo;
                        tbl.WhatsAppMobileNo = model.WhatsAppMobileNo;
                        tbl.IsSamePrimayMobileNo = model.IsSamePrimayMobileNo;
                        tbl.SiteAddress1st = model.SiteAddress1st;
                        tbl.SiteAddress2nd = model.SiteAddress2nd;
                        tbl.Pincode = model.Pincode;
                        tbl.CategoryBusinessInstallationId = model.CategoryBusinessInstallationId;
                        tbl.SpaceAvailableId = model.SpaceAvailableId;
                        tbl.SpaceAvailable_Area = model.SpaceAvailable_Area;
                        tbl.NatureofSpaceId = model.NatureofSpaceId;
                        tbl.NatureofSpace_other = model.NatureofSpace_other;
                        tbl.YNGridconnection = model.YNGridconnection;
                        tbl.YNDieselGenerator = model.YNDieselGenerator;
                        if (model.YNGridconnection.ToLower() == "yes")
                        {
                            tbl.DGYesAverageDailyHours = model.DGYesAverageDailyHours;
                            tbl.DGCapacity = model.DGCapacity;
                        }

                        tbl.YNMotorAppliances = model.YNMotorAppliances;
                        //tbl.OtherSourceEnergyMachineId = model.OtherSourceEnergyMachineId;
                        tbl.YNGovtSchemessubsidy = model.YNGovtSchemessubsidy;
                        tbl.SolarInstallationId = model.SolarInstallationId;
                        tbl.YNFinancialSupport = model.YNFinancialSupport;
                        tbl.Latitude = model.Latitude;
                        tbl.Longitude = model.Longitude;
                        tbl.Location = model.Location;
                        //image
                        if (!string.IsNullOrWhiteSpace(model.BeneficiaryPicHd))
                        {
                            var picexterpries = CommonModel.SaveSingleFileBase64string(model.BeneficiaryPicHd, "Enterprises", tbl.BeneficiaryId_pk.ToString());
                            tbl.EnterprisePhotoPath = picexterpries;
                        }

                        tbl.IsActive = true;
                        if (model.BeneficiaryId_pk == Guid.Empty)
                        {
                            tbl.CreatedBy = MvcApplication.CUser.UserId;
                            tbl.CreatedOn = DateTime.Now;
                            db.tbl_Beneficiary.Add(tbl);
                        }
                        else
                        {
                            tbl.UpdatedBy = MvcApplication.CUser.UserId;
                            tbl.UpdatedOn = DateTime.Now;
                        }

                        results = db.SaveChanges();
                    }

                    if (results > 0)
                    {
                        response = new JsonResponseData
                        {
                            StatusType = eAlertType.success.ToString(),
                            Message = model.BeneficiaryId_pk != Guid.Empty
                                ? "Beneficiary updated successfully!"
                                : "Beneficiary have been successfully registered!",
                            Data = null
                        };
                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    response = new JsonResponseData
                    {
                        StatusType = eAlertType.error.ToString(),
                        Message = "All Record Required !!",
                        Data = null
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                response = new JsonResponseData
                {
                    StatusType = eAlertType.error.ToString(),
                    Message = "There was a communication error: " + ex.Message,
                    Data = null
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return View(model);
        }
        public ActionResult BeneficiaryList()
        {
            return View();
        }
        public ActionResult GetBeneficiaryList()
        {
            DataTable tbllist = SPManager.SP_BeneficiaryList();
            try
            {
                if (tbllist.Rows.Count > 0)
                {
                    var html = ConvertViewToString("_BeneficiaryData", tbllist);
                    return Json(new { IsSuccess = true, Data = html }, JsonRequestBehavior.AllowGet);
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
        
        [HttpGet]
        public async Task<JsonResult> GetAddress(double lat, double lng)
        {
            string apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lng}&key={GoogleApiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = "Failed to fetch geocode data." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        public ActionResult LoadBeneficiaryView(string BfyId)
        {
            DataTable dt = new DataTable();
            dt = SPManager.Get_Usp_BeneficiaryDetails(BfyId);
            return PartialView("_BeneficiaryView", dt); // Return the partial view
        }

        //public ActionResult AddBeneficiaryform()
        //{
        //    return View();
        //}
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
    }
}