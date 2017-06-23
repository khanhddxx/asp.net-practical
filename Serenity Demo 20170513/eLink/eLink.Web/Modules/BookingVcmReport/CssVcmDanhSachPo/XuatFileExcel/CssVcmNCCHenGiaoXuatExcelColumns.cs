
namespace eLink.BookingVcmReport.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("BookingVcmReport.CssVcmNCCHenGiaoXuatExcel")]
    [BasedOnRow(typeof(Entities.CssVcmDanhSachPoDetRow))]
    public class CssVcmNCCHenGiaoXuatExcelColumns
    {
        public String MaPo { get; set; }
        public String NvLaiXe { get; set; }
        public String SdtNvLaiXe { get; set; }
        public String BienSoXe { get; set; }

        public String Article { get; set; }
        public String ShortText { get; set; }

        public Decimal OrderQuantity { get; set; }
        public String OrderUnit { get; set; }
        public String Ctns { get; set; }
        public Decimal Weight { get; set; }
        public String Cbm { get; set; }


        public DateTime NgaySanXuat { get; set; }
        public DateTime NgayHetHan { get; set; }

    }
}