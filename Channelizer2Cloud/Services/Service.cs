using MimeKit;
using MailKit.Net.Smtp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Channelizer2Cloud.Models;
using Channelizer2Cloud.ViewModel;
using Channelizer2Cloud.DataAccess;
using System.Web.Mvc;

namespace Channelizer2Cloud.Services
{
    public class Service
    {
 
        DBAccess access = new DBAccess();     
        public void SendPasswordEmail(string toemail,string password)
        {
            try
            {
                    var mailMessage = new MimeMessage();
                    mailMessage.From.Add(new MailboxAddress("sandeep ", "niharikangr@gmail.com"));
                    mailMessage.To.Add(new MailboxAddress("sksaklani92@gmail.com", "sksaklani92@gmail.com"));
                    mailMessage.Subject = "subject";
                mailMessage.Body = new TextPart("plain")
                {
                    Text = "Hello! " + toemail +"\n Password is " + password
                };

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.Connect("smtp.gmail.com", 25, false);
                        smtpClient.Authenticate("sksaklani92@gmail.com", "13741175k");
                        smtpClient.Send(mailMessage);
                        smtpClient.Disconnect(true);
                    }
                }
                catch (Exception ex)
            {
                EventLog eventlog = new EventLog();
                eventlog.EventLevel = "Error";
                eventlog.EventType = "Email Service";
                eventlog.ExceptionMessage = ex.InnerException.ToString();
                eventlog.Message = ex.Message.ToString();
                eventlog.CreatedOn = DateTime.Now;
                access.SaveEventLogError(eventlog);
            }
        }

