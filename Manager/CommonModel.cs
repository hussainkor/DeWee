using BitMiracle.LibTiff.Classic;
using DeWee.Helpers;
using DeWee.Models;
using Newtonsoft.Json;
using SubSonic.Extensions;
using SubSonic.Schema;
using System;
using System.Buffers.Text;
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
using System.Web.Services.Description;
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
        public static List<SelectListItem> GetIndicator(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }
            list.Add(new SelectListItem { Value = "1", Text = "Individual" });
            list.Add(new SelectListItem { Value = "2", Text = "Collective" });
            return list;
        }
        public static List<SelectListItem> GetALLCountryM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_Country.OrderBy(a => a.OrderBy).Select(a => new SelectListItem { Value = a.CountryId_pk.ToString(), Text = a.CountryName }).ToList();
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
        public static List<SelectListItem> GetALLStateM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_State.OrderBy(state => state.OrderBy).Select(state => new SelectListItem { Value = state.StateId_pk.ToString(), Text = state.StateName }).ToList();
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
            list = _db.mst_District.Where(x => x.IsActive == true && x.StateId_fk == StateId || 0 == StateId).OrderBy(x => x.DistrictName).Select(item => new SelectListItem { Value = item.DistrictId_pk.ToString(), Text = item.DistrictName }).ToList();
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
            list = _db.mst_Block.Where(Block => Block.IsActive == true && Block.DistrictId_fk == DistrictId).OrderBy(Block => Block.OrderBy).Select(Block => new SelectListItem { Value = Block.BlockId_pk.ToString(), Text = Block.BlockName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list.OrderBy(x => x.Text).ToList();
        }
        public static List<SelectListItem> GetALLPanchayatM(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_GP.Where(p => p.IsActive == true && p.DistrictId_fk == DistrictId && p.BlockId_fk == BlockId).OrderBy(Panchayat => Panchayat.OrderBy).Select(Panchayat => new SelectListItem { Value = Panchayat.GPId_pk.ToString(), Text = Panchayat.GPName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list.OrderBy(x => x.Text).ToList();
        }
        public static List<SelectListItem> GetALLVillM(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0, int PanchayatId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_Village.Where(x => x.IsActive == true && x.DistrictId_fk == DistrictId && x.BlockId_fk == BlockId && x.PanchayatId_fk == PanchayatId).OrderBy(Vill => Vill.OrderBy).Select(Vill => new SelectListItem { Value = Vill.VillageId_pk.ToString(), Text = Vill.VillageName }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }

            return list.OrderBy(x => x.Text).ToList();
        }
        public static List<SelectListItem> GetALLCLFM(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_CLF.Where(x => x.IsActive == true && x.DistrictId_fk == DistrictId && x.BlockId_fk == BlockId).OrderBy(CLF => CLF.OrderBy).Select(CLF => new SelectListItem { Value = CLF.CLFId_pk.ToString(), Text = CLF.CLFName }).ToList();
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
        public static List<SelectListItem> GetALLVO(int IsSelect = 0, int StateId = 0, int DistrictId = 0, int BlockId = 0, int PanchayatId = 0, int CLFId = 0, int VId = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();// && x.CLFId_fk == CLFId 
            list = _db.mst_VO.Where(x => x.IsActive == true && x.DistrictId_fk == DistrictId && x.BlockId_fk == BlockId && x.PanchayatId_fk == PanchayatId && x.VillageId_fk == VId).OrderBy(VO => VO.OrderBy).Select(VO => new SelectListItem { Value = VO.VOrgId_pk.ToString(), Text = VO.Village_OrganizationName }).ToList();
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
            list = _db.mst_Educational_Qualification.Where(EQ => EQ.IsActive == true).OrderBy(EQ => EQ.OrderBy).Select(EQ => new SelectListItem { Value = EQ.Qualification_Id.ToString(), Text = EQ.QualificationInEng }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }
            return list.OrderBy(x => x.Text).ToList();
        }
        public static List<SelectListItem> GetALLCaste(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_Caste.Where(CS => CS.IsActive == true).OrderBy(CS => CS.OrderBy).Select(CS => new SelectListItem { Value = CS.Caste_Id.ToString(), Text = CS.CasteInEng }).ToList();
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
            list = _db.mst_BusinessType.Where(BE => BE.IsActive == true).OrderBy(BE => BE.OrderBy).Select(BE => new SelectListItem { Value = BE.BusinessType_Id.ToString(), Text = BE.BusinessTypeInEng }).ToList();
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
            list = _db.mst_BusinessOwned.Where(Bo => Bo.IsActive == true).OrderBy(Bo => Bo.OrderBy).Select(Bo => new SelectListItem { Value = Bo.BusinessOwned_Id.ToString(), Text = Bo.BusinessOwnedInEng }).ToList();
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
            list = _db.mst_Enterprise_Established.Where(EE => EE.IsActive == true).OrderBy(EE => EE.OrderBy).Select(EE => new SelectListItem { Value = EE.Enterprise_Established_Id.ToString(), Text = EE.Enterprise_EstablishedInEng }).ToList();
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
            list = _db.mst_BusinessInvestment.Where(IB => IB.IsActive == true).OrderBy(IB => IB.OrderBy).Select(IB => new SelectListItem { Value = IB.BusinessInvestment_Id.ToString(), Text = IB.BusinessInvestmentInEng }).ToList();
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
            list = _db.mst_LoanDescribeSource.Where(LS => LS.IsActive == true).OrderBy(LS => LS.OrderBy).Select(LS => new SelectListItem { Value = LS.LoanDescribeSource_Id.ToString(), Text = LS.LoanDescribeSourceInEng }).ToList();
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
            list = _db.mst_EnterpriseMachine.Where(EM => EM.IsActive == true).OrderBy(EM => EM.OrderBy).Select(EM => new SelectListItem { Value = EM.EnterpriseMachine_Id.ToString(), Text = EM.EnterpriseMachineInEng }).ToList();
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
            list = _db.mst_MachineryPower.Where(MK => MK.IsActive == true).OrderBy(MK => MK.OrderBy).Select(MK => new SelectListItem { Value = MK.MachineryPower_Id.ToString(), Text = MK.MachineryPowerInEng }).ToList();
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
            list = _db.mst_PowerConnection.Where(PC => PC.IsActive == true).OrderBy(PC => PC.OrderBy).Select(PC => new SelectListItem { Value = PC.PowerConnection_Id.ToString(), Text = PC.PowerConnectionInEng }).ToList();
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
        public static List<SelectListItem> GetALLECBILL(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_ElectricityConsumption.Where(x => x.IsActive == true).OrderBy(x => x.OrderBy).Select(x => new SelectListItem { Value = x.ElectricityConsumption_Id.ToString(), Text = x.ElectricityConsumptionInEng }).ToList();
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
            list = _db.mst_SourceEnergy.Where(MS => MS.IsActive == true).OrderBy(MS => MS.OrderBy).Select(MS => new SelectListItem { Value = MS.SourceEnergy_Id.ToString(), Text = MS.SourceEnergyInEng }).ToList();
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
            list = _db.mst_Solarkilowatt.Where(SK => SK.IsActive == true).OrderBy(SK => SK.OrderBy).Select(SK => new SelectListItem { Value = SK.Solarkilowatt_Id.ToString(), Text = SK.SolarkilowattInEng }).ToList();
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
            list = _db.mst_TypeYesNo.Where(YN => YN.IsActive == true).OrderBy(YN => YN.OrderBy).Select(YN => new SelectListItem { Value = YN.SolarEpanel_Id.ToString(), Text = YN.SolarEpanelInEng }).ToList();
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
            list = _db.mst_Subisdy.Where(SS => SS.IsActive == true).OrderBy(SS => SS.OrderBy).Select(SS => new SelectListItem { Value = SS.Subisdy_Id.ToString(), Text = SS.SubisdyInEng }).ToList();
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
            list = _db.mst_MoneySavedSE.Where(MS => MS.IsActive == true).OrderBy(MS => MS.OrderBy).Select(MS => new SelectListItem { Value = MS.MoneySavedSE_Id.ToString(), Text = MS.MoneySavedSEInEng }).ToList();
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
            list = _db.mst_ElectricityUsed.Where(EU => EU.IsActive == true).OrderBy(EU => EU.OrderBy).Select(EU => new SelectListItem { Value = EU.ElectricityUsed_Id.ToString(), Text = EU.ElectricityUsedInEng }).ToList();
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
            list = _db.mst_MonthlyExpenseEB.Where(EBM => EBM.IsActive == true).OrderBy(EBM => EBM.OrderBy).Select(EBM => new SelectListItem { Value = EBM.MonthlyExpenseEB_Id.ToString(), Text = EBM.MonthlyExpenseEBInEng }).ToList();
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

        public static List<SelectListItem> GetALLBIM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_BusinessInstallation.Where(EBM => EBM.IsActive == true).OrderBy(EBM => EBM.OrderBy).Select(EBM => new SelectListItem { Value = EBM.BusinessInstallation_Id.ToString(), Text = EBM.BusinessInstallationInEng }).ToList();
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

        public static List<SelectListItem> GetALLSAM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_SpaceAvailable.Where(EBM => EBM.IsActive == true).OrderBy(EBM => EBM.OrderBy).Select(EBM => new SelectListItem { Value = EBM.SpaceAvailable_Id.ToString(), Text = EBM.SpaceAvailableInEng }).ToList();
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

        public static List<SelectListItem> GetALLNSM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_NatureSpace.Where(EBM => EBM.IsActive == true).OrderBy(EBM => EBM.OrderBy).Select(EBM => new SelectListItem { Value = EBM.NatureSpace_Id.ToString(), Text = EBM.NatureSpaceInEng }).ToList();
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

        public static List<SelectListItem> GetALLMSM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_MachineSource.Where(EBM => EBM.IsActive == true).OrderBy(EBM => EBM.OrderBy).Select(EBM => new SelectListItem { Value = EBM.MachineSource_Id.ToString(), Text = EBM.MachineSourceInEng }).ToList();
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

        public static List<SelectListItem> GetALLSIM(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_SolarInstallation.Where(EBM => EBM.IsActive == true).OrderBy(EBM => EBM.OrderBy).Select(EBM => new SelectListItem { Value = EBM.SolarInstallation_Id.ToString(), Text = EBM.SolarInstallationInEng }).ToList();
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
        public static List<SelectListItem> GetTypeOfRelative(int IsSelect = 0)
        {
            DeWee_DBEntities _db = new DeWee_DBEntities();
            List<SelectListItem> list = new List<SelectListItem>();
            list = _db.mst_Relative.Where(EQ => EQ.IsActive == true).OrderBy(EQ => EQ.OrderBy).Select(EQ => new SelectListItem { Value = EQ.TypeOfRelativeId_pk.ToString(), Text = EQ.TypeOfRelative }).ToList();
            if (IsSelect == 0)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "Select" });
            }
            else if (IsSelect == 1)
            {
                list.Insert(0, new SelectListItem { Value = "", Text = "All" });
            }
            return list.OrderBy(x => x.Text).ToList();
        }
        #endregion


        #region Document Upload
        public static string GetFilePath(HttpPostedFileBase file, string Module, string RegNo, string Ques_fk, string Folder)
        {
            var url = string.Empty;
            try
            {
                string file_extension = Path.GetExtension(file.FileName).ToLower();
                Stream strmStream = file.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                {
                    url = "~/Uploads/" + Module + "/" + RegNo + "/" + Folder + "/";
                    string extension = Path.GetExtension(file.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(url)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(url));
                    }
                    int index = 1;
                    string filenamewithoutext = Path.GetFileNameWithoutExtension(file.FileName);
                    string fname = filenamewithoutext + extension;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(url, fname))))
                    {
                        index++;
                        fname = file.FileName + "(" + index.ToString() + ")" + extension;
                    }
                    //url = HttpContext.Current.Server.MapPath(url + Ques_fk + "_" + fname);
                    url = url + Ques_fk + "_" + fname;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return url;
        }
        public static string SaveFileDynamically(HttpPostedFileBase[] files, string Module, string RegNo, string Ques_fk, string Folder)
        {
            string URL = "";
            try
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string file_extension = Path.GetExtension(file.FileName).ToLower();
                        Stream strmStream = file.InputStream;
                        if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                        {
                            URL = "~/Uploads/" + Module + "/" + RegNo + "/" + Folder + "/";
                            string extension = Path.GetExtension(file.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                            }
                            int index = 1;
                            string filenamewithoutext = Path.GetFileNameWithoutExtension(file.FileName);
                            string fname = filenamewithoutext + extension;
                            while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                            {
                                index++;
                                fname = file.FileName + "(" + index.ToString() + ")" + extension;
                            }
                            file.SaveAs(HttpContext.Current.Server.MapPath(URL + Ques_fk + "_" + fname));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return URL;
        }
        public static string SaveFile(HttpPostedFileBase[] files, string Module, string RegNo, string Folder)
        {
            string URL = "";
            try
            {
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string file_extension = Path.GetExtension(file.FileName).ToLower();
                        Stream strmStream = file.InputStream;
                        if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                        {
                            //URL = "~/Uploads/" + Module + "/" + RegNo + "/" + Folder + "/";
                            URL = "~/Uploads/" + RegNo + " / ";
                            string extension = Path.GetExtension(file.FileName);

                            if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                            {
                                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                            }
                            int index = 1;
                            string filenamewithoutext = Path.GetFileNameWithoutExtension(file.FileName);
                            string fname = filenamewithoutext + extension;
                            while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                            {
                                index++;
                                fname = file.FileName + "(" + index.ToString() + ")" + extension;
                            }
                            file.SaveAs(HttpContext.Current.Server.MapPath(URL + fname));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return URL;
        }
        public static string SaveSingleFile(HttpPostedFileBase files, string Module, string RegNo)
        {
            string URL = "";
            string filepath = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".doc" || file_extension == ".dotx" || file_extension == ".dot" || file_extension == ".pptx" || file_extension == ".ppt" || file_extension == ".rar" || file_extension == ".zip" || file_extension == ".xls" || file_extension == ".xlsx")
                {
                    //URL = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + Module + "/" + RegNo + "/"));
                    URL = "~/Uploads/" + RegNo + "/";
                    string extension = Path.GetExtension(files.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                    }
                    int index = 1;
                    string fname = files.FileName;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                    {
                        index++;
                        fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    }
                    var fpicpath = HttpContext.Current.Server.MapPath(URL + (Module + "-" + fname));
                    ResizeImage(fpicpath, fpicpath, 300, 300); // Resize to 300x300 px
                    files.SaveAs(fpicpath);
                    filepath = URL + (Module + "-" + fname);
                }
            }

            return filepath;
        }
        public static string SaveSingleFileBase64string(string base64Stringfiles, string Module, string RegNo)
        {
            string URL = "";
            string filepath = string.Empty;
            // byte[] base64String = Convert.FromBase64String(files);//Convert.FromBase64String(base64);
            if (!string.IsNullOrWhiteSpace(base64Stringfiles) && base64Stringfiles.Length > 0)
            {
                // Remove the data URI scheme prefix (if it exists), e.g., "data:image/png;base64,"
                string base64Data = base64Stringfiles.Split(',')[1]; // Get the Base64 data part

                // Convert the Base64 string into a byte array
                byte[] imageBytes = Convert.FromBase64String(base64Data);
                if (ValidateImageSizeDocoument(imageBytes, 5)) // 5 MB validation
                {
                    // Determine file extension (you may have the MIME type in the base64String or set it manually)
                    string extension = ".jpeg"; // Default to PNG or infer based on MIME type if available
                    string fileName = RegNo;
                    URL = "~/Uploads/" + Module + "/";
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                    }
                    int index = 1;
                    string fname = fileName;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                    {
                        index++;
                        fname = fileName + "(" + index.ToString() + ")" + extension;
                    }
                    filepath = URL + fname + extension;
                    var fpicpath = HttpContext.Current.Server.MapPath(filepath);
                    // Specify the full file path
                    //string filePath = Path.Combine(fpicpath, fileName);

                    // Save the byte array as an image file
                    System.IO.File.WriteAllBytes(fpicpath, imageBytes);
                    //ResizeImage(filePath, filePath, 300, 300); // Resize to 300x300 px
                }
                else
                {
                    return "201";
                }
            }
            return filepath;
        }
        public static bool ValidateImageSize(byte[] msby)
        {
            const int maxSizeInBytes = 1048576;// 1 * 1024 * 1024; // 1 MB in bytes

            // Check if the stream size is less than or equal to 1 MB
            if (msby.Length <= maxSizeInBytes)
            {
                return true; // Valid size
            }
            else
            {
                return false; // INvalid size
            }
        }
        public static bool ValidateImageSizeDocoument(byte[] imageBytes, int maxMB)
        {
            // Convert MB to bytes (1 MB = 1024 * 1024 bytes)
            int maxSizeInBytes = 5242880;//maxMB * 1024 * 1024;

            // Check if the image size is less than or equal to the specified limit
            if (imageBytes.Length <= maxSizeInBytes)
            {
                return true; // Valid size
            }

            return false; // Invalid size
        }

        public static string ConvertImageToByteToString()
        {
            string folderPath = @"C:\Users\BinduKumari\Downloads\folderdemo"; // Specify your folder path
            string base64String = string.Empty;
            // Get all image files in the folder
            string[] imageFiles = Directory.GetFiles(folderPath, "*.jpg"); // Or "*.png", "*.jpeg", etc.

            foreach (string imagePath in imageFiles)
            {
                // Convert each image to byte array
                byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);

                // Convert byte array to base64 string (optional)
                base64String = Convert.ToBase64String(imageBytes);
            }

            return base64String;
        }
        private static void ResizeImage(string originalFilePath, string resizedFilePath, int width, int height)
        {
            using (var img = System.Drawing.Image.FromFile(originalFilePath))
            {
                // Create a new bitmap with the specified size
                var resizedImg = new Bitmap(img, new Size(width, height));

                // Save the resized image
                resizedImg.Save(resizedFilePath, ImageFormat.Jpeg);
            }
        }
        private static void CompressImage(string originalFilePath, string compressedFilePath, long quality)
        {
            using (var image = System.Drawing.Image.FromFile(originalFilePath))
            {
                // Set compression parameters for JPEG
                var jpegEncoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                if (jpegEncoder != null)
                {
                    var encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                    // Save the compressed image
                    image.Save(compressedFilePath, jpegEncoder, encoderParams);
                }
            }
        }

        public static string SaveSingleExcelFile(HttpPostedFileBase files, string Module, string RegNo)
        {
            string URL = "";
            string filepath = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".xls" || file_extension == ".xlsx")
                {
                    //URL = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + Module + "/" + RegNo + "/"));
                    URL = "~/Uploads/" + RegNo + "/";
                    string extension = Path.GetExtension(files.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                    }
                    int index = 1;
                    string fname = files.FileName;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                    {
                        index++;
                        fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    }
                    files.SaveAs(HttpContext.Current.Server.MapPath(URL + (Module + "-" + fname)));
                    filepath = URL + (Module + "-" + fname);
                }
            }

            return filepath;
        }

        public static string DeleteSingleFile(HttpPostedFileBase files, string Module, string RegNo)
        {
            //ToDo: Add code to delete single file from directory
            string URL = "";
            string filepath = string.Empty;



            return filepath;
        }

        public static string SaveSingleFile(HttpPostedFileBase files, string Module, string RegNo, string CustomFileName)
        {
            string URL = "";
            string filepath = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                {
                    //URL = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads/" + Module + "/" + RegNo + "/"));
                    URL = "~/Uploads/" + RegNo + "/";
                    string extension = Path.GetExtension(files.FileName);

                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(URL)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(URL));
                    }
                    int index = 1;
                    string fname = CustomFileName + extension; // files.FileName;
                    while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(Path.Combine(URL, fname))))
                    {
                        index++;
                        fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    }
                    files.SaveAs(HttpContext.Current.Server.MapPath(URL + (Module + "-" + fname)));
                    filepath = URL + (Module + "-" + fname);
                }
            }

            return filepath;
        }
        public static string GetFileName(HttpPostedFileBase files)
        {
            string filename = string.Empty;

            if (files != null && files.ContentLength > 0)
            {
                string file_extension = Path.GetExtension(files.FileName).ToLower();
                string filenamewithoutext = Path.GetFileNameWithoutExtension(files.FileName);
                Stream strmStream = files.InputStream;
                if (IsValidImage(strmStream) == true || file_extension == ".pdf" || file_extension == ".docx" || file_extension == ".pptx")
                {
                    string extension = Path.GetExtension(files.FileName);
                    int index = 1;
                    string fname = files.FileName;
                    fname = filenamewithoutext + "(" + index.ToString() + ")" + extension;
                    filename = fname;
                }
            }
            return filename;
        }
        public static bool IsValidImage(Stream stream)
        {
            try
            {
                //Read an image from the stream...
                var i = System.Drawing.Image.FromStream(stream);
                //Move the pointer back to the beginning of the stream
                stream.Seek(0, SeekOrigin.Begin);

                if (ImageFormat.Jpeg.Equals(i.RawFormat))
                    return true;
                return ImageFormat.Png.Equals(i.RawFormat) || ImageFormat.Gif.Equals(i.RawFormat);
            }
            catch
            {
                return false;
            }
        }
        //public static Binary BinarySaveSingleFile(HttpPostedFileBase files)
        //{
        //    byte[] Databytes;
        //    //try
        //    //{
        //    string empFilename = Path.GetFileName(files.FileName);
        //    string FilecontentType = files.ContentType;
        //    using (var reader = new BinaryReader(files.InputStream))
        //    {
        //        Databytes = reader.ReadBytes(files.ContentLength);
        //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    string error = ex.Message;
        //    //}
        //    return Databytes;
        //}
        public static string GetFileExt(string filename)
        {
            string myFilePath = filename;
            string ext = Path.GetExtension(myFilePath);
            return ext;
        }
        #endregion

        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string ISMobile { get; set; }
            public string Version { get; set; }
            public string JsonData { get; set; }
            public bool RememberMe { get; set; }
            public int RowAfected { get; set; }
        }

    }
}