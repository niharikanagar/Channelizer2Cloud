using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_UserLoginDeviceInfo")]
    public class UserLoginDeviceInfo
    {
    [Key]
    public int UserLoginDeviceInfo_Id { get; set; }
    public string ip {get; set; }
    public string city {get; set; }
    public string region {get; set; }
    public string country { get; set; }
    public string loc {get; set; }
    public string org { get; set; }
    public string postal {get; set; }
    public string timezone {get; set; }
    public Guid? user_id { get; set; }
    public int? onetimepassword { get; set; }
    public DateTime? login_time {get; set; }
    }
}