using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_ReferenceDataListItem")]
    public class ReferenceDataListItem
    {
        [Key]
        public int ReferenceDataListItem_Id { get; set; }
        public int? ReferenceDataListId { get; set; }
        public int? ProgramId { get; set; }
        public string DisplayValue { get; set; }
        public string DataValue { get; set; }
        public int Sequence { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}