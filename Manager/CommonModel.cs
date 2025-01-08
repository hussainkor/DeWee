using DeWee.Helpers;
using DeWee.Models;
//using Irony.Parsing.Construction;
//using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using SubSonic.Extensions;
using SubSonic.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Entity;
//using System.Data.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
//using System.Windows.Interop;

namespace DeWee.Manager
{
    public class CommonModel
    {
        private static DeWee_DBEntities _db = new DeWee_DBEntities();

        public static List<SelectListItem> GetALLStateM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_State_Master.OrderBy(state => state.OrderBy).Select(state => new SelectListItem { Value = state.StateCode.ToString(), Text = state.StateName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select State" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }

        public static List<SelectListItem> GetALLDistrictM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_District_Master.Where(state => state.IsActive == true).OrderBy(state => state.OrderBy).Select(District => new SelectListItem { Value = District.DistrictCode.ToString(), Text = District.DistrictName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select District" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }

        public static List<SelectListItem> GetALLBlockM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Block_Master.Where(Block => Block.IsActive == true).OrderBy(Block => Block.OrderBy).Select(Block => new SelectListItem { Value = Block.BlockCode.ToString(), Text = Block.BlockName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Block" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLGpM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Panchayat_Master.Where(Panchayat => Panchayat.IsActive == true).OrderBy(Panchayat => Panchayat.OrderBy).Select(Panchayat => new SelectListItem { Value = Panchayat.PanchayatId_pk.ToString(), Text = Panchayat.PanchayatName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select GramPanchayat" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLVillM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Village_Master.Where(Vill => Vill.IsActive == true).OrderBy(Vill => Vill.OrderBy).Select(Vill => new SelectListItem { Value = Vill.VillageId_pk.ToString(), Text = Vill.VillageName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Village" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLCLFM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_CLF_Master.Where(CLF => CLF.IsActive == true).OrderBy(CLF => CLF.OrderBy).Select(CLF => new SelectListItem { Value = CLF.CLFId_pk.ToString(), Text = CLF.CLFName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select CLF" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLVO(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_VO_Master.Where(VO => VO.IsActive == true).OrderBy(VO => VO.OrderBy).Select(VO => new SelectListItem { Value = VO.VOrgId_pk.ToString(), Text = VO.Village_OrganizationName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select VO" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLEQ(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Educational_QualificationM.Where(EQ => EQ.IsActive == true).OrderBy(EQ => EQ.OrderBy).Select(EQ => new SelectListItem { Value = EQ.Qualification_Id.ToString(), Text = EQ.QualificationInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Education Qlf" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLCaste(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_CasteM.Where(CS => CS.IsActive == true).OrderBy(CS => CS.OrderBy).Select(CS => new SelectListItem { Value = CS.Caste_Id.ToString(), Text = CS.CasteInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Caste" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLBE(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_BusinessTypeM.Where(BE => BE.IsActive == true).OrderBy(BE => BE.OrderBy).Select(BE => new SelectListItem { Value = BE.BusinessType_Id.ToString(), Text = BE.BusinessTypeInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Business Type" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLBOT(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_BusinessOwnedM.Where(Bo => Bo.IsActive == true).OrderBy(Bo => Bo.OrderBy).Select(Bo => new SelectListItem { Value = Bo.BusinessOwned_Id.ToString(), Text = Bo.BusinessOwnedInEng}).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Business Owned Type" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLEE(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Enterprise_EstablishedM.Where(EE => EE.IsActive == true).OrderBy(EE => EE.OrderBy).Select(EE => new SelectListItem { Value = EE.Enterprise_Established_Id.ToString(), Text = EE.Enterprise_EstablishedInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Established Enterprises" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLIB(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_BusinessInvestmentM.Where(IB => IB.IsActive == true).OrderBy(IB => IB.OrderBy).Select(IB => new SelectListItem { Value = IB.BusinessInvestment_Id.ToString(), Text = IB.BusinessInvestmentInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Business Investment" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLLS(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_LoanDescribeSourceM.Where(LS => LS.IsActive == true).OrderBy(LS => LS.OrderBy).Select(LS => new SelectListItem { Value = LS.LoanDescribeSource_Id.ToString(), Text = LS.LoanDescribeSourceInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Loan Source" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLEM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_EnterpriseMachineM.Where(EM => EM.IsActive == true).OrderBy(EM => EM.OrderBy).Select(EM => new SelectListItem { Value = EM.EnterpriseMachine_Id.ToString(), Text = EM.EnterpriseMachineInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Machine Enterprises" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLMK(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_MachineryPowerM.Where(MK => MK.IsActive == true).OrderBy(MK => MK.OrderBy).Select(MK => new SelectListItem { Value = MK.MachineryPower_Id.ToString(), Text = MK.MachineryPowerInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Machine Power" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLPhase(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_PowerConnectionM.Where(PC => PC.IsActive == true).OrderBy(PC => PC.OrderBy).Select(PC => new SelectListItem { Value = PC.PowerConnection_Id.ToString(), Text = PC.PowerConnectionInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Phase" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLMB(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_MonthlyExpenseEBM.Where(MB => MB.IsActive == true).OrderBy(MB => MB.OrderBy).Select(MB => new SelectListItem { Value = MB.MonthlyExpenseEB_Id.ToString(), Text = MB.MonthlyExpenseEBInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Monthly Expense" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLMS(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_SourceEnergyM.Where(MS => MS.IsActive == true).OrderBy(MS => MS.OrderBy).Select(MS => new SelectListItem { Value = MS.SourceEnergy_Id.ToString(), Text = MS.SourceEnergyInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Energy Source" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLSK(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_SolarkilowattM.Where(SK => SK.IsActive == true).OrderBy(SK => SK.OrderBy).Select(SK => new SelectListItem { Value = SK.Solarkilowatt_Id.ToString(), Text = SK.SolarkilowattInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Please Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLYesandNo(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_TypeYesNoM.Where(YN => YN.IsActive == true).OrderBy(YN => YN.OrderBy).Select(YN => new SelectListItem { Value = YN.SolarEpanel_Id.ToString(), Text = YN.SolarEpanelInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Please Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLSubsidy(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_SubisdyM.Where(SS => SS.IsActive == true).OrderBy(SS => SS.OrderBy).Select(SS => new SelectListItem { Value = SS.Subisdy_Id.ToString(), Text = SS.SubisdyInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Subsidy" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLAvgAmt(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_MoneySavedSEM.Where(MS => MS.IsActive == true).OrderBy(MS => MS.OrderBy).Select(MS => new SelectListItem { Value = MS.MoneySavedSE_Id.ToString(), Text = MS.MoneySavedSEInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Please Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLEU(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_ElectricityUsedM.Where(EU => EU.IsActive == true).OrderBy(EU => EU.OrderBy).Select(EU => new SelectListItem { Value = EU.ElectricityUsed_Id.ToString(), Text = EU.ElectricityUsedInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Electricity Used" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLEBM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_MonthlyExpenseEBM.Where(EBM => EBM.IsActive == true).OrderBy(EBM => EBM.OrderBy).Select(EBM => new SelectListItem { Value = EBM.MonthlyExpenseEB_Id.ToString(), Text = EBM.MonthlyExpenseEBInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select Monthly Expenses" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
    }



       
}