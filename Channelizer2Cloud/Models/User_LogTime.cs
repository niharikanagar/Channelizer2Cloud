using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_User_LogTime")]
    public class User_LogTime
    {
        [Key]
        public int User_LogTime_Id { get; set; }
        public Guid? UserId { get; set; }
        public string SessionId { get; set; }
        public DateTime? LogInTime { get; set; }
        public DateTime? LogOutTime { get; set; }
        public bool? Offline { get; set; }
    }
}