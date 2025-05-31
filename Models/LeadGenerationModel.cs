using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class CreditProfileModel
    {
        public CreditProfileModel() { ID = 0; }
        public int ID { get; set; }
        public string BeneficiaryId { get; set; }
        public Nullable<int> SolarSolution { get; set; }
        public Nullable<int> Getloan { get; set; }
        public string Getloan_Other { get; set; }
        public string ActiveLoan { get; set; }
        public string SHGMeetingsPresent { get; set; }
        public string LoanSHGPreviously { get; set; }
        public string SHGTaken { get; set; }
        public string SHGFold { get; set; }
        public string IdentificationId { get; set; }
        public string LoanAmount { get; set; }
        public Nullable<System.DateTime> LoanProcessDate { get; set; }
        public Nullable<System.DateTime> LoanDisbursementDate { get; set; }
        public Nullable<int> ApplicationRejected { get; set; }
        public string ApplicationRejected_Other { get; set; }
        public string EMIDuration { get; set; }
        public string EMIAmount { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Version { get; set; }
        public string uuid { get; set; }
        public Nullable<System.DateTime> SynDate { get; set; }
        public Nullable<bool> IsMobile { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CeeatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string Latitude {  get; set; } 
        public string Longitude {  get; set; } 
        public string Location {  get; set; } 
    }
    public class EnergyRequirementModel
    {
        public EnergyRequirementModel() { ID = 0; }
        public int ID { get; set; }
        public string BeneficiaryId { get; set; }
        public int? InstallationProposed { get; set; }
        public string LoadEnterprisekW { get; set; }
        public string TechnicalAssessment { get; set; }
        public string TechnicalAssessment_Other { get; set; }
        public Nullable<int> CapacityInstallation { get; set; }
        public Nullable<int> SolarPVInstalledkW { get; set; }
        public string Version { get; set; }
        public string uuid { get; set; }
        public Nullable<System.DateTime> SynDate { get; set; }
        public Nullable<bool> IsMobile { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CeeatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location { get; set; }
    }
    public class InstallationCommissionModel
    {
        public InstallationCommissionModel() { ID = 0; }
        public int ID { get; set; }
        public string BeneficiaryId { get; set; }
        public string NameofVendor { get; set; }
        public Nullable<System.DateTime> DateofInstallation { get; set; }
        public Nullable<System.DateTime> DateofCommissioning { get; set; }
        public Nullable<System.DateTime> DateofTraining { get; set; }
        public Nullable<int> GHGEmissionYearlyKgs { get; set; }
        public Nullable<int> Numberofwomenemployed { get; set; }
        public Nullable<int> InverterWarranty { get; set; }
        public string AnnualMaintenanceDue { get; set; }
        public string ServiceContact { get; set; }
        public Nullable<System.DateTime> CompletionDate { get; set; }
        public string InverterName { get; set; }
        public string BatteryName { get; set; }
        public string BatteryWarranty { get; set; }
        public string SolarName { get; set; }
        public string SolarWarranty { get; set; }
        public string VfbMotorName { get; set; }
        public string VfbWarranty { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Version { get; set; }
        public string uuid { get; set; }
        public Nullable<System.DateTime> SynDate { get; set; }
        public Nullable<bool> IsMobile { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CeeatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location { get; set; }
    }
}