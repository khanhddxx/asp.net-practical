

namespace eLink.BookingVcmReport.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;

    [ConnectionKey("Default"), DisplayName(""), InstanceName("CSS_VCM_BAO_CAO_NCC"), TwoLevelCached]
    [ReadPermission("Administration")]
    [ModifyPermission("Administration")]
    public sealed class CssVcmBaoCaoNCCRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Column("ID"), Identity, Visible(false)]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Mã NCC"), Column("Vendor"), Width(100)]
        public string Vendor
        {
            get { return Fields.Vendor[this]; }
            set { Fields.Vendor[this] = value; }
        }

        [DisplayName("Tên NCC"), Column("Vendor_SupplyingSite"), Width(500)]
        public string Vendor_SupplyingSite
        {
            get { return Fields.Vendor_SupplyingSite[this]; }
            set { Fields.Vendor_SupplyingSite[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Vendor; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public CssVcmBaoCaoNCCRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Id;
            public StringField Vendor;
            public StringField Vendor_SupplyingSite;

            public RowFields()
                : base("[dbo].[CSS_VCM_BAO_CAO_NCC]")
            {
                LocalTextPrefix = "BookingVcmReport.CssVcmBaoCaoNCC";
            }
        }
    }
}