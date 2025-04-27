using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class SolarShopModel
    {
        public SolarShopModel() {
            SolarShopId_pk = 0;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SolarShopId_pk { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Name of Enterprise")]
        public string NameofEnterprise { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Name Of Owner")]
        public string NameofOwner { get; set; }

        [Required]
        //[StringLength(50)]
        [Display(Name = "Type of Enterprise")]
        public int? TypeofEnterprise { get; set; }

        [StringLength(500)]
        [Display(Name = "Type of Enterprise Other")]
        public string Other_TypeofEnterprise { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Primary Mobiile Number")]
        public string PrimaryMobileNo { get; set; }

        [Display(Name = "State")]
        public int StateId { get; set; }

        [Display(Name = "District")]
        public int DistrictId { get; set; }

        [Display(Name = "Block")]
        public int BlockId { get; set; }

        [Required]
        [StringLength(4000)]
        [Display(Name = "Site Address")]
        public string SiteAddress { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        // [StringLength(4000)]
        [Display(Name = "Location")]
        public string Location { get; set; }

        public string Iflinked { get; set; }

       // [Required]
        public string uuid { get; set; }

        public string Version { get; set; }

        public DateTime? SynDate { get; set; }

        public bool IsMobile { get; set; }

        public bool IsActive { get; set; }

       // [Required]
        //[StringLength(130)]
        public string CreatedBy { get; set; }

       // [Required]
        public DateTime CreatedOn { get; set; }
        public string SolarShopEnterprisePicPath { get; set; }
        public string SolarShopEnterprisebase64 { get; set; }
        public byte[] SolarShopEBTY { get; set; }
    }
}