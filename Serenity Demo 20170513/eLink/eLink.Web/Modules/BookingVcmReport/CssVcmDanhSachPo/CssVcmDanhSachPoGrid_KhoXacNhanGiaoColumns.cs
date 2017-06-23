
namespace eLink.BookingVcmReport.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;


    [ColumnsScript("BookingVcmReport.CssVcmDanhSachPoGrid_KhoXacNhanGiao")]
    [BasedOnRow(typeof(Entities.CssVcmDanhSachPoRow))]
    public class CssVcmDanhSachPoGrid_KhoXacNhanGiaoColumns 
    {       
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String MaPo { get; set; }
        [QuickFilter, QuickFilterOption("multiple", true)]
        public String TenTrangThai { get; set; }
        [QuickFilter]
        public DateTime NgayGiao { get; set; }
        public DateTime GioGiao { get; set; }
        public String Vendor { get; set; }
        public String VendorSupplyingSite { get; set; }
        public decimal SLKhungThoiGianDaXacNhan { get; set; }
        public String GhiChuHenGiao { get; set; }
        public String GhiChuTuChoi { get; set; }
        public String GhiChu { get; set; }
        public DateTime NgayNhanThucTe { get; set; }
        public DateTime GioNhanThucTe { get; set; }
        public String NvLaiXe { get; set; }
        public String SdtNvLaiXe { get; set; }
        public String BienSoXe { get; set; }
        [QuickFilter]
        public DateTime InsertDate { get; set; }     
        public String InsertUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public String UpdateUser { get; set; }
  

    }
}