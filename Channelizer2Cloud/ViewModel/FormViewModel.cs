using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Channelizer2Cloud.ViewModel
{
    public class FormViewModel
    {
        public int? VendorId { get; set; }
        public int? ProgramId { get; set; }
        public string FieldName { get; set; }
        public string FieldLabel { get; set; }
        public int? FieldTypeId { get; set; }
        public string FieldDescription { get; set; }
        public string Placeholder { get; set; }
        public int? ReferenceDataList_Id { get; set; }
        public bool? IsRequired { get; set; }
        public int Sequence { get; set; }
    }
}