using System;
using System.ComponentModel.DataAnnotations;

namespace DeWee.Models
{
    public class BeneficiaryModel
    {
        public BeneficiaryModel()
        {
            BeneficiaryId_pk = Guid.Empty; // Initialize to Guid.Empty
        }
        [Key]
        public Guid BeneficiaryId_pk { get; set; }

        [Display(Name = DisplayName.StateId)]
        [Required]
        public int StateId { get; set; }

        [Display(Name = DisplayName.DistrictId)]
        [Required]
        public int DistrictId { get; set; }

        [Display(Name = DisplayName.BlockId)]
        [Required]
        public int BlockId { get; set; }

        [Display(Name = DisplayName.GPId)]
        [Required]
        public int GPId { get; set; }

        [Display(Name = DisplayName.Village)]
        [Required]
        public string Village { get; set; }

        [Display(Name = DisplayName.CLF)]
        [Required]
        public string CLF { get; set; }

        [Display(Name = DisplayName.VO)]
        [Required]
        public string VO { get; set; }

        [Display(Name = DisplayName.NameofSHG)]
        [Required]
        public string NameofSHG { get; set; }

        [Display(Name = DisplayName.YearOfSHG)]
        [Required]
        public int YearOfSHG { get; set; }

        [Display(Name = DisplayName.NameofEnterprise)]
        //[Required]
        public string NameofEnterprise { get; set; }

        [Display(Name = DisplayName.TypeofEnterpriseBusinId)]
        [Required]
        public int TypeofEnterpriseBusinId { get; set; }

        [Display(Name = DisplayName.EnterpriseBusinId_other)]
       // [Required]
        public string EnterpriseBusinId_other { get; set; }

        [Display(Name = DisplayName.NameofSHGMember)]
        [Required]
        public string NameofSHGMember { get; set; }

        [Display(Name = DisplayName.NameofEnterpriseOwner)]
        [Required]
        public string NameofEnterpriseOwner { get; set; }

        [Display(Name = DisplayName.EnterpriseOwner_Gender)]
        [Required]
        public string EnterpriseOwner_Gender { get; set; }

        [Display(Name = DisplayName.DOB)]
        [Required]
        public DateTime? DOB { get; set; }

        [Display(Name = DisplayName.NameofGuardian)]
        [Required]
        public string NameofGuardian { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]

        [Display(Name = "Type of Relative")]
        public int TypeofRelative { get; set; }

        [Display(Name = DisplayName.Guardian_Gender)]
        [Required]
        public string Guardian_Gender { get; set; }

        [Display(Name = DisplayName.PrimaryMobileNo)]
        [Required]
        public string PrimaryMobileNo { get; set; }

        [Display(Name = DisplayName.AlternateMobileNo)]
        //[Required]
        public string AlternateMobileNo { get; set; }
        [Display(Name =DisplayName.IsSamePrimayMobileNo)]
        public bool IsSamePrimayMobileNo { get; set; }

        [Display(Name = DisplayName.WhatsAppMobileNo)]
        //[Required]
        public string WhatsAppMobileNo { get; set; }

        public int SiteAddress1stId { get; set; }


        [Display(Name = DisplayName.SiteAddress1st)]
        [Required]
        public string SiteAddress1st { get; set; }

        public int SiteAddress2ndId { get; set; }


        [Display(Name = DisplayName.SiteAddress2nd)]
        [Required]
        public string SiteAddress2nd { get; set; }

        [Display(Name = DisplayName.Pincode)]
        [Required]
        public int Pincode { get; set; }

        [Display(Name = DisplayName.CategoryBusinessInstallationId)]
        [Required]
        public int CategoryBusinessInstallationId { get; set; }

        [Display(Name = DisplayName.SpaceAvailableId)]
        [Required]
        public int SpaceAvailableId { get; set; }

        [Display(Name = DisplayName.SpaceAvailable_Area)]
        [Required]
        public string SpaceAvailable_Area { get; set; }

        [Display(Name = DisplayName.NatureofSpaceId)]
        [Required]
        public int NatureofSpaceId { get; set; }

        [Display(Name = DisplayName.NatureofSpace_other)]
        //[Required]
        public string NatureofSpace_other { get; set; }

        [Display(Name = DisplayName.YNGridconnection)]
        [Required]
        public string YNGridconnection { get; set; }

        [Display(Name = DisplayName.YNDieselGenerator)]
        [Required]
        public string YNDieselGenerator { get; set; }

        [Display(Name = DisplayName.YNMotorAppliances)]
        [Required]
        public string YNMotorAppliances { get; set; }

        [Display(Name = DisplayName.OtherSourceEnergyMachineId)]
        //[Required]
        public int OtherSourceEnergyMachineId { get; set; }

        [Display(Name = DisplayName.YNGovtSchemessubsidy)]
        [Required]
        public string YNGovtSchemessubsidy { get; set; }

