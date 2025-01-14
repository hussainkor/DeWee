using DeWee.Models;
using SubSonic.Schema;
using System;
using System.Data;
using System.Web;
using System.Web.Security;

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
        public static DataSet USP_GetDashboardLegend()
        {
            StoredProcedure sp = new StoredProcedure("USP_GetDashboardLegend");
            DataSet ds = sp.ExecuteDataSet();
            return ds;
        }
    }
}
