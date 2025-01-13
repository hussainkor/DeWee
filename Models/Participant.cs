using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class Participant
    {
        public Participant()
        {
            Indt_Id = Guid.Empty;
        }
        [Key]
        public Guid Indt_Id { get; set; }

        [Display(Name = PartDisplayName.StateId)]
        //[Required]
        public int StateId { get; set; }

        [Display(Name = PartDisplayName.DistrictId)]
        //[Required]
        public int DistrictId { get; set; }

        [Display(Name = PartDisplayName.BlockId)]
        //[Required]
        public int BlockId { get; set; }

        [Display(Name = PartDisplayName.PanchayatId)]
        //[Required]
        public int PanchayatId { get; set; }


        [Display(Name = PartDisplayName.VillageId)]
        //[Required]
        public int VillageId { get; set; }


        [Display(Name = PartDisplayName.CLFId)]
        //[Required]
        public int CLFId { get; set; }

        [Display(Name = PartDisplayName.VOId)]
        //[Required]
        public int VOId { get; set; }


        [Display(Name = PartDisplayName.NameofSHG)]
        //[Required]
        public string NameofSHG { get; set; }


        [Display(Name = PartDisplayName.YearOfSHG)]
        //[Required]
        public int YearOfSHG { get; set; }

        [Display(Name = PartDisplayName.NameofSHGmember)]
        //[Required]
        public string NameofSHGmember { get; set; }

        [Display(Name = PartDisplayName.NameofEnterpriseOwner)]
        //[Required]
        public string NameofEnterpriseOwner { get; set; }

        [Display(Name = PartDisplayName.Age)]
        //[Required]
        public int Age { get; set; }

        [Display(Name = PartDisplayName.EducationQlf_Id)]
        //[Required]
        public int EducationQlf_Id { get; set; }

        [Display(Name = PartDisplayName.Caste_Id)]
        //[Required]
        public int Caste_Id { get; set; }

        [Display(Name = PartDisplayName.PhoneNumber)]
        //[Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string PhoneNumber { get; set; }

        [Display(Name = PartDisplayName.TypeofEnterpriseBusin_Id)]
        //[Required]
        public int TypeofEnterpriseBusin_Id { get; set; }
        [Display(Name = PartDisplayName.TypeofEnterpriseBusin_Other)]
        //[Required]
        public string TypeofEnterpriseBusin_Other { get; set; }

        [Display(Name = PartDisplayName.BusinessOwnedType_Id)]
        //[Required]
        public int BusinessOwnedType_Id { get; set; }

        [Display(Name = PartDisplayName.EstablishedEnterpriseType_Id)]
        //[Required]
        public int EstablishedEnterpriseType_Id { get; set; }


        [Display(Name = PartDisplayName.TypeOfInvestBusin_Id)]
        //[Required]
        public int TypeOfInvestBusin_Id { get; set; }

        [Display(Name = PartDisplayName.TookSourceOfLoan_Id)]
        //[Required]
        public int TookSourceOfLoan_Id { get; set; }


        [Display(Name = PartDisplayName.TookLoanAmt)]
        //[Required]
        public decimal TookLoanAmt { get; set; }

        //[Display(Name = PartDisplayName.TookLoanAmtBank)]
        ////[Required]
        //public decimal TookLoanAmtBank { get; set; }

        //[Display(Name = PartDisplayName.TookLoanAmtR)]
        ////[Required]
        //public decimal TookLoanAmtR { get; set; }

        //[Display(Name = PartDisplayName.TookLoanAmtO)]
        ////[Required]
        //public decimal TookLoanAmtO { get; set; }

        [Display(Name = PartDisplayName.StartBusinessInvestAmt)]
        //[Required]
        public decimal StartBusinessInvestAmt { get; set; }


        [Display(Name = PartDisplayName.StartYourBusinessTakeAmt)]
        //[Required]
        public decimal StartYourBusinessTakeAmt { get; set; }

        [Display(Name = PartDisplayName.MonthlyProfitBusiness)]
        //[Required]
        public decimal MonthlyProfitBusiness { get; set; }

        [Display(Name = PartDisplayName.WorkInEnterprises_FamilyMembers)]
        //[Required]
        public int WorkInEnterprises_FamilyMembers { get; set; }

        [Display(Name = PartDisplayName.WorkInEnterprises_SHGMembers)]
        //[Required]
        public int WorkInEnterprises_SHGMembers { get; set; }


        [Display(Name = PartDisplayName.WorkInEnterprises_AssitantStaffs)]
        //[Required]
        public int WorkInEnterprises_AssitantStaff { get; set; }

        [Display(Name = PartDisplayName.TypeofEnterpriseBusin_Id)]
        //[Required]
        public int TypeOfMachineEnterprise_Id { get; set; }

        [Display(Name = PartDisplayName.MotorBasedOnMachinesInActualUsed)]
        //[Required]
        public int MotorBasedOnMachinesInActualUsed { get; set; }

        [Display(Name = PartDisplayName.MachineryPowerkilowatt_Id)]
        //[Required]
        public int MachineryPowerkilowatt_Id { get; set; }

        [Display(Name = PartDisplayName.ElectricityConnection_Id)]
        //[Required]
        public int ElectricityConnection_Id { get; set; }

        [Display(Name = PartDisplayName.ConnectionPhaseofPower_Id)]
        //[Required]
        public int ConnectionPhaseofPower_Id { get; set; }

        [Display(Name = PartDisplayName.MonthlyElectricityConsumption_Id)]
        //[Required]
        public int MonthlyElectricityConsumption_Id { get; set; }

        [Display(Name = PartDisplayName.MachineSourceofEnergy_Id)]
        //[Required]
        public int MachineSourceofEnergy_Id { get; set; }
        [Display(Name = PartDisplayName.MachineSourceofEnergy_Others)]
        public string MachineSourceofEnergy_Others { get; set; }

        [Display(Name = PartDisplayName.Solar_InKilowatt_Id)]
        //[Required]

        public int Solar_InKilowatt_Id { get; set; }

        [Display(Name = PartDisplayName.Solar_EnergyPanelYesNo_Id)]
        //[Required]
        public int Solar_EnergyPanelYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.Solar_ExpenditureIncurredAmt)]
        //[Required]
        public decimal Solar_ExpenditureIncurredAmt { get; set; }

        [Display(Name = PartDisplayName.SubsidySolarReceive_Id)]
        //[Required]
        public int SubsidySolarReceive_Id { get; set; }

        [Display(Name = PartDisplayName.LoanSolarPanelsYesNo_Id)]
        //[Required]
        public int LoanSolarPanelsYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.MonthAvgAmtSavedDescription_Id)]
        //[Required]
        public int MonthAvgAmtSavedDescription_Id { get; set; }

        [Display(Name = PartDisplayName.ElectricityUsedHours_Id)]
        //[Required]
        public int ElectricityUsedHours_Id { get; set; }

        [Display(Name = PartDisplayName.MonthlyExpenseInElectricityBill_Id)]
        //[Required]
        public int MonthlyExpenseInElectricityBill_Id { get; set; }

        [Display(Name = PartDisplayName.GeneratorElectricityUsedHours_Id)]
        //[Required]
        public int GeneratorElectricityUsedHours_Id { get; set; }

        [Display(Name = PartDisplayName.MonthlyExpenseFuelSource_Id)]
        //[Required]
        public int MonthlyExpenseFuelSource_Id { get; set; }

        [Display(Name = PartDisplayName.MonthlyRepairCost_Id)]
        //[Required]
        public int MonthlyRepairCost_Id { get; set; }

        [Display(Name = PartDisplayName.HeardAboutSolarEYesNo_Id)]
        //[Required]
        public int HeardAboutSolarEYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.HeardAboutSolarEYes_IfYeswhere)]
        //[Required]
        public string HeardAboutSolarEYes_IfYeswhere { get; set; }

        [Display(Name = PartDisplayName.InforknowledgeGovtSubsidyOfSEYesNo_Id)]
        //[Required]
        public int InforknowledgeGovtSubsidyOfSEYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.InforknowledgeIfYesAmtGovPaid)]
        //[Required]
        public decimal InforknowledgeIfYesAmtGovPaid { get; set; }

        [Display(Name = PartDisplayName.LoanProcedureInSEYesNo_Id)]
        //[Required]
        public int LoanProcedureInSEYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.AdoptSolarizationYesNo_Id)]
        //[Required]
        public int AdoptSolarizationYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.CapitalArrangedForSEYesNo_Id)]
        //[Required]
        public int CapitalArrangedForSEYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.IfYesCapitalArrangedForSEAmt)]
        //[Required]
        public decimal IfYesCapitalArrangedForSEAmt { get; set; }

        [Display(Name = PartDisplayName.OtherIndustriesEnterprisesYesNo_Id)]
        //[Required]
        public int OtherIndustriesEnterprisesYesNo_Id { get; set; }

        [Display(Name = PartDisplayName.IfYesFillForm_OtherIndustriesEnterprises)]
        //[Required]
        public string IfYesFillForm_OtherIndustriesEnterprises { get; set; }

        [Display(Name = PartDisplayName.DOB)]
        //[Required]
        public string DOB { get; set; }

        [Display(Name = PartDisplayName.AadharNo)]
        public string AadharNo { get; set; }

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

        public List<Participant> Participants { get; set; }
        public string Latitude {  get; set; }   
        public string Longitude {  get; set; }   
        public string Location {  get; set; }   
        public string Accuracy {  get; set; }   
        public string ParticipantPicPath {  get; set; }   
        public string SolarEnterprisePicPath {  get; set; }   
    }
    public class PartDisplayName
    {
        public const string StateId = "State/राज्य";
        public const string DistrictId = "District/जिला";
        public const string BlockId = "Block/ब्लॉक";
        public const string PanchayatId = "Panchayat/ग्राम पंचायत";
        public const string VillageId = "Village/ग्राम";
        public const string CLFId = "CLF/सामान्य जीविका महासंघ";
        public const string VOId = "Village Organization/ग्राम संगठन";
        public const string NameofSHG = "Name Of SHG/एसएचजी का नाम";
        public const string TempRegNo = "";
        public const string RegNo = "";
        public const string AadharNo = "Aadhar Number/आधार नंबर";
        public const string PhoneNumber = "Phone Number/मोबाइल नंबर";
        public const string YearOfSHG = "Year Of SHG/समूह का वर्ष";
        public const string NameofSHGmember = "Name of SHG member/समूह से जुड़ी महिला का नाम";
        public const string NameofEnterpriseOwner = "Name of Enterprise owner/उद्यम के मालिक का नाम";
        public const string Age = "Age/उम्र";
        public const string DOB = "DOB/जन्म तिथि";
        public const string EducationQlf_Id = "What is your educational qualification?/आप कहां तक पढ़े हैं?";
        public const string Caste_Id = "What is your caste?/आपकी जाति क्या है?";
        public const string TypeofEnterpriseBusin_Id = "Type of Business or Enterprise/व्यापार/उद्यम का प्रकार";
        public const string TypeofEnterpriseBusin_Other = "Type of Business or Enterprise (Other)/व्यापार/उद्यम का प्रकार (अन्य)";
        public const string BusinessOwnedType_Id = "Type of Business Owned?/उद्यम का प्रकार";
        public const string EstablishedEnterpriseType_Id = "Where is your enterprise established?/आपका उद्यम कहां स्थापित है?";
        public const string TypeOfInvestBusin_Id = "How did you arrange capital for investment in your business?/आपके व्यापार में निवेश करने के लिए पूंजी का इंतजाम कैसे किया";
        public const string TookSourceOfLoan_Id = "If you took a loan, describe source?/यदि ऋण लिया, तो कहां से ऋण लिया";
        public const string TookLoanAmt = "How much loan did you take from SHG?/समूह से कितना ऋण लिया?";
        public const string TookLoanAmtBank = "How much Loan did you take from bank?/बैंक से कितना ऋण लिया?";
        public const string TookLoanAmtR = "How much Loan did you take from relatives?/रिश्तेदारों से कितना ऋण लिया?";
        public const string TookLoanAmtO = "How much Loan did you take from other sources?/अन्य स्रोतों से कितना ऋण लिया?";
        public const string StartBusinessInvestAmt = "How much money did you invest from your side to start your business?/आपने व्यापार शुरू करने के लिए कितना पैसा स्वयं का निवेश किया?";
        public const string StartYourBusinessTakeAmt = "How much loan did you take to start your business?/आपने व्यापार शुरू करने के लिए कितना पैसा ऋण लिया?";
        public const string MonthlyProfitBusiness = "What is your monthly profit from the business?/आपको व्यापार में मासिक लाभ कितना होता है?";
        public const string WorkInEnterprises_FamilyMembers = "How many people work in your enterprise(Number's only)/कितने लोग आपके उद्यम में काम करते हैं? (संख्या लिखें)";
        public const string WorkInEnterprises_SHGMembers = "How many SHG people work in your enterprise(Number's only)/कितने लोग आपके एसएचजी में काम करते हैं? (संख्या लिखें)";
        public const string WorkInEnterprises_AssitantStaffs = "How many Assitant Staffs work in your enterprise(Number's only)/आपके उद्यम में कितने सहायक कर्मचारी काम करते हैं? (सिर्फ़ संख्या)";
        public const string TypeOfMachineEnterprise_Id = "What is the type of machine in your enterprise?/उद्यम में मशीन का प्रकार क्या है?";
        public const string MotorBasedOnMachinesInActualUsed = "If Mechanised (Motor based) , then how many machines are in actual use?/यदि मैकेनाइज्ड (मोटर आधारित) है, तो उपयोग की जाने वाली मशीनों की कितनी संख्या है?";
        public const string MachineryPowerkilowatt_Id = "What is the estimated power of all your machinery? (In kilowatt)/आपकी सभी मशीनरी की अनुमानित शक्ति (Power) कितनी है? (किलोवाट में)";
        public const string ElectricityConnection_Id = "Your Electricity Connection is of how many kilowatt?/आपका बिजली कनेक्शन कितने किलोवाट का है?";
        public const string ConnectionPhaseofPower_Id = "How many phases of power connection do you have?/आपका कितना फेज कनेक्शन है?";
        public const string MonthlyElectricityConsumption_Id = "How much is your monthly electricity consumption? (refer electricity Bill, if available)/आपका मासिक प्रति माह बिजली खपत कितना है? (बिजली बिल से यह उपलब्ध है)";
        public const string MachineSourceofEnergy_Id = "What is the source of energy for your machines?/मशीनों के लिए ऊर्जा स्रोत क्या है?";
        public const string MachineSourceofEnergy_Others = "What is the source of energy for your machines?(Other)/मशीनों के लिए ऊर्जा स्रोत क्या है?(अन्य)";
        public const string Solar_InKilowatt_Id = "If its solar, how many kilowatt is it?/यदि सौर है, तो कितने किलोवाट का है?";
        public const string Solar_EnergyPanelYesNo_Id = "Did you set up solar energy panel ?/क्या आपने सौर ऊर्जा पैनल / सेटअप लगाया था?";
        public const string Solar_ExpenditureIncurredAmt = "How much expenditure was incurred on solar energy panel set-up / establishment?/सौर ऊर्जा पैनल / सेटअप / स्थापना का कितना खर्चा आया था?";
        public const string SubsidySolarReceive_Id = "Did you receive any subisdy for setting up of solar energy panels ?/क्या सौर ऊर्जा पैनल / सेटअप के लिए कोई सब्सिडी प्राप्त हुई थी?";
        public const string LoanSolarPanelsYesNo_Id = "Did you receive any loan for setting up of solar energy panels?/क्या सौर ऊर्जा पैनल / सेटअप के लिए कोई ऋण/लोन प्राप्त हुआ था?";
        public const string MonthAvgAmtSavedDescription_Id = "What is the average amount saved every month due to solar energy?/अपने द्वारा हर महीने सौर-ऊर्जा के कारण बचाई गई धनराशि का औसत विवरण में?";
        public const string ElectricityUsedHours_Id = "How many hours is the electricity used? (1-24 hours)/यदि बिजली का उपयोग होता है तो, कितने घंटे उपयोग होता है? (1-24 घंटे)";
        public const string MonthlyExpenseInElectricityBill_Id = "What is your monthly expense on the electricity bill?/आपका बिजली बिल पर कितना व्यय हो जाता है? (मासिक)";
        public const string GeneratorElectricityUsedHours_Id = "If generator is in use, then mention the number of hours (1-24 hours)?/यदि जनरेटर का उपयोग होता है तो कितने घंटे के लिए? (1-24 घंटे)";
        public const string MonthlyExpenseFuelSource_Id = "What is your expense on other fuel sources? (Diesel, Coal, Kerosene, etc.) (Monthly)/आपका अन्य ईंधन स्रोतों पर व्यय कितना है? (डीजल, कोयला, kerosene, आदि) (मासिक)";
        public const string MonthlyRepairCost_Id = "How much is the cost towards repair for arranging electricity or ? (Monthly)/आपको बिजली व्यवस्था और अन्य ऊर्जा स्रोतों की मरम्मत/रिपेयरिंग में कितनी लागत आती है? (मासिक)";
        public const string HeardAboutSolarEYesNo_Id = "Have you heard about solar energy ?/क्या आपने सौर ऊर्जा के बारे में सुना है?";
        public const string HeardAboutSolarEYes_IfYeswhere = "If Yes, where did you hear about it ?/यदि हां, तो आपने इसके बारे में कहां सुना?";
        public const string InforknowledgeGovtSubsidyOfSEYesNo_Id = "Do you have information / knowledge about govt. subsidy/aid for uptake of solar energy?/क्या आपको सौर ऊर्जा अपनाने में सरकार द्वारा दी जाने वाली सब्सिडी/मदद राशि की जानकारी है?";
        public const string InforknowledgeIfYesAmtGovPaid = "If yes, then what is the amount of govt. aid provided?/यदि हां, तो सरकार द्वारा कितनी मदद राशि दी जाती है?";
        public const string LoanProcedureInSEYesNo_Id = "Are you aware of the loan procedure involved for uptake of solar energy?/क्या आपको सौर ऊर्जा अपनाने के लिए ऋण के प्रक्रिया के बारे में पता है?";
        public const string AdoptSolarizationYesNo_Id = "Are you willing to adopt solarization / solar energy?/क्या आपको सौर ऊर्जा अपनाने की इच्छा है?";
        public const string CapitalArrangedForSEYesNo_Id = "Have you arranged any capital for adoption of solar energy?/क्या आपने सौर ऊर्जा अपनाने के लिए कोई धन राशि इकट्ठा की है?";
        public const string IfYesCapitalArrangedForSEAmt = "If yes, then what amount of capital is arranged for investment in solar energy?/यदि हां, तो आपके पास सौर ऊर्जा में निवेश के लिए कितनी धनराशि उपलब्ध है?";
        public const string OtherIndustriesEnterprisesYesNo_Id = "Is there any other industry/enterprise in your village which has motor-operated machines installed? (includes SHG members)/क्या आपके गांव में और भी कोई उद्योग है जिसमें मोटर आधारित मशीनें लगी हुई हैं? (सभी SHG शामिल करें)";
        public const string IfYesFillForm_OtherIndustriesEnterprises = "If yes, then kindly fill in the details of the family and visit them to fill a fresh form./यदि हां, तो उस परिवार की जानकारी यहां लिखें और वह जाकर इस फॉर्म को भरें";


    }

}