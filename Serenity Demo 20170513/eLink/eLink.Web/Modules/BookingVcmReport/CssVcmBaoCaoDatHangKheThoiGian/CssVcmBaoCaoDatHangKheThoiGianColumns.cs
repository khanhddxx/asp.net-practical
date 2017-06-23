
namespace eLink.BookingVcmReport.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("BookingVcmReport.CssVcmBaoCaoDatHangKheThoiGian")]
    [BasedOnRow(typeof(Entities.CssVcmBaoCaoDatHangKheThoiGianRow))]
    public class CssVcmBaoCaoDatHangKheThoiGianColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [QuickFilter]
        public DateTime GioGiao { get; set; }       
        public string NgayGiao { get; set; }
        [EditLink]
        public String KheThoiGian { get; set; }
        public Int32 SoLuong { get; set; }
        public Int32 SoLuongToiDa { get; set; }
        public Int32 ChenhLech { get; set; }

    }
}