using DeWee.Models;
using DocumentFormat.OpenXml.EMMA;
using SubSonic.Schema;
using System;
using System.Data;
using System.EnterpriseServices;
using System.Web;
using System.Web.Security;
using static DeWee.Manager.CommonModel;

namespace DeWee.Manager
{
    public static partial class SPManager
    {
        public static DataTable GetSPMasterList(int StateId, string RoleIds, string TrainingCenterIds)
        {
            StoredProcedure sp = new StoredProcedure("SPMasterList");
            sp.Command.AddParameter("@StateId", StateId, DbType.Int32);
            sp.Command.AddParameter("@RoleIds", RoleIds, DbType.String);
            sp.Command.AddParameter("@TrainingCenterIds", TrainingCenterIds, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable Check_ParticipantAlready(string Id,string Pno, string AdhNo)
        {
            StoredProcedure sp = new StoredProcedure("Check_ParticipantAlready");
            sp.Command.AddParameter("@ID", Id, DbType.Int32);
            sp.Command.AddParameter("@PhoneNo", Pno, DbType.String);
            sp.Command.AddParameter("@AadharNo", AdhNo, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable Get_USP_ParticipantList()
        {
            StoredProcedure sp = new StoredProcedure("USP_ParticipantList");
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable SP_BeneficiaryList(string SId = "", string DId = "", string BId = "")
        {
            StoredProcedure sp = new StoredProcedure("SP_BeneficiaryList");
            sp.Command.AddParameter("@SId", SId, DbType.String);
            sp.Command.AddParameter("@DId", DId, DbType.String);
            sp.Command.AddParameter("@BId", BId, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable Get_Usp_BeneficiaryDetails(string BfyId)
        {
            StoredProcedure sp = new StoredProcedure("Usp_BeneficiaryDetails");
            sp.Command.AddParameter("@BfyId", BfyId, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataSet USP_GetDashboardLegend(int CId, int SId, int DId, int BId, int TypeOfEnterpriseId, int TypeofIndicator)
        {
            StoredProcedure sp = new StoredProcedure("SP_GetDashboardMain");
            sp.Command.AddParameter("@CId", CId, DbType.Int32);
            sp.Command.AddParameter("@SId", SId, DbType.Int32);
            sp.Command.AddParameter("@DId", DId, DbType.Int32);
            sp.Command.AddParameter("@BId", BId, DbType.Int64);
            sp.Command.AddParameter("@TypeOfEnterpriseId", TypeOfEnterpriseId, DbType.Int64);
            sp.Command.AddParameter("@TypeofIndicator", TypeofIndicator, DbType.Int32);
            DataSet ds = sp.ExecuteDataSet();
            return ds;
        }
        public static DataSet USP_PartQAList()
        {
            StoredProcedure sp = new StoredProcedure("USP_PartQAList");
            DataSet ds = sp.ExecuteDataSet();
            return ds;
        }
        public static DataSet Usp_GetMasterDataInJson(LoginModel model)
        {
            StoredProcedure sp = new StoredProcedure("Usp_GetMasterDataInJson");
            sp.Command.AddParameter("@UserName", model.UserName, DbType.String);
            DataSet ds = sp.ExecuteDataSet();
            return ds;
        }
        public static DataTable SP_BeneficiaryJsonPostData(LoginModel model)
        {
            StoredProcedure sp = new StoredProcedure("SP_BeneficiaryJsonPostData");
            sp.Command.AddParameter("@UserName", model.UserName, DbType.String);
            sp.Command.AddParameter("@Password", model.Password, DbType.String);
            sp.Command.AddParameter("@Version",model.Version, DbType.String);
            sp.Command.AddParameter("@JsonData", model.JsonData, DbType.String);
            sp.Command.AddParameter("@RowAfected", model.RowAfected, DbType.Int32);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable Usp_PostEnterpriseImage(string imguuid = "",string filepath="",string type = "", string Version = "")
        {
            StoredProcedure sp = new StoredProcedure("Usp_SaveApiEnterpriseImage");
            sp.Command.AddParameter("@imguuid", imguuid, DbType.String);
            sp.Command.AddParameter("@filepath", filepath, DbType.String);
            sp.Command.AddParameter("@filetype", type, DbType.String);
            sp.Command.AddParameter("@Version", Version, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable SP_GetBFYId(string uuid = "")
        {
            StoredProcedure sp = new StoredProcedure("SP_GetBFYId");
            sp.Command.AddParameter("@uuid", uuid, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }

        public static DataTable Usp_GetTHRList(string SId = "", string DId = "", string BId = "")
        {
            StoredProcedure sp = new StoredProcedure("Usp_GetTHRList");
            sp.Command.AddParameter("@SId", SId, DbType.String);
            sp.Command.AddParameter("@DId", DId, DbType.String);
            sp.Command.AddParameter("@BId", BId, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable Usp_ReferralList(string DId = "", string BId = "")
        {
            StoredProcedure sp = new StoredProcedure("Usp_ReferralList");
            sp.Command.AddParameter("@DId", DId, DbType.String);
            sp.Command.AddParameter("@BId", BId, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable Usp_SolarShopList(string DId = "", string BId = "")
        {
            StoredProcedure sp = new StoredProcedure("Usp_SolarShopList");
            sp.Command.AddParameter("@DId", DId, DbType.String);
            sp.Command.AddParameter("@BId", BId, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
    }
}
