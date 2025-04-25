using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class ReferralModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReferralId_pk { get; set; }

        [Required]
        [StringLength(100)]
        public string NameofOwner { get; set; }

        public int? TypeofEnterprise { get; set; }

        [StringLength(100)]
        public string Other_TypeofEnterprise { get; set; }

        [Required]
        [StringLength(15)]
        public string PrimaryMobileNo { get; set; }

        public int? DistrictId { get; set; }

        public int? BlockId { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

       // [Required]
        [StringLength(50)]
        public string Version { get; set; }

        //[Required]
        //[StringLength(36)] // GUID length
        public string uuid { get; set; }

        public bool IsActive { get; set; } = true;

        //[Required]
        //[StringLength(50)]
        public string CreatedBy { get; set; }

       // [Required]
        public DateTime CreatedOn { get; set; }

        public bool IsBeneficiaryProcessed { get; set; } = false;

        public Guid BeneficiaryId_fk { get; set; }

        public DateTime? SynDate { get; set; }

        public bool IsMobile { get; set; } = false;
    }
}