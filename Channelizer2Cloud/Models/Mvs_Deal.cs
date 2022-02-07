using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_Mvs_Deal")]
    public class Mvs_Deal
    {
        [Key]
        public int Mvs_Deal_Id { get; set; }
        public int? Vendor_Id { get; set; }
        public int? Vendor_Program_Id { get; set; }
        public string DealName { get; set; }
        public string DealDescription { get; set; }
        public string ExpectedRevenue { get; set; }
        public string DealStatus { get; set; }//save as draft or submit
        public DateTime? SubmittedOn { get; set; }
        public int? Mvs_VarId { get; set; }
        public int? Customer_Id { get; set; }
        public int? CustomerContact_Id { get; set; }
        public int? MvsSalesRepresentative_Id { get; set; }
        public int? SubmitedBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual Vendor vendor { get; set; }
        public virtual Vendor_Program vendor_Program { get; set; }
        public virtual Customer customer { get; set; }
        public virtual CustomerContact customerContact { get; set; }
        public virtual MvsSalesRepresentative mvsSalesRepresentative { get; set; }
    }
}