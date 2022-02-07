using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Channelizer2Cloud.Models;
using Channelizer2Cloud.Data;
using System.Web.Mvc;
using Channelizer2Cloud.ViewModel;

namespace Channelizer2Cloud.DataAccess
{
    public class DBAccess
    {
        private ChannelizerAppContext db = new ChannelizerAppContext();

        public void SaveUserLoginDeviceInfo(UserLoginDeviceInfo json)
        {
            db.UserLoginDeviceInfoes.Add(json);
            db.SaveChanges();
        }

        public void SaveEventLogError(EventLog json)
        {
            db.EventLogs.Add(json);
            db.SaveChanges();
        }
        public void SaveAuditLogInformation(Auditlog json)
        {
            db.Auditlogs.Add(json);
            db.SaveChanges();
        }

        public void SaveUserLogTimeInfo(User_LogTime json)
        {
            User_LogTime checksession = db.User_LogTime.Where(x => x.SessionId == json.SessionId).FirstOrDefault();
            if (checksession == null)
            {
                db.User_LogTime.Add(json);
            }
            else
            {
                checksession.LogOutTime = json.LogOutTime;
                checksession.Offline = json.Offline;
                db.Entry(checksession).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }

        public UserInformation GetUserfromUserName(string username)
        {
            return db.UserInformations.Where(x => x.UserName == username).FirstOrDefault();
        }
        public string UpdateUserPassword(string password, string username)
        {
            UserInformation userInformation = db.UserInformations.Where(x => x.UserName == username).FirstOrDefault();
            userInformation.Password = password;
            db.Entry(userInformation).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Password saved Successfully";
        }

        public string SaveVendorInformation(Vendor vendor)
        {
            Vendor checkVendor = db.Vendors.Where(x => x.VendorName == vendor.VendorName).FirstOrDefault();
            if (checkVendor == null)
            {
                db.Vendors.Add(vendor);
            }
            else
            {
                return "Vendor Name Already Exists";
                // db.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return "Vendor saved Successfully";
        }

        public string SaveVendorProgram(Vendor_Program vendorProgram)
        {
            Vendor_Program checkVendorProgram = db.Vendor_Program.Where(x => x.Vendor_Id == vendorProgram.Vendor_Id && x.ProgramName == vendorProgram.ProgramName).FirstOrDefault();
            if (checkVendorProgram == null)
            {
                db.Vendor_Program.Add(vendorProgram);
            }
            else
            {
                db.Entry(vendorProgram).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return "Vendor Program saved Successfully";
        }

        public List<SelectListItem> GetVendorList(int? id)
        {
            if (id == null)
            {
                return db.Vendors.Select(x => new SelectListItem
                {
                    Value = x.Vendor_Id.ToString(),
                    Text = x.VendorName
                }).ToList();
            }
            else
            {
                return db.Vendors.Where(x => x.Vendor_Id == id).Select(x => new SelectListItem
                {
                    Value = x.Vendor_Id.ToString(),
                    Text = x.VendorName
                }).ToList();
            }

        }

        public List<Vendor_RegistrationFormField> GetSavedFormData(int? programId, int? vendorId)
        {
            return db.Vendor_RegistrationFormField.Where(x => x.VendorId == vendorId && x.VendorProgramId == programId).ToList();
        }

        public string SaveReferenceDataList(List<ReferenceDataListItem> referenceDataListItems)
        {
            foreach (ReferenceDataListItem referenceDataListItem in referenceDataListItems)
            {
                ReferenceDataListItem checkReferenceDataListItem = db.ReferenceDataListItems.Where(x => x.ProgramId == referenceDataListItem.ProgramId && x.ReferenceDataListId == referenceDataListItem.ReferenceDataListId && x.DisplayValue == referenceDataListItem.DisplayValue).FirstOrDefault();
                if (checkReferenceDataListItem == null)
                {
                    db.ReferenceDataListItems.Add(referenceDataListItem);
                }
                else
                {
                    db.Entry(checkReferenceDataListItem).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
            return "ReferenceDataListItem saved Successfully";
        }

        public string SaveVendorRegistrtaionFormField(Vendor_RegistrationFormField vendorRegistrationFormField)
        {
            Vendor_RegistrationFormField checkVendorRegistrationFormField = db.Vendor_RegistrationFormField.Where(x => x.VendorProgramId == vendorRegistrationFormField.VendorProgramId && x.FieldTypeId == vendorRegistrationFormField.FieldTypeId && x.FieldName == vendorRegistrationFormField.FieldName).FirstOrDefault();
            if (checkVendorRegistrationFormField == null)
            {
                db.Vendor_RegistrationFormField.Add(vendorRegistrationFormField);
            }
            else
            {
                // checkVendorRegistrationFormField.
                db.Entry(checkVendorRegistrationFormField).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return "VendorRegistrationFormField saved Successfully";
        }

        public int SaveSaleRepInfo(MvsSalesRepresentative mvsSalesRepresentative)
        {
            MvsSalesRepresentative checkMvsSalesRepresentative = db.MvsSalesRepresentatives.Where(x => x.Email == mvsSalesRepresentative.Email || x.Phone == mvsSalesRepresentative.Phone).FirstOrDefault();
            if (checkMvsSalesRepresentative == null)
            {
                db.MvsSalesRepresentatives.Add(mvsSalesRepresentative);
            }
            else
            {
                mvsSalesRepresentative.MvsSalesRepresentative_Id = checkMvsSalesRepresentative.MvsSalesRepresentative_Id;
                db.Entry(checkMvsSalesRepresentative).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return mvsSalesRepresentative.MvsSalesRepresentative_Id;
        }
        public int SaveCustomerInfo(Customer customer)
        {
            Customer checkCustomer = db.Customers.Where(x => x.Name == customer.Name && x.Address1 == customer.Address1 && x.Country == customer.Country && x.State == customer.State && x.City == customer.City).FirstOrDefault();
            if (checkCustomer == null)
            {
                db.Customers.Add(customer);
            }
            else
            {
                customer.Customer_Id = checkCustomer.Customer_Id;
                db.Entry(checkCustomer).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return customer.Customer_Id;
        }
        public int SaveCustomerContactInfo(CustomerContact customerContact)
        {
            CustomerContact checkCustomerContact = db.CustomerContacts.Where(x => x.Email == customerContact.Email || x.Mobile == customerContact.Mobile).FirstOrDefault();
            if (checkCustomerContact == null)
            {
                db.CustomerContacts.Add(customerContact);
            }
            else
            {
                customerContact.CustomerContact_Id = checkCustomerContact.CustomerContact_Id;
                db.Entry(checkCustomerContact).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return customerContact.CustomerContact_Id;
        }

        public int SaveMvsDealInfo(Mvs_Deal mvs_Deal)
        {
            Mvs_Deal checkMvs_Deal = db.Mvs_Deal.Where(x => x.Vendor_Program_Id == mvs_Deal.Vendor_Program_Id && x.MvsSalesRepresentative_Id == mvs_Deal.MvsSalesRepresentative_Id && x.Customer_Id == mvs_Deal.Customer_Id && x.CustomerContact_Id == mvs_Deal.CustomerContact_Id && x.DealName == mvs_Deal.DealName).FirstOrDefault();
            if (checkMvs_Deal == null)
            {
                db.Mvs_Deal.Add(mvs_Deal);
            }
            else
            {
                db.Entry(checkMvs_Deal).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return mvs_Deal.Mvs_Deal_Id;
        }

        public List<SelectListItem> GetProgramList()
        {
            return db.Vendor_Program.Select(x => new SelectListItem
            {
                Value = x.Vendor_Program_Id.ToString(),
                Text = x.ProgramName
            }).ToList();

        }
        public List<SelectListItem> GetCountryList()
        {
            return db.Countries.Select(x => new SelectListItem
            {
                Value = x.Country_Id.ToString(),
                Text = x.Name
            }).ToList();

        }
        public List<SelectListItem> GetStateList(int countryId)
        {
            return db.States.Where(x => x.Country_Id == countryId).Select(x => new SelectListItem
            {
                Value = x.State_Id.ToString(),
                Text = x.Name
            }).ToList();

        }

        public Vendor GetVendorDetails(int? id)
        {

            return db.Vendors.Where(x => x.Vendor_Id == id).FirstOrDefault();

        }

        public Vendor_Program GetVendorProgramDetails(int? id)
        {

            return db.Vendor_Program.Where(x => x.Vendor_Program_Id == id).FirstOrDefault();


        }

        public Guid SaveUserInfo(UserInformation userinfo)
        {
            UserInformation checkUserInformation = db.UserInformations.Where(x => x.Email == userinfo.Email && x.Phone == userinfo.Phone).FirstOrDefault();
            if (checkUserInformation == null)
            {
                db.UserInformations.Add(userinfo);
            }
            else
            {
                userinfo.UserInformation_Id = checkUserInformation.UserInformation_Id;
                db.Entry(checkUserInformation).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return userinfo.UserInformation_Id;
        }

        public List<Mvs_Deal> GetAllRegistrations(Guid UserId)
        {

            //   return db.Mvs_Deal.Include(m => ).Include(m => m.customerContact).Include(m => m.vendor).Include(m => m.vendor_Program).Where(x => x.CreatedBy == UserId).ToList()
            return db.Mvs_Deal.Where(x => x.CreatedBy == UserId).ToList();
        }

        public List<Mvs_Deal> GetAllDeletedRegistrations(Guid UserId)
        {
            return db.Mvs_Deal.Where(x => x.CreatedBy == UserId && x.IsDeleted == true).ToList();
        }
        public string CreateRole(Roles roles)
        {
            Roles checkRoles = db.Roles.Where(x => x.RoleName == roles.RoleName).FirstOrDefault();
            if (checkRoles == null)
            {
                db.Roles.Add(roles);
                db.SaveChanges();
                return "Roles saved Successfully";
            }
            else
            {
                db.Entry(checkRoles).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "RoleName Already Exists";
            }
        }

        public List<Roles> GetAllRoles()
        {
            return db.Roles.Where(x => x.IsDeleted == false).ToList();
        }

        public List<Vendor_RegistrationFormField> GetFormFields(int? programId)
        {

            return db.Vendor_RegistrationFormField.Where(x => x.IsActive == true && x.VendorProgramId == programId).ToList();
        }

        public string GetVendorLogobyProgramId(int? programId)
        {
            int? vendorId = db.Vendor_Program.Where(x => x.Vendor_Program_Id == programId).Select(x => x.Vendor_Id).FirstOrDefault();
            return db.Vendors.Where(x => x.Vendor_Id == vendorId).Select(x => x.VendorLogo).FirstOrDefault();
        }

        public List<SelectListItem> GetReferenceDataListItem(int? programId, int? fieldId)
        {
            return db.ReferenceDataListItems.Where(x => x.ReferenceDataListId == fieldId && x.ProgramId == programId)
             .Select(x => new SelectListItem { Value = x.DisplayValue, Text = x.DisplayValue }).ToList();
        }

        public string SaveVendorDealInformation(Mvs_DealData dealData, int? dealId)
        {
            Mvs_DealData mvs_DealData = db.Mvs_DealData.Where(x => x.Mvs_DealId == dealId && x.DataKey == dealData.DataKey).FirstOrDefault();
            if (mvs_DealData == null)
            {
                db.Mvs_DealData.Add(dealData);
            }
            else
            {
                mvs_DealData.DataValue = dealData.DataValue;
                db.Entry(mvs_DealData).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return "Deal Information saved Successfully";
        }

        public List<Mvs_DealData> GetDealDataInformation(int? dealId)
        {
            return db.Mvs_DealData.Where(x => x.Mvs_DealId == dealId).ToList();
        }

        public IQueryable<DealFormViewModel> GetDealWithFormField(int? dealId, int? programId)
        {
            return db.Vendor_RegistrationFormField.Where(y => y.VendorProgramId == programId).OrderBy(y => y.Sequence).Join(db.Mvs_DealData.Where(x => x.Mvs_DealId == dealId), x => x.FieldName, y => y.DataKey, (v, d) => new DealFormViewModel
            {
                FieldLabel = v.FieldLabel,
                DataValue = d.DataValue
            });
        }

        public int? GetCountFormfields(int? programId)
        {
            return db.Vendor_RegistrationFormField.Where(x => x.VendorProgramId == programId).Select(x => x.FieldName.Substring(8, x.FieldName.Length)).Select(int.Parse).ToList().Max();

        }

        public string SaveUserInformation(UserInformation userInformation)
        {
            UserInformation userInfoObj = db.UserInformations.Where(x => x.UserInformation_Id == userInformation.UserInformation_Id).FirstOrDefault();
            if (userInfoObj == null)
            {

                db.UserInformations.Add(userInformation);
            }
            else
            {
                userInfoObj.FirstName = userInformation.FirstName;
                userInfoObj.LastName = userInformation.LastName;
                userInfoObj.Email = userInformation.Email;
                userInfoObj.Phone = userInformation.Phone;
                userInfoObj.IsActive = userInformation.IsActive;
                userInfoObj.role_id = userInformation.role_id;
                userInfoObj.UserTypeId = userInformation.UserTypeId;
                db.Entry(userInfoObj).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return "User Information saved Successfully";
        }

        public List<SelectListItem> GetUserTypeList()
        {
            return db.UserTypes.Select(x => new SelectListItem
            {
                Value = x.UserType_Id.ToString(),
                Text = x.UserTypeName
            }).ToList();

        }
        public void SaveRoleAppPermissions(RolesAppPermission rolesAppPermission)
        {
            RolesAppPermission rolesAppObj = db.RolesAppPermissions.Where(x => x.Role_Id == rolesAppPermission.Role_Id && x.Controller == rolesAppPermission.Controller && x.Action == rolesAppPermission.Action).FirstOrDefault();
            if (rolesAppObj == null)
            {
                db.RolesAppPermissions.Add(rolesAppPermission);
            }
            else
            {
                db.Entry(rolesAppObj).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();

        }

        public List<RolesAppPermission> GetRolesAppPermissions(int roleId)
        {
            return db.RolesAppPermissions.Where(x => x.Role_Id == roleId).ToList();
        }

        public List<SelectListItem> GetAllControllers()
        {
            return db.AllControllers.Where(x => x.ControllerName == "Main")
                .Select(x => new SelectListItem
                {
                    Value = x.Controller_Id.ToString(),
                    Text = x.ControllerName
                }).ToList();

        }
        public List<SelectListItem> GetAllActionsByControllerId(int controllerId)
        {
            return db.AllActions.Where(x => x.Controller_Id == controllerId).Select(x => new SelectListItem
            {
                Value = x.Action_Id.ToString(),
                Text = x.ActionName
            }).ToList();

        }

        public List<RolesAppPermission> GetAllPermissions(int roleId)
        {
            return db.RolesAppPermissions.Where(x => x.Role_Id == roleId).ToList();
        }


        public void DeleteRoleAppPermissions(int rolesAppPermissionId)
        {
            RolesAppPermission rolesAppPermission = db.RolesAppPermissions.Find(rolesAppPermissionId);
            db.RolesAppPermissions.Remove(rolesAppPermission);
            db.SaveChanges();
        }

        //public void AssignUserRole(AssignUserRoleModel assignUserRoleModel)
        //{
        //    Guid userinformatonId = new Guid(assignUserRoleModel.Userinformation_Id);
        //    UserInformation UserInformations = db.UserInformations.Where(x => x.UserInformation_Id == userinformatonId).FirstOrDefault();
        //    if (UserInformations != null)
        //    {

        //        UserInformations.role_id = assignUserRoleModel.Role_Id;
        //        db.Entry(UserInformations).State = System.Data.Entity.EntityState.Modified;
        //    }
        //    db.SaveChanges();

        //}


        public List<UserInformation> UserList()
        {
            return db.UserInformations.ToList();

        }

        public List<SelectListItem> GetRoleList()
        {
            return db.Roles.Select(x => new SelectListItem
            {
                Value = x.Role_Id.ToString(),
                Text = x.RoleName
            }).ToList();
        }
        public UserInformation GetUserInfoById(Guid? userInfoId)
        {
            return db.UserInformations.Where(x => x.UserInformation_Id == userInfoId).FirstOrDefault();
        }

        public List<string> GetActionPermissionList(Guid userId)
        {
            UserInformation objUserInformation = db.UserInformations.Where(x => x.UserInformation_Id == userId).FirstOrDefault();
            int controllerId = db.AllControllers.Where(x => x.ControllerName == "Main").Select(x=>x.Controller_Id).FirstOrDefault();
            if (objUserInformation.UserTypeId == 1)//systemId
                return db.AllActions.Where(x => x.Controller_Id == controllerId).Select(x => x.ActionName).ToList();
            else
                return db.RolesAppPermissions.Where(x => x.Role_Id == objUserInformation.role_id).Select(x => x.Action).ToList();
        }

        public string GetUserTypeInfoById(Guid userId)
        {
            var usertypeid = db.UserInformations.Where(z => z.UserInformation_Id == userId).Select(x=>x.UserTypeId).FirstOrDefault();
            return db.UserTypes.Where(x => x.UserType_Id == usertypeid).Select(z=>z.UserTypeName).FirstOrDefault();
        }

    }
}