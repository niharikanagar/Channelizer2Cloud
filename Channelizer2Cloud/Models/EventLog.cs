using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Channelizer2Cloud.Models
{[Table("tbl_EventLog")]
    public class EventLog
    {[Key]
        public int EventLog_Id { get; set; }
        public string EventLevel { get; set; }
        public string EventType { get; set; }
        public Guid? UserId { get; set; }
        public int VendorId { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }

        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}