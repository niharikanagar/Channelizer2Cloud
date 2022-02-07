using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Channelizer2Cloud.ViewModel
{
    public class LoginUser
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}