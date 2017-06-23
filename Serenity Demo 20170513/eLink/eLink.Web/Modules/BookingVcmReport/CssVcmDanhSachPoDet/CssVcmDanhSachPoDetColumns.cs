
namespace eLink.BookingVcmReport.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("BookingVcmReport.CssVcmDanhSachPoDet")]
    [BasedOnRow(typeof(Entities.CssVcmDanhSachPoDetRow))]
    public class CssVcmDanhSachPoDetColumns
    {
        [DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }

        public String MaPo { get; set; }
        public DateTime DocumentDate { get; set; }
        public String Vendor { get; set; }
        public String VendorSupplyingSite { get; set; }
        public Int32 Item { get; set; }
        public String Article { get; set; }
        public String OrderUnit { get; set; }
        public String GTIN { get; set; }
        public String ShortText { get; set; }
        public String MerchandiseCategory { get; set; }
        public Decimal SoLuongUpload { get; set; }
        //public Decimal OrderQuantity { get; set; }
        public Decimal SoLuongNccHenGiao { get; set; }
        public Decimal SoLuongThucNhan { get; set; }
        public String Ctns { get; set; }
        public Decimal Weight { get; set; }
        public String Cbm { get; set; }
        public String NameOfUploader { get; set; }
        public String TelofUploader { get; set; }
        public String Note { get; set; }
        public DateTime NgaySanXuat { get; set; }
        public DateTime NgayHetHan { get; set; }
    }
}