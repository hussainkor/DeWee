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
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Data.Entity.Infrastructure;
using System.Drawing.Imaging;
using System.Data.Entity.Core.Common.CommandTrees;

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
        public ActionResult AddBeneficiary(Guid? BeneficiaryId,int? RId)
        {
            BeneficiaryModel model = new BeneficiaryModel();
            if (RId>0)
            {
                var tblr = db.tbl_Referral.Find(RId);
                model.ReferralId = tblr.ReferralId_pk;
                model.DistrictId = tblr.DistrictId.Value;
                model.BlockId = tblr.BlockId.Value;
                model.NameofEnterpriseOwner = tblr.NameofOwner;
                model.PrimaryMobileNo=tblr.PrimaryMobileNo;
                model.TypeofEnterpriseBusinId = tblr.TypeofEnterprise.Value;
            }
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

                        tbl.DGYesAverageDailyHours = model.YNGridconnection.ToLower() == "Yes" ? model.DGYesAverageDailyHours.ToString() : null;
                        tbl.DGCapacity = model.YNGridconnection.ToLower() == "Yes" ? model.DGCapacity.ToString() : null;
                        tbl.DGAverageExpense = model.YNGridconnection.ToLower() == "Yes" ? model.DGAverageExpense.ToString() : null;

                        tbl.YNMotorAppliances = model.YNMotorAppliances;
                        tbl.IfYesTypeofMotor = model.YNMotorAppliances == "Yes" ? tbl.IfYesTypeofMotor : null;
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
                            tbl.ReferralId = model.ReferralId;
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
        public ActionResult GetBeneficiaryList(string SId = "", string DId = "", string BId = "")
        {
            DataTable tbllist = SPManager.SP_BeneficiaryList(SId, DId, BId);
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
        public ActionResult AddReferral()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddReferral(ReferralModel model)
        {
            string filepath = "/Uploads/JsonDataLog/";
            var context = new DeWee_DBEntities();
            // Validate model
            if (model == null)
            {
                return Json(new { success = false, message = "Invalid referral data" });
            }

            if (string.IsNullOrWhiteSpace(model.NameofOwner))
            {
                return Json(new { success = false, message = "Owner name is required" });
            }

            if (string.IsNullOrWhiteSpace(model.PrimaryMobileNo))
            {
                return Json(new { success = false, message = "Mobile number is required" });
            }
            try
            {
                // Check for duplicate mobile number if needed
                if (context.tbl_Referral.Any(r => r.PrimaryMobileNo == model.PrimaryMobileNo))
                {
                    return Json(new { success = false, message = "Mobile number already exists" });
                }

                var newReferral = new tbl_Referral
                {
                    NameofOwner = model.NameofOwner,
                    TypeofEnterprise = model.TypeofEnterprise, // Assuming 1 represents some enterprise type
                    Other_TypeofEnterprise = model.Other_TypeofEnterprise, // Assuming 1 represents some enterprise type
                    PrimaryMobileNo = model.PrimaryMobileNo,
                    DistrictId = model.DistrictId,
                    BlockId = model.BlockId,
                    Address = model.Address,
                    uuid = Guid.NewGuid().ToString(),
                    CreatedBy = MvcApplication.CUser.UserId,
                    CreatedOn = DateTime.UtcNow,
                    IsBeneficiaryProcessed = false,
                    IsActive = true
                    //BeneficiaryId_fk=model.BeneficiaryId_fk

                    // Other fields will use their default values
                };
                context.tbl_Referral.Add(newReferral);
                context.SaveChanges();
                filepath = filepath + "ArchiveBeneficiaryDataPost/";
                filepath = filepath + model.PrimaryMobileNo + " Referral" + "^" + model.Version + "^" + Guid.NewGuid() + "^-" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ".txt";
                StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(filepath), false, System.Text.Encoding.UTF8);
                sw.WriteLine(model);
                sw.Close();
                return Json(new
                {
                    success = true,
                    message = "Referral added successfully",
                    ReferralId_pk = newReferral.ReferralId_pk,
                });
            }
            catch (Exception ex)
            {
                filepath = filepath + "/ErrorBeneficiaryDataPost/";
                filepath = filepath + model.PrimaryMobileNo + " ReferralEx" + "^" + model.Version + "^" + Guid.NewGuid() + "^-" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ".txt";
                StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(filepath), false, System.Text.Encoding.UTF8);
                sw.WriteLine(model);
                sw.Close();
                // Log the exception (you should implement proper logging)
                // Logger.LogError(ex, "Error adding new referral");

                return Json(new
                {
                    success = false,
                    message = "An error occurred while saving the referral",
                    error = ex.Message
                });
            }
        }
        public ActionResult ReferralList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetReferralList(string DId = "", string BId = "")
        {
            DataTable tbllist = SPManager.Usp_ReferralList(DId, BId);
            try
            {
                if (tbllist.Rows.Count > 0)
                {
                    var html = ConvertViewToString("_ReferralData", tbllist);
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

        //public ActionResult GetReferralList(string DId = "", string BId = "")
        //{
        //    DataTable tbllist = SPManager.Usp_ReferralList(DId,BId);
        //    try
        //    {
        //        if (tbllist.Rows.Count > 0)
        //        {
        //            var html = ConvertViewToString("_ReferralData", tbllist);
        //            return Json(new { IsSuccess = true, Data = html }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { IsSuccess = false, Data = Enums.GetEnumDescription(Enums.eReturnReg.RecordNotFound) }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { IsSuccess = false, Data = Enums.GetEnumDescription(Enums.eReturnReg.ExceptionError) }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public ActionResult AddSolarShop()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddSolarShop(SolarShopModel model)
        {
            int res = 0;
            string filepath = "/Uploads/JsonDataLog/";
            var context = new DeWee_DBEntities();
            try
            {
                if (model == null)
                {
                    return Json(new { success = false, message = "Invalid referral data" });
                }

                if (string.IsNullOrWhiteSpace(model.NameofOwner))
                {
                    return Json(new { success = false, message = "Owner name is required" });
                }

                if (string.IsNullOrWhiteSpace(model.PrimaryMobileNo))
                {
                    return Json(new { success = false, message = "Mobile number is required" });
                }

                if (context.tbl_SolarShop.Any(r => r.PrimaryMobileNo == model.PrimaryMobileNo))
                {
                    return Json(new { success = false, message = "Mobile number already exists" });
                }
                filepath = filepath + "/ArchiveBeneficiaryDataPost/";
                filepath = filepath + model.PrimaryMobileNo + " SolarShopWeb" + "^" + model.Version + "^" + Guid.NewGuid() + "^-" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ".txt";
                
                var newShop = new tbl_SolarShop
                {
                    NameofEnterprise = model.NameofEnterprise.Trim(),
                    NameofOwner = model.NameofOwner,
                    TypeofEnterprise = model.TypeofEnterprise,
                    Other_TypeofEnterprise = model.Other_TypeofEnterprise,
                    PrimaryMobileNo = model.PrimaryMobileNo,
                    DistrictId = model.DistrictId,
                    BlockId = model.BlockId,
                    SiteAddress = model.SiteAddress,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Location = model.Location,
                    Iflinked = model.Iflinked,
                    uuid = Guid.NewGuid().ToString(),
                    IsActive = true,
                    CreatedBy = MvcApplication.CUser.UserId,
                    CreatedOn = DateTime.UtcNow
                };

                // Validate model before saving
                var validationResults = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(newShop, new ValidationContext(newShop), validationResults, true);

                if (!isValid)
                {
                    var errors = validationResults.Select(vr => vr.ErrorMessage);
                    return Json(new { success = false, message = "Validation failed", errors });
                }

                string fullOutputPath = "~/Uploads/EnterprisesSolarShop/";
                string filetype = "png";
                bool bsaveimg = false;
                // byte[] bytes = System.IO.File.ReadAllBytes(@"C:/Users/BinduKumari/Downloads/AFD2 (2).pdf");//Convert.FromBase64String(base64);
                byte[] bytes = Convert.FromBase64String(model.SolarShopEnterprisebase64);//Convert.FromBase64String(base64);
                fullOutputPath = fullOutputPath + newShop.PrimaryMobileNo.ToString() + "_" + DateTime.Now.ToDateTimeDDMMYYYY() + ".png";
                System.Drawing.Image image;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
                {
                    using (image = System.Drawing.Image.FromStream(ms))
                    {
                        if (ValidateImageSize(bytes))
                        {
                            if (image.Width <= 1390 && image.Height <= 490)
                            {
                                SaveImageWithTargetSize(image, Server.MapPath(fullOutputPath), 1 * 1024 * 1024); // 1 MB
                            }
                            else
                            {
                                using (Bitmap b = new Bitmap(image))
                                {
                                    using (System.Drawing.Image resizedImage = ResizeImage(b, new System.Drawing.Size(1390, 490)))
                                    {
                                        SaveImageWithTargetSize(resizedImage, Server.MapPath(fullOutputPath), 1 * 1024 * 1024); // 1 MB
                                    }
                                }
                            }
                            bsaveimg = true;
                        }
                        else
                        {
                            bsaveimg = false;
                            return Json(new
                            {
                                success = false,
                                message = "Image size exceeds 1 MB.",
                            });
                        }
                    }
                }
                if (bsaveimg)
                {
                    newShop.SolarShopEnterprisePicPath = fullOutputPath;
                    context.tbl_SolarShop.Add(newShop);
                    res = context.SaveChanges();
                    StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(filepath), false, System.Text.Encoding.UTF8);
                    sw.WriteLine(model);
                    sw.Close();
                }
                if (res > 0)
                {
                    return Json(new
                    {
                        success = true,
                        message = "Solar shop added successfully",
                        SolarShopId_pk = newShop.SolarShopId_pk,
                        data = new
                        {
                            newShop.NameofEnterprise,
                            newShop.NameofOwner,
                            newShop.PrimaryMobileNo,
                            newShop.SiteAddress,
                            newShop.SolarShopEnterprisePicPath
                        }
                    });
                }
                else
                {
                    return Json(new { success = false, message = "Record Not Submit." });
                }

            }
            catch (DbUpdateException dbEx)
            {
                filepath = filepath + "/ErrorBeneficiaryDataPost/";
                filepath = filepath + model.PrimaryMobileNo + " SolarShop_dbex" + "^" + model.Version + "^" + Guid.NewGuid() + "^-" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ".txt";
                //----- Directory check for error folder by Harshit -----
                string errorDirectoryPath = Path.GetDirectoryName(Server.MapPath(filepath));
                if (!Directory.Exists(errorDirectoryPath))
                {
                    Directory.CreateDirectory(errorDirectoryPath);
                }
                //------------------------------------------------


                StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(filepath), false, System.Text.Encoding.UTF8);
                sw.WriteLine(model);
                sw.Close();
                // Handle database specific exceptions
                return Json(new
                {
                    success = false,
                    message = "Database error while saving solar shop",
                    error = dbEx.InnerException?.Message ?? dbEx.Message
                });
            }
            catch (Exception ex)
            {
                filepath = filepath + "/ErrorBeneficiaryDataPost/";
                filepath = filepath + model.PrimaryMobileNo + " SolarShop_ex" + "^" + model.Version + "^" + Guid.NewGuid() + "^-" + DateTime.Now.ToString("ddMMMyyyyHHmmss") + ".txt";
                //----- Directory check for error folder by Harshit-----
                string errorDirectoryPath = Path.GetDirectoryName(Server.MapPath(filepath));
                if (!Directory.Exists(errorDirectoryPath))
                {
                    Directory.CreateDirectory(errorDirectoryPath);
                }
                //------------------------------------------------
                StreamWriter sw = new System.IO.StreamWriter(Server.MapPath(filepath), false, System.Text.Encoding.UTF8);
                sw.WriteLine(model);
                sw.Close();
                // Handle other exceptions
                return Json(new
                {
                    success = false,
                    message = "An error occurred while adding solar shop",
                    error = ex.Message
                });
            }

        }
        public ActionResult SolarshopList()
        {
            return View();
        }
        public ActionResult GetSolarshopList(string DId = "", string BId = "")
        {
            DataTable tbllist = SPManager.Usp_SolarShopList(DId, BId);
            try
            {
                if (tbllist.Rows.Count > 0)
                {
                    var html = ConvertViewToString("_SolarshopData", tbllist);
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

        //public ActionResult AddBeneficiaryform()
        //{
        //    return View();
        //}
        private bool ValidateImageSize(byte[] bytes)
        {
            // 1 MB = 1 * 1024 * 1024 bytes
            return bytes.Length <= (1 * 1024 * 1024);
        }
        private void SaveImageWithTargetSize(Image image, string path, int maxSizeInBytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                if (ms.Length <= maxSizeInBytes)
                {
                    image.Save(path, ImageFormat.Png);
                }
                else
                {
                    throw new Exception("Image size exceeds maximum allowed size.");
                }
            }
        }
        private Image ResizeImage(Bitmap image, Size size)
        {
            Bitmap resizedImage = new Bitmap(size.Width, size.Height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, size.Width, size.Height);
            }
            return resizedImage;
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
    }
}