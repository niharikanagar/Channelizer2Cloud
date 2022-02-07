using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_Mvs_DealData")]
    public class Mvs_DealData
    {
            [Key]
            public int Id { get; set; }
            public int Mvs_DealId { get; set; }
            public string DataKey { get; set; }
            public string DataValue { get; set; }
            public DateTime? CreatedOn { get; set; }
            public Guid? CreatedBy { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? LastModifiedOn { get; set; }
            public Guid? ModifiedBy { get; set; }          

    }
}
