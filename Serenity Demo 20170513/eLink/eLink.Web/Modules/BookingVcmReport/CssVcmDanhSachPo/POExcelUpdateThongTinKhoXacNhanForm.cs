namespace eLink.BookingVcmReport.Forms
{
    using Serenity.ComponentModel;
    using System;
    using System.ComponentModel;

    [FormScript("BookingVcmReport.POExcelUpdateThongTinKhoXacNhan")]
    public class POExcelUpdateThongTinKhoXacNhanForm
    {
        [DisplayName("Chọn file"), FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}
