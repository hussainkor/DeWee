using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeWee.Models
{
    public class CLFModel
    {
        public CLFModel() { CLF_Id = 0; }
        public Nullable<int> CLF_Id { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public Nullable<int> BlockId { get; set; }
        public string NameofCLF { get; set; }
        public string CLFAddress { get; set; }
        public Nullable<System.DateTime> FirstMeetingDate { get; set; }
        public Nullable<System.DateTime> SecondMeetingDate { get; set; }
        public string NameofBMM { get; set; }
        public string BMMContactNo { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Location { get; set; }
        public string Accuracy { get; set; }
        public string Version { get; set; }
        public Nullable<System.DateTime> SynDate { get; set; }
        public string NameofBookkeeper { get; set; }
        public string BookKeeperContactNo { get; set; }
        public Nullable<int> IsCLF { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public string uuid { get; set; }
    }
}