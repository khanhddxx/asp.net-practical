
namespace eLink.BookingVcmReport.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("BookingVcmReport.CssVcmBaoCaoDatHangKheThoiGian")]
    [BasedOnRow(typeof(Entities.CssVcmBaoCaoDatHangKheThoiGianRow))]
    public class CssVcmBaoCaoDatHangKheThoiGianForm
    {
        public DateTime NgayGiao { get; set; }
        public String KheThoiGian { get; set; }
        public Int32 SoLuong { get; set; }
        public Int32 SoLuongToiDa { get; set; }
        public Int32 ChenhLech { get; set; }
        public DateTime GioGiao { get; set; }
    }
}