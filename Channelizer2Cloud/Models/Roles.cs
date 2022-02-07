using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_Roles")]
    public class Roles
    {
        [Key]
        public int Role_Id { get; set; }
        public string RoleName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }

    [Table("tbl_RolesUserPermission")]
    public class RolesUserPermission
    {
        [Key]
        public int RolesUserPermission_Id { get; set; }
        public Guid? User_Id { get; set; }
        public int? Role_Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }

    [Table("tbl_RolesAppPermission")]
    public class RolesAppPermission
    {
        [Key]
        public int RolesAppPermission_Id { get; set; }
        public int? Role_Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }

    [Table("tbl_AllControllers")]
    public class AllController
    {
        [Key]
        public int Controller_Id { get; set; }
        public string ControllerName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }

    [Table("tbl_AllActions")]
    public class AllActions
    {
        [Key]
        public int Action_Id { get; set; }
        public string ActionName { get; set; }
        public int? Controller_Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public virtual AllController ControllerId { get; set; }
      }
}