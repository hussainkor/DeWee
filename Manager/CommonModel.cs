using DeWee.Helpers;
using DeWee.Models;
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
using System.Web.ClientServices;
using System.Web.Mvc;
using System.Web.UI.WebControls;
//using System.Windows.Interop;

namespace DeWee.Manager
{
    public class CommonModel
    {
        private static DeWee_DBEntities _db = new DeWee_DBEntities();

        #region BaseUrl
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            // throw new Exception("No network adapters with an IPv4 address in the system!");
            return "Error";
        }
        public static string GetPublicIPAddress()
        {
            using (HttpClient client = new HttpClient())
            {
                string publicIPAddress = client.GetStringAsync("https://api.ipify.org").Result;
                return publicIPAddress;
            }
        }

        public static string GetBaseUrl()
        {
            var str = HttpContext.Current.Request.Url.Host;
            //return str;
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            string host = HttpContext.Current.Request.Url.Host;
            if (host == "localhost")
            {
                host = HttpContext.Current.Request.Url.Authority;
                return HttpContext.Current.Request.Url.Scheme + "://" + host;
            }
            //return urlHelper.Content("~/");
            return HttpContext.Current.Request.Url.Scheme + "://" + str;
        }
        public static string GetWebUrl()
        {
            return ConfigurationManager.AppSettings["WebUrl"];
        }
        public static bool ValidateImageSizeMemory(MemoryStream ms)
        {
            const int maxSizeInBytes = 1 * 1024 * 1024; // 1 MB in bytes

            // Check if the stream size is less than or equal to 1 MB
            if (ms.Length <= maxSizeInBytes)
            {
                return true; // Valid size
            }

            return false; // Invalid size
        }
        public static bool ValidateImageSize(HttpPostedFileBase image)
        {
            const int maxSizeInBytes = 1 * 1024 * 1024; // 1 MB in bytes

            // Check if the stream size is less than or equal to 1 MB
            if (image.ContentLength <= maxSizeInBytes)
            {
                return true; // Valid size
            }

            return false; // Invalid size
        }

        public static bool IsEmailConfiguredToLive()
        {
            var isLive = Convert.ToBoolean(ConfigurationManager.AppSettings["IsEmailSetLive"].ToString());
            return isLive;
        }
        public static string GetLocalEmailAddress()
        {
            var emailAddr = ConfigurationManager.AppSettings["LocalEmailAddress"].ToString();
            return emailAddr;
        }

        public static string GetFileUrl(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                return CommonModel.GetBaseUrl() + filePath.ToString().Replace("~", "");
            else
                return string.Empty;
        }

        public static string GetMultipleFileUrlFromComma(string filePaths)
        {
            //string filePath = string.Empty;
            //var filePathArray = filePaths.Split(',');
            List<string> filePathList = new List<string>();
            foreach (var path in filePaths.Split(','))
            {
                if (!string.IsNullOrEmpty(path))
                {
                    //return CommonModel.GetBaseUrl() + path.ToString().Replace("~", "");
                    filePathList.Add(CommonModel.GetBaseUrl() + path.Trim().ToString().Replace("~", ""));
                }
                //else
                //    return string.Empty;
            }
            //filePathList=.Join(',');
            return string.Join(",", filePathList);
        }

        public static string GetHeaderUSLogo(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                return filePath.ToString().Replace("src=\"..//Content/images/USAID_Template.png\"", "src=\"" + CommonModel.GetWebUrl() + "/Content/images/USAID_Template.png\"");
            else
                return string.Empty;
        }
        public static string GetHeaderCareLogo(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                return filePath.ToString().Replace("src=\"..//Content/images/Care_Template.png\"", "src=\"" + CommonModel.GetWebUrl() + "/Content/images/Care_Template.png\"");
            else
                return string.Empty;
        }
        #endregion

        #region Master

        public static List<SelectListItem> GetALLStateM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_State_Master.OrderBy(state => state.OrderBy).Select(state => new SelectListItem { Value = state.StateId_pk.ToString(), Text = state.StateName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }

        public static List<SelectListItem> GetALLDistrictM(int IsSelect = 0, int StateId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_District_Master.Where(x => x.IsActive == true && x.StateId_fk == StateId || 0 == StateId).OrderBy(x => x.OrderBy).Select(item => new SelectListItem { Value = item.DistrictId_pk.ToString(), Text = item.DistrictName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }
            return list;
        }
        public static List<SelectListItem> GetALLBlockM(int IsSelect = 0, int StateId = 0, int DistrictId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Block_Master.Where(Block => Block.IsActive == true && Block.DistrictId_fk == DistrictId).OrderBy(Block => Block.OrderBy).Select(Block => new SelectListItem { Value = Block.BlockId_pk.ToString(), Text = Block.BlockName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLPanchayatM(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Panchayat_Master.Where(p => p.IsActive == true && p.DistrictId_fk == DistrictId && p.BlockId_fk == BlockId).OrderBy(Panchayat => Panchayat.OrderBy).Select(Panchayat => new SelectListItem { Value = Panchayat.PanchayatId_pk.ToString(), Text = Panchayat.PanchayatName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLVillM(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0, int PanchayatId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_Village_Master.Where(x => x.IsActive == true && x.DistrictId_fk == DistrictId && x.BlockId_fk == BlockId && x.PanchayatId_fk == PanchayatId).OrderBy(Vill => Vill.OrderBy).Select(Vill => new SelectListItem { Value = Vill.VillageId_pk.ToString(), Text = Vill.VillageName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLCLFM(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_CLF_Master.Where(x => x.IsActive == true && x.DistrictId_fk == DistrictId && x.BlockId_fk == BlockId).OrderBy(CLF => CLF.OrderBy).Select(CLF => new SelectListItem { Value = CLF.CLFId_pk.ToString(), Text = CLF.CLFName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        public static List<SelectListItem> GetALLVO(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0, int PanchayatId = 0, int CLFId = 0,int VId=0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.Tbl_VO_Master.Where(x => x.IsActive == true && x.DistrictId_fk == DistrictId && x.BlockId_fk == BlockId && x.PanchayatId_fk == PanchayatId && x.CLFId_fk == CLFId).OrderBy(VO => VO.OrderBy).Select(VO => new SelectListItem { Value = VO.VOrgId_pk.ToString(), Text = VO.Village_OrganizationName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
            list = _db.Tbl_BusinessOwnedM.Where(Bo => Bo.IsActive == true).OrderBy(Bo => Bo.OrderBy).Select(Bo => new SelectListItem { Value = Bo.BusinessOwned_Id.ToString(), Text = Bo.BusinessOwnedInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Subsidy" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
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
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list;
        }
        #endregion
    }




}