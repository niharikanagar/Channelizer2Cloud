using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Channelizer2Cloud.ViewModel
{
    public class RegistrationViewModel
    {
        public int? Mvs_VarId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }

        public string SaleRepFirstName { get; set; }
        public string SaleRepLastName { get; set; }
        public string SaleRepEmail { get; set; }
        public string SaleRepPhone { get; set; }
        public int? VendorId { get; set; }
        public int? ProgramId { get; set; }
       
        public string DealName { get; set; }
        public string DealDescription { get; set; }
        public string DealStatus { get; set; }
        public DateTime? SubmittedOn { get; set; }
        public Guid? CreatedBy { get; set; }

    }
}