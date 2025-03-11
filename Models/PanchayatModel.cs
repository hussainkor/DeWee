using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class PanchayatModel
    {
        public PanchayatModel()
        {
            GPId_pk = 0;
        }
        public int GPId_pk { get; set; }

        [Display(Name = "State")]
        public int StateId { get; set; }

        [Display(Name = "District")]
        public int DistrictId_fk { get; set; }

        [Display(Name = "Block")]
        public int BlockId_fk { get; set; }

        [Display(Name = "")]
        public int GPCode { get; set; }

        [Display(Name = "Garam Panchayat")]
        public string GPName { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public int? OrderBy { get; set; }

        [Display(Name = "")]
        public int CLFId_fk { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}