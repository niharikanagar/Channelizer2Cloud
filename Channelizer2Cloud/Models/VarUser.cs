using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Channelizer2Cloud.Models
{
        [Table("tbl_VarUser")]
        public class VarUser
        {
            [Key]
            public int VarUser_Id { get; set; }
            public Guid? UserId { get; set; }
            public int? Mvs_VarId { get; set; }
            public DateTime? CreatedOn { get; set; }
            public Guid? CreatedBy { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? LastModifiedOn { get; set; }
            public Guid? ModifiedBy { get; set; }
        }
    
}