        public void SendEmail(string toemail,string emailBodyText)
        {
            try
            {
                var mailMessage = new MimeMessage();
                mailMessage.From.Add(new MailboxAddress("Admin", "niharikangr@gmail.com"));
                mailMessage.To.Add(new MailboxAddress(toemail, toemail));
                mailMessage.Subject = "subject";
                mailMessage.Body = new TextPart("plain")
                {
                    Text = "Hello! " + toemail + "<br/><br/>"+ emailBodyText
                };

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 25, false);
                    smtpClient.Authenticate("sksaklani92@gmail.com", "13741175k");
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                EventLog eventlog = new EventLog();
                eventlog.EventLevel = "Error";
                eventlog.EventType = "Email Service";
                eventlog.ExceptionMessage = ex.InnerException.ToString();
                eventlog.Message = ex.Message.ToString();
                eventlog.CreatedOn = DateTime.Now;
                access.SaveEventLogError(eventlog);
            }
        }
        public void SendSMS()
        {
            try
            {
                var client = new RestClient("https://rest-api.d7networks.com/secure/send");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Authorization", "Basic aWpmbzc5NTA6UDJiNEdwZks=");
                request.AddParameter("application/x-www-form-urlencoded", "{" +
                    "\n\t\"to\":\"9991272639\"," +
                    "\n\t\"content\":\"Welcome to D7 sms , we will help you to talk with your customer effectively\"," +
                    "\n\t\"from\":\"SMSINFO\"," +
                    "\n\t\"dlr\":\"yes\"," +
                    "\n\t\"dlr-method\":\"GET\"," +
                    " \n\t\"dlr-level\":\"2\", " +
                    "\n\t\"dlr-url\":\"http://yourcustompostbackurl.com\"\n}",
                    ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
            }
            catch(Exception ex)
            {
                EventLog eventlog = new EventLog();
                eventlog.EventLevel = "Error";
                eventlog.EventType = "SMS Service";
                eventlog.ExceptionMessage = ex.InnerException.ToString();
                eventlog.Message = ex.Message.ToString();
                access.SaveEventLogError(eventlog);
            }
        }
        public void SaveUserLoginDeviceInfo(UserLoginDeviceInfo userLoginDeviceInfo)
        {
             access.SaveUserLoginDeviceInfo(userLoginDeviceInfo);
        }
        public int GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }

        public string GenerateRandomPassword()
        {
            int length = 15;
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        public void SaveUserLogTimeInfo(User_LogTime user_LogTime)
        {
            access.SaveUserLogTimeInfo(user_LogTime);
        }
        public UserInformation GetUserfromUserName(string username) 
        { 
             return access.GetUserfromUserName(username);
        }
        public string CheckUserValid(LoginUser loginuser)
        {
         //  loginuser.password = Base64Decode(loginuser.password);
            loginuser.password = Base64Encode(loginuser.password);
            var checkUser= access.GetUserfromUserName(loginuser.username);
            if (checkUser is null)
            {
                return "UserName not Matched";
            }
            else if (checkUser.UserName==loginuser.username && checkUser.Password == loginuser.password)
            {
                HttpContext.Current.Session["Username"] = checkUser.UserName;
                HttpContext.Current.Session["User_Id"] = checkUser.UserInformation_Id;
                return "UserName and Password are Matched";
            }
            else if (checkUser.UserName == loginuser.username && checkUser.Password != loginuser.password)
            {
                return "UserName only Matched";
            }
            else 
            {
                return null;
            }
        }
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public string CheckPasswordValid(UserViewVodel userViewVodel)
        {
            int validationCount = 0;
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };
            var checkUser = access.GetUserfromUserName(userViewVodel.Username);
            if (checkUser is null)
            {
                return "Username does not exist";
            }
            else if (checkUser.Password != Base64Encode(userViewVodel.CurrentPassword))
            {              
                return "Current Password are not Match";
            }
            else if (userViewVodel.NewPassword != userViewVodel.ConfirmPassword)
            {
                return "New and Confirm Password are not Match";
            }
            else if (userViewVodel.NewPassword.Length < 8)
            {
                return "Password not Strong";
            }
            else if (userViewVodel.NewPassword.IndexOfAny(special) == -1) 
            { 
                return "Password not Strong";
            }
            else if(Base64Encode(userViewVodel.NewPassword)==checkUser.Password)
            {
                return "Old and New Password are not Same";
            }
            else if (userViewVodel.NewPassword != null)
            {
                foreach (char c in userViewVodel.NewPassword)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        validationCount++;
                        break;
                    }
                }
                foreach (char c in userViewVodel.NewPassword)
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        validationCount++;
                        break;
                    }
                }
                foreach (char c in userViewVodel.NewPassword)
                {
                    if (c >= '0' && c <= '9')
                    {
                        validationCount++;
                        break;
                      
                    }
                }
               
            }
            if (validationCount == 3)
                return access.UpdateUserPassword(Base64Encode(userViewVodel.ConfirmPassword), userViewVodel.Username);
            else
                return null;

        }

         public string saveLogInformation(UserViewVodel userViewVodel)
        {
            int validationCount = 0;
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };
            var checkUser = access.GetUserfromUserName(userViewVodel.Username);
            if (checkUser is null)
            {
                return "Username does not exist";
            }
            else if (checkUser.Password != Base64Encode(userViewVodel.CurrentPassword))
            {              
                return "Current Password are not Match";
            }
            else if (userViewVodel.NewPassword != userViewVodel.ConfirmPassword)
            {
                return "New and Confirm Password are not Match";
            }
            else if (userViewVodel.NewPassword.Length < 8)
            {
                return "Password not Strong";
            }
            else if (userViewVodel.NewPassword.IndexOfAny(special) == -1) 
            { 
                return "Password not Strong";
            }
            else if(Base64Encode(userViewVodel.NewPassword)==checkUser.Password)
            {
                return "Old and New Password are not Same";
            }
            else if (userViewVodel.NewPassword != null)
            {
                foreach (char c in userViewVodel.NewPassword)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        validationCount++;
                        break;
                    }
                }
                foreach (char c in userViewVodel.NewPassword)
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        validationCount++;
                        break;
                    }
                }
                foreach (char c in userViewVodel.NewPassword)
                {
                    if (c >= '0' && c <= '9')
                    {
                        validationCount++;
                        break;
                      
                    }
                }
               
            }
            if (validationCount == 3)
                return access.UpdateUserPassword(Base64Encode(userViewVodel.ConfirmPassword), userViewVodel.Username);
            else
                return null;

        }


        public string SaveVendorInformation(Vendor vendor)
        {
            return access.SaveVendorInformation(vendor);
        }

        public string SaveVendorProgram(Vendor_Program vendorProgram)
        {
            return access.SaveVendorProgram(vendorProgram);
        }

        public List<SelectListItem> GetVendorList(int? id) 
        { 
             return access.GetVendorList(id);
        }


        public List<Vendor_RegistrationFormField> GetSavedFormData(int? programId,int? vendorId){ 
            return access.GetSavedFormData(programId,vendorId);
        }

        public void SaveEventLogError(EventLog eventlog)
        {
            access.SaveEventLogError(eventlog);
        }

        public string SaveReferenceDataList(List<ReferenceDataListItem> referenceDataListItem)
        {
            return access.SaveReferenceDataList(referenceDataListItem);
        }

        public string SaveVendorRegistrtaionFormField(Vendor_RegistrationFormField vendorRegistrationFormField)
        {
            return access.SaveVendorRegistrtaionFormField(vendorRegistrationFormField);
        }

        public int SaveDealDataInformation(RegistrationViewModel registrationViewModel)
        {
            //get logic to get salerepid
            var currentPassword = GenerateRandomPassword();
            UserInformation userinfo = new UserInformation();
            userinfo.FirstName= registrationViewModel.SaleRepFirstName;
            userinfo.LastName= registrationViewModel.SaleRepLastName;
            userinfo.Email= registrationViewModel.SaleRepEmail;
            userinfo.Phone= registrationViewModel.SaleRepPhone;
            userinfo.Password = Base64Encode(currentPassword);
            userinfo.UserName = registrationViewModel.SaleRepEmail;
            userinfo.UserTypeId = 3;
            userinfo.CreatedBy = registrationViewModel.CreatedBy;
            userinfo.UserInformation_Id = Guid.NewGuid();
            Guid userInfoId = access.SaveUserInfo(userinfo);

            MvsSalesRepresentative mvsSalesRepresentative = new MvsSalesRepresentative();
            mvsSalesRepresentative.UserId = userInfoId;
            mvsSalesRepresentative.FirstName = registrationViewModel.SaleRepFirstName;
            mvsSalesRepresentative.LastName = registrationViewModel.SaleRepLastName;
            mvsSalesRepresentative.Email = registrationViewModel.SaleRepEmail;
            mvsSalesRepresentative.Phone = registrationViewModel.SaleRepPhone;
            var salerepid = access.SaveSaleRepInfo(mvsSalesRepresentative);
            //SendPasswordEmail(mvsSalesRepresentative.Email, currentPassword);

            //get logic to get customer
            Customer customer = new Customer();
            customer.Name = registrationViewModel.Name;
            customer.Address1 = registrationViewModel.Address1;
            customer.Address2 = registrationViewModel.Address2;
            customer.Address3 = registrationViewModel.Address3;
            customer.Country = registrationViewModel.Country;
            customer.State = registrationViewModel.State;
            customer.City = registrationViewModel.City;
            customer.PostalCode = registrationViewModel.PostalCode;
            customer.Website = registrationViewModel.Website;
            var customerid = access.SaveCustomerInfo(customer);
            //get logic to get customercontactId
            CustomerContact customerContact = new CustomerContact();
            customerContact.FirstName = registrationViewModel.FirstName;
            customerContact.LastName = registrationViewModel.LastName;
            customerContact.Title = registrationViewModel.Title;
            customerContact.Email = registrationViewModel.Email;
            customerContact.Phone = registrationViewModel.Phone;
            customerContact.Fax = registrationViewModel.Fax;
            customerContact.Mobile = registrationViewModel.Mobile;
            var customercontactid = access.SaveCustomerContactInfo(customerContact);
            Mvs_Deal mvs_Deal = new Mvs_Deal();
            mvs_Deal.DealName = registrationViewModel.DealName;
            mvs_Deal.DealStatus = "Draft";
            mvs_Deal.DealDescription = registrationViewModel.DealDescription;
            mvs_Deal.Vendor_Program_Id = registrationViewModel.ProgramId;
            mvs_Deal.Vendor_Id = GetVendorProgramDetails(registrationViewModel.ProgramId).Vendor_Id;
            mvs_Deal.Customer_Id = customerid;
            mvs_Deal.MvsSalesRepresentative_Id = salerepid;
            mvs_Deal.CustomerContact_Id = customercontactid;
            mvs_Deal.CreatedOn = DateTime.Now;
            mvs_Deal.CreatedBy = registrationViewModel.CreatedBy;
            return access.SaveMvsDealInfo(mvs_Deal);
        }

        public List<SelectListItem> GetProgramList()
        {
            return access.GetProgramList();
        }
        public List<SelectListItem> GetCountryList()
        {
            return access.GetCountryList();
        }
        public List<SelectListItem> GetStateList(int countryId)
        {
            return access.GetStateList(countryId);
        }
        public Vendor_Program GetVendorProgramDetails(int? id)
        {
            return access.GetVendorProgramDetails(id);
        }
        public Vendor GetVendorDetails(int? id)
        {
            return access.GetVendorDetails(id);
        }


        public List<Mvs_Deal> GetAllRegistrations(Guid UserId)
        {
            return access.GetAllRegistrations(UserId);
        }
        public List<Mvs_Deal> GetAllDeletedRegistrations(Guid UserId)
        {
            return access.GetAllDeletedRegistrations(UserId);
        }

        public string CreateRole(Roles roles)
        {
            roles.IsDeleted = false;
            roles.CreatedOn = DateTime.Now;
            return access.CreateRole(roles);
        }

        public List<Roles> GetAllRoles()
        {
            return access.GetAllRoles();
        }

        public List<Vendor_RegistrationFormField> GetFormFields(int? programId)
        {

            return access.GetFormFields(programId);
        }

        public string GetVendorLogobyProgramId (int? programId)
        {
            return access.GetVendorLogobyProgramId(programId);
        }

        public List<SelectListItem> GetReferenceDataListItem(int? programId, int? fieldId)
        {
            return access.GetReferenceDataListItem(programId, fieldId);
        }

        public string SaveVendorDealInformation(Mvs_DealData dealData,int? dealId)
        {
            return access.SaveVendorDealInformation(dealData, dealId);
        }

        public List<Mvs_DealData> GetDealDataInformation(int? dealId)
        {
            return access.GetDealDataInformation(dealId);
        }

        public IQueryable<DealFormViewModel> GetDealWithFormField(int? dealId,int? programId)
        {
            return access.GetDealWithFormField(dealId,programId);
        }

        public int? GetCountFormfields(int? programId)
        {
            return access.GetCountFormfields(programId);
        }

       public string SaveUserInformation(UserInformation userInformation)
        {
            if(userInformation.Password !=null)
            userInformation.Password = Base64Encode(userInformation.Password);
            return access.SaveUserInformation(userInformation);
        }
        public List<SelectListItem> GetUserTypeList()
        {
            return access.GetUserTypeList();
        }
        public void SaveRoleAppPermissions(RolesAppPermission rolesAppPermission)
        {
             access.SaveRoleAppPermissions(rolesAppPermission);
        }

        //public RoleAppPermissionViewModel GetRolesAppPermissions(int roleId)
        //{
        //    RoleAppPermissionViewModel roleAppPermissionViewModel = null;
        //    try
        //    {
        //        List<RolesAppPermission> rolesAppPermissions = access.GetRolesAppPermissions(roleId);
        //        if (rolesAppPermissions != null && rolesAppPermissions.Count > 0)
        //        {
        //            roleAppPermissionViewModel = new RoleAppPermissionViewModel();
        //            RolePermissionViewModel rolePermissionViewModel = null;
        //            List<RolePermissionViewModel> rolePermissionViewModelList = new List<RolePermissionViewModel>();
        //            foreach (RolesAppPermission rolesAppPermission in rolesAppPermissions)
        //            {
        //                rolePermissionViewModel = rolePermissionViewModelList.Find(r => r.ControllerName == rolesAppPermission.Controller);
        //                if (rolePermissionViewModel == null)
        //                    rolePermissionViewModel = new RolePermissionViewModel();
        //                else
        //                    rolePermissionViewModelList.Remove(rolePermissionViewModel);

        //                rolePermissionViewModel.PermissionId = rolesAppPermission.RolesAppPermission_Id;
        //                rolePermissionViewModel.ControllerName = rolesAppPermission.Controller;

        //                if (rolesAppPermission.Action == "Index")
        //                    rolePermissionViewModel.IsIndex = true;
        //                if (rolesAppPermission.Action == "Create")
        //                    rolePermissionViewModel.IsCreate = true;
        //                if (rolesAppPermission.Action == "Edit")
        //                    rolePermissionViewModel.IsEdit = true;
        //                if (rolesAppPermission.Action == "Delete")
        //                    rolePermissionViewModel.IsDelete = true;

        //                rolePermissionViewModelList.Add(rolePermissionViewModel);
        //            }

        //            roleAppPermissionViewModel.RoleId = roleId;
        //            roleAppPermissionViewModel.Permissions = rolePermissionViewModelList;
        //        }
        //    }
        //    catch { }
        //    return roleAppPermissionViewModel;
        //}

        public UserInformation CheckUserExists(string userName)
        {
            return access.GetUserfromUserName(userName);
        }

        public List<SelectListItem> GetAllControllers()
        {
            return access.GetAllControllers();
        }
        public List<SelectListItem> GetAllActionsByControllerId(int controllerId)
        { 
            return access.GetAllActionsByControllerId(controllerId);
        }
        public List<RolesAppPermission> GetAllPermissions(int roleId)
        {
            return access.GetAllPermissions(roleId);
        }

        public void DeleteRoleAppPermissions(int rolesAppPermissionId)
        {
            access.DeleteRoleAppPermissions(rolesAppPermissionId);
        }

        //public void AssignUserRole(UserInformation userInformation)
        //{
        //    access.AssignUserRole(userInformation);
        //}

        public List<SelectListItem> GetRoleList()
        {
            return access.GetRoleList();
        }

        public List<UserInformation> UserList()
        {
            return access.UserList();
        }

        
            public UserInformation GetUserInfoById(Guid? userInfoId)
        {
            return access.GetUserInfoById(userInfoId);
        }

        public List<string> GetActionPermissionList(Guid userId)
        {
            return access.GetActionPermissionList(userId);
        }

        public string GetUserTypeInfoById(Guid userId)
        {
            return access.GetUserTypeInfoById(userId);
        }
        

    }
}