using DeWee.Manager;
using DeWee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DeWee.Manager.Enums;

namespace DeWee.Controllers
{
    public class ParticipantController : Controller
    {
        DeWee_DBEntities db = new DeWee_DBEntities();
        int results = 0;
        // GET: Participant
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult AddParticipant(Guid? Indt_Id)
        {
            //Participant model = new Participant();
            //if (Indt_Id != Guid.Empty && Indt_Id != null)
            //{
            //    var tbl = db.Tbl_IndtSolarization.Find(Indt_Id);
            //    if (tbl != null)
            //    {
            //        model.Indt_Id = tbl.Indt_Id;
            //        model.NameofSHGmember = tbl.NameofSHGMember;
            //        model.YearOfSHG = Convert.ToInt32(tbl.YearOfSHG);
            //        model.PhoneNumber = tbl.PhoneNumber;
            //        model.NameofEnterpriseOwner = tbl.NameofEnterpriseOwner;
            //        model.Age = Convert.ToInt32(tbl.Age);
            //        model.EducationQlf_Id = Convert.ToInt32(tbl.EducationQlf_Id);
            //        model.Caste_Id = Convert.ToInt32(tbl.Caste_Id);
            //        model.TypeofEnterpriseBusin_Id = Convert.ToInt32(tbl.TypeofEnterpriseBusin_Id);
            //        model.BusinessOwnedType_Id = Convert.ToInt32(tbl.BusinessOwnedType_Id);
            //        model.EstablishedEnterpriseType_Id = Convert.ToInt32(tbl.EstablishedEnterpriseType_Id);
            //        model.TypeOfInvestBusin_Id = Convert.ToInt32(tbl.TypeOfInvestBusin_Id);
            //        model.TookSourceOfLoan_Id = Convert.ToInt32(tbl.TookSourceOfLoan_Id);
            //        model.TookLoanAmt = Convert.ToInt32(tbl.TookLoanAmt);
            //        model.TookLoanAmtBank = Convert.ToInt32(tbl.TookLoanAmt);
            //        model.TookLoanAmtR = Convert.ToInt32(tbl.TookLoanAmt);
            //        model.TookLoanAmtO = Convert.ToInt32(tbl.TookLoanAmt);
            //        model.StartBusinessInvestAmt = Convert.ToInt32(tbl.StartBusinessInvestAmt);
            //        model.StartYourBusinessTakeAmt = Convert.ToInt32(tbl.StartYourBusinessTakeAmt);
            //        model.MonthlyProfitBusiness = Convert.ToInt32(tbl.MonthlyProfitBusiness);
            //        model.WorkInEnterprises_FamilyMembers = Convert.ToInt32(tbl.WorkInEnterprises_FamilyMembers);
            //        model.WorkInEnterprises_SHGMembers = Convert.ToInt32(tbl.WorkInEnterprises_SHGMembers);
            //        model.WorkInEnterprises_AssitantStaff = Convert.ToInt32(tbl.WorkInEnterprises_AssitantStaffs);
            //        model.TypeOfMachineEnterprise_Id = Convert.ToInt32(tbl.TypeOfMachineEnterprise_Id);
            //        model.MotorBasedOnMachinesInActualUsed = Convert.ToInt32(tbl.TypeOfMachineEnterprise_Id);
            //        model.MachineryPowerkilowatt_Id = Convert.ToInt32(tbl.MachineryPowerkilowatt_Id);
            //        model.ElectricityConnection_Id = Convert.ToInt32(tbl.ElectricityConnection_Id);
            //        model.ConnectionPhaseofPower_Id = Convert.ToInt32(tbl.ConnectionPhaseofPower_Id);
            //        model.MonthlyElectricityConsumption_Id = Convert.ToInt32(tbl.MonthlyElectricityConsumption_Id);
            //        model.MachineSourceofEnergy_Id = Convert.ToInt32(tbl.MachineSourceofEnergy_Id);
            //        model.Solar_InKilowatt_Id = Convert.ToInt32(tbl.Solar_InKilowatt_Id);
            //        model.Solar_EnergyPanelYesNo_Id = Convert.ToInt32(tbl.Solar_EnergyPanelYesNo_Id);
            //        model.Solar_ExpenditureIncurredAmt = Convert.ToInt32(tbl.Solar_ExpenditureIncurredAmt);
            //        model.SubsidySolarReceive_Id = Convert.ToInt32(tbl.SubsidySolarReceive_Id);
            //        model.LoanSolarPanelsYesNo_Id = Convert.ToInt32(tbl.LoanSolarPanelsYesNo_Id);
            //        model.MonthAvgAmtSavedDescription_Id = Convert.ToInt32(tbl.MonthAvgAmtSavedDescription_Id);
            //        model.ElectricityUsedHours_Id = Convert.ToInt32(tbl.ElectricityUsedHours_Id);
            //        model.MonthlyExpenseInElectricityBill_Id = Convert.ToInt32(tbl.MonthlyExpenseInElectricityBill_Id);
            //        model.GeneratorElectricityUsedHours_Id = Convert.ToInt32(tbl.GeneratorElectricityUsedHours_Id);
            //        model.MonthlyExpenseFuelSource_Id = Convert.ToInt32(tbl.MonthlyExpenseFuelSource_Id);
            //        model.MonthlyRepairCost_Id = Convert.ToInt32(tbl.MonthlyRepairCost_Id);
            //        model.HeardAboutSolarEYesNo_Id = Convert.ToInt32(tbl.HeardAboutSolarEYesNo_Id);
            //        model.HeardAboutSolarEYes_IfYeswhere = tbl.HeardAboutSolarEYes_IfYeswhere;
            //        model.InforknowledgeGovtSubsidyOfSEYesNo_Id = Convert.ToInt32(tbl.InformationknowledgeGovtSubsidyOfSEYesNo_Id);
            //        model.InforknowledgeIfYesAmtGovPaid = Convert.ToInt32(tbl.InformationknowledgeIfYesAmtGovPaid);
            //        model.LoanProcedureInSEYesNo_Id = Convert.ToInt32(tbl.LoanProcedureInSEYesNo_Id);
            //        model.AdoptSolarizationYesNo_Id = Convert.ToInt32(tbl.AdoptSolarizationYesNo_Id);
            //        model.CapitalArrangedForSEYesNo_Id = Convert.ToInt32(tbl.CapitalArrangedForSEYesNo_Id);
            //        model.IfYesCapitalArrangedForSEAmt = Convert.ToInt32(tbl.IfYesCapitalArrangedForSEAmt);
            //        model.OtherIndustriesEnterprisesYesNo_Id = Convert.ToInt32(tbl.OtherIndustriesEnterprisesYesNo_Id);
            //        model.IfYesFillForm_OtherIndustriesEnterprises = tbl.IfYesFillForm_OtherIndustriesEnterprises;
            //    }
            //}
            return View();
        }
        public ActionResult GetAddParticipant(Participant model)
        {
            JsonResponseData response = new JsonResponseData();
            try
            {
                if (ModelState.IsValid)
                {
                    var existingPart = SPManager.Check_ParticipantAlready(model.Indt_Id.ToString(), model.PhoneNumber, model.AadharNo); //db.Tbl_IndtSolarization.Where(x => x.IsActive == true && x.PhoneNumber == model.PhoneNumber.Trim())?.FirstOrDefault();

                    if (existingPart.Rows.Count > 0)
                    {
                        response = new JsonResponseData
                        {
                            StatusType = eAlertType.error.ToString(),
                            Message = $"Already Exists Registration.<br /> <span> Reg ID : <strong> {existingPart.Rows[0]["RegNo"].ToString()} </strong>  </span>",
                            Data = null
                        };
                        return Json(response, JsonRequestBehavior.AllowGet);
                    }
                    var participant = model.Indt_Id != Guid.Empty ? db.Tbl_IndtSolarization.Find(model.Indt_Id) : new Tbl_IndtSolarization();

                    if (participant != null)
                    {
                        participant.NameofSHGMember = model.NameofSHGmember?.Trim();
                        participant.PhoneNumber = model.PhoneNumber?.Trim();
                        participant.Age = model.Age;
                        participant.EducationQlf_Id = model.EducationQlf_Id;
                        participant.YearOfSHG = model.YearOfSHG;
                        participant.NameofEnterpriseOwner = model.NameofEnterpriseOwner;
                        participant.Caste_Id = model.Caste_Id;
                        participant.TypeofEnterpriseBusin_Id = model.TypeofEnterpriseBusin_Id;
                        participant.BusinessOwnedType_Id = model.BusinessOwnedType_Id;
                        participant.EstablishedEnterpriseType_Id = model.EstablishedEnterpriseType_Id;
                        participant.TypeOfInvestBusin_Id = model.TypeOfInvestBusin_Id;
                        participant.TookSourceOfLoan_Id = model.TookSourceOfLoan_Id;
                        participant.TookLoanAmt = model.TookLoanAmt;
                        participant.TookLoanAmt = model.TookLoanAmtBank;
                        participant.TookLoanAmt = model.TookLoanAmtR;
                        participant.TookLoanAmt = model.TookLoanAmtO;
                        participant.StartBusinessInvestAmt = model.StartBusinessInvestAmt;
                        participant.StartYourBusinessTakeAmt = model.StartYourBusinessTakeAmt;
                        participant.MonthlyProfitBusiness = model.MonthlyProfitBusiness;
                        participant.WorkInEnterprises_FamilyMembers = model.WorkInEnterprises_FamilyMembers;
                        participant.WorkInEnterprises_SHGMembers = model.WorkInEnterprises_SHGMembers;
                        participant.WorkInEnterprises_AssitantStaffs = model.WorkInEnterprises_AssitantStaff;
                        participant.TypeOfMachineEnterprise_Id = model.TypeOfMachineEnterprise_Id;
                        participant.MotorBasedOnMachinesInActualUsed = model.TypeOfMachineEnterprise_Id;
                        participant.MachineryPowerkilowatt_Id = model.MachineryPowerkilowatt_Id;
                        participant.ElectricityConnection_Id = model.ElectricityConnection_Id;
                        participant.ConnectionPhaseofPower_Id = model.ConnectionPhaseofPower_Id;
                        participant.MonthlyElectricityConsumption_Id = model.MonthlyElectricityConsumption_Id;
                        participant.MachineSourceofEnergy_Id = model.MachineSourceofEnergy_Id;
                        participant.Solar_InKilowatt_Id = model.Solar_InKilowatt_Id;
                        participant.Solar_EnergyPanelYesNo_Id = model.Solar_EnergyPanelYesNo_Id;
                        participant.Solar_ExpenditureIncurredAmt = model.Solar_ExpenditureIncurredAmt;
                        participant.SubsidySolarReceive_Id = model.SubsidySolarReceive_Id;
                        participant.LoanSolarPanelsYesNo_Id = model.LoanSolarPanelsYesNo_Id;
                        participant.MonthAvgAmtSavedDescription_Id = model.MonthAvgAmtSavedDescription_Id;
                        participant.ElectricityUsedHours_Id = model.ElectricityUsedHours_Id;
                        participant.MonthlyExpenseInElectricityBill_Id = model.MonthlyExpenseInElectricityBill_Id;
                        participant.GeneratorElectricityUsedHours_Id = model.GeneratorElectricityUsedHours_Id;
                        participant.MonthlyExpenseFuelSource_Id = model.MonthlyExpenseFuelSource_Id;
                        participant.MonthlyRepairCost_Id = model.MonthlyRepairCost_Id;
                        participant.HeardAboutSolarEYesNo_Id = model.HeardAboutSolarEYesNo_Id;
                        participant.HeardAboutSolarEYes_IfYeswhere = model.HeardAboutSolarEYes_IfYeswhere;
                        participant.InformationknowledgeGovtSubsidyOfSEYesNo_Id = model.InforknowledgeGovtSubsidyOfSEYesNo_Id;
                        participant.InformationknowledgeIfYesAmtGovPaid = model.InforknowledgeIfYesAmtGovPaid;
                        participant.LoanProcedureInSEYesNo_Id = model.LoanProcedureInSEYesNo_Id;
                        participant.AdoptSolarizationYesNo_Id = model.AdoptSolarizationYesNo_Id;
                        participant.CapitalArrangedForSEYesNo_Id = model.CapitalArrangedForSEYesNo_Id;
                        participant.IfYesCapitalArrangedForSEAmt = model.IfYesCapitalArrangedForSEAmt;
                        participant.OtherIndustriesEnterprisesYesNo_Id = model.OtherIndustriesEnterprisesYesNo_Id;
                        participant.IfYesFillForm_OtherIndustriesEnterprises = model.IfYesFillForm_OtherIndustriesEnterprises;
                        participant.IsActive = true;
                        participant.CreatedOn = DateTime.Now;
                        if (model.Indt_Id == Guid.Empty)
                        {
                            participant.Indt_Id = Guid.NewGuid();
                            db.Tbl_IndtSolarization.Add(participant);
                        }
                        else
                        {
                            participant.UpdatedOn = DateTime.Now;
                        }

                        results = db.SaveChanges();
                    }

                    if (results > 0)
                    {
                        response = new JsonResponseData
                        {
                            StatusType = eAlertType.success.ToString(),
                            Message = model.Indt_Id != Guid.Empty
                                ? "Congratulations, you have been updated successfully!"
                                : "Congratulations, you have been successfully registered!",
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
    }
}