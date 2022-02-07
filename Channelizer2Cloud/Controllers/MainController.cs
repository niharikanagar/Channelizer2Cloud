using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PagedList;
using Channelizer2Cloud.ViewModel;
using Channelizer2Cloud.Models;
using Channelizer2Cloud.Services;


namespace Channelizer2Cloud.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        Service _service = new Service();
        public ActionResult Home()
        {
            ViewBag.ActionPermissionList = _service.GetActionPermissionList(new Guid(Session["User_Id"].ToString()));
            ViewBag.UserType = _service.GetUserTypeInfoById(new Guid(Session["User_Id"].ToString()));
            return View();
        }
        public ActionResult CreateVendor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVendor([Bind(Include = "Vendor_Id,VendorName,VendorPrimaryColor,VendorSecondaryColor,VendorFont,TwitterLink,LinkedinLink,IsDeleted")] Vendor vendor, HttpPostedFileBase LogoImage)
        {
                string path = Server.MapPath("~/Content/img/vendor/");
                vendor.VendorLogo = LogoImage.FileName;
                LogoImage.SaveAs(path + Path.GetFileName(LogoImage.FileName));
                vendor.IsDeleted = false;
                ViewBag.Message = _service.SaveVendorInformation(vendor);
                return RedirectToAction("CreateProgram", "Main",new { @id= vendor.Vendor_Id });
        }

        public ActionResult CreateProgram(int? id)
        {
            ViewBag.VendorList = _service.GetVendorList(id);
            return View();
        }

        [HttpPost]
        public ActionResult CreateProgram([Bind(Include = "Vendor_Program_Id,Vendor_Id,ProgramName,Description,IsActive,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy")] Vendor_Program vendorProgram)
        {
            
            ViewBag.Message = _service.SaveVendorProgram(vendorProgram);
            return RedirectToAction("CreateForm", "Main",new { @programId = vendorProgram.Vendor_Program_Id,@vendorId= vendorProgram.Vendor_Id });
        }
        public ActionResult CreateForm(int? programId,int? vendorId)
        {
            ViewBag.ProgramId = programId;
            ViewBag.VendorId = vendorId;
            ViewBag.Counter = 1;
            ViewBag.OptionCounter = 1;
           
            return View();
        }

       
        [HttpPost]
        public string SaveVendorFormField(FormViewModel formViewModel)
        {
            Vendor_RegistrationFormField vendorFormField = new Vendor_RegistrationFormField();
            vendorFormField.VendorId = formViewModel.VendorId;
            vendorFormField.VendorProgramId = formViewModel.ProgramId;
            vendorFormField.ReferenceDataListId = formViewModel.ReferenceDataList_Id;
            vendorFormField.IsRequired = formViewModel.IsRequired;
            vendorFormField.FieldLabel = formViewModel.FieldLabel;
            vendorFormField.FieldTypeId = formViewModel.FieldTypeId;
            vendorFormField.FieldName = formViewModel.FieldName;
            vendorFormField.FieldDescription = formViewModel.FieldDescription;
            vendorFormField.Placeholder = formViewModel.Placeholder;
            vendorFormField.Sequence = formViewModel.Sequence;
            vendorFormField.CreatedOn = DateTime.Now;
            vendorFormField.IsActive = true;
            return _service.SaveVendorRegistrtaionFormField(vendorFormField);
        }
        [HttpPost]
        public string SaveReferernceDataList(List<ReferenceDataListItem> dataListItem)
        {
            return _service.SaveReferenceDataList(dataListItem);
        }
        public ActionResult CreateNewReg()
        {
            ViewBag.GetProgramList = _service.GetProgramList();
            ViewBag.GetCountryList = _service.GetCountryList();
           // ViewBag.GetStateList = _service.GetStateList(int countryId);
            return View();
        }

        public ActionResult CreateNewRegDeal(int? ProgramId, int? DealId )
        {
            ViewBag.DealID = DealId;
            ViewBag.ProgramID = ProgramId;
            ViewBag.VendorLogo = _service.GetVendorLogobyProgramId(ProgramId);
            List <Vendor_RegistrationFormField> vendorFormFieldList = _service.GetFormFields(ProgramId);
            foreach(var fields in vendorFormFieldList)
            {
                if (fields.FieldTypeId == 24 || fields.FieldTypeId == 2 || fields.FieldTypeId == 13)
                {
                    int fieldId = Convert.ToInt32((fields.FieldName).Remove(0, 8));
                    List<SelectListItem> ObjList = _service.GetReferenceDataListItem(ProgramId, fieldId);
                    ViewData[Convert.ToString(fieldId)] = ObjList;
                }
            }
            return View(vendorFormFieldList);
        }

        public ActionResult EditRegDeal(int? ProgramId, int? DealId)
        {
            ViewBag.DealID = DealId;
            ViewBag.ProgramID = ProgramId;
            ViewBag.VendorLogo = _service.GetVendorLogobyProgramId(ProgramId);
            List<Vendor_RegistrationFormField> vendorFormFieldList = _service.GetFormFields(ProgramId);
            foreach (var fields in vendorFormFieldList)
            {
                if (fields.FieldTypeId == 24 || fields.FieldTypeId == 2 || fields.FieldTypeId == 13)
                {
                    int fieldId = Convert.ToInt32((fields.FieldName).Remove(0, 8));
                    List<SelectListItem> ObjList = _service.GetReferenceDataListItem(ProgramId, fieldId);
                    ViewData[Convert.ToString(fieldId)] = ObjList;
                }
            }
            ViewBag.DealFormField = _service.GetDealWithFormField(DealId, ProgramId);
            return View(vendorFormFieldList);
        }

        public ActionResult ViewDealInformation(int? dealId, int? programId)
        {
            ViewBag.VendorLogo = _service.GetVendorLogobyProgramId(programId);
            ViewBag.DealFormField = _service.GetDealWithFormField(dealId,programId);
            return View();
        }


        [HttpPost]
        public ActionResult CreateNewReg(RegistrationViewModel registrationViewModel)
        {
            registrationViewModel.CreatedBy = new Guid(Session["User_Id"].ToString());
            int DealId = _service.SaveDealDataInformation(registrationViewModel);
            return RedirectToAction("CreateNewRegDeal", "Main", new { @ProgramId = registrationViewModel.ProgramId,@DealId = DealId});
        }

        public ActionResult ViewRegistrations(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var GetAllRegistrations = _service.GetAllRegistrations(new Guid(Session["User_Id"].ToString()));

            if (!String.IsNullOrEmpty(searchString))
            {
                GetAllRegistrations = GetAllRegistrations.Where(s => s.DealName.Contains(searchString)||s.DealDescription.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    GetAllRegistrations = GetAllRegistrations.OrderByDescending(s => s.CreatedOn).ToList();
                    break;
                default:
                    GetAllRegistrations = GetAllRegistrations.OrderBy(s => s.CreatedOn).ToList();
                    break;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(GetAllRegistrations.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DeletedRegistrations(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var GetAllRegistrations = _service.GetAllDeletedRegistrations(new Guid(Session["User_Id"].ToString()));

            if (!String.IsNullOrEmpty(searchString))
            {
                GetAllRegistrations = GetAllRegistrations.Where(s => s.DealName.Contains(searchString) || s.DealDescription.Contains(searchString)).ToList();
            }


            switch (sortOrder)
            {
                case "name_desc":
                    GetAllRegistrations = GetAllRegistrations.OrderByDescending(s => s.CreatedOn).ToList();
                    break;
                default:
                    GetAllRegistrations = GetAllRegistrations.OrderBy(s => s.CreatedOn).ToList();
                    break;
            }

            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(GetAllRegistrations.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult ChangePassword()
        {
            UserViewVodel userViewModel = new UserViewVodel();
            userViewModel.Username = Session["Username"].ToString();
            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult ChangePassword(UserViewVodel userViewVodel)
        {
            var checkPasswordValidResponse= _service.CheckPasswordValid(userViewVodel);
            switch (checkPasswordValidResponse)
            {
                case "New and Confirm Password are not Match":
                    ViewBag.Validationerror = "New Password and Confirmed Password are not Match";
                    return View();
                case "Current Password are not Match":
                    ViewBag.Validationerror = "Current Password are not Match";
                    return View();
                case "Password not Strong":
                    ViewBag.Validationerror = "1. At least one lower case letter\r\n 2. At least one upper case letter\r\n 3. At least special character\r\n 4. At least one number\r\n 5. At least 8 characters length\r\n";
                    return View();
                case "Old and New Password are not Same":
                    ViewBag.Validationerror = "New Password will not be old password.";
                    return View();
                case "Password saved Successfully":

                    return RedirectToAction("Home", "Main");
                default:
                    ViewBag.Validationerror = "1. At least one lower case letter\r\n 2. At least one upper case letter\r\n 3. At least special character\r\n 4. At least one number\r\n 5. At least 8 characters length\r\n";
                    return View();
            }
        }


        public ActionResult RoleManage()
        {
            List<Roles> role = _service.GetAllRoles();
            return View(role);
        }

        [HttpPost]
        public ActionResult RoleManage(Roles roles)
        {
            roles.CreatedBy= new Guid(Session["User_Id"].ToString());
            @ViewBag.ValidationError= _service.CreateRole(roles);
            List<Roles> role = _service.GetAllRoles();
            return View(role);
           
        }

        //[HttpGet]
        //public PartialViewResult RenderRolePermission()
        //{
        //    return PartialView("_RolePermission");
        //}


        [HttpPost]
        public ActionResult SaveDealRegistrationForm(FormCollection collection, int dealId)
        {
            Mvs_DealData dd = new Mvs_DealData();
            dd.Mvs_DealId = dealId;
            foreach (var item in collection.AllKeys)
            {
                dd.DataKey = item;
                dd.DataValue = collection[item];
                _service.SaveVendorDealInformation(dd, dealId);  
            }
            return RedirectToAction("Home", "Main");
        }
        
        public ActionResult EditForm(int? programId, int? vendorId)
        {
            ViewBag.counter = _service.GetCountFormfields(programId);
            ViewBag.programId = programId;
            ViewBag.vendorId = vendorId;
            ViewBag.VendorLogo = _service.GetVendorLogobyProgramId(programId);
            List<Vendor_RegistrationFormField> vendorFormFieldList = _service.GetFormFields(programId);
            foreach (var fields in vendorFormFieldList)
            {
            if (fields.FieldTypeId == 24 || fields.FieldTypeId == 2 || fields.FieldTypeId == 13)
                {
                    int fieldid = Convert.ToInt32((fields.FieldName).Remove(0, 8));
                    List<SelectListItem> ObjList = _service.GetReferenceDataListItem(programId, fieldid);
                        ViewData[Convert.ToString(fieldid)] = ObjList;
                }

            }
            return View(vendorFormFieldList);
        }
        public JsonResult GetStateList(int countryId)
        {
            List<SelectListItem> StateList=_service.GetStateList(countryId);
            return Json(StateList, JsonRequestBehavior.AllowGet);

        }
        // GET: UserInformations/Create
        public ActionResult UserManagement(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.GetUserTypeList =_service.GetUserTypeList();
            ViewBag.GetRoleList = _service.GetRoleList();
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var userList= _service.UserList();

            if (!String.IsNullOrEmpty(searchString))
            {
                userList = userList.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Email.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    userList = userList.OrderByDescending(s => s.CreatedOn).ToList();
                    break;
                default:
                    userList = userList.OrderBy(s => s.CreatedOn).ToList();
                    break;
            }
            int pageSize = 7;
            int pageNumber = (page ?? 1);

            return View(userList.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult EditUserManagement()
        {
            ViewBag.GetUserTypeList = _service.GetUserTypeList();
            ViewBag.GetRoleList = _service.GetRoleList();
            return View();
        }

        public ActionResult UpdateUserManagement(Guid? Id)
        {
            ViewBag.GetUserTypeList = _service.GetUserTypeList();
            ViewBag.GetRoleList = _service.GetRoleList();
            UserInformation userInfo = _service.GetUserInfoById(Id);
            return View(userInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserManagement([Bind(Include = "UserInformation_Id,UserTypeId,FirstName,LastName,UserName,Email,Phone,Password,SuccessfulLoginCount,ForcePasswordChangeNextLogin,IsActive,IsLockedOut,LastLogindate,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy,role_id")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                //userInformation.UserInformation_Id = Guid.NewGuid();

                _service.SaveUserInformation(userInformation);
                return RedirectToAction("UserManagement");
            }

            return View();
        }



        // POST: UserInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserManagement([Bind(Include = "UserInformation_Id,UserTypeId,FirstName,LastName,UserName,Email,Phone,Password,SuccessfulLoginCount,ForcePasswordChangeNextLogin,IsActive,IsLockedOut,LastLogindate,CreatedOn,CreatedBy,IsDeleted,LastModifiedOn,ModifiedBy,role_id")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                userInformation.UserInformation_Id = Guid.NewGuid();

                _service.SaveUserInformation(userInformation);
                return RedirectToAction("Home");
            }

            return View();
        }

        [HttpGet]
        public PartialViewResult RenderRolePermission(int roleId)
        {
            List<RolesAppPermission> rolesAppPermission = new List<RolesAppPermission>();
                ViewBag.allController = _service.GetAllControllers();
            rolesAppPermission = _service.GetAllPermissions(roleId);
                return PartialView("_RolePermission", rolesAppPermission);
        }

        public JsonResult GetActionList(int controllerId)
        {
            List<SelectListItem> ActionList = _service.GetAllActionsByControllerId(controllerId);
            return Json(ActionList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveRolePermission(RolesAppPermission rolesAppPermission)
        {
            List<RolesAppPermission> rolesAppPermissions = new List<RolesAppPermission>();
            _service.SaveRoleAppPermissions(rolesAppPermission);
            //int roleid = Convert.ToInt32(rolesAppPermission.Role_Id);
            //ViewBag.allController = _service.GetAllControllers();
            //rolesAppPermissions = _service.GetAllPermissions(roleid);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DeleteRoleAppPermissions(int rolesAppPermissionId)
        {
            List<RolesAppPermission> rolesAppPermissions = new List<RolesAppPermission>();
            _service.DeleteRoleAppPermissions(rolesAppPermissionId);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }

       

    }
}