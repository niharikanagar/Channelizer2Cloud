using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_VendorUser")]
    public class VendorUser
    {[Key]
        public int VendorUser_Id { get; set; }
        public Guid? UserId { get; set; }
        public int? VendorId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}