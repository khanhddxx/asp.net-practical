
namespace eLink.BookingVcmReport.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("BookingVcmReport.CssVcmBaoCaoDatHangThang")]
    [BasedOnRow(typeof(Entities.CssVcmBaoCaoDatHangThangRow))]
    public class CssVcmBaoCaoDatHangThangColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public String MaPo { get; set; }
        [QuickFilter]
        public String Vendor { get; set; }
        public String Vendor_SupplyingSite { get; set; }
        [QuickFilter]
        public DateTime NgayDatHang { get; set; }
        public DateTime NgayThucNhan { get; set; }
        public Int32 SkuKeHoach { get; set; }
        public Int32 UnitKeHoach { get; set; }
        public Int32 SkuThucNhan { get; set; }
        public Int32 UnitThucNhan { get; set; }
        public Int32 SkuChenhLech { get; set; }
        public Int32 UnitChenhLech { get; set; }
        public Decimal SkuTiLe { get; set; }
        public Decimal UnitTiLe { get; set; }
        [EditLink]
        public String DeliveryInFullGrade { get; set; }
        public DateTime GioGiao { get; set; }
        public DateTime GioNhanThucTe { get; set; }
        public TimeSpan ThoiGianTre { get; set; }
        public String GhiChuHenGiao { get; set; }
        public String DeliveryInTimeGrade { get; set; }
    }
}