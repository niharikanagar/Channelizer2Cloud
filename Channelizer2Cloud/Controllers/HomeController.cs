using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Channelizer2Cloud.Services;
using Channelizer2Cloud.Models;
using Newtonsoft.Json;
using System.Web.Helpers;
using System.Net.Http;
using System.Net;
using System.IO;
using Channelizer2Cloud.ViewModel;
using System.Web.Security;



namespace Channelizer2Cloud.Controllers
{
    public class HomeController : Controller
    {
        Service _service = new Service();
        public ActionResult LogIn()
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("LogIn", "Home");
            }
            return View();
        }


        [HttpPost]
        public ActionResult LogIn(LoginUser loginuser)
        {
            var checkUserValidResponse = _service.CheckUserValid(loginuser);
            switch (checkUserValidResponse)
            {
                case "UserName and Password are Matched":   // username and password are match and login successfully
                    User_LogTime user_LogTime = new User_LogTime();
                    if (Session["User_Id"] != null)
                        user_LogTime.UserId = new Guid(Session["User_Id"].ToString());
                    user_LogTime.SessionId = Session.SessionID;
                    user_LogTime.Offline = false;
                    user_LogTime.LogInTime = DateTime.Now;
                    _service.SaveUserLogTimeInfo(user_LogTime);

                    UserLoginDeviceInfo userLoginDeviceInfo = new UserLoginDeviceInfo();
                    string ipAddress = GetVistorIpAddress();
                  userLoginDeviceInfo = GetUserLoginDeviceInfo(ipAddress);
                    userLoginDeviceInfo.login_time = DateTime.Now;
                    userLoginDeviceInfo.user_id = new Guid(Session["User_Id"].ToString());
                    userLoginDeviceInfo.onetimepassword = _service.GenerateOTP();
                   _service.SaveUserLoginDeviceInfo(userLoginDeviceInfo);
                   // _service.SendEmail(loginuser.username);
                    FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), false);
                    return RedirectToAction("Home", "Main");
                case "UserName only Matched":  // username and password are match and login successfully
                    ViewBag.ValidationError = "Username and Password are incorrect";
                    return View();
                case "UserName not Matched":  // username and password are match and login successfully
                    ViewBag.ValidationError = "Username doesn't exists";
                    return View();
                default:
                    return View();
            }
        }

        public ActionResult LogOut()
        {
            User_LogTime user_LogTime = new User_LogTime();
            if (Session["User_Id"] != null)
                user_LogTime.UserId = new Guid(Session["User_Id"].ToString());
            user_LogTime.SessionId = Session.SessionID;
            user_LogTime.Offline = true;
            user_LogTime.LogOutTime = DateTime.Now;
            _service.SaveUserLogTimeInfo(user_LogTime);

            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("LogIn", "Home");
        }

        public string GetVistorIpAddress()
        {
            if (Request.ServerVariables["HTTP_CLIENT_IP"] != null)
            {
                return Request.ServerVariables["HTTP_CLIENT_IP"];
            }
            else if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                return Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else
            {
                return Request.ServerVariables["REMOTE_ADDR"];
            }
        }
        public UserLoginDeviceInfo GetUserLoginDeviceInfo(string vis_ip)
        {
            var url = "https://ipinfo.io/" + vis_ip;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            var result = "";
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result += streamReader.ReadToEnd();
            }
            UserLoginDeviceInfo userLoginDeviceInfo = JsonConvert.DeserializeObject<UserLoginDeviceInfo>(result);
            return userLoginDeviceInfo;
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string userName)
        {
            var IsUserExists = _service.CheckUserExists(userName);

            if (IsUserExists == null)
            {
                 ViewBag.ValidationError = "Username doesn't exists";
                return View();
            }
            else
            {
                string password = _service.Base64Decode(IsUserExists.Password);
               // string emailBodyText = "Your password is :: " + password;
                _service.SendPasswordEmail(IsUserExists.Email, password);
                return RedirectToAction("LogIn","Home");
            }
        }
    }
}