using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Channelizer2Cloud.ViewModel
{
    public class UserViewVodel
    {
        public string Username { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
    public class RoleAppPermissionViewModel
    {
        public int Role_Id { get; set; }     
        
        public string Controller { get; set; }
        public string Action { get; set; }

    }

    public class AssignUserRoleModel
    {
        public int Role_Id { get; set; }
        public string Userinformation_Id { get; set; }


    }
}
