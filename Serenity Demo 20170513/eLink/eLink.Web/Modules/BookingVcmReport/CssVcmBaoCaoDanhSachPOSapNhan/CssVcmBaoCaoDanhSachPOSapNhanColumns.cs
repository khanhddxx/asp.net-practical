
namespace eLink.BookingVcmReport.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;


    [ColumnsScript("BookingVcmReport.CssVcmBaoCaoDanhSachPOSapNhan")]
    [BasedOnRow(typeof(Entities.CssVcmDanhSachPoRow))]
    public class CssVcmBaoCaoDanhSachPOSapNhanColumns
    {        
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }       
        public String MaPo { get; set; }       
        public String TenTrangThai { get; set; }
        public DateTime NgayGiao { get; set; }
        public DateTime GioGiao { get; set; }
        public String Vendor { get; set; }
        public String VendorSupplyingSite { get; set; }      
        public String GhiChuHenGiao { get; set; }
        public String GhiChuTuChoi { get; set; }
        public String GhiChu { get; set; }
        public DateTime NgayNhanThucTe { get; set; }
        public DateTime GioNhanThucTe { get; set; }
        public String NvLaiXe { get; set; }
        public String SdtNvLaiXe { get; set; }
        public String BienSoXe { get; set; }
        public DateTime InsertDate { get; set; }     
        public String InsertUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public String UpdateUser { get; set; }
  

    }
}