using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_UserInformation")]
    public class UserInformation
    {[Key]
        public Guid UserInformation_Id { get; set; }
        public int? UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? SuccessfulLoginCount { get; set; }
        public bool? ForcePasswordChangeNextLogin { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsLockedOut { get; set; }
        public DateTime? LastLogindate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public int role_id {get;set;}

    }
}