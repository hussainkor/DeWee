using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class FilterModel
    {
        [Display(Name = DisplayName.Country_Id)]
        //[Required]
        public int CountryId { get; set; }
        [Display(Name = DisplayName.State_Id)]
       // [Required]
        public int StateId { get; set; }

        [Display(Name = DisplayName.District_Id)]
       // [Required]
        public int DistrictId { get; set; }

        [Display(Name = DisplayName.Block_Id)]
        //[Required]
        public int BlockId { get; set; }

        [Display(Name = DisplayName.GP_Id)]
        //[Required]
        public int GPId { get; set; }

        [Display(Name = DisplayName.TypeOfEnterprise_Id)]
        //[Required]
        public int TypeofEnterpriseBusinId { get; set; }
        [Display(Name = "Type of Indicator")]
        //[Required]
        public int TypeofIndicator { get; set; }
    }
}