using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_Vendor")]
    public class Vendor
    {
        [Key]
        public int Vendor_Id { get; set; }
      
        [Required]
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [Display(Name = "Upload Vendor Logo")]
        public string VendorLogo { get; set; }
        [Required]
        [Display(Name = "Vendor Primary Color")]
        public string VendorPrimaryColor { get; set; }
        [Display(Name = "Vendor Secondary Color")]
        public string VendorSecondaryColor { get; set; }
        [Required]
        [Display(Name = "Vendor Font")]
        public string VendorFont { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedinLink { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}