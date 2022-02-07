using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_Auditlog")]
    public class Auditlog
    {   [Key]
        public int Auditlog_Id { get; set; }
        public string EventLevel { get; set; }

        public string EventType { get; set; }

        public int VendorId { get; set; }
        public string Message { get; set; }
        public string EventRaiser { get; set; }

        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }


    }
}