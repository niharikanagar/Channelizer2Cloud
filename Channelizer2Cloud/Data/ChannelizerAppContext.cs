using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Channelizer2Cloud.Data
{
    public class ChannelizerAppContext : DbContext
    {
        public ChannelizerAppContext() : base("name=ChannelizerDBConnectionString")
        {
            Database.SetInitializer<ChannelizerAppContext>(new CreateDatabaseIfNotExists<ChannelizerAppContext>());
        }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.FieldType> FieldTypes { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Vendor_RegistrationFormField> Vendor_RegistrationFormField { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Vendor_Program> Vendor_Program { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.UserLoginDeviceInfo> UserLoginDeviceInfoes { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Auditlog> Auditlogs { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.EventLog> EventLogs { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.User_LogTime> User_LogTime { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.UserInformation> UserInformations { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.VendorUser> VendorUsers { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.VarUser> VarUsers { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.CustomerContact> CustomerContacts { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.MvsSalesRepresentative> MvsSalesRepresentatives { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Mvs_Deal> Mvs_Deal { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.ReferenceDataListItem> ReferenceDataListItems { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.AllController> AllControllers { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.AllActions> AllActions { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Roles> Roles { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.RolesUserPermission> RolesUserPermissions { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.RolesAppPermission> RolesAppPermissions { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.Mvs_DealData> Mvs_DealData { get; set; }

        public System.Data.Entity.DbSet<Channelizer2Cloud.Models.UserType> UserTypes { get; set; }
    }
}