using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class Participant
    {
        [Key]
        public Guid Indt_Id { get; set; }

        [Display(Name = PartDisplayName.State_Id)]
        [Required]
        public int State_Id { get; set; }

        [Display(Name = "District")]
        [Required]
        public int District_Id { get; set; }

        [Display(Name = "Block")]
        [Required]
        public int Block_Id { get; set; }

        [Display(Name = "GP Name")]
        [Required]
        public int Panchayat_Id { get; set; }


        [Display(Name = "Village Name")]
        [Required]
        public int Village_Id { get; set; }


        [Display(Name = "CLF Name")]
        [Required]
        public int CLF_Id { get; set; }

        [Display(Name = "VO Name")]
        [Required]
        public int VO_Id { get; set; }


        [Display(Name = "SHG Name")]
        [Required]
        public int SHG_Id { get; set; }


        [Display(Name = "Establishment Year of SHG")]
        [Required]
        public int YearOfSHG { get; set; }

        [Display(Name = "Name of SHG Member")]
        [Required]
        public string NameofSHGmember { get; set; }

        [Display(Name = "Name of Owner Enterprises")]
        [Required]
        public string NameofEnterpriseOwner { get; set; }

        [Display(Name = "Age")]
        [Required]
        public int Age { get; set; }

        [Display(Name = "Education Qlf")]
        [Required]
        public int EducationQlf_Id { get; set; }

        [Display(Name = "Caste")]
        [Required]
        public int Caste_Id { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Type of Business or Enterprise")]
        [Required]
        public int TypeofEnterpriseBusin_Id { get; set; }

        [Display(Name = "Business Owned Type")]
        [Required]
        public int BusinessOwnedType_Id { get; set; }

        [Display(Name = "Where is your enterprise established?")]
        [Required]
        public int EstablishedEnterpriseType_Id { get; set; }


        [Display(Name = "How did you arrange capital for investment in your business?")]
        [Required]
        public int TypeOfInvestBusin_Id { get; set; }

        [Display(Name = "If you took a loan, describe source?")]
        [Required]
        public int TookSourceOfLoan_Id { get; set; }


        [Display(Name = "How much loan did you take from SHG?")]
        [Required]
        public decimal TookLoanAmt { get; set; }

        [Display(Name = "How much Loan did you take from bank?")]
        [Required]
        public decimal TookLoanAmtBank { get; set; }

        [Display(Name = "How much Loan did you take from relatives?")]
        [Required]
        public decimal TookLoanAmtR { get; set; }

        [Display(Name = "How much Loan did you take from other sources?")]
        [Required]
        public decimal TookLoanAmtO { get; set; }

        [Display(Name = "How much money did you invest from your side to start your business?")]
        [Required]
        public decimal StartBusinessInvestAmt { get; set; }


        [Display(Name = "How much loan did you take to start your business?")]
        [Required]
        public decimal StartYourBusinessTakeAmt { get; set; }

        [Display(Name = "What is your monthly profit from the business?")]
        [Required]
        public decimal MonthlyProfitBusiness { get; set; }

        [Display(Name = "How many people work in your enterprise?(Family-Member's)")]
        [Required]
        public int WorkInEnterprises_FamilyMembers { get; set; }

        [Display(Name = "How many people work in your enterprise?(SHG-Member's)")]
        [Required]
        public int WorkInEnterprises_SHGMembers { get; set; }


        [Display(Name = "How many people work in your enterprise?(Assitant / Staff's)")]
        [Required]
        public int WorkInEnterprises_AssitantStaff { get; set; }

        [Display(Name = "What is the type of machine in your enterprise?")]
        [Required]
        public int TypeOfMachineEnterprise_Id { get; set; }

        [Display(Name = "If Mechanised (Motor based) , then how many machines are in actual use?")]
        [Required]
        public int MotorBasedOnMachinesInActualUsed { get; set; }

        [Display(Name = "What is the estimated power of all your machinery? (In kilowatt)")]
        [Required]
        public int MachineryPowerkilowatt_Id { get; set; }

        [Display(Name = "Your Electricity Connection is of how many kilowatt?")]
        [Required]
        public int ElectricityConnection_Id { get; set; }

        [Display(Name = "Your Electricity Connection is of how many kilowatt?")]
        [Required]
        public int ConnectionPhaseofPower_Id { get; set; }

        [Display(Name = "How much is your monthly electricity consumption?")]
        [Required]
        public int MonthlyElectricityConsumption_Id { get; set; }

        [Display(Name = "What is the source of energy for your machines?")]
        [Required]
        public int MachineSourceofEnergy_Id { get; set; }

        [Display(Name = "If its solar, how many kilowatt is it?")]
        [Required]
        public int Solar_InKilowatt_Id { get; set; }

        [Display(Name = "Did you set up solar energy panel ?")]
        [Required]
        public int Solar_EnergyPanelYesNo_Id { get; set; }

        [Display(Name = "How much expenditure was incurred on solar energy panel set-up / establishment?")]
        [Required]
        public decimal Solar_ExpenditureIncurredAmt { get; set; }

        [Display(Name = "Did you receive any subisdy for setting up of solar energy panels ?")]
        [Required]
        public int Subsidy_Id { get; set; }

        [Display(Name = "Did you receive any loan for setting up of solar energy panels?")]
        [Required]
        public int LoanForSolarPanels_Id { get; set; }

        [Display(Name = "Give the average amount of money saved by you every month due to solar energy?")]
        [Required]
        public int AvgAmtSavedFromSolarE_Id { get; set; }

        [Display(Name = "How many hours is the electricity used? (1-24 hours)")]
        [Required]
        public int ElectricityUsed_Id { get; set; }

        [Display(Name = "What is your monthly expense on the electricity bill?")]
        [Required]
        public int MonthlyExpenseInElectricity_Id { get; set; }

        [Display(Name = "If generator is in use, then mention the number of hours (1-24 hours)?")]
        [Required]
        public int GeneratorElectricityUsed_Id { get; set; }

        [Display(Name = "What is your expense on other fuel sources? (Diesel, Coal, Kerosene, etc.) (Monthly)")]
        [Required]
        public int ExpenseFuelSource_Id { get; set; }

        [Display(Name = "How much is the cost towards repair for arranging electricity or ? (Monthly)")]
        [Required]
        public int RepairCost_Id { get; set; }

        [Display(Name = "Have you heard about solar energy ?")]
        [Required]
        public int HeardAboutSE_Id { get; set; }

        [Display(Name = "If Yes, where did you hear about it ?")]
        [Required]
        public string IfYeswhere { get; set; }

        [Display(Name = "Do you have information / knowledge about govt. subsidy/aid for uptake of solar energy?")]
        [Required]
        public int InformationknowledgeAboutgovtsubsidyOfSE_Id { get; set; }

        [Display(Name = "If yes, then what is the amount of govt. aid provided?")]
        [Required]
        public int IfYesAmtGovPaid { get; set; }

        [Display(Name = "Are you aware of the loan procedure involved for uptake of solar energy?")]
        [Required]
        public int LoanProcedureInSE_Id { get; set; }

        [Display(Name = "Are you willing to adopt solarization / solar energy?")]
        [Required]
        public int AdoptSolarization_Id { get; set; }

        [Display(Name = "Have you arranged any capital for adoption of solar energy?")]
        [Required]
        public int CapitalArrangedForSE_Id { get; set; }

        [Display(Name = "If yes, then what amount of capital is arranged for investment in solar energy?")]
        [Required]
        public int IfYesCapitalArrangedForSE_Id { get; set; }

        [Display(Name = "Is there any other industry/enterprise in your village which has motor-operated machines installed? (includes SHG members)")]
        [Required]
        public int OtherIndustriesEnterprises_Id { get; set; }

        [Display(Name = "Is there any other industry/enterprise in your village which has motor-operated machines installed? (includes SHG members)")]
        [Required]
        public string IfYesFillTheForm { get; set; }


        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Deleted On")]
        public DateTime? DeletedOn { get; set; }

        //public List<Participant> Participants { get; set; }

    }
    public class PartDisplayName
    {
        public const string State_Id = "State";
        public const string District_Id = "District";

    }

}