        [Display(Name = DisplayName.SolarInstallationId)]
        [Required]
        public int SolarInstallationId { get; set; }

        [Display(Name = DisplayName.YNFinancialSupport)]
        [Required]
        public string YNFinancialSupport { get; set; }

        [Display(Name = DisplayName.EnterprisePhotoPath)]
        //[Required]
        public string EnterprisePhotoPath { get; set; }
        public string BeneficiaryPicHd { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location { get; set; }
        public string Accuracy { get; set; }
    }
    public class DisplayName
    {
        public const string Section1st = "Geographical Background";
        public const string StateId = "A. राज्य/STATE";
        public const string DistrictId = "B. जनपद/DISTRICT";
        public const string BlockId = "C. ब्लॉक/Block";
        public const string GPId = "D. ग्राम पंचायत/GP Name ";
        public const string Village = "E. ग्राम/Village Name";

        public const string Section2nd = "SHG Network";
        public const string CLF = "A. सामान्य जीविका महासंघ/CLF Name";
        public const string VO = "B. ग्राम संगठन/VO Name";
        public const string NameofSHG = "C. एसएचजी का नाम/SHG Name";
        public const string YearOfSHG = "D. एसएचजी का स्थापना वर्ष/Establishment Year of SHG";

        public const string Section3rd = "Basic Information";
        public const string NameofEnterprise = "A. उद्यम का नाम / Name of Enterprise";
        public const string TypeofEnterpriseBusinId = "B. उद्यम का प्रकार / Type of Enterprise";
        public const string EnterpriseBusinId_other = "B(a).Type of Enterprise (Other)";
        public const string NameofSHGMember = "C. परिवार में SHG सदस्य का नाम / Name of SHG Member in family";
        public const string NameofEnterpriseOwner = "D. मालिक का नाम / Name of Owner";
        public const string EnterpriseOwner_Gender = "D.(a) लिंग / Gender";
        public const string DOB = "E. मालिक की जन्म तिथि / DOB";
        public const string TypeofRelative = "F.Type Of Relative";
        public const string NameofGuardian = "F(a). अभिभावक का नाम / Name of Guardian";
        public const string Guardian_Gender = "F(b). लिंग / Gender";
        public const string PrimaryMobileNo = "G. मुख्य मोबाइल नंबर / Primary Mobile Number";
        public const string AlternateMobileNo = "H. वैकल्पिक मोबाइल नंबर / Alternate Mobile Number";
        public const string IsSamePrimayMobileNo = "G(a). Is same as Primary Mobile Number? ";
        public const string WhatsAppMobileNo = "I. व्हाट्सएप मोबाइल नंबर / WhatsApp Mobile Number";
        public const string SiteAddress1stId = "";
        public const string SiteAddress1st = "J. साइट का पता लाइन 1 / Site Address (Line 1)";
        public const string SiteAddress2ndId = "";
        public const string SiteAddress2nd = "K. साइट का पता लाइन 2 / Site Address (Line 2)";
        public const string Pincode = "L. पिन कोड / PIN Code";
        public const string CategoryBusinessInstallationId = "M. व्यवसाय स्थापना की श्रेणी / Category of Business Installation";
        public const string SpaceAvailableId = "N. उपलब्ध स्थान / Space Available";
        public const string SpaceAvailable_Area = "N(a). Space Available Area(sq.ft)";
        public const string NatureofSpaceId = "O. उपलब्ध स्थान की प्रकृति / Nature of Space";
        public const string NatureofSpace_other = "O(a). Other";
        public const string YNGridconnection = "P. क्या आपके पास पावर ग्रिड कनेक्शन है? / Do you have a grid connection?";
        public const string YNDieselGenerator = "Q. क्या आप डीजल जनरेटर का उपयोग करते हैं? / Do you use DG (diesel generator) set?";
        public const string YNMotorAppliances = "R. क्या आप किसी मोटर उपकरण का उपयोग करते हैं? / Do you use any motor appliances?";
        public const string OtherSourceEnergyMachineId = "S. क्या आप मशीन के लिए किसी अन्य ऊर्जा स्रोत का उपयोग करते हैं? / Do you use any other source of energy for the machine?";
        public const string YNGovtSchemessubsidy = "T. क्या आप सौर ऊर्जा से संबंधित किसी सरकारी योजना/सब्सिडी के बारे में जानते हैं? / Are you aware of any govt. schemes / subsidy related to solar energy?";
        public const string SolarInstallationId = "U. क्या आप सौर ऊर्जा की स्थापना चाहते हैं? / Do you want a solar installation?";
        public const string YNFinancialSupport = "V. क्या आपको वित्तीय सहायता की आवश्यकता है? / Do you need financial support?";
        public const string EnterprisePhotoPath = "W. उद्यम / स्थान के निर्देशांक के साथ फोटो कैप्चर करें / Capture photo with coordinate of enterprise / space";
    }
}