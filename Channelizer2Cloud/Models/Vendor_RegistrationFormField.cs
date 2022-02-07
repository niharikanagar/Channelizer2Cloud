using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Channelizer2Cloud.Models
{
    [Table("tbl_Vendor_RegistrationFormField")]
    public class Vendor_RegistrationFormField
    {
        [Key]
        public int Vendor_RegistrationFormField_Id { get; set; }
        public int? VendorId { get; set; }
        public int? VendorProgramId { get; set; }
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }
        public int? FieldTypeId { get; set; }
        public string FieldDescription { get; set; }
        public string Placeholder { get; set; }
        public int? ReferenceDataListId { get; set; }
        public int? Sequence { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}