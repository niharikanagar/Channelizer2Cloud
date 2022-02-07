using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Channelizer2Cloud.Models
{[Table("tbl_State")]
    public class State
    {[Key]
        public int State_Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string ISOCode { get; set; }
        public int? Country_Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual Country country { get; set; }

    }
}